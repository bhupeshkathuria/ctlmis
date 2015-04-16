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
    Clay.Sale.Bll.CreditDetail cr_report = new Clay.Sale.Bll.CreditDetail();
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

    decimal april_bill = 0;
    decimal may_bill = 0;
    decimal june_bill = 0;
    decimal july_bill = 0;
    decimal aug_bill = 0;
    decimal sept_bill = 0;
    decimal oct_bill = 0;
    decimal nov_bill = 0;
    decimal dec_bill = 0;
    decimal jan_bill = 0;
    decimal feb_bill = 0;
    decimal mar_bill = 0;



    decimal april_coll = 0;
    decimal may_coll = 0;
    decimal june_coll = 0;
    decimal july_coll = 0;
    decimal aug_coll = 0;
    decimal sept_coll = 0;
    decimal oct_coll = 0;
    decimal nov_coll = 0;
    decimal dec_coll = 0;
    decimal jan_coll = 0;
    decimal feb_coll = 0;
    decimal mar_coll = 0;

    decimal april_per = 0;
    decimal may_per = 0;
    decimal june_per = 0;
    decimal july_per = 0;
    decimal aug_per = 0;
    decimal sept_per = 0;
    decimal oct_per = 0;
    decimal nov_per = 0;
    decimal dec_per = 0;
    decimal jan_per = 0;
    decimal feb_per = 0;
    decimal mar_per = 0;

    decimal total = 0;
    string controlname = string.Empty;
    string controltype = string.Empty;
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
        dt.Columns.Add("Branch", string.Empty.GetType());

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
            string _fYear = ddlyear2byyear.SelectedItem.Text.Trim();
            ViewState["Fyear"] = ddlyear2byyear.SelectedItem.Text.Trim();
            string fromYear, toYear;
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
                DataSet ds_all = cr_report.Get_Monthly_Report(fromdate, todate);
                if (ds_all.Tables["report"].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds_all.Tables["branch"].Rows)
                    {
                        DataRow dr_ = dt.NewRow();
                        branchid = Convert.ToInt32(dr["branchid"]);
                        branchname = dr["branchname"].ToString();
                        for (i = 0; i < month.Length; i++)
                        {
                            DataRow[] dr_april_bill = ds_all.Tables["report"].Select("xtype=" + 1 + " and branch=" + branchid + " and month1=" + month[i]);
                            if (dr_april_bill.Length > 0)
                            {
                                if (dr_april_bill[0]["xtype"] != DBNull.Value)
                                {
                                    april_bill = Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(dr_april_bill[0]["amount"])));
                                }
                                else
                                {
                                    april_bill = 0;// Convert.ToDecimal(dr_april_bill[0]["amount"]);
                                }
                            }
                            else
                            {
                                april_bill = 0;
                            }
                            DataRow[] dr_april_coll = ds_all.Tables["report"].Select("xtype=" + 2 + "and branch=" + branchid + " and month1=" + month[i]);
                            if (dr_april_coll.Length > 0)
                            {
                                if (dr_april_coll[0]["xtype"] != DBNull.Value)
                                {
                                    april_coll = Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(dr_april_coll[0]["amount"])));// Convert.ToDecimal(dr_april_coll[0]["amount"]);
                                }
                                else
                                {
                                    april_coll = 0;// Convert.ToDecimal(dr_april_coll[0]["amount"]);
                                }
                            }

                            else
                            {
                                april_coll = 0;
                            }

                            if (month[i] == 4)
                            {

                                dr_["aprilbill"] = april_bill.ToString();
                                dr_["aprilcoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    total = ((april_coll * 100) / april_bill);
                                    dr_["aprilper"] = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
                                }
                                else
                                {
                                    dr_["aprilper"] = "0.0";
                                }

                            }
                            else if (month[i] == 5)
                            {
                                dr_["maybill"] = april_bill.ToString();
                                dr_["maycoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {

                                    total = ((april_coll * 100) / april_bill);
                                    dr_["mayper"] = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
                                }
                                else
                                {
                                    dr_["mayper"] = "0.0";
                                }
                            }
                            else if (month[i] == 6)
                            {
                                dr_["junebill"] = april_bill.ToString();
                                dr_["junecoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    total = ((april_coll * 100) / april_bill);
                                    dr_["juneper"] = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
                                }
                                else
                                {
                                    dr_["juneper"] = "0.0";
                                }
                            }
                            else if (month[i] == 7)
                            {
                                dr_["julybill"] = april_bill.ToString();
                                dr_["julycoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    total = ((april_coll * 100) / april_bill);
                                    dr_["julyper"] = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
                                }
                                else
                                {
                                    dr_["julyper"] = "0.0";
                                }
                            }
                            else if (month[i] == 8)
                            {
                                dr_["augbill"] = april_bill.ToString();
                                dr_["augcoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    total = ((april_coll * 100) / april_bill);
                                    dr_["augper"] = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
                                }
                                else
                                {
                                    dr_["augper"] = "0.0";
                                }
                            }
                            else if (month[i] == 9)
                            {
                                dr_["septbill"] = april_bill.ToString();
                                dr_["septcoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    total = ((april_coll * 100) / april_bill);
                                    dr_["septper"] = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
                                }
                                else
                                {
                                    dr_["septper"] = "0.0";
                                }

                            }
                            else if (month[i] == 10)
                            {
                                dr_["octbill"] = april_bill.ToString();
                                dr_["octcoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    total = ((april_coll * 100) / april_bill);
                                    dr_["octper"] = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
                                }
                                else
                                {
                                    dr_["octper"] = "0.0";
                                }
                            }
                            else if (month[i] == 11)
                            {
                                dr_["novbill"] = april_bill.ToString();
                                dr_["novcoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    total = ((april_coll * 100) / april_bill);
                                    dr_["novper"] = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
                                }
                                else
                                {
                                    dr_["novper"] = "0.0";
                                }

                            }
                            else if (month[i] == 12)
                            {
                                dr_["decbill"] = april_bill.ToString();
                                dr_["deccoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    total = ((april_coll * 100) / april_bill);
                                    dr_["decper"] = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
                                }
                                else
                                {
                                    dr_["decper"] = "0.00";
                                }
                            }
                            else if (month[i] == 1)
                            {
                                dr_["janbill"] = april_bill.ToString();
                                dr_["jancoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    total = ((april_coll * 100) / april_bill);
                                    dr_["janper"] = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
                                }
                                else
                                {
                                    dr_["janper"] = "0.0";
                                }
                            }
                            else if (month[i] == 2)
                            {
                                dr_["febbill"] = april_bill.ToString();
                                dr_["febcoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    total = ((april_coll * 100) / april_bill);
                                    dr_["febper"] = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
                                }
                                else
                                {
                                    dr_["febper"] = "0.0";
                                }
                            }
                            else if (month[i] == 3)
                            {
                                dr_["marbill"] = april_bill.ToString();
                                dr_["marcoll"] = april_coll.ToString();
                                if (april_bill != 0)
                                {
                                    total = ((april_coll * 100) / april_bill);
                                    dr_["marper"] = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
                                }
                                else
                                {
                                    dr_["marper"] = "0.0";
                                }
                            }


                        }
                        dr_["Branch"] = branchname.ToString();
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
            Label lblaprilcoll = (Label)e.Item.FindControl("lblaprilcoll");
            Label lblaprilper = (Label)e.Item.FindControl("lblaprilper");

            Label lblmaybill = (Label)e.Item.FindControl("lblmaybill");
            Label lblmaycoll = (Label)e.Item.FindControl("lblmaycoll");
            Label lblmayper = (Label)e.Item.FindControl("lblmayper");

            Label lbljunebill = (Label)e.Item.FindControl("lbljunebill");
            Label lbljunecoll = (Label)e.Item.FindControl("lbljunecoll");
            Label lbljuneper = (Label)e.Item.FindControl("lbljuneper");

            Label lbljulybill = (Label)e.Item.FindControl("lbljulybill");
            Label lbljulycoll = (Label)e.Item.FindControl("lbljulycoll");
            Label lbljulyper = (Label)e.Item.FindControl("lbljulyper");

            Label lblaugbill = (Label)e.Item.FindControl("lblaugbill");
            Label lblaugcoll = (Label)e.Item.FindControl("lblaugcoll");
            Label lblaugper = (Label)e.Item.FindControl("lblaugper");

            Label lblseptbill = (Label)e.Item.FindControl("lblseptbill");
            Label lblseptcoll = (Label)e.Item.FindControl("lblseptcoll");
            Label lblseptper = (Label)e.Item.FindControl("lblseptper");

            Label lbloctbill = (Label)e.Item.FindControl("lbloctbill");
            Label lbloctcoll = (Label)e.Item.FindControl("lbloctcoll");
            Label lbloctper = (Label)e.Item.FindControl("lbloctper");

            Label lblnovbill = (Label)e.Item.FindControl("lblnovbill");
            Label lblnovcoll = (Label)e.Item.FindControl("lblnovcoll");
            Label lblnovper = (Label)e.Item.FindControl("lblnovper");

            Label lbldecbill = (Label)e.Item.FindControl("lbldecbill");
            Label lbldeccoll = (Label)e.Item.FindControl("lbldeccoll");
            Label lbldecper = (Label)e.Item.FindControl("lbldecper");

            Label lbljanbill = (Label)e.Item.FindControl("lbljanbill");
            Label lbljancoll = (Label)e.Item.FindControl("lbljancoll");
            Label lbljanper = (Label)e.Item.FindControl("lbljanper");

            Label lblfebbill = (Label)e.Item.FindControl("lblfebbill");
            Label lblfebcoll = (Label)e.Item.FindControl("lblfebcoll");
            Label lblfebper = (Label)e.Item.FindControl("lblfebper");

            Label lblmarbill = (Label)e.Item.FindControl("lblmarbill");
            Label lblmarcoll = (Label)e.Item.FindControl("lblmarcoll");
            Label lblmarper = (Label)e.Item.FindControl("lblmarper");

            april_bill += Convert.ToDecimal(lblaprilbill.Text);
            may_bill += Convert.ToDecimal(lblmaybill.Text);
            june_bill += Convert.ToDecimal(lbljunebill.Text);
            july_bill += Convert.ToDecimal(lbljulybill.Text);
            aug_bill += Convert.ToDecimal(lblaugbill.Text);
            sept_bill += Convert.ToDecimal(lblseptbill.Text);
            oct_bill += Convert.ToDecimal(lbloctbill.Text);
            nov_bill += Convert.ToDecimal(lblnovbill.Text);
            dec_bill += Convert.ToDecimal(lbldecbill.Text);
            jan_bill += Convert.ToDecimal(lbljanbill.Text);
            feb_bill += Convert.ToDecimal(lblfebbill.Text);
            mar_bill += Convert.ToDecimal(lblmarbill.Text);



            april_coll += Convert.ToDecimal(lblaprilcoll.Text);
            may_coll += Convert.ToDecimal(lblmaycoll.Text);
            june_coll += Convert.ToDecimal(lbljunecoll.Text);
            july_coll += Convert.ToDecimal(lbljulycoll.Text);
            aug_coll += Convert.ToDecimal(lblaugcoll.Text);
            sept_coll += Convert.ToDecimal(lblseptcoll.Text);
            oct_coll += Convert.ToDecimal(lbloctcoll.Text);
            nov_coll += Convert.ToDecimal(lblnovcoll.Text);
            dec_coll += Convert.ToDecimal(lbldeccoll.Text);
            jan_coll += Convert.ToDecimal(lbljancoll.Text);
            feb_coll += Convert.ToDecimal(lblfebcoll.Text);
            mar_coll += Convert.ToDecimal(lblmarcoll.Text);

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

        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Label lblaprilbilltotal = (Label)e.Item.FindControl("lblaprilbilltotal");
            Label lblaprilcolltotal = (Label)e.Item.FindControl("lblaprilcolltotal");
            Label lblaprilpertotal = (Label)e.Item.FindControl("lblaprilpertotal");

            Label lblmaybilltotal = (Label)e.Item.FindControl("lblmaybilltotal");
            Label lblmaycolltotal = (Label)e.Item.FindControl("lblmaycolltotal");
            Label lblmaypertotal = (Label)e.Item.FindControl("lblmaypertotal");

            Label lbljunebilltotal = (Label)e.Item.FindControl("lbljunebilltotal");
            Label lbljunecolltotal = (Label)e.Item.FindControl("lbljunecolltotal");
            Label lbljunepertotal = (Label)e.Item.FindControl("lbljunepertotal");

            Label lbljulybilltotal = (Label)e.Item.FindControl("lbljulybilltotal");
            Label lbljulycolltotal = (Label)e.Item.FindControl("lbljulycolltotal");
            Label lbljulypertotal = (Label)e.Item.FindControl("lbljulypertotal");

            Label lblaugbilltotal = (Label)e.Item.FindControl("lblaugbilltotal");
            Label lblaugcolltotal = (Label)e.Item.FindControl("lblaugcolltotal");
            Label lblaugpertotal = (Label)e.Item.FindControl("lblaugpertotal");

            Label lblseptbilltotal = (Label)e.Item.FindControl("lblseptbilltotal");
            Label lblseptcolltotal = (Label)e.Item.FindControl("lblseptcolltotal");
            Label lblseptpertotal = (Label)e.Item.FindControl("lblseptpertotal");

            Label lbloctbilltotal = (Label)e.Item.FindControl("lbloctbilltotal");
            Label lbloctcolltotal = (Label)e.Item.FindControl("lbloctcolltotal");
            Label lbloctpertotal = (Label)e.Item.FindControl("lbloctpertotal");

            Label lblnovbilltotal = (Label)e.Item.FindControl("lblnovbilltotal");
            Label lblnovcolltotal = (Label)e.Item.FindControl("lblnovcolltotal");
            Label lblnovpertotal = (Label)e.Item.FindControl("lblnovpertotal");

            Label lbldecbilltotal = (Label)e.Item.FindControl("lbldecbilltotal");
            Label lbldeccolltotal = (Label)e.Item.FindControl("lbldeccolltotal");
            Label lbldecpertotal = (Label)e.Item.FindControl("lbldecpertotal");

            Label lbljanbilltotal = (Label)e.Item.FindControl("lbljanbilltotal");
            Label lbljancolltotal = (Label)e.Item.FindControl("lbljancolltotal");
            Label lbljanpertotal = (Label)e.Item.FindControl("lbljanpertotal");

            Label lblfebbilltotal = (Label)e.Item.FindControl("lblfebbilltotal");
            Label lblfebcolltotal = (Label)e.Item.FindControl("lblfebcolltotal");
            Label lblfebpertotal = (Label)e.Item.FindControl("lblfebpertotal");

            Label lblmarbilltotal = (Label)e.Item.FindControl("lblmarbilltotal");
            Label lblmarcolltotal = (Label)e.Item.FindControl("lblmarcolltotal");
            Label lblmarpertotal = (Label)e.Item.FindControl("lblmarpertotal");


            // ========
            lblaprilbilltotal.Text = april_bill.ToString();
            lblaprilcolltotal.Text = april_coll.ToString();
            if (april_bill != 0)
            {
                total = ((april_coll * 100) / april_bill);
                lblaprilpertotal.Text = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
            }
            //lblaprilpertotal .Text =
            lblmaybilltotal.Text = may_bill.ToString();
            lblmaycolltotal.Text = may_coll.ToString();
            if (may_bill != 0)
            {
                total = ((may_coll * 100) / may_bill);
                lblmaypertotal.Text = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
            }
            //lblmaypertotal .Text =

            lbljunebilltotal.Text = june_bill.ToString();
            lbljunecolltotal.Text = june_coll.ToString();

            if (june_bill != 0)
            {
                total = ((june_coll * 100) / june_bill);
                lbljunepertotal.Text = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
            }
            //lbljunepertotal .Text =

            lbljulybilltotal.Text = july_bill.ToString();
            lbljulycolltotal.Text = july_coll.ToString();
            //lbljulypertotal .Text = 
            if (july_bill != 0)
            {
                total = ((july_coll * 100) / july_bill);
                lbljulypertotal.Text = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
            }
            lblaugbilltotal.Text = aug_bill.ToString();
            lblaugcolltotal.Text = aug_coll.ToString();
            //lblaugpertotal .Text = 
            if (july_bill != 0)
            {
                total = ((july_coll * 100) / july_bill);
                lblaugpertotal.Text = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
            }
            lblseptbilltotal.Text = sept_bill.ToString();
            lblseptcolltotal.Text = sept_coll.ToString();
            //lblseptpertotal .Text = 
            if (sept_bill != 0)
            {
                total = ((sept_coll * 100) / sept_bill);
                lblseptpertotal.Text = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
            }
            lbloctbilltotal.Text = oct_bill.ToString();
            lbloctcolltotal.Text = oct_coll.ToString();
            //lbloctpertotal .Text = 
            if (oct_bill != 0)
            {
                total = ((oct_coll * 100) / oct_bill);
                lbloctpertotal.Text = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
            }
            lblnovbilltotal.Text = nov_bill.ToString();
            lblnovcolltotal.Text = nov_coll.ToString();
            //lblnovpertotal .Text = 
            if (nov_bill != 0)
            {
                total = ((nov_coll * 100) / nov_bill);
                lblnovpertotal.Text = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
            }
            lbldecbilltotal.Text = dec_bill.ToString();
            lbldeccolltotal.Text = dec_coll.ToString();
            //lbldecpertotal .Text = 
            if (dec_bill != 0)
            {
                total = ((dec_coll * 100) / dec_bill);
                lbldecpertotal.Text = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
            }
            lbljanbilltotal.Text = jan_bill.ToString();
            lbljancolltotal.Text = jan_coll.ToString();
            //lbljanpertotal .Text = 
            if (jan_bill != 0)
            {
                total = ((jan_coll * 100) / jan_bill);
                lbljanpertotal.Text = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
            }
            lblfebbilltotal.Text = feb_bill.ToString();
            lblfebcolltotal.Text = feb_coll.ToString();
            //lblfebpertotal .Text = 
            if (feb_bill != 0)
            {
                total = ((feb_coll * 100) / feb_bill);
                lblfebpertotal.Text = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
            }
            lblmarbilltotal.Text = mar_bill.ToString();
            lblmarcolltotal.Text = mar_coll.ToString();
            //lblmarpertotal .Text = 
            if (mar_bill != 0)
            {
                total = ((mar_coll * 100) / mar_bill);
                lblfebpertotal.Text = (ConvertToMoneyFormat(Convert.ToDouble(total)).ToString());
            }


        }
    }
    
}