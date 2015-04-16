using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using System.IO;

public partial class MISReport_TrafficControl : System.Web.UI.Page
{

    Clay.Common.Bll.Country objCountry = new Clay.Common.Bll.Country();
    DataSet dsCountry = new DataSet();

    Clay.Invoice.Bll.Query objQuery = new Clay.Invoice.Bll.Query();
    DataSet dsQry = new DataSet();

    Clay.Invoice.Bll.ProviderReseller objProvider = new Clay.Invoice.Bll.ProviderReseller();
    DataSet dsPRovider = new DataSet();

    Clay.Invoice.Bll.Provider objProviderR = new Clay.Invoice.Bll.Provider();
    DataSet dsPr = new DataSet();

    Clay.Invoice.Bll.Invoice objTrafficControl = new Clay.Invoice.Bll.Invoice();
    int userId = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            userId = Convert.ToInt32(Session["UserId"]);
        }
        catch (Exception ex)
        {
            userId = 0;
        }

        if (userId == 0)
        {
            Response.Redirect("../Logout.aspx");
        }
        else
        {
        }
        if (!IsPostBack)
        {
            loadCountryDDL();
            rdpMaxDate.SelectedDate = DateTime.Now.Date;
            rdpMinDate.SelectedDate = DateTime.Now.Date;
            btnExport.Visible = false;
        }
    }

    void checkpageright()
    {
        Clay.Invoice.Bll.Page objPage = new Clay.Invoice.Bll.Page();
        DataSet dspageright = new DataSet();
        string page;
        int user;
        user = Convert.ToInt32(Session["UserID"]);
        page = System.IO.Path.GetFileName(Request.ServerVariables["SCRIPT_NAME"]);
        objPage.PageName = page;
        objPage.UserId = user;
        dspageright = objPage.CheckPageRight();

        if (dspageright.Tables[0].Rows.Count == 0)
        {
            Response.Redirect("../Default.aspx");
            return;
        }

    }

    void checkSession()
    {
        try
        {
            if (!(Convert.ToInt32(Session["UserID"]) > 0))
            {
                Response.Redirect("../../Login.aspx", false);
            }
        }
        catch
        {
        }
    }


    protected void btnShowTraffic_Click(object sender, EventArgs e)
    {
        BindTraffic();
    }

    protected void BindTraffic()
    {
        if (ValidForm() == false)
        {
            return;
        }
        try
        {
            string strQry = "select ((sum(tc.filecost)*100)/sum(tc.clientcosttotal)) as margin, sum(zombiecost) as zombiecost, sum(tc.callcount) as callcount,sum(tc.noofunit) as noofunit,"
                + " sum(tc.filecost) as filecost, sum(tc.clientcost) as  clientcost, sum(tc.discount) as discount,sum(tc.clientcosttotal)"
                + " as clientcosttotal,c.calltypename from ERPInvoicing.trafficcontrol tc inner join clayerp.calltype c "
                + " on tc.calltypeid=c.calltypeid where tc.generateday>='" + Convert.ToDateTime(rdpMinDate.SelectedDate).ToString("yyyy-MM-dd")
                + "' and generateday<='" + Convert.ToDateTime(rdpMaxDate.SelectedDate).ToString("yyyy-MM-dd") + "' and tc.countryid=" + ddlCountry.SelectedValue
                + " and tc.providerid=" + ddlReseller.SelectedValue + " group by tc.calltypeid;";
            dsQry = objQuery.RunSelectQueryDBDirect("ERPInvoicing", strQry);

            Int64 countCalls = 0;
            Int64 duration = 0;
            double fileCost = 0;
            double clientCost = 0;
            double disValue = 0;
            double actual_Cost = 0;
            double zombie_cost = 0;
            double margin = 0;
            //DateTime genDate = Convert.ToDateTime(dsQry.Tables[0].Rows[i][7]);

            if (dsQry.Tables[0].Rows.Count > 0)
            {
                btnExport.Visible = true;
                for (int x = 0; x < dsQry.Tables[0].Rows.Count; x++)
                {
                    if (dsQry.Tables[0].Rows[x]["noofunit"].ToString() != "")
                    {
                        duration += Convert.ToInt64(dsQry.Tables[0].Rows[x]["noofunit"]);
                    }
                    else
                    {
                        dsQry.Tables[0].Rows[x]["noofunit"] = "0";
                    }
                    if (dsQry.Tables[0].Rows[x]["callcount"].ToString() != "")
                    {
                        countCalls += Convert.ToInt64(dsQry.Tables[0].Rows[x]["callcount"]);
                    }
                    else
                    {
                        dsQry.Tables[0].Rows[x]["callcount"] = "0";
                    }
                    if (dsQry.Tables[0].Rows[x]["filecost"].ToString() != "")
                    {
                        fileCost += Convert.ToDouble(dsQry.Tables[0].Rows[x]["filecost"]);
                    }
                    else
                    {
                        dsQry.Tables[0].Rows[x]["filecost"] = "0";
                    }
                    if (dsQry.Tables[0].Rows[x]["clientcost"].ToString() != "")
                    {
                        clientCost += Convert.ToDouble(dsQry.Tables[0].Rows[x]["clientcost"]);
                    }
                    else
                    {
                        dsQry.Tables[0].Rows[x]["clientcost"] = "0";
                    }
                    if (dsQry.Tables[0].Rows[x]["discount"].ToString() != "")
                    {
                        disValue += Convert.ToDouble(dsQry.Tables[0].Rows[x]["discount"]);
                    }
                    else
                    {
                        dsQry.Tables[0].Rows[x]["discount"] = "0";
                    }
                    if (dsQry.Tables[0].Rows[x]["clientcosttotal"].ToString() != "")
                    {
                        actual_Cost += Convert.ToDouble(dsQry.Tables[0].Rows[x]["clientcosttotal"]);
                    }
                    else
                    {
                        dsQry.Tables[0].Rows[x]["clientcosttotal"] = "0";
                    }

                    if (dsQry.Tables[0].Rows[x]["zombiecost"].ToString() != "")
                    {
                        zombie_cost += Convert.ToDouble(dsQry.Tables[0].Rows[x]["zombiecost"]);
                    }
                    else
                    {
                        dsQry.Tables[0].Rows[x]["zombiecost"] = "0";
                    }

                    if (dsQry.Tables[0].Rows[x]["margin"].ToString() != "")
                    {
                        margin += Convert.ToDouble(dsQry.Tables[0].Rows[x]["margin"]);
                    }
                    else
                    {
                        dsQry.Tables[0].Rows[x]["margin"] = "0";
                    }
                }

                dsQry.Tables[0].Rows.Add(margin, zombie_cost.ToString(), countCalls.ToString(), duration.ToString(), fileCost.ToString(), clientCost.ToString(), disValue.ToString(), actual_Cost.ToString(), "Total");

                RadGrid1.DataSource = dsQry;
                RadGrid1.DataBind();

                lblHeader.Text = "Showing traffic control for <span style='font-weight:bold;'> " + ddlCountry.SelectedItem.Text + " </span> between <span style='font-weight:bold;'> "
                    + Convert.ToDateTime(rdpMinDate.SelectedDate.ToString()).ToString("dd-MMM-yyyy") + " </span> and <span style='font-weight:bold;'> " + Convert.ToDateTime(rdpMaxDate.SelectedDate.ToString()).ToString("dd-MMM-yyyy") + " </span>";
                lblmsg.Text = "";
                RadGrid1.Visible = true;
                Session["tripdata"] = dsQry;

            }
            else
            {
                btnExport.Visible = false;
                RadGrid1.Visible = false;
                lblHeader.Text = "";
                lblmsg.Text = "Firstly Generate Traffic";
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }



    protected void RadGrid1_SortCommand(object source, Telerik.Web.UI.GridSortCommandEventArgs e)
    {
        BindTraffic();
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        try
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;



                TableCell cell = item["Sno"];

                DataRowView dr = (DataRowView)e.Item.DataItem;

                Label labelSNo = (Label)cell.FindControl("lblSno");
                labelSNo.Text = Convert.ToString((RadGrid1.CurrentPageIndex * RadGrid1.PageSize) + e.Item.ItemIndex + 1);

                Label lblCallType = (Label)cell.FindControl("lblCalltype");

                //DateTime genDate = Convert.ToDateTime(dr["generateday"]);
                string strCallType = dr["calltypename"].ToString();
                lblCallType.Text = strCallType;

                if (strCallType == "Total")
                {
                    e.Item.BackColor = System.Drawing.Color.Gray;
                    labelSNo.Text = "";
                }

                Label lblMargin = (Label)cell.FindControl("lblMargin");

                //DateTime genDate = Convert.ToDateTime(dr["generateday"]);
                string strMargin = dr["margin"].ToString();
                lblMargin.Text = ConvertToMoneyFormat(Convert.ToDouble(strMargin));

                if (strCallType == "Total")
                {
                    if (strMargin == "0")
                    {
                        lblMargin.Text = "0";
                    }
                    else
                    {
                        lblMargin.Text = "";
                    }
                }


                //DateTime dtTest =  Convert.ToDateTime("1900-01-01");

                //if (genDate != dtTest)
                //{
                //    labelDate.Text = genDate.ToString("dd-MMM-yyyy");
                //}
                //else
                //{
                //    e.Item.BorderColor  = System.Drawing.Color.Gray;
                //    e.Item.BackColor= System.Drawing.Color.Gray;
                //    labelSNo.Text = "";
                //    //item.BackColor = System.Drawing.Color.Gray;
                //}




            }
        }
        catch (Exception ex)
        {

        }

    }

    private string ConvertToMoneyFormat(double myval)
    {
        return string.Format("{0:0.00}", myval) + "%";

    }

    protected void btnTrafficGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidForm() == false)
            {
                return;
            }


            if (CheckTrafficExistOrNot() == false)
            {
                lblmsg.Text = "Traffic Does not exist";
                return;
            }

            DateTime minDate = Convert.ToDateTime(rdpMinDate.SelectedDate);
            DateTime maxDate = Convert.ToDateTime(rdpMaxDate.SelectedDate);

            TrafiicGenerate(minDate, maxDate, Convert.ToInt32(ddlCountry.SelectedValue), Convert.ToInt32(ddlReseller.SelectedValue));


            //while (minDate <= maxDate)
            //{
            //    objTrafficControl.TrafficControlInsertNew(Convert.ToInt32(ddlCountry.SelectedValue), Convert.ToInt32(ddlReseller.SelectedValue), minDate, Convert.ToInt32(Session["UserID"]));
            //    minDate = minDate.AddDays(1);
            //}





            ////DateTime fromDate = Convert.ToDateTime(rdpMinDate.SelectedDate);
            ////DateTime todate = Convert.ToDateTime(rdpMaxDate.SelectedDate);


            ////string strQuery = "select count(*) as countCalls , lcalltype , sum(billable_units),sum(providercost), sum(our_cost), sum(dis_value),"
            ////    + " (sum(our_cost)-sum(dis_value)) as actual_Cost, calldate from P" + countryCode.ToString() + ".PT where providerid=" + ddlReseller.SelectedValue.ToString()
            ////    + " and calldate>='" + fromDate.ToString("yyyy-MM-dd") + "' and calldate<='" + todate.ToString("yyyy-MM-dd") + "' group by lcalltype,calldate order by calldate;";
            ////dsQry = objQuery.RunSelectQueryDBDirect("ERPInvoicing", strQuery);

            ////if (dsQry.Tables[0].Rows.Count > 0)
            ////{
            ////    for (int i = 0; i < dsQry.Tables[0].Rows.Count; i++)
            ////    {
            ////        int countCalls = Convert.ToInt32(dsQry.Tables[0].Rows[i][0]);
            ////        int CallTypeID = Convert.ToInt32(dsQry.Tables[0].Rows[i][1]);
            ////        int duration = Convert.ToInt32(dsQry.Tables[0].Rows[i][2]);
            ////        double fileCost = Convert.ToDouble(dsQry.Tables[0].Rows[i][3]);
            ////        double clientCost = Convert.ToDouble(dsQry.Tables[0].Rows[i][4]);
            ////        double disValue = Convert.ToDouble(dsQry.Tables[0].Rows[i][5]);
            ////        double actual_Cost = Convert.ToDouble(dsQry.Tables[0].Rows[i][6]);

            ////        objTrafficControl.TrafficControlInsert(Convert.ToInt32(ddlCountry.SelectedValue), Convert.ToInt32(ddlReseller.SelectedValue),
            ////            countCalls, CallTypeID, duration, fileCost, clientCost, disValue, actual_Cost, genDate,
            ////            Convert.ToInt32(Session["UserID"]));

            ////        //string strInsert = "insert into ERPInvoicing.trafficcontrol (countryid, providerid, calltypeid, callcount, noofunit, filecost, clientcost, discount, clientcosttotal, generateday, createddatetime, userid)values("
            ////        //+ ddlCountry.SelectedValue + "," + ddlReseller.SelectedValue + "," + CallTypeID + "," + countCalls + "," + duration + ","
            ////        //+ fileCost.ToString() + "," + clientCost + "," + disValue + "," + actual_Cost + ",'" + genDate.ToString("yyyy-MM-dd") + "',now()," + Session["UserID"].ToString() + ");";

            ////        //objQuery.CQuery = strInsert;
            ////        //objQuery.RunMultipleInsertQuery();
            ////    }

            lblmsg.Text = "Traffic Generate Successfully";

            ////}
            ////else
            ////{
            ////    lblmsg.Text = "Traffic does not exist";
            ////}



        }
        catch (Exception ex)
        {

        }
    }

    protected Boolean ValidForm()
    {
        if (ddlCountry.SelectedIndex <= 0)
        {
            lblmsg.Text = "Please select country";
            return false;
        }
        if (ddlProvider.SelectedIndex <= 0)
        {
            lblmsg.Text = "Please select Provider";
            return false;
        }
        if (ddlReseller.SelectedIndex <= 0)
        {
            lblmsg.Text = "Please select reseller";
            return false;
        }

        if (rdpMinDate.SelectedDate == null)
        {
            lblmsg.Text = "Please Enter From Date";
            return false;
        }
        if (rdpMaxDate.SelectedDate == null)
        {
            lblmsg.Text = "Please Enter To Date";
            return false;
        }

        DateTime dtTemp1 = Convert.ToDateTime(rdpMinDate.SelectedDate);
        DateTime dtTemp2 = Convert.ToDateTime(rdpMaxDate.SelectedDate);

        if (dtTemp1 > dtTemp2)
        {
            lblmsg.Text = "From date should be less than To Date";
            return false;
        }
        //if (ddlMonth.SelectedIndex <= 0)
        //{
        //    lblmsg.Text = "Please select Month";
        //    return false;
        //}

        //if (ddlYear.SelectedIndex <= 0)
        //{
        //    lblmsg.Text = "Please select Year";
        //    return false; 
        //}
        return true;

    }

    private void loadCountryDDL()
    {

        string strCon = "select * from clayerp.country where countryid in (select distinct countryid from ERPInvoicing.invoicing) order by countryname";
        dsCountry = objQuery.RunSelectQueryDBDirect("ERPInvoicing", strCon);

        //objCountry.CountryId = 0;
        //dsCountry = objCountry.GetCountry();

        ddlCountry.DataSource = dsCountry;
        ddlCountry.DataTextField = "countryname";
        ddlCountry.DataValueField = "countryid";
        ddlCountry.DataBind();

    }

    private int GetCountryCode(int countryid)
    {
        dsCountry = objCountry.GetCountryByCountryId(0, countryid);

        if (dsCountry.Tables[0].Rows.Count > 0)
        {
            return Convert.ToInt32(dsCountry.Tables[0].Rows[0]["countrydicode"]);
        }
        else
        {
            return 0;
        }
    }

    private Boolean CheckTrafficExistOrNot()
    {
        int countryCode = GetCountryCode(Convert.ToInt32(ddlCountry.SelectedValue));

        string strQry = "select count(*) from P" + countryCode.ToString() + ".PT where calldate>='" + Convert.ToDateTime(rdpMinDate.SelectedDate).ToString("yyyy-MM-dd")
            + "' and calldate<='" + Convert.ToDateTime(rdpMaxDate.SelectedDate).ToString("yyyy-MM-dd") + "'"
            + " and providerid=" + ddlReseller.SelectedValue + ";";
        dsQry = objQuery.RunSelectQueryDBDirect("ERPInvoicing", strQry);

        if (Convert.ToInt32(dsQry.Tables[0].Rows[0][0]) == 0)
        {
            return false;
        }
        else
        {
            return true;
        }

    }

    private void loadProviderDDL(int selectedCountryID)
    {
        objProviderR.CountryId = selectedCountryID;
        dsPr = objProviderR.GetProviderByCountryId();

        ddlProvider.DataSource = dsPr;
        ddlProvider.DataTextField = "provider_name";
        ddlProvider.DataValueField = "provider_id";
        ddlProvider.DataBind();
        ddlProvider.Items.Insert(0, "Select Provider");

    }

    protected void ddlProvider_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            objProvider.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
            objProvider.ProviderId = Convert.ToInt32(ddlProvider.SelectedValue);
            dsPRovider = objProvider.GetProviderByCountryId();

            ddlReseller.DataSource = dsPRovider;
            ddlReseller.DataTextField = "provider_name";
            ddlReseller.DataValueField = "provider_id";
            ddlReseller.DataBind();
            ddlReseller.Items.Insert(0, "Select Reseller");
        }
        catch (Exception ex)
        {
        }
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(ddlCountry.SelectedValue) > 0)
            {
                loadProviderDDL(Convert.ToInt32(ddlCountry.SelectedValue));
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        RadGrid1.ExportSettings.ExportOnlyData = true;
        RadGrid1.ExportSettings.FileName = "TrafficControlReport" + DateTime.Now.ToString();
        RadGrid1.ExportSettings.IgnorePaging = true;
        RadGrid1.MasterTableView.ExportToExcel();

        //Response.Clear();
        //Response.Charset = "";
        //Response.ContentType = "application/vnd.ms-excel";
        ////create a string writer
        //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        ////create an htmltextwriter which uses the stringwriter
        //System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

        //DataSet ds = new DataSet();
        //ds = (DataSet)Session["tripdata"];
        //GVTrip.DataSource = (DataSet)Session["tripdata"];

        //GVTrip.PageSize = 20000;
        //GVTrip.DataBind();

        //string myFileName = "Traffic_Control_Report_" + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".xls";
        //Response.AddHeader("content-disposition", "attachment;filename=" + myFileName);

        //GVTrip.RenderControl(htmlWrite);
        ////all that's left is to output the html
        //Response.Write(stringWrite.ToString());
        //Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void TrafiicGenerate(DateTime fromDate, DateTime ToDate, int CountryID, int ProviderID)
    {
        try
        {

            string strDelete = "delete from ERPInvoicing.trafficcontrol where countryid=" + CountryID + " and providerid=" + ProviderID + " and generateday>='" + fromDate.ToString("yyyy-MM-dd") + "' and generateday<='" + ToDate.ToString("yyyy-MM-dd") + "';";
            string strInsert = "";
            string updateTrafficControlFromPT = "";
            string strUpdateTraffiConFromZombiCost = "";

            int countryCode = GetCountryCode(Convert.ToInt32(ddlCountry.SelectedValue));

            DateTime tempFromDate = fromDate;
            while (tempFromDate <= ToDate)
            {
                strInsert += "insert into ERPInvoicing.trafficcontrol (countryid, providerid, calltypeid, callcount, noofunit, filecost, clientcost, discount, clientcosttotal, generateday, createddatetime, userid) select " + CountryID + " ," + ProviderID + " ,calltypeid,0,0,0,0,0,0,'" + tempFromDate.ToString("yyyy-MM-dd") + "',now()," + Session["UserID"].ToString() + " from clayerp.calltype where countryid=" + CountryID + " and isdeleted=0;";
                tempFromDate = tempFromDate.AddDays(1);

                if (strInsert.Length > 1000000)
                {
                    UpdateQuery(strInsert);
                    strInsert = "";
                }
            }

            string strGetZombiCost = "select sum(providercost) as providercost, lcalltype,calldate from P" + countryCode + ".zombie where calldate>='"
             + fromDate.ToString("yyyy-MM-dd") + "' and calldate<='" + ToDate.ToString("yyyy-MM-dd") + "' and providerid=" + ProviderID + " group by calldate,lcalltype;";


            string strGetPTData = "select count(*) as callcount, sum(our_cost) as clientcost, sum(providercost) as filecost, sum(dis_value) as discount,"
                + " (sum(our_cost)-sum(dis_value)) as totalcost , sum(billable_units) as duration, lcalltype,calldate from P" + countryCode + ".PT where calldate>='"
                + fromDate.ToString("yyyy-MM-dd") + "' and calldate<='" + ToDate.ToString("yyyy-MM-dd") + "' and providerid=" + ProviderID + " group by calldate,lcalltype;";

            DataSet dsGet = objQuery.RunSelectQueryDBDirect("ERPInvoicing", strGetPTData);

            DataSet dsGetZombieCost = objQuery.RunSelectQueryDBDirect("ERPInvoicing", strGetZombiCost);

            int countCalls = 0;
            int duration = 0;
            double fileCost = 0;
            double clientCost = 0;
            double disValue = 0;
            double actual_Cost = 0;
            int lcalltype = 0;
            DateTime genDay = new DateTime();

            if (dsGet.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsGet.Tables[0].Rows.Count; i++)
                {
                    countCalls = Convert.ToInt32(dsGet.Tables[0].Rows[i][0]);
                    duration = Convert.ToInt32(dsGet.Tables[0].Rows[i][5]);
                    fileCost = Convert.ToDouble(dsGet.Tables[0].Rows[i][2]);
                    clientCost = Convert.ToDouble(dsGet.Tables[0].Rows[i][1]);
                    disValue = Convert.ToDouble(dsGet.Tables[0].Rows[i][3]);
                    actual_Cost = Convert.ToDouble(dsGet.Tables[0].Rows[i][4]);
                    lcalltype = Convert.ToInt32(dsGet.Tables[0].Rows[i][6]);
                    genDay = Convert.ToDateTime(dsGet.Tables[0].Rows[i][7]);

                    updateTrafficControlFromPT += "update ERPInvoicing.trafficcontrol set callcount=" + countCalls
                    + ", noofunit=" + duration
                    + ", filecost=" + fileCost
                    + ", clientcost=" + clientCost
                    + ", discount=" + disValue
                    + ", clientcosttotal=" + actual_Cost
                    + " where providerid=" + ProviderID.ToString() + " and countryid=" + CountryID.ToString() + " and calltypeid=" + lcalltype + " and generateday='" + genDay.ToString("yyyy-MM-dd") + "';";


                    if (updateTrafficControlFromPT.Length > 1000000)
                    {
                        UpdateQuery(updateTrafficControlFromPT);
                        updateTrafficControlFromPT = ""; ;
                    }
                }
            }

            double zombieFileCost = 0;
            int zombieCallType = 0;
            DateTime zombieCalldate = new DateTime();

            if (dsGetZombieCost.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsGetZombieCost.Tables[0].Rows.Count; i++)
                {
                    zombieFileCost = Convert.ToDouble(dsGetZombieCost.Tables[0].Rows[i][0]);
                    zombieCallType = Convert.ToInt32(dsGetZombieCost.Tables[0].Rows[i][1]);
                    zombieCalldate = Convert.ToDateTime(dsGetZombieCost.Tables[0].Rows[i][2]);

                    strUpdateTraffiConFromZombiCost += "update ERPInvoicing.trafficcontrol set zombiecost=" + zombieFileCost

                    + " where providerid=" + ProviderID.ToString() + " and countryid=" + CountryID.ToString() + " and calltypeid=" + zombieCallType
                    + " and generateday='" + zombieCalldate.ToString("yyyy-MM-dd") + "';";

                    if (strUpdateTraffiConFromZombiCost.Length > 1000000)
                    {
                        UpdateQuery(strUpdateTraffiConFromZombiCost);
                        strUpdateTraffiConFromZombiCost = ""; ;
                    }
                }
            }

            UpdateQuery(strDelete);
            UpdateQuery(strInsert);
            UpdateQuery(strUpdateTraffiConFromZombiCost);
            UpdateQuery(updateTrafficControlFromPT);

        }
        catch (Exception ex)
        {
        }
    }


    protected void UpdateQuery(string strUpdate)
    {
        try
        {
            Clay.Invoice.Bll.Query objUpdateQuery = new Clay.Invoice.Bll.Query();
            if (strUpdate.Length > 0)
            {
                string str = string.Empty;
                while (strUpdate.Length > 0)
                {
                    //lengthofQuery = strUpdate.Length;
                    if (strUpdate.Length > 500000)
                    {
                        int indexOff2 = Convert.ToString(strUpdate).LastIndexOf(";", 500000);

                        if (indexOff2 > 0)
                        {
                            str = strUpdate.Substring(0, indexOff2 + 1);

                            objUpdateQuery.CQuery = str;
                            objUpdateQuery.RunMultipleInsertQuery();
                            strUpdate = strUpdate.Remove(0, indexOff2 + 1);
                        }
                    }
                    else
                    {
                        // When Data length less then 1000 then update query....................
                        objUpdateQuery.CQuery = Convert.ToString(strUpdate);
                        objUpdateQuery.RunMultipleInsertQuery();
                        return;
                    }

                }

            }
        }
        catch (Exception ex)
        {

        }
    }
}