using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Sales_LeadSourceDetail : System.Web.UI.Page
{
    Clay.Sale.Bll.SalesSummaryReport objlead;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["UserId"]) == 821)
        {
            rbaffiliate.Checked = true;
            rbcst.Enabled = false;
        }
        else if (Convert.ToInt32(Session["UserId"]) == 569)
        {
            rbcst.Checked = true;
            rbaffiliate.Enabled = false;
        }
        else
        {
            rbcst.Enabled = true;
            rbaffiliate.Enabled = true;
        }
    }
    protected void lnksearch_Click(object sender, EventArgs e)
    {
        #region Create Datatable
        System.Data.DataTable dt = new System.Data.DataTable();

        dt.Columns.Add("Sale Confirmed", typeof(string));
        dt.Columns.Add("Prospects", typeof(string));
        dt.Columns.Add("To be followed up", typeof(string));

        dt.Columns.Add("Fake Calls", typeof(string));
        dt.Columns.Add("Wrong No", typeof(string));
        dt.Columns.Add("Test calls", typeof(string));

        dt.Columns.Add("High Pricing", typeof(string));
        dt.Columns.Add("Not Interested", typeof(string));
        dt.Columns.Add("Call Not connected", typeof(string));
        #endregion

        if (rbaffiliate.Checked)
        {
            this.pnlcst.Visible = false;
            #region Affiliate

            int _saleconfirm = 0;
            int _saleconfirm2 = 0;
            int _Prospects = 0;
            int _followed = 0;
            int _cardsold = 0;
            int _FakeCalls = 0;
            int _WrongNo = 0;
            int _Testcalls = 0;

            int _Duplicate = 0;
            int _Cancelled = 0;
            int _ExpectedSale = 0;

            int _HighPricing = 0;
            int _Notintersted = 0;
            int _Notsconnected = 0;
            int cardsold = 0;
            int totalleads = 0;

            // affliatedpartner
            int _saleconfirm1 = 0;
            int _cardsold1 = 0;
            int _saleconfirm21 = 0;
            int _Prospects1 = 0;
            int _followed1 = 0;
            int _FakeCalls1 = 0;
            int _WrongNo1 = 0;
            int _Testcalls1 = 0;
            int _Duplicate1 = 0;
            int _Cancelled1 = 0;
            int _ExpectedSale1 = 0;
            int _HighPricing1 = 0;
            int _Notintersted1 = 0;
            int _Notsconnected1 = 0;
            int cardsold1 = 0;
            int totalleads1 = 0;

            // All Lead Partner
            int _saleconfirmall = 0;
            int _cardsoldl = 0;
            int _saleconfirm22 = 0;
            int _Prospects2 = 0;
            int _followed2 = 0;
            int _FakeCalls2 = 0;
            int _WrongNo2 = 0;
            int _Testcalls2 = 0;
            int _Duplicate2 = 0;
            int _Cancelled2 = 0;
            int _ExpectedSale2 = 0;
            int _HighPricing2 = 0;
            int _Notintersted2 = 0;
            int _Notsconnected2 = 0;
            int cardsold2 = 0;
            int totalleads2 = 0;


            DataSet ds_lead = new DataSet();
            objlead = new Clay.Sale.Bll.SalesSummaryReport();
            ds_lead = objlead.GetLeadSourceReport_Groupwise(Convert.ToDateTime(txtfromdate.Text), Convert.ToDateTime(txttodate.Text));
            string msg = string.Empty;

            if (ds_lead.Tables[3].Rows.Count > 0)
            {
                lbltotallead.Text = ds_lead.Tables[3].Rows[0]["totallead"].ToString();
            }

            if (ds_lead.Tables[0].Rows.Count > 0)
            {
                pnllead.Visible = true;
                #region First part
                msg += "<table style='font-family:Verdana' valign=top align=center width=100% border=1 cellpadding=0 cellspacing=0>";
                msg += "";
                msg += "<tr style=background-color:#B4B4B4;color:Black;font-size:12>";
                msg += "<td rowspan='2' align=center background-color=#B4B4B4><b>Month</b></td>";
                msg += "<td colspan='4' align=center><b>Potential Leads</b></td>";
                msg += "<td colspan='3' align=center><b>Non- Potential Leads</b></td>";
                msg += "<td colspan='3' align=center><b>Not Converted</b></td>";
                msg += "<td colspan='3' align=center><b>Others</b></td>";
                msg += "</tr>";
                msg += "<tr style=background-color:#B4B4B4;color:Black;font-size:12>";
                msg += "<td align=center><b>Sale Confirmed</b></td>";
                msg += "<td align=center><b>Card Sold</b></td>";
                msg += "<td align=center><b>Prospects</b></td>";
                msg += "<td align=center><b>To be followed up</b></td>";
                msg += "<td align=center><b>Fake Calls</b></td>";
                msg += "<td align=center><b>Wrong No</b></td>";
                msg += "<td align=center><b>Test calls</b></td>";
                msg += "<td align=center><b>High Pricing</b></td>";
                msg += "<td align=center><b>Not Interested</b></td>";
                msg += "<td align=center><b>Call Not connected</b></td>";

                msg += "<td align=center><b>Duplicate Entry</b></td>";
                msg += "<td align=center><b>Cancelled</b></td>";
                msg += "<td align=center><b>ExpectedSale</b></td>";

                msg += "</tr>";
                foreach (DataRow item in ds_lead.Tables[0].Rows)
                {
                    msg += "<tr style=font-size:10>";
                    msg += "<td align=center style=background-color:#B4B4B4;color:Black;><b><b>" + item["leadmonth"] + "</b></td>";
                    msg += "<td align=center><b>" + item["salesconfirm"] + "</b></td>";
                    _saleconfirm += Convert.ToInt32(item["salesconfirm"]);

                    msg += "<td align=center><b>" + item["CardSold"] + "</b></td>";
                    _cardsold += Convert.ToInt32(item["CardSold"]);

                    msg += "<td align=center><b>" + item["Prospects"] + "</b></td>";
                    _Prospects += Convert.ToInt32(item["Prospects"]);

                    msg += "<td align=center><b>" + item["followup"] + "</b></td>";
                    _followed += Convert.ToInt32(item["followup"]);

                    msg += "<td align=center><b>" + item["Fake"] + "</b></td>";
                    _FakeCalls += Convert.ToInt32(item["Fake"]);

                    msg += "<td align=center><b>" + item["Wrongeno"] + "</b></td>";
                    _WrongNo += Convert.ToInt32(item["Wrongeno"]);

                    msg += "<td align=center><b>" + item["TestCall"] + "</b></td>";
                    _Testcalls += Convert.ToInt32(item["TestCall"]);

                    msg += "<td align=center><b>" + item["HighPrice"] + "</b></td>";
                    _HighPricing += Convert.ToInt32(item["HighPrice"]);

                    msg += "<td align=center><b>" + item["NotInterested"] + "</b></td>";
                    _Notintersted += Convert.ToInt32(item["NotInterested"]);
                    msg += "<td align=center><b>" + item["CallnotConnected"] + "</b></td>";
                    _Notsconnected += Convert.ToInt32(item["CallnotConnected"]);



                    msg += "<td align=center><b>" + item["Duplicate Entry"] + "</b></td>";
                    _Duplicate += Convert.ToInt32(item["Duplicate Entry"]);

                    msg += "<td align=center><b>" + item["Cancelled"] + "</b></td>";
                    _Cancelled += Convert.ToInt32(item["Cancelled"]);

                    msg += "<td align=center><b>" + item["ExpectedSale"] + "</b></td>";
                    _ExpectedSale += Convert.ToInt32(item["ExpectedSale"]);

                    msg += "</tr>";


                }
                msg += "<tr style=font-size:10 >";
                msg += "<td align=center style=background-color:#B4B4B4;color:Black;><b>MTD</b></td>";

                msg += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _saleconfirm + "</b></td>";
                msg += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _cardsold + "</b></td>";
                msg += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Prospects + "</b></td>";
                //msg += "<td align=center>" + (p + r) + "</td>";
                msg += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _followed + "</b></td>";
                msg += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _FakeCalls + "</b></td>";

                msg += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _WrongNo + "</b></td>";
                msg += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Testcalls + "</b></td>";



                msg += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _HighPricing + "</b></td>";
                msg += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Notintersted + "</b></td>";
                msg += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Notsconnected + "</b></td>";

                msg += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Duplicate + "</b></td>";
                msg += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Cancelled + "</b></td>";
                msg += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _ExpectedSale + "</b></td>";

                msg += "</tr>";
                msg += "</table>";
                lbllead.Text = msg.ToString();
                #endregion

                string msg2 = string.Empty;

                #region Secound Part
                msg2 += "<table style='font-family:Verdana' valign=top align=center width=100% border=1 cellpadding=0 cellspacing=0>";
                msg2 += "";
                msg2 += "<tr style=background-color:#B4B4B4;color:Black;font-size:12>";
                msg2 += "<td align=center background-color=#B4B4B4><b>Month</b></td>";
                msg2 += "<td align=center><b>Total Leads(Potential Leads+ Not Converted)</b></td>";
                msg2 += "<td align=center><b>Sale Confirmed</b></td>";
                msg2 += "<td align=center><b>No. of cards sold</b></td>";

                msg2 += "</tr>";


                foreach (DataRow item in ds_lead.Tables[0].Rows)
                {
                    msg2 += "<tr style=font-size:10>";
                    msg2 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + item["leadmonth"] + "</b></td>";
                    msg2 += "<td align=center><b>" + item["bothpotenandconvert"] + "</b></td>";
                    totalleads += Convert.ToInt32(item["bothpotenandconvert"]);
                    msg2 += "<td align=center><b>" + item["salesconfirm"] + "</b></td>";
                    _saleconfirm2 += Convert.ToInt32(item["salesconfirm"]);

                    msg2 += "<td align=center><b>" + item["CardSold"] + "</b></td>";
                    cardsold += Convert.ToInt32(item["CardSold"]);


                    msg2 += "</tr>";


                }
                msg2 += "<tr style=font-size:10 >";
                msg2 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>MTD</b></td>";

                msg2 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + totalleads + "</b></td>";
                msg2 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _saleconfirm2 + "</b></td>";
                //msg += "<td align=center>" + (p + r) + "</td>";
                msg2 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + cardsold + "</b></td>";


                msg += "</tr>";
                msg2 += "</table>";
                #endregion

                lbllead2.Text = msg2.ToString();

                // Affliated Partner
                string msg3 = string.Empty;
                #region Affliated part
                msg3 += "<table style='font-family:Verdana' valign=top align=center width=100% border=1 cellpadding=0 cellspacing=0>";
                msg3 += "";
                msg3 += "<tr style=background-color:#B4B4B4;color:Black;font-size:12>";
                msg3 += "<td rowspan='2' align=center background-color=#B4B4B4><b>Source</b></td>";
                msg3 += "<td colspan='4' align=center><b>Potential Leads</b></td>";
                msg3 += "<td colspan='3' align=center><b>Non- Potential Leads</b></td>";
                msg3 += "<td colspan='3' align=center><b>Not Converted</b></td>";
                msg3 += "<td colspan='3' align=center><b>Others</b></td>";
                msg3 += "</tr>";
                msg3 += "<tr style=background-color:#B4B4B4;color:Black;font-size:12>";
                msg3 += "<td align=center><b>Sale Confirmed</b></td>";
                msg3 += "<td align=center><b>Card Sold</b></td>";
                msg3 += "<td align=center><b>Prospects</b></td>";
                msg3 += "<td align=center><b>To be followed up</b></td>";
                msg3 += "<td align=center><b>Fake Calls</b></td>";
                msg3 += "<td align=center><b>Wrong No</b></td>";
                msg3 += "<td align=center><b>Test calls</b></td>";



                msg3 += "<td align=center><b>High Pricing</b></td>";
                msg3 += "<td align=center><b>Not Interested</b></td>";
                msg3 += "<td align=center><b>Call Not connected</b></td>";

                msg3 += "<td align=center><b>Duplicate Entry</b></td>";
                msg3 += "<td align=center><b>Cancelled</b></td>";
                msg3 += "<td align=center><b>ExpectedSale</b></td>";

                msg3 += "</tr>";
                foreach (DataRow item in ds_lead.Tables[2].Rows)
                {
                    msg3 += "<tr style=font-size:10>";
                    msg3 += "<td align=Left style=background-color:#B4B4B4;color:Black ;> <b>" + item["ccenquirysource"] + "</b></td>";
                    msg3 += "<td align=center><b>" + item["salesconfirm"] + "</b></td>";
                    _saleconfirm1 += Convert.ToInt32(item["salesconfirm"]);

                    msg3 += "<td align=center><b>" + item["CardSold"] + "</b></td>";
                    _cardsold1 += Convert.ToInt32(item["CardSold"]);

                    msg3 += "<td align=center><b>" + item["Prospects"] + "</b></td>";
                    _Prospects1 += Convert.ToInt32(item["Prospects"]);

                    msg3 += "<td align=center><b>" + item["followup"] + "</b></td>";
                    _followed1 += Convert.ToInt32(item["followup"]);

                    msg3 += "<td align=center><b>" + item["Fake"] + "</b></td>";
                    _FakeCalls1 += Convert.ToInt32(item["Fake"]);

                    msg3 += "<td align=center><b>" + item["Wrongeno"] + "</b></td>";
                    _WrongNo1 += Convert.ToInt32(item["Wrongeno"]);

                    msg3 += "<td align=center><b>" + item["TestCall"] + "</b></td>";
                    _Testcalls1 += Convert.ToInt32(item["TestCall"]);

                    msg3 += "<td align=center><b>" + item["HighPrice"] + "</b></td>";
                    _HighPricing1 += Convert.ToInt32(item["HighPrice"]);

                    msg3 += "<td align=center><b>" + item["NotInterested"] + "</b></td>";
                    _Notintersted1 += Convert.ToInt32(item["NotInterested"]);
                    msg3 += "<td align=center><b>" + item["CallnotConnected"] + "</b></td>";
                    _Notsconnected1 += Convert.ToInt32(item["CallnotConnected"]);



                    msg3 += "<td align=center><b>" + item["Duplicate Entry"] + "</b></td>";
                    _Duplicate1 += Convert.ToInt32(item["Duplicate Entry"]);

                    msg3 += "<td align=center><b>" + item["Cancelled"] + "</b></td>";
                    _Cancelled1 += Convert.ToInt32(item["Cancelled"]);

                    msg3 += "<td align=center><b>" + item["ExpectedSale"] + "</b></td>";
                    _ExpectedSale1 += Convert.ToInt32(item["ExpectedSale"]);

                    msg3 += "</tr>";


                }
                msg3 += "<tr style=font-size:10 >";
                msg3 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>Total</b></td>";

                msg3 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _saleconfirm1 + "</b></td>";
                msg3 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _cardsold1 + "</b></td>";
                msg3 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Prospects1 + "</b></td>";
                //msg += "<td align=center>" + (p + r) + "</td>";
                msg3 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _followed1 + "</b></td>";
                msg3 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _FakeCalls1 + "</b></td>";

                msg3 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _WrongNo1 + "</b></td>";
                msg3 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Testcalls1 + "</b></td>";

                msg3 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _HighPricing1 + "</b></td>";
                msg3 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Notintersted1 + "</b></td>";
                msg3 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Notsconnected1 + "</b></td>";

                msg3 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Duplicate1 + "</b></td>";
                msg3 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Cancelled1 + "</b></td>";
                msg3 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _ExpectedSale1 + "</b></td>";

                msg3 += "</tr>";
                msg3 += "</table>";
                lblaffiliated.Text = msg3.ToString();
                #endregion

                if (Convert.ToInt32(Session["UserId"]) != 821)
                {
                    // All  Partner
                    string msg4 = string.Empty;
                    #region All lead Patner part
                    msg4 += "<table style='font-family:Verdana' valign=top align=center width=100% border=1 cellpadding=0 cellspacing=0>";
                    msg4 += "";
                    msg4 += "<tr style=background-color:#B4B4B4;color:Black;font-size:12>";
                    msg4 += "<td rowspan='2' align=center background-color=#B4B4B4><b>Source</b></td>";
                    msg4 += "<td colspan='3' align=center><b>Potential Leads</b></td>";
                    msg4 += "<td colspan='3' align=center><b>Non- Potential Leads</b></td>";
                    msg4 += "<td colspan='3' align=center><b>Not Converted</b></td>";
                    msg4 += "<td colspan='4' align=center><b>Others</b></td>";
                    msg4 += "</tr>";
                    msg4 += "<tr style=background-color:#B4B4B4;color:Black;font-size:12>";
                    msg4 += "<td align=center><b>Sale Confirmed</b></td>";
                    msg4 += "<td align=center><b>Card Sold</b></td>";
                    msg4 += "<td align=center><b>Prospects</b></td>";
                    msg4 += "<td align=center><b>To be followed up</b></td>";
                    msg4 += "<td align=center><b>Fake Calls</b></td>";
                    msg4 += "<td align=center><b>Wrong No</b></td>";
                    msg4 += "<td align=center><b>Test calls</b></td>";

                    msg4 += "<td align=center><b>High Pricing</b></td>";
                    msg4 += "<td align=center><b>Not Interested</b></td>";
                    msg4 += "<td align=center><b>Call Not connected</b></td>";


                    msg4 += "<td align=center><b>Duplicate Entry</b></td>";
                    msg4 += "<td align=center><b>Cancelled</b></td>";
                    msg4 += "<td align=center><b>ExpectedSale</b></td>";

                    msg4 += "</tr>";
                    foreach (DataRow item in ds_lead.Tables[1].Rows)
                    {
                        msg4 += "<tr style=font-size:10>";
                        msg4 += "<td align=Left style=background-color:#B4B4B4;color:Black;><b>" + item["ccenquirysource"] + "</b></td>";
                        msg4 += "<td align=center><b>" + item["salesconfirm"] + "</b></td>";
                        _saleconfirmall += Convert.ToInt32(item["salesconfirm"]);

                        msg4 += "<td align=center><b>" + item["CardSold"] + "</b></td>";
                        _cardsoldl += Convert.ToInt32(item["CardSold"]);

                        msg4 += "<td align=center><b>" + item["Prospects"] + "</b></td>";
                        _Prospects2 += Convert.ToInt32(item["Prospects"]);

                        msg4 += "<td align=center><b>" + item["followup"] + "</b></td>";
                        _followed2 += Convert.ToInt32(item["followup"]);

                        msg4 += "<td align=center><b>" + item["Fake"] + "</b></td>";
                        _FakeCalls2 += Convert.ToInt32(item["Fake"]);

                        msg4 += "<td align=center><b>" + item["Wrongeno"] + "</b></td>";
                        _WrongNo2 += Convert.ToInt32(item["Wrongeno"]);

                        msg4 += "<td align=center><b>" + item["TestCall"] + "</b></td>";
                        _Testcalls2 += Convert.ToInt32(item["TestCall"]);

                        msg4 += "<td align=center><b>" + item["HighPrice"] + "</b></td>";
                        _HighPricing2 += Convert.ToInt32(item["HighPrice"]);

                        msg4 += "<td align=center><b>" + item["NotInterested"] + "</b></td>";
                        _Notintersted2 += Convert.ToInt32(item["NotInterested"]);
                        msg4 += "<td align=center><b>" + item["CallnotConnected"] + "</b></td>";
                        _Notsconnected2 += Convert.ToInt32(item["CallnotConnected"]);



                        msg4 += "<td align=center><b>" + item["Duplicate Entry"] + "</b></td>";
                        _Duplicate2 += Convert.ToInt32(item["Duplicate Entry"]);

                        msg4 += "<td align=center><b>" + item["Cancelled"] + "</b></td>";
                        _Cancelled2 += Convert.ToInt32(item["Cancelled"]);

                        msg4 += "<td align=center><b>" + item["ExpectedSale"] + "</b></td>";
                        _ExpectedSale2 += Convert.ToInt32(item["ExpectedSale"]);

                        msg4 += "</tr>";


                    }
                    msg4 += "<tr style=font-size:10 >";
                    msg4 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>Total</b></td>";

                    msg4 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _saleconfirmall + "</b></td>";
                    msg4 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _cardsoldl + "</b></td>";
                    msg4 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Prospects2 + "</b></td>";
                    //msg += "<td align=center>" + (p + r) + "</td>";
                    msg4 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _followed2 + "</b></td>";
                    msg4 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _FakeCalls2 + "</b></td>";

                    msg4 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _WrongNo2 + "</b></td>";
                    msg4 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Testcalls2 + "</b></td>";

                    msg4 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _HighPricing2 + "</b></td>";
                    msg4 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Notintersted2 + "</b></td>";
                    msg4 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Notsconnected2 + "</b></td>";



                    msg4 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Duplicate2 + "</b></td>";
                    msg4 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Cancelled2 + "</b></td>";
                    msg4 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _ExpectedSale2 + "</b></td>";

                    msg4 += "</tr>";
                    msg4 += "</table>";
                    lblalllead.Text = msg4.ToString();
                    #endregion
                }
                else
                {
                    txt1.Visible = false;
                }


            }
            else
            {
                pnllead.Visible = false;
                //lbllead.Text = "No Record Found";
                //lbllead2.Text = "No Record Found";
            }

            #endregion
        }
        if (rbcst.Checked)
        {
            this.pnllead.Visible = false;
            #region CST

            int _saleconfirm = 0;
            int _Prospects = 0;
            int _followed = 0;
            int _cardsold = 0;
            int _FakeCalls = 0;
            int _WrongNo = 0;
            int _Testcalls = 0;

            int _Duplicate = 0;
            int _Cancelled = 0;
            int _ExpectedSale = 0;

            int _HighPricing = 0;
            int _Notintersted = 0;
            int _Notsconnected = 0;
            int _TotalLead = 0;

            DataSet ds_Cstlead = new DataSet();
            objlead = new Clay.Sale.Bll.SalesSummaryReport();
            ds_Cstlead = objlead.GetCSTLeadReport(Convert.ToDateTime(txtfromdate.Text), Convert.ToDateTime(txttodate.Text));
            string msg5 = string.Empty;

            if (ds_Cstlead.Tables[0].Rows.Count > 0)
            {
                pnlcst.Visible = true;
                #region First part
                msg5 += "<table style='font-family:Verdana' valign=top align=center width=100% border=1 cellpadding=0 cellspacing=0>";
                msg5 += "";
                msg5 += "<tr style=background-color:#B4B4B4;color:Black;font-size:12>";
                msg5 += "<td rowspan='2' align=center background-color=#B4B4B4><b>Employee Name</b></td>";
                //msg5 += "<td rowspan='2' align=center background-color=#B4B4B4><b>Source</b></td>";
                msg5 += "<td rowspan='2' align=center><b>Total Leads</b></td>";
                msg5 += "<td colspan='4' align=center><b>Potential Leads</b></td>";
                msg5 += "<td colspan='3' align=center><b>Non- Potential Leads</b></td>";
                msg5 += "<td colspan='3' align=center><b>Not Converted</b></td>";
                msg5 += "<td colspan='3' align=center><b>Others</b></td>";
                msg5 += "</tr>";
                msg5 += "<tr style=background-color:#B4B4B4;color:Black;font-size:12>";
                //msg5 += "<td align=center></td>";
                msg5 += "<td align=center><b>Sale Confirmed</b></td>";
                msg5 += "<td align=center><b>Card Sold</b></td>";
                msg5 += "<td align=center><b>Prospects</b></td>";
                msg5 += "<td align=center><b>To be followed up</b></td>";
                msg5 += "<td align=center><b>Fake Calls</b></td>";
                msg5 += "<td align=center><b>Wrong No</b></td>";
                msg5 += "<td align=center><b>Test calls</b></td>";



                msg5 += "<td align=center><b>High Pricing</b></td>";
                msg5 += "<td align=center><b>Not Interested</b></td>";
                msg5 += "<td align=center><b>Call Not connected</b></td>";

                msg5 += "<td align=center><b>Duplicate Entry</b></td>";
                msg5 += "<td align=center><b>Cancelled</b></td>";
                msg5 += "<td align=center><b>ExpectedSale</b></td>";

                msg5 += "</tr>";
                foreach (DataRow item in ds_Cstlead.Tables[0].Rows)
                {
                    msg5 += "<tr style=font-size:10>";
                    msg5 += "<td align=Left style=background-color:#B4B4B4;color:Black ;> <b>" + item["employeename"] + "</b></td>";
                   // msg5 += "<td align=Left style=background-color:#B4B4B4;color:Black ;> <b>" + item["ccenquirysource"] + "</b></td>";
                    msg5 += "<td align=center style=background-color:#B4B4B4;color:Black ;> <b>" + item["LeadCount"] + "</b></td>";
                    _TotalLead += Convert.ToInt32(item["LeadCount"]);

                    msg5 += "<td align=center><b>" + item["salesconfirm"] + "</b></td>";
                    _saleconfirm += Convert.ToInt32(item["salesconfirm"]);

                    msg5 += "<td align=center><b>" + item["CardSold"] + "</b></td>";
                    _cardsold += Convert.ToInt32(item["CardSold"]);

                    msg5 += "<td align=center><b>" + item["Prospects"] + "</b></td>";
                    _Prospects += Convert.ToInt32(item["Prospects"]);

                    msg5 += "<td align=center><b>" + item["followup"] + "</b></td>";
                    _followed += Convert.ToInt32(item["followup"]);

                    msg5 += "<td align=center><b>" + item["Fake"] + "</b></td>";
                    _FakeCalls += Convert.ToInt32(item["Fake"]);

                    msg5 += "<td align=center><b>" + item["Wrongeno"] + "</b></td>";
                    _WrongNo += Convert.ToInt32(item["Wrongeno"]);

                    msg5 += "<td align=center><b>" + item["TestCall"] + "</b></td>";
                    _Testcalls += Convert.ToInt32(item["TestCall"]);

                    msg5 += "<td align=center><b>" + item["HighPrice"] + "</b></td>";
                    _HighPricing += Convert.ToInt32(item["HighPrice"]);

                    msg5 += "<td align=center><b>" + item["NotInterested"] + "</b></td>";
                    _Notintersted += Convert.ToInt32(item["NotInterested"]);
                    msg5 += "<td align=center><b>" + item["CallnotConnected"] + "</b></td>";
                    _Notsconnected += Convert.ToInt32(item["CallnotConnected"]);



                    msg5 += "<td align=center><b>" + item["Duplicate Entry"] + "</b></td>";
                    _Duplicate += Convert.ToInt32(item["Duplicate Entry"]);

                    msg5 += "<td align=center><b>" + item["Cancelled"] + "</b></td>";
                    _Cancelled += Convert.ToInt32(item["Cancelled"]);

                    msg5 += "<td align=center><b>" + item["ExpectedSale"] + "</b></td>";
                    _ExpectedSale += Convert.ToInt32(item["ExpectedSale"]);

                    msg5 += "</tr>";


                }
                msg5 += "<tr style=font-size:10 >";
                //msg5 += "<td align=center style=background-color:#B4B4B4;color:Black;></td>";
                msg5 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>Total</b></td>";
                msg5 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _TotalLead + "</b></td>";
                msg5 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _saleconfirm + "</b></td>";
                msg5 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _cardsold + "</b></td>";
                msg5 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Prospects + "</b></td>";
                //msg += "<td align=center>" + (p + r) + "</td>";
                msg5 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _followed + "</b></td>";
                msg5 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _FakeCalls + "</b></td>";

                msg5 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _WrongNo + "</b></td>";
                msg5 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Testcalls + "</b></td>";

                msg5 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _HighPricing + "</b></td>";
                msg5 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Notintersted + "</b></td>";
                msg5 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Notsconnected + "</b></td>";

                msg5 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Duplicate + "</b></td>";
                msg5 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _Cancelled + "</b></td>";
                msg5 += "<td align=center style=background-color:#B4B4B4;color:Black;><b>" + _ExpectedSale + "</b></td>";

                msg5 += "</tr>";
                msg5 += "</table>";
                lblcstleads.Text = msg5.ToString();
                lbltotallead.Text = _TotalLead.ToString();
                #endregion
            }

            #endregion
        }
    }
}