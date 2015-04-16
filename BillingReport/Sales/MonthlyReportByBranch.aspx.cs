using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class CreditControl_MonthlyReportByBranch : System.Web.UI.Page
{
    //Clay.Sale.Bll.CreditDetail cr_report = new Clay.Sale.Bll.CreditDetail();
    Clay.Sale.Bll.SalesSummaryReport cr_report = new Clay.Sale.Bll.SalesSummaryReport();
    private void loadYear()
    {
        //Load Years
        DataRow drYear;
        DataSet dsYear = new DataSet();
        DataTable dtYears = new DataTable();
        dsYear.Tables.Add(dtYears);

        DataColumn SNoColumn1 = new DataColumn();
        SNoColumn1.ColumnName = "yearVal";
        dsYear.Tables[0].Columns.Add(SNoColumn1);

        DataColumn SNoColumn2 = new DataColumn();
        SNoColumn2.ColumnName = "yearTxt";
        dsYear.Tables[0].Columns.Add(SNoColumn2);

        drYear = dsYear.Tables[0].NewRow();
        drYear["yearVal"] = "Select";
        drYear["yearTxt"] = 0;
        dsYear.Tables[0].Rows.InsertAt(drYear, 0);

        for (int i = 2010; i <= DateTime.Now.Year; i++)
        {
            drYear = dsYear.Tables[0].NewRow();
            drYear["yearVal"] = i;
            drYear["yearTxt"] = i;
            dsYear.Tables[0].Rows.InsertAt(drYear, i + 1 - 2010);
        }


        ddlyear2byyear.DataSource = dsYear.Tables[0];
        ddlyear2byyear.DataTextField = "yearVal";
        ddlyear2byyear.DataValueField = "yearTxt";
        ddlyear2byyear.DataBind();
        ddlyear2byyear.SelectedIndex = 0;

    }

    int branchid = 0;
    string branchname = string.Empty;

    int april_bill = 0;
    int may_bill = 0;
    int june_bill = 0;
    int july_bill = 0;
    int aug_bill = 0;
    int sept_bill = 0;
    int oct_bill = 0;
    int nov_bill = 0;
    int dec_bill = 0;
    int jan_bill = 0;
    int feb_bill = 0;
    int mar_bill = 0;



    int april_coll = 0;
    int may_coll = 0;
    int june_coll = 0;
    int july_coll = 0;
    int aug_coll = 0;
    int sept_coll = 0;
    int oct_coll = 0;
    int nov_coll = 0;
    int dec_coll = 0;
    int jan_coll = 0;
    int feb_coll = 0;
    int mar_coll = 0;

    int april_per = 0;
    int may_per = 0;
    int june_per = 0;
    int july_per = 0;
    int aug_per = 0;
    int sept_per = 0;
    int oct_per = 0;
    int nov_per = 0;
    int dec_per = 0;
    int jan_per = 0;
    int feb_per = 0;
    int mar_per = 0;

    int total = 0;
    string controlname = string.Empty;
    string controltype = string.Empty;
    static string fromYear, toYear;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private string ConvertToMoneyFormat(double myval)
    {
        return string.Format("{0:0.00}", myval);
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        #region Create Datatable
        System.Data.DataTable dt = new System.Data.DataTable();
        // dt.Columns.Add("Branchid", string.Empty.GetType());
        dt.Columns.Add("LeadSource", string.Empty.GetType());

        dt.Columns.Add("aprilbill", string.Empty.GetType());
        dt.Columns.Add("aprilcoll", string.Empty.GetType());
        dt.Columns.Add("aprilper", string.Empty.GetType());

        dt.Columns.Add("maybill", string.Empty.GetType());
        dt.Columns.Add("maycoll", string.Empty.GetType());
        dt.Columns.Add("mayper", string.Empty.GetType());


        dt.Columns.Add("junebill", string.Empty.GetType());
        dt.Columns.Add("junecoll", string.Empty.GetType());
        dt.Columns.Add("juneper", string.Empty.GetType());

        dt.Columns.Add("julybill", string.Empty.GetType());
        dt.Columns.Add("julycoll", string.Empty.GetType());
        dt.Columns.Add("julyper", string.Empty.GetType());

        dt.Columns.Add("augbill", string.Empty.GetType());
        dt.Columns.Add("augcoll", string.Empty.GetType());
        dt.Columns.Add("augper", string.Empty.GetType());


        dt.Columns.Add("septbill", string.Empty.GetType());
        dt.Columns.Add("septcoll", string.Empty.GetType());
        dt.Columns.Add("septper", string.Empty.GetType());

        dt.Columns.Add("octbill", string.Empty.GetType());
        dt.Columns.Add("octcoll", string.Empty.GetType());
        dt.Columns.Add("octper", string.Empty.GetType());

        dt.Columns.Add("novbill", string.Empty.GetType());
        dt.Columns.Add("novcoll", string.Empty.GetType());
        dt.Columns.Add("novper", string.Empty.GetType());

        dt.Columns.Add("decbill", string.Empty.GetType());
        dt.Columns.Add("deccoll", string.Empty.GetType());
        dt.Columns.Add("decper", string.Empty.GetType());


        dt.Columns.Add("janbill", string.Empty.GetType());
        dt.Columns.Add("jancoll", string.Empty.GetType());
        dt.Columns.Add("janper", string.Empty.GetType());


        dt.Columns.Add("febbill", string.Empty.GetType());
        dt.Columns.Add("febcoll", string.Empty.GetType());
        dt.Columns.Add("febper", string.Empty.GetType());


        dt.Columns.Add("marbill", string.Empty.GetType());
        dt.Columns.Add("marcoll", string.Empty.GetType());
        dt.Columns.Add("marper", string.Empty.GetType());

        #endregion

        int[] month = { 4, 5, 6, 7, 8, 9, 10, 11, 12, 1, 2, 3 };
        int i = 0;
        string fromdate = string.Empty;
        string todate = string.Empty;
        int year = 0;
        if (ddlyear2byyear.SelectedItem.Text == "Select")
        {
            lblInvoice.Text = "Please select Financial Year";
            RAFRepeater.DataSource = null;
            RAFRepeater.DataBind();
        }
        else
        {
            lblInvoice.Text = "";
            string _fYear = ddlyear2byyear.SelectedItem.Text.Trim();
            ViewState["Fyear"] = ddlyear2byyear.SelectedItem.Text.Trim();
            string[] yearArray = _fYear.Split('-');
            if (yearArray.Length > 1)
            {
                fromYear = yearArray[0].ToString();
                toYear = yearArray[1].ToString();

                fromdate = fromYear + "-" + "04" + "-" + "01";
                todate = toYear + "-" + "03" + "-" + "31";




                //fromdate = ddlyear2byyear.SelectedItem.Text + "-04-01";
                //year = Convert.ToInt32(ddlyear2byyear.SelectedItem.Text);
                // todate = year + 1 + "-03-31";
                // DataSet ds_all=cr_report.Get_Monthly_Report("2012-04-01","2013-03-31");
                DataSet ds_all = cr_report.GetLeadReportLevel2(Convert.ToDateTime(fromdate), Convert.ToDateTime(todate));
                if (ds_all.Tables["LeadSale"].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds_all.Tables[0].Rows)
                    {
                        DataRow dr_ = dt.NewRow();
                        //branchid = Convert.ToInt32(dr["branchid"]);
                        branchname = dr["leadsourcename"].ToString();
                        for (i = 0; i < month.Length; i++)
                        {
                            //DataRow[] dr_april_bill = ds_all.Tables["report"].Select("xtype=" + 1 + " and branch=" + branchid + " and month1=" + month[i]);
                            DataRow[] dr_april_bill = ds_all.Tables[1].Select("monthnumber='" + month[i] + "' and ccenquirysource='" + branchname + "'");
                            if (dr_april_bill.Length > 0)
                            {
                                if (dr_april_bill[0]["count1"] != DBNull.Value)
                                {
                                    april_bill = Convert.ToInt32(dr_april_bill[0]["count1"]);
                                    april_coll = Convert.ToInt32(dr_april_bill[0]["SaleConfirmed"]);// Convert.ToDecimal(dr_april_coll[0]["amount"]);
                                    total = Convert.ToInt32(dr_april_bill[0]["CardSold"]);// Convert.ToDecimal(dr_april_coll[0]["amount"]);
                                }
                                else
                                {
                                    april_bill = 0;// Convert.ToDecimal(dr_april_bill[0]["amount"]);
                                    april_coll = 0;
                                    total = 0;
                                }



                            }
                            else
                            {
                                april_bill = 0;// Convert.ToDecimal(dr_april_bill[0]["amount"]);
                                april_coll = 0;
                                total = 0;
                            }

                            if (month[i] == 4)
                            {

                                dr_["aprilbill"] = april_bill.ToString();
                                dr_["aprilcoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    // total = ((april_coll * 100) / april_bill);
                                    dr_["aprilper"] = Convert.ToInt32(total);
                                }
                                else
                                {
                                    dr_["aprilper"] = "0";
                                }

                            }
                            else if (month[i] == 5)
                            {
                                dr_["maybill"] = april_bill.ToString();
                                dr_["maycoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {

                                    //total = ((april_coll * 100) / april_bill);
                                    dr_["mayper"] = Convert.ToInt32(total);
                                }
                                else
                                {
                                    dr_["mayper"] = "0"; ;
                                }
                            }
                            else if (month[i] == 6)
                            {
                                dr_["junebill"] = april_bill.ToString();
                                dr_["junecoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    // total = ((april_coll * 100) / april_bill);
                                    dr_["juneper"] = Convert.ToInt32(total);
                                }
                                else
                                {
                                    dr_["juneper"] = "0"; ;
                                }
                            }
                            else if (month[i] == 7)
                            {
                                dr_["julybill"] = april_bill.ToString();
                                dr_["julycoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    //total = ((april_coll * 100) / april_bill);
                                    dr_["julyper"] = Convert.ToInt32(total);
                                }
                                else
                                {
                                    dr_["julyper"] = "0"; ;
                                }
                            }
                            else if (month[i] == 8)
                            {
                                dr_["augbill"] = april_bill.ToString();
                                dr_["augcoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    //total = ((april_coll * 100) / april_bill);
                                    dr_["augper"] = Convert.ToInt32(total);
                                }
                                else
                                {
                                    dr_["augper"] = "0"; ;
                                }
                            }
                            else if (month[i] == 9)
                            {
                                dr_["septbill"] = april_bill.ToString();
                                dr_["septcoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    //total = ((april_coll * 100) / april_bill);
                                    dr_["septper"] = Convert.ToInt32(total);
                                }
                                else
                                {
                                    dr_["septper"] = "0"; ;
                                }

                            }
                            else if (month[i] == 10)
                            {
                                dr_["octbill"] = april_bill.ToString();
                                dr_["octcoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    //total = ((april_coll * 100) / april_bill);
                                    dr_["octper"] = Convert.ToInt32(total);
                                }
                                else
                                {
                                    dr_["octper"] = "0"; ;
                                }
                            }
                            else if (month[i] == 11)
                            {
                                dr_["novbill"] = april_bill.ToString();
                                dr_["novcoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    // total = ((april_coll * 100) / april_bill);
                                    dr_["novper"] = Convert.ToInt32(total);
                                }
                                else
                                {
                                    dr_["novper"] = "0"; ;
                                }

                            }
                            else if (month[i] == 12)
                            {
                                dr_["decbill"] = april_bill.ToString();
                                dr_["deccoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    // total = ((april_coll * 100) / april_bill);
                                    dr_["decper"] = Convert.ToInt32(total);
                                }
                                else
                                {
                                    dr_["decper"] = "0";
                                }
                            }
                            else if (month[i] == 1)
                            {
                                dr_["janbill"] = april_bill.ToString();
                                dr_["jancoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    // total = ((april_coll * 100) / april_bill);
                                    dr_["janper"] = Convert.ToInt32(total);
                                }
                                else
                                {
                                    dr_["janper"] = "0"; ;
                                }
                            }
                            else if (month[i] == 2)
                            {
                                dr_["febbill"] = april_bill.ToString();
                                dr_["febcoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    // total = ((april_coll * 100) / april_bill);
                                    dr_["febper"] = Convert.ToInt32(total);
                                }
                                else
                                {
                                    dr_["febper"] = "0"; ;
                                }
                            }
                            else if (month[i] == 3)
                            {
                                dr_["marbill"] = april_bill.ToString();
                                dr_["marcoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    // total = ((april_coll * 100) / april_bill);
                                    dr_["marper"] = Convert.ToInt32(total);
                                }
                                else
                                {
                                    dr_["marper"] = "0"; ;
                                }
                            }


                        }
                        dr_["LeadSource"] = branchname.ToString();
                        dt.Rows.Add(dr_);
                        dt.AcceptChanges();

                        RAFRepeater.DataSource = dt;
                        RAFRepeater.DataBind();

                        tdexcel.Visible = true;
                        empty();

                    }
                }
                else
                {
                    RAFRepeater.DataSource = null;
                    RAFRepeater.DataBind();
                    tdexcel.Visible = false;
                }
            }
            else
            {
                lblInvoice.Text = "Please Select financial year !";
                RAFRepeater.DataSource = null;
                RAFRepeater.DataBind();
                tdexcel.Visible = false;
                return;
            }
        }
    }

    public void empty()
    {
        april_bill = 0;
        may_bill = 0;
        june_bill = 0;
        july_bill = 0;
        aug_bill = 0;
        sept_bill = 0;
        oct_bill = 0;
        nov_bill = 0;
        dec_bill = 0;
        jan_bill = 0;
        feb_bill = 0;
        mar_bill = 0;



        april_coll = 0;
        may_coll = 0;
        june_coll = 0;
        july_coll = 0;
        aug_coll = 0;
        sept_coll = 0;
        oct_coll = 0;
        nov_coll = 0;
        dec_coll = 0;
        jan_coll = 0;
        feb_coll = 0;
        mar_coll = 0;

        april_per = 0;
        may_per = 0;
        june_per = 0;
        july_per = 0;
        aug_per = 0;
        sept_per = 0;
        oct_per = 0;
        nov_per = 0;
        dec_per = 0;
        jan_per = 0;
        feb_per = 0;
        mar_per = 0;

        total = 0;
    }

    protected void imgexport_Click(object sender, ImageClickEventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Report_'" + DateTime.Now.ToString("hh:mm:ss tt") + "'.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";
        StringWriter str = new StringWriter();
        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(str);
        //  RAFRepeater.AllowPaging = false;
        //BindVehicleGrid();
        RAFRepeater.RenderControl(HtmlTextWriter);
        Response.Write(str.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void RAFRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblaprilbill = (Label)e.Item.FindControl("lblaprilbill");
            LinkButton lblaprilcoll = (LinkButton)e.Item.FindControl("lblaprilcoll");
            Label lblaprilper = (Label)e.Item.FindControl("lblaprilper");

            Label lblmaybill = (Label)e.Item.FindControl("lblmaybill");
            LinkButton lblmaycoll = (LinkButton)e.Item.FindControl("lblmaycoll");
            Label lblmayper = (Label)e.Item.FindControl("lblmayper");

            Label lbljunebill = (Label)e.Item.FindControl("lbljunebill");
            LinkButton lbljunecoll = (LinkButton)e.Item.FindControl("lbljunecoll");
            Label lbljuneper = (Label)e.Item.FindControl("lbljuneper");

            Label lbljulybill = (Label)e.Item.FindControl("lbljulybill");
            LinkButton lbljulycoll = (LinkButton)e.Item.FindControl("lbljulycoll");
            Label lbljulyper = (Label)e.Item.FindControl("lbljulyper");

            Label lblaugbill = (Label)e.Item.FindControl("lblaugbill");
            LinkButton lblaugcoll = (LinkButton)e.Item.FindControl("lblaugcoll");
            Label lblaugper = (Label)e.Item.FindControl("lblaugper");

            Label lblseptbill = (Label)e.Item.FindControl("lblseptbill");
            LinkButton lblseptcoll = (LinkButton)e.Item.FindControl("lblseptcoll");
            Label lblseptper = (Label)e.Item.FindControl("lblseptper");

            Label lbloctbill = (Label)e.Item.FindControl("lbloctbill");
            LinkButton lbloctcoll = (LinkButton)e.Item.FindControl("lbloctcoll");
            Label lbloctper = (Label)e.Item.FindControl("lbloctper");

            Label lblnovbill = (Label)e.Item.FindControl("lblnovbill");
            LinkButton lblnovcoll = (LinkButton)e.Item.FindControl("lblnovcoll");
            Label lblnovper = (Label)e.Item.FindControl("lblnovper");

            Label lbldecbill = (Label)e.Item.FindControl("lbldecbill");
            LinkButton lbldeccoll = (LinkButton)e.Item.FindControl("lbldeccoll");
            Label lbldecper = (Label)e.Item.FindControl("lbldecper");

            Label lbljanbill = (Label)e.Item.FindControl("lbljanbill");
            LinkButton lbljancoll = (LinkButton)e.Item.FindControl("lbljancoll");
            Label lbljanper = (Label)e.Item.FindControl("lbljanper");

            Label lblfebbill = (Label)e.Item.FindControl("lblfebbill");
            LinkButton lblfebcoll = (LinkButton)e.Item.FindControl("lblfebcoll");
            Label lblfebper = (Label)e.Item.FindControl("lblfebper");

            Label lblmarbill = (Label)e.Item.FindControl("lblmarbill");
            LinkButton lblmarcoll = (LinkButton)e.Item.FindControl("lblmarcoll");
            Label lblmarper = (Label)e.Item.FindControl("lblmarper");

            april_bill += Convert.ToInt32(lblaprilbill.Text);
            may_bill += Convert.ToInt32(lblmaybill.Text);
            june_bill += Convert.ToInt32(lbljunebill.Text);
            july_bill += Convert.ToInt32(lbljulybill.Text);
            aug_bill += Convert.ToInt32(lblaugbill.Text);
            sept_bill += Convert.ToInt32(lblseptbill.Text);
            oct_bill += Convert.ToInt32(lbloctbill.Text);
            nov_bill += Convert.ToInt32(lblnovbill.Text);
            dec_bill += Convert.ToInt32(lbldecbill.Text);
            jan_bill += Convert.ToInt32(lbljanbill.Text);
            feb_bill += Convert.ToInt32(lblfebbill.Text);
            mar_bill += Convert.ToInt32(lblmarbill.Text);



            april_coll += Convert.ToInt32(lblaprilcoll.Text);
            may_coll += Convert.ToInt32(lblmaycoll.Text);
            june_coll += Convert.ToInt32(lbljunecoll.Text);
            july_coll += Convert.ToInt32(lbljulycoll.Text);
            aug_coll += Convert.ToInt32(lblaugcoll.Text);
            sept_coll += Convert.ToInt32(lblseptcoll.Text);
            oct_coll += Convert.ToInt32(lbloctcoll.Text);
            nov_coll += Convert.ToInt32(lblnovcoll.Text);
            dec_coll += Convert.ToInt32(lbldeccoll.Text);
            jan_coll += Convert.ToInt32(lbljancoll.Text);
            feb_coll += Convert.ToInt32(lblfebcoll.Text);
            mar_coll += Convert.ToInt32(lblmarcoll.Text);

            april_per += Convert.ToInt32(lblaprilper.Text);
            may_per += Convert.ToInt32(lblmayper.Text);
            june_per += Convert.ToInt32(lbljuneper.Text);
            july_per += Convert.ToInt32(lbljulyper.Text);
            aug_per += Convert.ToInt32(lblaugper.Text);
            sept_per += Convert.ToInt32(lblseptper.Text);
            oct_per += Convert.ToInt32(lbloctper.Text);
            nov_per += Convert.ToInt32(lblnovper.Text);
            dec_per += Convert.ToInt32(lbldecper.Text);
            jan_per += Convert.ToInt32(lbljanper.Text);
            feb_per += Convert.ToInt32(lblfebper.Text);
            mar_per += Convert.ToInt32(lblmarper.Text);

        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Label lblaprilbilltotal = (Label)e.Item.FindControl("lblaprilbilltotal");
            LinkButton lblaprilcolltotal = (LinkButton)e.Item.FindControl("lblaprilcolltotal");
            Label lblaprilpertotal = (Label)e.Item.FindControl("lblaprilpertotal");

            Label lblmaybilltotal = (Label)e.Item.FindControl("lblmaybilltotal");
            LinkButton lblmaycolltotal = (LinkButton)e.Item.FindControl("lblmaycolltotal");
            Label lblmaypertotal = (Label)e.Item.FindControl("lblmaypertotal");

            Label lbljunebilltotal = (Label)e.Item.FindControl("lbljunebilltotal");
            LinkButton lbljunecolltotal = (LinkButton)e.Item.FindControl("lbljunecolltotal");
            Label lbljunepertotal = (Label)e.Item.FindControl("lbljunepertotal");

            Label lbljulybilltotal = (Label)e.Item.FindControl("lbljulybilltotal");
            LinkButton lbljulycolltotal = (LinkButton)e.Item.FindControl("lbljulycolltotal");
            Label lbljulypertotal = (Label)e.Item.FindControl("lbljulypertotal");

            Label lblaugbilltotal = (Label)e.Item.FindControl("lblaugbilltotal");
            LinkButton lblaugcolltotal = (LinkButton)e.Item.FindControl("lblaugcolltotal");
            Label lblaugpertotal = (Label)e.Item.FindControl("lblaugpertotal");

            Label lblseptbilltotal = (Label)e.Item.FindControl("lblseptbilltotal");
            LinkButton lblseptcolltotal = (LinkButton)e.Item.FindControl("lblseptcolltotal");
            Label lblseptpertotal = (Label)e.Item.FindControl("lblseptpertotal");

            Label lbloctbilltotal = (Label)e.Item.FindControl("lbloctbilltotal");
            LinkButton lbloctcolltotal = (LinkButton)e.Item.FindControl("lbloctcolltotal");
            Label lbloctpertotal = (Label)e.Item.FindControl("lbloctpertotal");

            Label lblnovbilltotal = (Label)e.Item.FindControl("lblnovbilltotal");
            LinkButton lblnovcolltotal = (LinkButton)e.Item.FindControl("lblnovcolltotal");
            Label lblnovpertotal = (Label)e.Item.FindControl("lblnovpertotal");

            Label lbldecbilltotal = (Label)e.Item.FindControl("lbldecbilltotal");
            LinkButton lbldeccolltotal = (LinkButton)e.Item.FindControl("lbldeccolltotal");
            Label lbldecpertotal = (Label)e.Item.FindControl("lbldecpertotal");

            Label lbljanbilltotal = (Label)e.Item.FindControl("lbljanbilltotal");
            LinkButton lbljancolltotal = (LinkButton)e.Item.FindControl("lbljancolltotal");
            Label lbljanpertotal = (Label)e.Item.FindControl("lbljanpertotal");

            Label lblfebbilltotal = (Label)e.Item.FindControl("lblfebbilltotal");
            LinkButton lblfebcolltotal = (LinkButton)e.Item.FindControl("lblfebcolltotal");
            Label lblfebpertotal = (Label)e.Item.FindControl("lblfebpertotal");

            Label lblmarbilltotal = (Label)e.Item.FindControl("lblmarbilltotal");
            LinkButton lblmarcolltotal = (LinkButton)e.Item.FindControl("lblmarcolltotal");
            Label lblmarpertotal = (Label)e.Item.FindControl("lblmarpertotal");


            // ========
            lblaprilbilltotal.Text = april_bill.ToString();
            lblaprilcolltotal.Text = april_coll.ToString();
            if (april_bill != 0)
            {
                total = (april_coll + april_bill);
                //lblaprilpertotal.Text = total.ToString();
                lblaprilpertotal.Text = april_per.ToString();
            }
            //lblaprilpertotal .Text =
            lblmaybilltotal.Text = may_bill.ToString();
            lblmaycolltotal.Text = may_coll.ToString();
            if (may_bill != 0)
            {
                total = (may_coll + may_bill);
                //lblmaypertotal.Text = total.ToString();
                lblmaypertotal.Text = may_per.ToString();
            }
            //lblmaypertotal .Text =

            lbljunebilltotal.Text = june_bill.ToString();
            lbljunecolltotal.Text = june_coll.ToString();

            if (june_bill != 0)
            {
                total = (june_coll + june_bill);
                //lbljunepertotal.Text = total.ToString();
                lbljunepertotal.Text = june_per.ToString();
            }
            //lbljunepertotal .Text =

            lbljulybilltotal.Text = july_bill.ToString();
            lbljulycolltotal.Text = july_coll.ToString();
            //lbljulypertotal .Text = 
            if (july_bill != 0)
            {
                total = (july_coll + july_bill);
                //lbljulypertotal.Text = total.ToString();
                lbljulypertotal.Text = july_per.ToString();
            }
            lblaugbilltotal.Text = aug_bill.ToString();
            lblaugcolltotal.Text = aug_coll.ToString();
            //lblaugpertotal .Text = 
            if (aug_bill != 0)
            {
                total = (july_coll + aug_bill);
                //lblaugpertotal.Text = total.ToString();
                lblaugpertotal.Text = aug_per.ToString();
            }
            lblseptbilltotal.Text = sept_bill.ToString();
            lblseptcolltotal.Text = sept_coll.ToString();
            //lblseptpertotal .Text = 
            if (sept_bill != 0)
            {
                total = (sept_coll + sept_bill);
                //lblseptpertotal.Text = total.ToString();
                lblseptpertotal.Text = sept_per.ToString();
            }
            lbloctbilltotal.Text = oct_bill.ToString();
            lbloctcolltotal.Text = oct_coll.ToString();
            //lbloctpertotal .Text = 
            if (oct_bill != 0)
            {
                total = (oct_coll + oct_bill);
                //lbloctpertotal.Text = total.ToString();
                lbloctpertotal.Text = oct_per.ToString();
            }
            lblnovbilltotal.Text = nov_bill.ToString();
            lblnovcolltotal.Text = nov_coll.ToString();
            //lblnovpertotal .Text = 
            if (nov_bill != 0)
            {
                total = (nov_coll + nov_bill);
                //lblnovpertotal.Text = total.ToString();
                lblnovpertotal.Text = nov_per.ToString();
            }
            lbldecbilltotal.Text = dec_bill.ToString();
            lbldeccolltotal.Text = dec_coll.ToString();
            //lbldecpertotal .Text = 
            if (dec_bill != 0)
            {
                total = (dec_coll + dec_bill);
                //lbldecpertotal.Text = total.ToString();
                lbldecpertotal.Text = dec_per.ToString();
            }
            lbljanbilltotal.Text = jan_bill.ToString();
            lbljancolltotal.Text = jan_coll.ToString();
            //lbljanpertotal .Text = 
            if (jan_bill != 0)
            {
                total = (jan_coll + jan_bill);
                //lbljanpertotal.Text = total.ToString();
                lbljanpertotal.Text = jan_per.ToString();
            }
            lblfebbilltotal.Text = feb_bill.ToString();
            lblfebcolltotal.Text = feb_coll.ToString();
            //lblfebpertotal .Text = 
            if (feb_bill != 0)
            {
                total = (feb_coll + feb_bill);
                //lblfebpertotal.Text = total.ToString();
                lblfebpertotal.Text = feb_per.ToString();
            }
            lblmarbilltotal.Text = mar_bill.ToString();
            lblmarcolltotal.Text = mar_coll.ToString();
            //lblmarpertotal .Text = 
            if (mar_bill != 0)
            {
                total = (mar_coll + mar_bill);
                //lblmarpertotal.Text = total.ToString();
                lblmarpertotal.Text = mar_per.ToString();
            }


        }
    }

    protected void RAFRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(e.CommandName))
        {
            string month = string.Empty;
            string LeadSource = string.Empty;
            switch (e.CommandName)
            {
                case "April":
                    month = "April";
                    LeadSource = e.CommandArgument.ToString();
                    break;
                case "May":
                    month = "May";
                    LeadSource = e.CommandArgument.ToString();
                    break;
                case "June":
                    month = "June";
                    LeadSource = e.CommandArgument.ToString();
                    break;
                case "July":
                    month = "July";
                    LeadSource = e.CommandArgument.ToString();
                    break;
                case "August":
                    month = "August";
                    LeadSource = e.CommandArgument.ToString();
                    break;
                case "September":
                    month = "September";
                    LeadSource = e.CommandArgument.ToString();
                    break;
                case "October":
                    month = "October";
                    LeadSource = e.CommandArgument.ToString();
                    break;
                case "November":
                    month = "November";
                    LeadSource = e.CommandArgument.ToString();
                    break;
                case "December":
                    month = "December";
                    LeadSource = e.CommandArgument.ToString();
                    break;
                case "January":
                    month = "January";
                    LeadSource = e.CommandArgument.ToString();
                    break;
                case "February":
                    month = "February";
                    LeadSource = e.CommandArgument.ToString();
                    break;
                case "March":
                    month = "March";
                    LeadSource = e.CommandArgument.ToString();
                    break;
                default:
                    break;
            }

            if (!string.IsNullOrWhiteSpace(month) && !string.IsNullOrWhiteSpace(LeadSource))
            {
                string url = "frmLeadDetails.aspx?month=" + month + "&leadsource=" + LeadSource + "&fromyear=" + fromYear + "&toyear=" + toYear;

                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>openNewWin('" + url + "')</script>");
            }

            if (!string.IsNullOrWhiteSpace(month) && string.IsNullOrWhiteSpace(LeadSource))
            {
                string url = "frmLeadDetails.aspx?month=" + month + "&leadsource=" + LeadSource + "&fromyear=" + fromYear + "&toyear=" + toYear;

                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>openNewWin('" + url + "')</script>");
            }
        }
    }
}