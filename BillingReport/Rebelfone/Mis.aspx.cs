using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Google.GData.Analytics;
using Google.GData.Client;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Text;
public partial class Rebelfone_Mis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!(Convert.ToInt32(Session["UserID"]) > 0))
            {
                Response.Redirect("Login.aspx", false);
            }
            if (!IsPostBack)
            {
                string day = DateTime.Now.AddDays(-1).Day.ToString();
                DateTime fromdate = Convert.ToDateTime(DateTime.Now.Year + "-" + DateTime.Now.Month +"-"+ day);
                DateTime todate = Convert.ToDateTime(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + day);
                lblmis.Text = FatchMISInformationShishpal(fromdate, todate);
            }
        }
        catch (Exception ex)
        {

        }
    }
    public string VisitsNumber(DateTime validatefrom, DateTime validateto, string Metrics)
    {
        string data = string.Empty;

        string username = "rebelfone1@gmail.com";
        string pass = "rebel4n123";

        string gkey = "?key=AIzaSyApvwdBbpXUUooH4VgGsqZccDff0WtdhpA";

        string dataFeedUrl = "https://www.google.com/analytics/feeds/data" + gkey;
        string accountFeedUrl = "https://www.googleapis.com/analytics/v2.4/management/accounts" + gkey;

        AnalyticsService service = new AnalyticsService("www.rebelfone.com");
        service.setUserCredentials(username, pass);

        DataQuery query1 = new DataQuery(dataFeedUrl);
        //query1.Dimensions = "ga:visits";
        query1.Ids = "ga:11397690";



        query1.Metrics = Metrics;


        //You were setting 2013-09-01 and thats an invalid date because it hasn't been reached yet, be sure you set valid dates
        //For start date is better to place an aprox date when you registered the domain on Google Analytics for example January 2nd 2012, for an end date the actual date is enough, no need to go further
        query1.GAStartDate = validatefrom.ToString("yyyy-MM-dd");
        query1.GAEndDate = validateto.ToString("yyyy-MM-dd");



        //  query1.StartIndex = 1;

        DataFeed dataFeedVisits = service.Query(query1);

        foreach (DataEntry entry in dataFeedVisits.Entries)
        {
            data = entry.Metrics[0].Value;
        }

        return !string.IsNullOrEmpty(data) ? data : "0";

        //return data != "" ?data.ToString():"0";
    }
    public string FatchMISInformation()
    {
        try
        {
            string ppc = "ga:adCost";
            string _ppcCurrentDay = string.Empty;
            string _ppcCurrentMonth = string.Empty;

            DateTime date = DateTime.Now.AddDays(-1).Date;
            DateTime date2 = DateTime.Now.AddDays(-1);
            DateTime fromdate = new DateTime(date.Year, date.Month, 1);
            DateTime todate = new DateTime(date2.Year, date2.Month, date2.Day);

            _ppcCurrentDay = VisitsNumber(todate, todate, ppc);

            _ppcCurrentMonth = VisitsNumber(fromdate, todate, ppc);

            DateTime MisDate = DateTime.Now.AddDays(-1);

            SqlConnection conn = new SqlConnection("Database=Rebelfone;Data Source=64.91.226.230;User ID=rebelsa;Password=dYe95Efs78*");

            conn.Open();
            // SqlCommand cmd = new SqlCommand("sproc_misreport", conn);
            SqlCommand cmd = new SqlCommand("select_mis", conn);
            DataSet dsMis = new DataSet();

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dsMis);
            conn.Close();


            string[,] strClient = new string[22, 2];
            strClient[0, 0] = "Accessories Sold";
            strClient[1, 0] = "SIM + Cell Phone Rentals";
            strClient[2, 0] = "Follow Me Service Sold";
            strClient[4, 0] = "SIM Card Only";
            strClient[3, 0] = "Handset Sold";
            strClient[5, 0] = "Mi-Fi Device";
            strClient[6, 0] = "Prepaid";
            strClient[7, 0] = "Data Bundle";
            strClient[16, 0] = "Airtime";
            strClient[19, 0] = "Total";
            strClient[21, 0] = "Amount";

            strClient[0, 1] = "0";
            strClient[1, 1] = "0";
            strClient[2, 1] = "0";
            strClient[4, 1] = "0";
            strClient[3, 1] = "0";
            strClient[5, 1] = "0";
            strClient[6, 1] = "0";
            strClient[7, 1] = "0";
            strClient[17, 1] = "0";


            strClient[8, 1] = "0";
            strClient[9, 1] = "0";
            strClient[10, 1] = "0";
            strClient[11, 1] = "0";
            strClient[12, 1] = "0";
            strClient[13, 1] = "0";
            strClient[14, 1] = "0";
            strClient[15, 1] = "0";
            strClient[16, 1] = "0";
            strClient[18, 1] = "0";
            strClient[19, 1] = "0";
            strClient[20, 1] = "0";
            strClient[21, 1] = "0";
            #region DayWise

            if (dsMis.Tables[3].Rows.Count > 0)
            {
                int SimTotal = 0;
                int Prepaid = 0;
                int Datacartd = 0;
                int simtotalnew = 0;

                for (int i = 0; i <= dsMis.Tables[0].Rows.Count - 1; i++)
                {
                    string str = Convert.ToString(dsMis.Tables[0].Rows[i]["Type"]);

                    string str1 = Convert.ToString(dsMis.Tables[0].Rows[i]["quantity"]);

                    if (str == "Accessories")
                    {
                        strClient[0, 1] = str1;
                    }
                    else if (str == "Cell rental")
                    {
                        strClient[1, 1] = str1;
                    }


                    else if (str == "Follow Me SIM")
                    {
                        strClient[2, 1] = str1;
                    }
                    else if (str == "World DataCard" || str == "World Datacard")
                    {
                        Datacartd += Convert.ToInt16(str1);
                        strClient[5, 1] = Convert.ToString(Datacartd);
                    }
                    else if (str == "SIM")
                    {

                        SimTotal = Convert.ToInt32(str1) + SimTotal;

                        strClient[4, 1] = SimTotal.ToString();
                    }
                    else if (str == "Handset")
                    {
                        strClient[3, 1] = str1;
                    }
                    else if (str == "Prepaid" || str == "Global SIM")
                    {
                        Prepaid += Convert.ToInt16(str1);
                        strClient[6, 1] = Convert.ToString(Prepaid);
                    }

                    else if (str == "Databundle")
                    {
                        strClient[7, 1] = str1;
                    }

                    else if (str == "Airtime")
                    {
                        strClient[16, 1] = str1;
                    }
                    else
                    {
                        strClient[5, 0] = str;
                        strClient[5, 1] = str1;
                    }

                }

            }

            #endregion
            //For Month Wise
            #region Month Wise

            if (dsMis.Tables[3].Rows.Count > 0)
            {
                int SimTotal = 0;
                int Prepaid = 0;
                int Datacartd = 0;
                int simtotalnew = 0;

                for (int i = 0; i <= dsMis.Tables[3].Rows.Count - 1; i++)
                {
                    string str = Convert.ToString(dsMis.Tables[3].Rows[i]["Type"]);

                    string str1 = Convert.ToString(dsMis.Tables[3].Rows[i]["quantity"]);

                    if (str == "Accessories")
                    {
                        strClient[8, 1] = str1;
                    }
                    else if (str == "Cell rental")
                    {
                        strClient[9, 1] = str1;
                    }


                    else if (str == "Follow Me SIM")
                    {
                        strClient[10, 1] = str1;
                    }
                    else if (str == "World DataCard" || str == "World Datacard")
                    {
                        Datacartd += Convert.ToInt16(str1);
                        strClient[11, 1] = Convert.ToString(Datacartd);
                    }
                    else if (str == "SIM")
                    {

                        SimTotal = Convert.ToInt32(str1) + SimTotal;

                        strClient[12, 1] = SimTotal.ToString();
                    }
                    else if (str == "Handset")
                    {
                        strClient[13, 1] = str1;
                    }
                    else if (str == "Prepaid" || str == "Global SIM")
                    {
                        Prepaid += Convert.ToInt16(str1);
                        strClient[14, 1] = Convert.ToString(Prepaid);
                    }

                    else if (str == "Databundle")
                    {
                        strClient[15, 1] = str1;
                    }

                    else if (str == "Airtime")
                    {
                        strClient[18, 1] = str1;
                    }
                    else
                    {
                        strClient[5, 0] = str;
                        strClient[5, 1] = str1;
                    }
                }

            }

            string msg = string.Empty;

            int m = Convert.ToInt32(strClient[4, 1]);
            int n = Convert.ToInt32(strClient[1, 1]);
            int l = Convert.ToInt32(strClient[5, 1]);
            int k = Convert.ToInt32(strClient[6, 1]);

            int p = Convert.ToInt32(strClient[9, 1]);
            int q = Convert.ToInt32(strClient[11, 1]);
            int r = Convert.ToInt32(strClient[12, 1]);
            int s = Convert.ToInt32(strClient[14, 1]);

            #endregion


            msg += "<table style='font-family:Verdana' valign=top align=center width=100% border=1 cellpadding=0 cellspacing=0>";
            msg += "";
            msg += "<tr style=background-color:#B4B4B4;color:#fff;font-size:14>";
            msg += "<td rowspan='2' align=center background-color=#B4B4B4><b>Date</b></td>";
            msg += "<td colspan='5' align=center><b>Services Sold</b></td>";
            msg += "<td colspan='6' align=center><b>Other Items</b></td>";
            msg += "<td rowspan='2' align=center background-color=#B4B4B4><b>PPC Spent($)</b></td>";
            msg += "</tr>";
            msg += "<tr style=background-color:#ccc;color:#fff;font-size:12>";

            msg += "<td align=center><b>" + strClient[4, 0] + "</b></td>";
            msg += "<td align=center><b>" + strClient[1, 0] + "</b></td>";
            msg += "<td align=center><b>" + strClient[19, 0] + "</b></td>";
            msg += "<td align=center><b>" + strClient[5, 0] + "</b></td>";
            msg += "<td align=center><b>" + strClient[6, 0] + "</b></td>";


            msg += "<td align=center><b>" + strClient[3, 0] + "</b></td>";
            msg += "<td align=center><b>" + strClient[0, 0] + "</b></td>";
            msg += "<td align=center><b>" + strClient[2, 0] + "</b></td>";
            msg += "<td align=center><b>" + strClient[7, 0] + "</b></td>";
            msg += "<td align=center><b>" + strClient[16, 0] + "</b></td>";
            msg += "<td align=center><b>" + strClient[21, 0] + "</b></td>";

            msg += "</tr>";



            msg += "<tr style=font-size:10>";
            msg += "<td align=center><b>" + MisDate.Day + "-" + MisDate.ToString("MMM") + "</b></td>";
            msg += "<td align=center><b>" + strClient[4, 1] + "</b></td>";
            msg += "<td align=center>" + strClient[1, 1] + "</td>";
            msg += "<td align=center>" + (m + n) + "</td>";
            msg += "<td align=center>" + strClient[5, 1] + "</td>";
            msg += "<td align=center>" + strClient[6, 1] + "</td>";
            msg += "<td align=center>" + strClient[3, 1] + "</td>";
            msg += "<td align=center>" + strClient[0, 1] + "</td>";
            msg += "<td align=center>" + strClient[2, 1] + "</td>";
            msg += "<td align=center>" + strClient[7, 1] + "</td>";
            msg += "<td align=center>" + strClient[16, 1] + "</td>";
            msg += "<td align=center>" + String.Format("{0:0.00}", dsMis.Tables[4].Rows[0]["UnitPrice"]) + "</td>";
            msg += "<td align=center>" + _ppcCurrentDay + "</td>";

            msg += "</tr>";

            msg += "<tr style=font-size:10>";
            msg += "<td align=center><b>MTD</b></td>";

            msg += "<td align=center>" + strClient[12, 1] + "</td>";
            msg += "<td align=center>" + strClient[9, 1] + "</td>";
            msg += "<td align=center>" + (p + r) + "</td>";
            msg += "<td align=center>" + strClient[11, 1] + "</td>";
            msg += "<td align=center>" + strClient[14, 1] + "</td>";

            msg += "<td align=center>" + strClient[13, 1] + "</td>";
            msg += "<td align=center>" + strClient[8, 1] + "</td>";
            msg += "<td align=center>" + strClient[10, 1] + "</td>";
            msg += "<td align=center>" + strClient[15, 1] + "</td>";
            msg += "<td align=center>" + strClient[18, 1] + "</td>";
            msg += "<td align=center>" + String.Format("{0:0.00}", dsMis.Tables[5].Rows[0]["TotalMonthMAmount"]) + "</td>";
            msg += "<td align=center>" + _ppcCurrentMonth + "</td>";
            msg += "</tr>";

            msg += "</table>";

            msg += "<Br/><Br/>";

            msg += "<div style='clear:both;height:40px; float:left; margin-top:40px;'><div/>";
            msg += "<table style='font-family:Verdana' valign=top align=left width=70% border=1 cellpadding=0 cellspacing=0>";
            msg += "";

            if (dsMis.Tables[2].Rows.Count > 0)
            {

                msg += "<tr style=background-color:#B4B4B4;color:#fff;font-size:12>";


                msg += "<td align=center colspan='4'><b> Description</b></td>";


                msg += "</tr>";


                msg += "<tr style=background-color:Gray;color:#fff;font-size:10>";


                msg += "<td align=center><b> OrderId</b></td> <td align=center><b> Item Name</b></td>";
                msg += "<td align=center><b> Quantity</b></td> ";
                msg += "<td align=center><b> Amount</b></td> ";
                msg += "<td align=center><b> Shipped State</b></td>";


                msg += "</tr>";

                decimal orderamount = 0;

                for (int i = 0; i <= dsMis.Tables[2].Rows.Count - 1; i++)
                {

                    msg += "<tr style=font-size:10>";

                    msg += "<td align=center>" + Convert.ToString(dsMis.Tables[2].Rows[i]["orderid"]) + "</td>";
                    msg += "<td align=left> " + Convert.ToString(dsMis.Tables[2].Rows[i]["Categoryname"]) + " </td>";
                    msg += "<td align=center>" + Convert.ToString(dsMis.Tables[2].Rows[i]["Quantity"]) + "</td>";
                    msg += "<td align=center>" + Convert.ToString(dsMis.Tables[2].Rows[i]["Unitprice"]) + "</td>";
                    msg += "<td align=center>" + Convert.ToString(dsMis.Tables[2].Rows[i]["shippingstate"]) + "</td>";
                    orderamount += Convert.ToDecimal(dsMis.Tables[2].Rows[i]["Unitprice"]);

                    msg += "</tr>";

                }
                msg += "<tr style=font-size:10>";

                msg += "<td align=center> </td>";
                msg += "<td align=left> Total </td>";
                msg += "<td align=center></td>";
                msg += "<td align=center>" + orderamount + "</td>";
                msg += "<td align=center></td>";


                msg += "</tr>";
            }

            msg += "</table>";
            msg += "</br></br>";

            #region For Rebelfone IVR Report

            //DataTable dtIVr = IVRGetData();




            ////IVR Report

            //msg += "<div style='clear:both;height:40px; float:left; margin-top:40px;'><div/>";
            //msg += "<table style='font-family:Verdana' valign=top align=left width=100% border=1 cellpadding=0 cellspacing=0>";
            //msg += "";

            //if (dsMis.Tables[2].Rows.Count > 0)
            //{

            //    msg += "<tr style=background-color:Gray;color:#fff;font-size:14>";


            //    msg += "<td align=center colspan='5' ><b>IVR Description</b></td>";


            //    msg += "</tr>";


            //    msg += "<tr style=background-color:#ccc;color:#fff;font-size:12>";


            //    msg += "<td align=center ><b> Total Calls</b></td> <td align=center ><b> Call Answer</b></td> <td align=center><b> Call HangUp</b></td> <td align=center><b> Call Transfer</b></td> <td align=center><b> Request For Agent</b></td>";


            //    msg += "</tr>";



            //    DataRow dr = dtIVr.Rows[dtIVr.Rows.Count - 1];
            //    if(dr!=null)
            //    {

            //        msg += "<tr style=font-size:10>";

            //        msg += "<td align=center>" + Convert.ToString(dr["Calls_on_IVR"]) + "</td> <td align=center> " + Convert.ToString(dr["Ans_By_Agent"]) + " </td> <td align=center>" + Convert.ToString(dr["Calls_Hungup_on_IVR"]) + "</td> <td align=center>" + Convert.ToString(dr["Calls_Transfer_On_Mobile"]) + "</td><td align=center>" + Convert.ToString(dr["Requested_for_Agent"]) + "</td>";


            //        msg += "</tr>";

            //    }
            //}

            #endregion

            #region Techscoot
            //DataSet dsTotaldata = new DataSet();
            //DataSet dsperday = new DataSet();
            //DateTime datenow = DateTime.Now.AddDays(-1);
            ////DateTime MisDate = DateTime.Now.AddDays(-1);
            //MySqlConnection conn1 = new MySqlConnection("Database=techscoot;Data Source=208.74.79.46;User ID=techscoot;Password=techscoot#2013");
            //// string dt = "2013-12-24";
            //string dt = Convert.ToString(datenow.ToString("yyyy") + "-" + datenow.ToString("MM") + "-" + datenow.ToString("dd"));
            //conn.Open();

            //MySqlCommand cmd1 = new MySqlCommand("SELECT  COUNT(CASE WHEN card.`amount`=99.99 THEN card.amount END) AS '99.99',COUNT(CASE WHEN card.`amount`=149.99 THEN card.amount END) AS '149.99',COUNT(CASE WHEN card.`amount`=199.99 THEN card.amount END) AS '199.99', COUNT(CASE WHEN card.`amount`=299.99 THEN card.amount END) AS '299.99' FROM carddetail card INNER JOIN `order` od ON od.`orderid`=card.`orderid` WHERE DATE(DATE_ADD(card.createdon,INTERVAL -9 HOUR)) BETWEEN '" + dt + "' AND '" + dt + "' AND od.`paymentstatus`=1 AND card.isdeleted=0", conn1);
            //cmd1.CommandType = CommandType.Text;

            //cmd1.CommandTimeout = 36000;

            //MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);

            //da1.Fill(dsTotaldata);

            //MySqlCommand cmd2 = new MySqlCommand("SELECT SUM(spend) AS perday FROM sale WHERE  DATE(dateofsale) BETWEEN '" + dt + "' AND '" + dt + "'", conn1);
            //cmd2.CommandType = CommandType.Text;

            //cmd2.CommandTimeout = 36000;

            //MySqlDataAdapter adp = new MySqlDataAdapter(cmd2);

            //adp.Fill(dsperday);

            //int total_sale = 0;
            //decimal toatal_amt = 0;
            //int tot_amt = 0;
            //total_sale += Convert.ToInt32(dsTotaldata.Tables[0].Rows[0]["99.99"]);

            //total_sale += Convert.ToInt32(dsTotaldata.Tables[0].Rows[0]["149.99"]);
            //total_sale += Convert.ToInt32(dsTotaldata.Tables[0].Rows[0]["199.99"]);
            //total_sale += Convert.ToInt32(dsTotaldata.Tables[0].Rows[0]["299.99"]);

            //tot_amt = Convert.ToInt32(dsTotaldata.Tables[0].Rows[0]["99.99"]);
            //toatal_amt += Convert.ToDecimal(tot_amt * 99.99);
            //tot_amt = Convert.ToInt32(dsTotaldata.Tables[0].Rows[0]["149.99"]);
            //toatal_amt += Convert.ToDecimal(tot_amt * 149.99);
            //tot_amt = Convert.ToInt32(dsTotaldata.Tables[0].Rows[0]["199.99"]);
            //toatal_amt += Convert.ToDecimal(tot_amt * 199.99);
            //tot_amt = Convert.ToInt32(dsTotaldata.Tables[0].Rows[0]["299.99"]);
            //toatal_amt += Convert.ToDecimal(tot_amt * 299.99);

            //string _mailstr = string.Empty;
            //_mailstr += "</br></br></br></br></br></br></br></br></br>";
            //_mailstr += "<table style='font-family:Verdana' valign=top align=center width=70% border=1 cellpadding=0 cellspacing=0>";
            //_mailstr += "";
            //_mailstr += "<tr style=background-color:Gray;color:#fff;font-size:14>";
            //_mailstr += "<td colspan=8 align=center background-color=Gray><b>TechScoot Sale </b></td>";
            //_mailstr += "</tr>";
            //_mailstr += "<tr style=background-color:Gray;color:#fff;font-size:14>";
            //_mailstr += "<td  align=center background-color=Gray><b>Date</b></td>";
            //_mailstr += "<td  align=center><b>Plan 99.99 </b></td>";
            //_mailstr += "<td  align=center><b>Plan 149.99</b></td>";
            //_mailstr += "<td  align=center><b>Plan 199.99</b></td>";
            //_mailstr += "<td  align=center><b>Plan 299.99</b></td>";
            //_mailstr += "<td  align=center><b>Total Sale</b></td>";
            //_mailstr += "<td  align=center><b>Total Amount ($)</b></td>";

            //_mailstr += "<td  align=center background-color=Gray><b>Spent ($)</b></td>";
            //_mailstr += "</tr>";

            //_mailstr += "<tr style=background-color:#ccc;font-size:12>";
            //_mailstr += "<td align=center><b>" + MisDate.Day + "-" + MisDate.ToString("MMM") + "<b></td>";
            //_mailstr += "<td align=center>" + dsTotaldata.Tables[0].Rows[0]["99.99"].ToString() + "</td>";
            //_mailstr += "<td align=center>" + dsTotaldata.Tables[0].Rows[0]["149.99"].ToString() + "</td>";
            //_mailstr += "<td align=center>" + dsTotaldata.Tables[0].Rows[0]["199.99"].ToString() + "</td>";
            //_mailstr += "<td align=center>" + dsTotaldata.Tables[0].Rows[0]["299.99"].ToString() + "</td>";
            //_mailstr += "<td align=center>" + total_sale + "</td>";
            //_mailstr += "<td align=center>" + toatal_amt + "</td>";
            //if (dsperday.Tables[0].Rows.Count > 0)
            //{
            //    _mailstr += "<td align=center>" + dsperday.Tables[0].Rows[0]["perday"].ToString() + "</td>";
            //}
            //else
            //{
            //    _mailstr += "<td align=center>0.00</td>";
            //}

            //_mailstr += "</tr>";

            //_mailstr += "</table>";

            //cmd1.Dispose();
            //if (conn1.State == ConnectionState.Open)
            //{
            //    conn1.Close();
            //}
            #endregion
            //msg += _mailstr;
            msg += "</table>";

            return msg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public string FatchMISInformationcopy(DateTime fromdatemis,DateTime todatemis)
    {
        #region Varibles
        int _sim = 0;
        int _simrental = 0;
        int _mifi = 0;
        int _prapid = 0;
        int _handset = 0;
        int _accessory = 0;
        int _followme = 0;
        int _databundle = 0;
        int _airtime = 0;
        decimal _amount = 0;
        decimal _shippingprice = 0;
        decimal _ppccost = 0;

        decimal _ServiceLengthPrice = 0;
        decimal _AirtimePrice = 0;
        decimal _DataBundlePrice = 0;

        #endregion


        try
        {
            string ppc = "ga:adCost";
            string _ppcCurrentDay = string.Empty;
            string _ppcCurrentMonth = string.Empty;

            DateTime date = DateTime.Now.AddDays(-1).Date;
            DateTime date2 = DateTime.Now.AddDays(-1);
            DateTime fromdate = new DateTime(date.Year, date.Month, 1);
            DateTime todate = new DateTime(date2.Year, date2.Month, date2.Day);

           // _ppcCurrentDay = VisitsNumber(todate, todate, ppc);

            //_ppcCurrentMonth = VisitsNumber(fromdate, todate, ppc);

            DateTime MisDate = DateTime.Now.AddDays(-1);

            SqlConnection conn = new SqlConnection("Database=Rebelfone;Data Source=64.91.226.230;User ID=rebelsa;Password=dYe95Efs78*");

            conn.Open();
            // SqlCommand cmd = new SqlCommand("sproc_misreport", conn);
            SqlCommand cmd = new SqlCommand("sproc_misreport_copy", conn);
            DataSet dsMis = new DataSet();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@fromdate", fromdatemis);
            cmd.Parameters.Add("@todate", todatemis);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dsMis);
            conn.Close();

            string[,] strClient = new string[25, 2];
            strClient[0, 0] = "Accessories Sold";
            strClient[1, 0] = "SIM + Cell Phone Rentals";
            strClient[2, 0] = "Follow Me Service Sold";
            strClient[4, 0] = "SIM Card Only";
            strClient[3, 0] = "Handset Sold";
            strClient[5, 0] = "Mi-Fi Device";
            strClient[6, 0] = "Prepaid";
            strClient[7, 0] = "Data Bundle";
            strClient[16, 0] = "Airtime";
            strClient[21, 0] = "Shipping Price";
             strClient[19, 0] = "Total";

            // changes done by tarun
             strClient[22, 0] = "ServiceLengthPrice";
             strClient[23, 0] = "AirtimePrice";
             strClient[24, 0] = "DataBundlePrice";

            //////////////////////
            

            strClient[0, 1] = "0";
            strClient[1, 1] = "0";
            strClient[2, 1] = "0";
            strClient[4, 1] = "0";
            strClient[3, 1] = "0";
            strClient[5, 1] = "0";
            strClient[6, 1] = "0";
            strClient[7, 1] = "0";
            strClient[17, 1] = "0";


            strClient[8, 1] = "0";
            strClient[9, 1] = "0";
            strClient[10, 1] = "0";
            strClient[11, 1] = "0";
            strClient[12, 1] = "0";
            strClient[13, 1] = "0";
            strClient[14, 1] = "0";
            strClient[15, 1] = "0";
            strClient[16, 1] = "0";
            strClient[18, 1] = "0";
            strClient[19, 1] = "0";
            strClient[20, 1] = "0";
            strClient[21, 1] = "0";

            // changes done by tarun
            strClient[22, 1] = "0";
            strClient[23, 1] = "0";
            strClient[24, 1] = "0";
            /////////////////////////

            #region DayWise

            //if (dsMis.Tables[3].Rows.Count > 0)
            //{
            //    int SimTotal = 0;
            //    int Prepaid = 0;
            //    int Datacartd = 0;
            //    int simtotalnew = 0;

            //    for (int i = 0; i <= dsMis.Tables[0].Rows.Count - 1; i++)
            //    {
            //        string str = Convert.ToString(dsMis.Tables[0].Rows[i]["Type"]);

            //        string str1 = Convert.ToString(dsMis.Tables[0].Rows[i]["quantity"]);

            //        if (str == "Accessories")
            //        {
            //            strClient[0, 1] = str1;
            //        }
            //        else if (str == "Cell rental")
            //        {
            //            strClient[1, 1] = str1;
            //        }


            //        else if (str == "Follow Me SIM")
            //        {
            //            strClient[2, 1] = str1;
            //        }
            //        else if (str == "World DataCard" || str == "World Datacard")
            //        {
            //            Datacartd += Convert.ToInt16(str1);
            //            strClient[5, 1] = Convert.ToString(Datacartd);
            //        }
            //        else if (str == "SIM")
            //        {

            //            SimTotal = Convert.ToInt32(str1) + SimTotal;

            //            strClient[4, 1] = SimTotal.ToString();
            //        }
            //        else if (str == "Handset")
            //        {
            //            strClient[3, 1] = str1;
            //        }
            //        else if (str == "Prepaid" || str == "Global SIM")
            //        {
            //            Prepaid += Convert.ToInt16(str1);
            //            strClient[6, 1] = Convert.ToString(Prepaid);
            //        }

            //        else if (str == "Databundle")
            //        {
            //            strClient[7, 1] = str1;
            //        }

            //        else if (str == "Airtime")
            //        {
            //            strClient[16, 1] = str1;
            //        }
            //        else
            //        {
            //            strClient[5, 0] = str;
            //            strClient[5, 1] = str1;
            //        }

            //    }

            //}

            #endregion
            //For Month Wise
            #region Month Wise

            if (dsMis.Tables[2].Rows.Count > 0)
            {
                int SimTotal = 0;
                int Prepaid = 0;
                int Datacartd = 0;
                int simtotalnew = 0;

                for (int i = 0; i <= dsMis.Tables[2].Rows.Count - 1; i++)
                {
                    string str = Convert.ToString(dsMis.Tables[2].Rows[i]["Type"]);

                    string str1 = Convert.ToString(dsMis.Tables[2].Rows[i]["quantity"]);

                    if (str == "Accessories")
                    {
                        strClient[8, 1] = str1;
                    }
                    else if (str == "Cell rental")
                    {
                        strClient[9, 1] = str1;
                    }


                    else if (str == "Follow Me SIM")
                    {
                        strClient[10, 1] = str1;
                    }
                    else if (str == "World DataCard" || str == "World Datacard")
                    {
                        Datacartd += Convert.ToInt16(str1);
                        strClient[11, 1] = Convert.ToString(Datacartd);
                    }
                    else if (str == "SIM")
                    {

                        SimTotal = Convert.ToInt32(str1) + SimTotal;

                        strClient[12, 1] = SimTotal.ToString();
                    }
                    else if (str == "Handset")
                    {
                        strClient[13, 1] = str1;
                    }
                    else if (str == "Prepaid" || str == "Global SIM")
                    {
                        Prepaid += Convert.ToInt16(str1);
                        strClient[14, 1] = Convert.ToString(Prepaid);
                    }

                    else if (str == "Databundle")
                    {
                        strClient[15, 1] = str1;
                    }

                    else if (str == "Airtime")
                    {
                        strClient[18, 1] = str1;
                    }
                    else
                    {
                        strClient[5, 0] = str;
                        strClient[5, 1] = str1;
                    }
                }

            }

            string msg = string.Empty;

            //int m = Convert.ToInt32(strClient[4, 1]);
            //int n = Convert.ToInt32(strClient[1, 1]);
            //int l = Convert.ToInt32(strClient[5, 1]);
            //int k = Convert.ToInt32(strClient[6, 1]);

            //int p = Convert.ToInt32(strClient[9, 1]);
            //int q = Convert.ToInt32(strClient[11, 1]);
            //int r = Convert.ToInt32(strClient[12, 1]);
            //int s = Convert.ToInt32(strClient[14, 1]);

            #endregion


            msg += "<table style='font-family:Verdana' valign=top align=center width=100% border=1 cellpadding=0 cellspacing=0>";
            msg += "";
            msg += "<tr style=background-color:#B4B4B4;color:white;font-size:12>";
            msg += "<td rowspan='2' align=center background-color=#B4B4B4><b>Date</b></td>";
            msg += "<td colspan='4' align=center><b>Services Sold</b></td>";
            msg += "<td colspan='10' align=center><b>Other Items</b></td>";
            msg += "<td rowspan='2' align=center background-color=#B4B4B4><b>PPC Spent($)</b></td>";
            msg += "</tr>";
            msg += "<tr style=background-color:#B4B4B4;color:white;font-size:12>";

            //msg += "<td align=center></td>";
            //msg += "<td align=center></td>";

            msg += "<td align=center><b>" + strClient[4, 0] + "</b></td>";
            msg += "<td align=center><b>" + strClient[1, 0] + "</b></td>";
            //
            msg += "<td align=center><b>" + strClient[5, 0] + "</b></td>";
            msg += "<td align=center><b>" + strClient[6, 0] + "</b></td>";


            msg += "<td align=center><b>" + strClient[3, 0] + "</b></td>";
            msg += "<td align=center><b>" + strClient[0, 0] + "</b></td>";
            msg += "<td align=center><b>" + strClient[2, 0] + "</b></td>";
            msg += "<td align=center><b>" + strClient[7, 0] + "</b></td>";
            msg += "<td align=center><b>" + strClient[16, 0] + "</b></td>";
            msg += "<td align=center><b>" + strClient[21, 0] + "</b></td>";
            msg += "<td align=center><b>" + strClient[19, 0] + "</b></td>";

            // changes done by tarun
            msg += "<td align=center><b>" + strClient[22, 0] + "</b></td>";
            msg += "<td align=center><b>" + strClient[23, 0] + "</b></td>";
            msg += "<td align=center><b>" + strClient[24, 0] + "</b></td>";
            ///////////////////////////
            

            msg += "</tr>";

            #region Commmentcode
            //foreach (DataRow item in dsMis.Tables[0].Rows)
            //{

            //    msg += "<tr style=font-size:10>";
            //    DateTime dtfrom = Convert.ToDateTime(item["fromdate"]);
            //    msg += "<td align=center><b>" + dtfrom.Day + "-" + dtfrom.ToString("MMM") + "</b></td>";
            //    if (item["Type"].ToString() == "SIM")
            //    {
            //        msg += "<td align=center><b>" + item["quantity"].ToString() + "</b></td>";
            //    }
            //    else
            //    {
            //        msg += "<td align=center><b>0</b></td>";
            //    }
            //    if (item["Type"].ToString() == "Cell rental")
            //    {
            //        msg += "<td align=center><b>" + item["quantity"].ToString() + "</b></td>";
            //    }
            //    else
            //    {
            //        msg += "<td align=center><b>0</b></td>";
            //    }
            //    if (item["Type"].ToString() == "World DataCard" || item["Type"].ToString() == "World Datacard")
            //    {
            //        msg += "<td align=center><b>" + item["quantity"].ToString() + "</b></td>";
            //    }
            //    else
            //    {
            //        msg += "<td align=center><b>0</b></td>";
            //    }
            //    if (item["Type"].ToString() == "Prepaid" || item["Type"].ToString() == "Global SIM")
            //    {
            //        msg += "<td align=center><b>" + item["quantity"].ToString() + "</b></td>";
            //    }
            //    else
            //    {
            //        msg += "<td align=center><b>0</b></td>";
            //    }
            //    if (item["Type"].ToString() == "Handset")
            //    {
            //        msg += "<td align=center><b>" + item["quantity"].ToString() + "</b></td>";
            //    }
            //    else
            //    {
            //        msg += "<td align=center><b>0</b></td>";
            //    }
            //    if (item["Type"].ToString() == "Accessories")
            //    {
            //        msg += "<td align=center><b>" + item["quantity"].ToString() + "</b></td>";
            //    }
            //    else
            //    {
            //        msg += "<td align=center><b>0</b></td>";
            //    }
            //    if (item["Type"].ToString() == "Follow Me SIM")
            //    {
            //        msg += "<td align=center><b>" + item["quantity"].ToString() + "</b></td>";
            //    }
            //    else
            //    {
            //        msg += "<td align=center><b>0</b></td>";
            //    }
            //    if (item["Type"].ToString() == "Databundle")
            //    {
            //        msg += "<td align=center><b>" + item["quantity"].ToString() + "</b></td>";
            //    }
            //    else
            //    {
            //        msg += "<td align=center><b>0</b></td>";
            //    }
            //    if (item["Type"].ToString() == "Airtime")
            //    {
            //        msg += "<td align=center><b>" + item["quantity"].ToString() + "</b></td>";
            //    }
            //    else
            //    {
            //        msg += "<td align=center><b>0</b></td>";
            //    }
            //    msg += "<td align=center>" + VisitsNumber(dtfrom, dtfrom, ppc) +"</td>";  
            //    msg += "</tr>";
            //}

            #endregion
            string newdate = string.Empty;
            string olddate = string.Empty;
            DateTime startdate;
            DateTime dtfrom =DateTime.Now;
           
            if (dsMis.Tables[0].Rows.Count > 0)
            {
                startdate = Convert.ToDateTime(dsMis.Tables[0].Rows[0]["fromdate"]);
                foreach (DataRow item in dsMis.Tables[0].Rows)
                {
                    strClient[0, 1] = "0";
                    strClient[1, 1] = "0";
                    strClient[2, 1] = "0";
                    strClient[4, 1] = "0";
                    strClient[3, 1] = "0";
                    strClient[5, 1] = "0";
                    strClient[6, 1] = "0";
                    strClient[7, 1] = "0";
                    strClient[16, 1] = "0";
                    strClient[19, 1] = "0";
                    strClient[21, 1] = "0";

                    // changes done by tarun
                    strClient[22, 1] = "0";
                    strClient[23, 1] = "0";
                    strClient[24, 1] = "0";
                    /////////////////////

                    msg += "<tr style=font-size:10>";
                    dtfrom = Convert.ToDateTime(item["fromdate"]);
                    string fromdatenew = item["fromdate"].ToString();
                    // DataRow[] dr_new = dsMis.Tables[0].Select(dsMis.Tables[0].Locale, "whn = '{0:o}'" + fromdatenew);
                    DataRow[] dr_new = dsMis.Tables[0].Select(String.Format(dsMis.Tables[0].Locale, "fromdate = '{0:o}'", fromdatenew));
                    newdate = item["fromdate"].ToString();
                    if (newdate != olddate)
                    {
                        if (dr_new.Length > 0)
                        {

                            for (int j = 0; j < dr_new.Length; j++)
                            {
                                if (dr_new[j]["Type"].ToString() == "SIM")
                                {
                                    //msg += "<td align=center><b>" + item["quantity"].ToString() + "</b></td>";
                                    strClient[4, 1] = dr_new[j]["quantity"].ToString();
                                    _sim += Convert.ToInt32(dr_new[j]["quantity"]);

                                    //strClient[22, 1] = dr_new[j]["ServiceLengthPrice"].ToString();
                                    //_ServiceLengthPrice += Convert.ToInt32(dr_new[j]["ServiceLengthPrice"]);

                                    //strClient[24, 1] = dr_new[j]["DataBundlePrice"].ToString();
                                    //_DataBundlePrice += Convert.ToInt32(dr_new[j]["DataBundlePrice"]);

                                    //strClient[23, 1] = dr_new[j]["AirtimePrice"].ToString();
                                    //_AirtimePrice += Convert.ToInt32(dr_new[j]["AirtimePrice"]);
                                }

                                else if (dr_new[j]["Type"].ToString() == "Cell rental")
                                {
                                    //msg += "<td align=center><b>" + item["quantity"].ToString() + "</b></td>";
                                    strClient[1, 1] = dr_new[j]["quantity"].ToString();
                                    _simrental += Convert.ToInt32(dr_new[j]["quantity"]);

                                    //strClient[22, 1] = dr_new[j]["ServiceLengthPrice"].ToString();
                                    //_ServiceLengthPrice += Convert.ToInt32(dr_new[j]["ServiceLengthPrice"]);

                                    //strClient[24, 1] = dr_new[j]["DataBundlePrice"].ToString();
                                    //_DataBundlePrice += Convert.ToInt32(dr_new[j]["DataBundlePrice"]);

                                    //strClient[23, 1] = dr_new[j]["AirtimePrice"].ToString();
                                    //_AirtimePrice += Convert.ToInt32(dr_new[j]["AirtimePrice"]);
                                }

                                else if (dr_new[j]["Type"].ToString() == "World DataCard" || dr_new[j]["Type"].ToString() == "World Datacard")
                                {
                                    // msg += "<td align=center><b>" + item["quantity"].ToString() + "</b></td>";
                                    strClient[5, 1] = dr_new[j]["quantity"].ToString();
                                    _mifi += Convert.ToInt32(dr_new[j]["quantity"]);

                                    //strClient[22, 1] = dr_new[j]["ServiceLengthPrice"].ToString();
                                    //_ServiceLengthPrice += Convert.ToInt32(dr_new[j]["ServiceLengthPrice"]);

                                    //strClient[24, 1] = dr_new[j]["DataBundlePrice"].ToString();
                                    //_DataBundlePrice += Convert.ToInt32(dr_new[j]["DataBundlePrice"]);

                                    //strClient[23, 1] = dr_new[j]["AirtimePrice"].ToString();
                                    //_AirtimePrice += Convert.ToInt32(dr_new[j]["AirtimePrice"]);
                                }

                                else if (dr_new[j]["Type"].ToString() == "Prepaid" || dr_new[j]["Type"].ToString() == "Global SIM")
                                {
                                    //msg += "<td align=center><b>" + item["quantity"].ToString() + "</b></td>";
                                    strClient[6, 1] = dr_new[j]["quantity"].ToString();
                                    _prapid += Convert.ToInt32(dr_new[j]["quantity"]);

                                    //strClient[22, 1] = dr_new[j]["ServiceLengthPrice"].ToString();
                                    //_ServiceLengthPrice += Convert.ToInt32(dr_new[j]["ServiceLengthPrice"]);

                                    //strClient[24, 1] = dr_new[j]["DataBundlePrice"].ToString();
                                    //_DataBundlePrice += Convert.ToInt32(dr_new[j]["DataBundlePrice"]);

                                    //strClient[23, 1] = dr_new[j]["AirtimePrice"].ToString();
                                    //_AirtimePrice += Convert.ToInt32(dr_new[j]["AirtimePrice"]);
                                }

                                else if (dr_new[j]["Type"].ToString() == "Handset")
                                {
                                    //msg += "<td align=center><b>" + item["quantity"].ToString() + "</b></td>";

                                    strClient[3, 1] = dr_new[j]["quantity"].ToString();
                                    _handset += Convert.ToInt32(dr_new[j]["quantity"]);

                                    //strClient[22, 1] = dr_new[j]["ServiceLengthPrice"].ToString();
                                    //_ServiceLengthPrice += Convert.ToInt32(dr_new[j]["ServiceLengthPrice"]);

                                    //strClient[24, 1] = dr_new[j]["DataBundlePrice"].ToString();
                                    //_DataBundlePrice += Convert.ToInt32(dr_new[j]["DataBundlePrice"]);

                                    //strClient[23, 1] = dr_new[j]["AirtimePrice"].ToString();
                                    //_AirtimePrice += Convert.ToInt32(dr_new[j]["AirtimePrice"]);
                                }

                                else if (dr_new[j]["Type"].ToString() == "Accessories")
                                {
                                    //msg += "<td align=center><b>" + item["quantity"].ToString() + "</b></td>";
                                    strClient[0, 1] = dr_new[j]["quantity"].ToString();
                                    _accessory += Convert.ToInt32(dr_new[j]["quantity"]);

                                    //strClient[22, 1] = dr_new[j]["ServiceLengthPrice"].ToString();
                                    //_ServiceLengthPrice += Convert.ToInt32(dr_new[j]["ServiceLengthPrice"]);

                                    //strClient[24, 1] = dr_new[j]["DataBundlePrice"].ToString();
                                    //_DataBundlePrice += Convert.ToInt32(dr_new[j]["DataBundlePrice"]);

                                    //strClient[23, 1] = dr_new[j]["AirtimePrice"].ToString();
                                    //_AirtimePrice += Convert.ToInt32(dr_new[j]["AirtimePrice"]);
                                }

                                else if (dr_new[j]["Type"].ToString() == "Follow Me SIM")
                                {
                                    //msg += "<td align=center><b>" + item["quantity"].ToString() + "</b></td>";
                                    strClient[2, 1] = dr_new[j]["quantity"].ToString();
                                    _followme += Convert.ToInt32(dr_new[j]["quantity"]);

                                    //strClient[22, 1] = dr_new[j]["ServiceLengthPrice"].ToString();
                                    //_ServiceLengthPrice += Convert.ToInt32(dr_new[j]["ServiceLengthPrice"]);

                                    //strClient[24, 1] = dr_new[j]["DataBundlePrice"].ToString();
                                    //_DataBundlePrice += Convert.ToInt32(dr_new[j]["DataBundlePrice"]);

                                    //strClient[23, 1] = dr_new[j]["AirtimePrice"].ToString();
                                    //_AirtimePrice += Convert.ToInt32(dr_new[j]["AirtimePrice"]);
                                }

                                else if (dr_new[j]["Type"].ToString() == "Databundle")
                                {
                                    //msg += "<td align=center><b>" + item["quantity"].ToString() + "</b></td>";
                                    strClient[7, 1] = dr_new[j]["quantity"].ToString();
                                    _databundle += Convert.ToInt32(dr_new[j]["quantity"]);

                                    //msg += "<td align=center><b>" + item["ServiceLengthPrice"].ToString() + "</b></td>";
                                    //strClient[22, 1] = dr_new[j]["ServiceLengthPrice"].ToString();
                                    //_ServiceLengthPrice += Convert.ToInt32(dr_new[j]["ServiceLengthPrice"]);

                                    strClient[24, 1] = dr_new[j]["DataBundlePrice"].ToString();
                                    _DataBundlePrice += Convert.ToInt32(dr_new[j]["DataBundlePrice"]);

                                    //strClient[23, 1] = dr_new[j]["AirtimePrice"].ToString();
                                    //_AirtimePrice += Convert.ToInt32(dr_new[j]["AirtimePrice"]);

                                }

                                else if (dr_new[j]["Type"].ToString() == "Airtime")
                                {
                                    //msg += "<td align=center><b>" + item["quantity"].ToString() + "</b></td>";
                                    strClient[16, 1] = dr_new[j]["quantity"].ToString();
                                    _airtime += Convert.ToInt32(dr_new[j]["quantity"]);

                                    //strClient[23, 1] = dr_new[j]["AirtimePrice"].ToString();
                                    //_AirtimePrice += Convert.ToInt32(dr_new[j]["AirtimePrice"]);
                                }

                                //  changes done by tarun

                                //else if (dr_new[j]["Type"].ToString() == "ServiceLengthPrice")
                                //{
                                //    msg += "<td align=center><b>" + item["ServiceLengthPrice"].ToString() + "</b></td>";
                                //    strClient[22, 1] = dr_new[j]["ServiceLengthPrice"].ToString();
                                //    _ServiceLengthPrice += Convert.ToInt32(dr_new[j]["ServiceLengthPrice"]);
                                //}
                                //else if (dr_new[j]["Type"].ToString() == "AirtimePrice")
                                //{
                                //    msg += "<td align=center><b>" + item["AirtimePrice"].ToString() + "</b></td>";
                                //    strClient[23, 1] = dr_new[j]["AirtimePrice"].ToString();
                                //    _AirtimePrice += Convert.ToInt32(dr_new[j]["AirtimePrice"]);
                                //}
                                //else if (dr_new[j]["Type"].ToString() == "DataBundlePrice")
                                //{
                                //    msg += "<td align=center><b>" + item["DataBundlePrice"].ToString() + "</b></td>";
                                //    strClient[24, 1] = dr_new[j]["DataBundlePrice"].ToString();
                                //    _DataBundlePrice += Convert.ToInt32(dr_new[j]["DataBundlePrice"]);
                                //}

                                ////////////////////////////

                               
                                


                                strClient[19, 1] = dr_new[j]["UnitPrice"].ToString();
                                strClient[21, 1] = dr_new[j]["ShippingPrice"].ToString();

                                strClient[22, 1] = dr_new[j]["ServiceLengthPrice"].ToString();
                                strClient[23, 1] = dr_new[j]["AirtimePrice"].ToString();
                                strClient[24, 1] = dr_new[j]["DataBundlePrice"].ToString();


                                _amount += Convert.ToDecimal(dr_new[j]["UnitPrice"]);
                                _shippingprice += Convert.ToDecimal(dr_new[j]["ShippingPrice"]);


                                // changes done by tarun
                                _ServiceLengthPrice += Convert.ToDecimal(dr_new[j]["ServiceLengthPrice"]);
                                _AirtimePrice += Convert.ToDecimal(dr_new[j]["AirtimePrice"]);
                                //_DataBundlePrice += Convert.ToDecimal(dr_new[j]["DataBundlePrice"]);

                                ///////////////////////

                                // changes done by tarun
                                //strClient[22, 1] = dr_new[j]["ServiceLengthPrice"].ToString();
                                //strClient[23, 1] = dr_new[j]["AirtimePrice"].ToString();
                                //strClient[24, 1] = dr_new[j]["DataBundlePrice"].ToString();
                                ////////////////////////////
                            }
                        }

                        msg += "<td align=center style=background-color:#B4B4B4;color:white;><b>" + dtfrom.Day + "-" + dtfrom.ToString("MMM") + "</b></td>";

                        msg += "<td align=center>" + strClient[4, 1] + "</td>";

                        msg += "<td align=center>" + strClient[1, 1] + "</td>";
                        // msg += "<td align=center>" + (m + n) + "</td>";
                        msg += "<td align=center>" + strClient[5, 1] + "</td>";
                        msg += "<td align=center>" + strClient[6, 1] + "</td>";
                        msg += "<td align=center>" + strClient[3, 1] + "</td>";
                        msg += "<td align=center>" + strClient[0, 1] + "</td>";
                        msg += "<td align=center>" + strClient[2, 1] + "</td>";
                        msg += "<td align=center>" + strClient[7, 1] + "</td>";
                        msg += "<td align=center>" + strClient[16, 1] + "</td>";
                        msg += "<td align=center>" + strClient[21, 1] + "</td>";

                        

                        msg += "<td align=right>" + String.Format("{0:0.00}", strClient[19, 1]) + "</td>";

                        //Changes done by tarun
                        msg += "<td align=center>" + strClient[22, 1] + "</td>";
                        msg += "<td align=center>" + strClient[23, 1] + "</td>";
                        msg += "<td align=center>" + strClient[24, 1] + "</td>";
                        //////////////////////

                        string perdayppc = VisitsNumber(dtfrom, dtfrom, ppc);
                        _ppccost += Convert.ToDecimal(perdayppc);
                        msg += "<td align=right>" + perdayppc + "</td>";
                        msg += "</tr>";
                        olddate = item["fromdate"].ToString();
                    }
                }
            }



            msg += "<tr style=font-size:10 >";
            msg += "<td align=center style=background-color:#B4B4B4;color:white;><b>MTD</b></td>";

            msg += "<td align=center style=background-color:#B4B4B4;color:white;>" + _sim + "</td>";
            msg += "<td align=center style=background-color:#B4B4B4;color:white;>" + _simrental + "</td>";
            //msg += "<td align=center>" + (p + r) + "</td>";
            msg += "<td align=center style=background-color:#B4B4B4;color:white;>" + _mifi + "</td>";
            msg += "<td align=center style=background-color:#B4B4B4;color:white;>" + _prapid + "</td>";

            msg += "<td align=center style=background-color:#B4B4B4;color:white;>" + _handset + "</td>";
            msg += "<td align=center style=background-color:#B4B4B4;color:white;>" + _accessory + "</td>";
            msg += "<td align=center style=background-color:#B4B4B4;color:white;>" + _followme + "</td>";
            msg += "<td align=center style=background-color:#B4B4B4;color:white;>" + _databundle + "</td>";
            msg += "<td align=center style=background-color:#B4B4B4;color:white;>" + _airtime + "</td>";
            msg += "<td align=center style=background-color:#B4B4B4;color:white;>" + String.Format("{0:0.00}", _shippingprice) + "</td>";
            msg += "<td align=right style=background-color:#B4B4B4;color:white;>" + String.Format("{0:0.00}", _amount) + "</td>";

            //Changes done by tarun
            msg += "<td align=right style=background-color:#B4B4B4;color:white;>" + String.Format("{0:0.00}", _ServiceLengthPrice) + "</td>";
            msg += "<td align=right style=background-color:#B4B4B4;color:white;>" + String.Format("{0:0.00}", _AirtimePrice) + "</td>";
            msg += "<td align=right style=background-color:#B4B4B4;color:white;>" + String.Format("{0:0.00}", _DataBundlePrice) + "</td>";
            ///////////////////////


            msg += "<td align=right style=background-color:#B4B4B4;color:white;>" + _ppccost + "</td>";
            msg += "</tr>";

            //msg += "<tr style=font-size:10 >";
            //msg += "<td align=center style=background-color:gray;color:white;><b>MTD</b></td>";

            //msg += "<td align=center style=background-color:gray;color:white;>" + strClient[12, 1] + "</td>";
            //msg += "<td align=center style=background-color:gray;color:white;>" + strClient[9, 1] + "</td>";
            ////msg += "<td align=center>" + (p + r) + "</td>";
            //msg += "<td align=center style=background-color:gray;color:white;>" + strClient[11, 1] + "</td>";
            //msg += "<td align=center style=background-color:gray;color:white;>" + strClient[14, 1] + "</td>";

            //msg += "<td align=center style=background-color:gray;color:white;>" + strClient[13, 1] + "</td>";
            //msg += "<td align=center style=background-color:gray;color:white;>" + strClient[8, 1] + "</td>";
            //msg += "<td align=center style=background-color:gray;color:white;>" + strClient[10, 1] + "</td>";
            //msg += "<td align=center style=background-color:gray;color:white;>" + strClient[15, 1] + "</td>";
            //msg += "<td align=center style=background-color:gray;color:white;>" + strClient[18, 1] + "</td>";
            //msg += "<td align=center style=background-color:gray;color:white;>" + String.Format("{0:0.00}", dsMis.Tables[4].Rows[0]["TotalMonthMAmount"]) + "</td>";
            //msg += "<td align=center style=background-color:gray;color:white;>" + VisitsNumber(startdate, dtfrom, ppc) + "</td>";
            //msg += "</tr>";

            msg += "</table>";

            msg += "<Br/><Br/>";

            //msg += "<div style='clear:both;height:40px; float:left; margin-top:40px;'><div/>";
            //msg += "<table style='font-family:Verdana' valign=top align=left width=70% border=1 cellpadding=0 cellspacing=0>";
            //msg += "";

            //if (dsMis.Tables[2].Rows.Count > 0)
            //{

            //    msg += "<tr style=background-color:Gray;color:#fff;font-size:12>";


            //    msg += "<td align=center colspan='4'><b> Description</b></td>";


            //    msg += "</tr>";


            //    msg += "<tr style=background-color:Gray;color:#fff;font-size:10>";


            //    msg += "<td align=center><b> OrderId</b></td> <td align=center><b> Item Name</b></td>";
            //    msg += "<td align=center><b> Quantity</b></td> ";
            //    msg += "<td align=center><b> Amount</b></td> ";
            //    msg += "<td align=center><b> Shipped State</b></td>";


            //    msg += "</tr>";

            //    decimal orderamount = 0;

            //    for (int i = 0; i <= dsMis.Tables[2].Rows.Count - 1; i++)
            //    {

            //        msg += "<tr style=font-size:10>";

            //        msg += "<td align=center>" + Convert.ToString(dsMis.Tables[2].Rows[i]["orderid"]) + "</td>";
            //        msg += "<td align=left> " + Convert.ToString(dsMis.Tables[2].Rows[i]["Categoryname"]) + " </td>";
            //        msg += "<td align=center>" + Convert.ToString(dsMis.Tables[2].Rows[i]["Quantity"]) + "</td>";
            //        msg += "<td align=center>" + Convert.ToString(dsMis.Tables[2].Rows[i]["Unitprice"]) + "</td>";
            //        msg += "<td align=center>" + Convert.ToString(dsMis.Tables[2].Rows[i]["shippingstate"]) + "</td>";
            //        orderamount += Convert.ToDecimal(dsMis.Tables[2].Rows[i]["Unitprice"]);

            //        msg += "</tr>";

            //    }
            //    msg += "<tr style=font-size:10>";

            //    msg += "<td align=center> </td>";
            //    msg += "<td align=left> Total </td>";
            //    msg += "<td align=center></td>";
            //    msg += "<td align=center>" + orderamount + "</td>";
            //    msg += "<td align=center></td>";


            //    msg += "</tr>";
            //}

            //msg += "</table>";
            //msg += "</br></br>";




            //msg += _mailstr;
            msg += "</table>";

            return msg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnksearch_Click(object sender, EventArgs e)
    {
      //lblmis.Text= FatchMISInformationcopy(Convert.ToDateTime(txtfromdate.Text), Convert.ToDateTime(txttodate.Text));
        lblmis.Text = FatchMISInformationShishpal(Convert.ToDateTime(txtfromdate.Text), Convert.ToDateTime(txttodate.Text));
    }

    private string FatchMISInformationShishpal(DateTime fromdate, DateTime todate)
    {
        DataTable dt = new DataTable();
        DataTable dtBilling = new DataTable();
        try
        {
            SqlConnection conn = new SqlConnection("Database=Rebelfone;Data Source=64.91.226.230;User ID=rebelsa;Password=dYe95Efs78*");
            SqlCommand cmd = new SqlCommand("sproc_misreport_v1", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fromdate", fromdate.Date));
            cmd.Parameters.Add(new SqlParameter("@todate", todate.Date));
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            dtBilling = RebelDataAccess.GetRebelBilling(Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd"), Convert.ToDateTime(todate).ToString("yyyy-MM-dd"));
        }
        catch (Exception ex)
        {
            ex = null;
        }


        StringBuilder sb = new StringBuilder();

        sb.AppendLine("<table style='font-family:Verdana' valign=top align=center width=100% border=1 cellpadding=0 cellspacing=0>");

        //First Header Row
        sb.AppendLine("<tr style=background-color:#B4B4B4;color:white;font-size:12>");
        sb.AppendLine("<td rowspan='2' align=center background-color=#B4B4B4 style='width:80px'><b>Date</b></td>");
        sb.AppendLine("<td colspan='4' align=center><b>Services Sold</b></td>");
        sb.AppendLine("<td colspan='9' align=center><b>Other Items</b></td>");
        sb.AppendLine("<td rowspan='2' align=center background-color=#B4B4B4><b>PPC Spent($)</b></td>");
        sb.AppendLine("</tr>");

        //Second Header Row
        sb.AppendLine("<tr style=background-color:#B4B4B4;color:white;font-size:12>");
        sb.AppendLine("<td align=center><b>SIM Card Only</b></td>");
        sb.AppendLine("<td align=center><b>SIM + Cell Phone Rentals</b></td>");
        sb.AppendLine("<td align=center><b>Mi-Fi Device</b></td>");
        sb.AppendLine("<td align=center><b>Prepaid</b></td>");
        sb.AppendLine("<td align=center><b>Handset Sold</b></td>");
        sb.AppendLine("<td align=center><b>Accessories Sold</b></td>");
        sb.AppendLine("<td align=center><b>Follow Me Service Sold</b></td>");


        sb.AppendLine("<td align=center><b>Shipping Price</b></td>");
        sb.AppendLine("<td align=center><b>ServiceLength Price</b></td>");
        sb.AppendLine("<td align=center><b>AirtimePrice</b></td>");
        sb.AppendLine("<td align=center><b>DataBundle Price</b></td>");
        sb.AppendLine("<td align=center><b>Total Sale Amount</b></td>");
        sb.AppendLine("<td align=center><b>Total Billing Amount</b></td>");

        sb.AppendLine("</tr>");


        //Date wise data
        string perdayppc = string.Empty;
        double totalPPC = 0;
        double Billing = 0;
        double totalBilling = 0;
        foreach (DataRow dr in dt.Rows)
        {
            sb.AppendLine("<tr style=font-size:10>");
            sb.AppendLine("<td align=center style=background-color:#B4B4B4;color:white;><b>" + Convert.ToDateTime(dr["SDate"]).ToString("dd-MMM-ddd") + "</b></td>");
            sb.AppendLine("<td align=center>" + dr["SIMCard"].ToString() + "</td>");
            sb.AppendLine("<td align=right>" + Convert.ToDouble(dr["SIMCELLPhone"]).ToString("0.00") + "</td>");
            sb.AppendLine("<td align=right>" + Convert.ToDouble(dr["MIFI"]).ToString("0.00") + "</td>");
            sb.AppendLine("<td align=right>" + Convert.ToDouble(dr["Prepaid"]).ToString("0.00") + "</td>");
            sb.AppendLine("<td align=right>" + Convert.ToDouble(dr["Handset"]).ToString("0.00") + "</td>");
            sb.AppendLine("<td align=right>" + Convert.ToDouble(dr["Accessories"]).ToString("0.00") + "</td>");
            sb.AppendLine("<td align=right>" + Convert.ToDouble(dr["FollowMe"]).ToString("0.00") + "</td>");

            sb.AppendLine("<td align=right>" + Convert.ToDouble(dr["ShippingPrice"]).ToString("0.00") + "</td>");
            sb.AppendLine("<td align=right>" + Convert.ToDouble(dr["ServiceLengthPrice"]).ToString("0.00") + "</td>");
            sb.AppendLine("<td align=right>" + Convert.ToDouble(dr["AirtimePrice"]).ToString("0.00") + "</td>");
            sb.AppendLine("<td align=right>" + Convert.ToDouble(dr["DataBundlePrice"]).ToString("0.00") + "</td>");
            sb.AppendLine("<td align=right>" + Convert.ToDouble(dr["Total"]).ToString("0.00") + "</td>");

            Billing = GetBillingAmount(Convert.ToDateTime(dr["SDate"]), dtBilling);
            totalBilling += Billing;

            sb.AppendLine("<td align=right>" + Billing.ToString("0.00") + "</td>");
            try
            {
                perdayppc = VisitsNumber(Convert.ToDateTime(dr["SDate"]), Convert.ToDateTime(dr["SDate"]), "ga:adCost");
                totalPPC += Convert.ToDouble(perdayppc);
            }
            catch (Exception ex)
            {
                ex = null;
                perdayppc = "Error";
            }
            sb.AppendLine("<td align=right>" + perdayppc + "</td>");
            sb.AppendLine("</tr>");
        }

        //Footer Total

        sb.AppendLine("<tr style=font-size:10>");
        sb.AppendLine("<td align=center style=background-color:#B4B4B4;color:white;><b>MTD</b></td>");
        sb.AppendLine("<td align=center style=background-color:#B4B4B4;color:white;><b>" + FooterTotal(dt, "SIMCard") + "</b></td>");
        sb.AppendLine("<td align=right style=background-color:#B4B4B4;color:white;><b>" + FooterTotal(dt, "SIMCELLPhone", isMoney: true) + "</b></td>");
        sb.AppendLine("<td align=right style=background-color:#B4B4B4;color:white;><b>" + FooterTotal(dt, "MIFI", isMoney: true) + "</b></td>");
        sb.AppendLine("<td align=right style=background-color:#B4B4B4;color:white;><b>" + FooterTotal(dt, "Prepaid", isMoney: true) + "</b></td>");
        sb.AppendLine("<td align=right style=background-color:#B4B4B4;color:white;><b>" + FooterTotal(dt, "Handset", isMoney: true) + "</b></td>");
        sb.AppendLine("<td align=right style=background-color:#B4B4B4;color:white;><b>" + FooterTotal(dt, "Accessories", isMoney: true) + "</b></td>");
        sb.AppendLine("<td align=right style=background-color:#B4B4B4;color:white;><b>" + FooterTotal(dt, "FollowMe", isMoney: true) + "</b></td>");

        sb.AppendLine("<td align=right style=background-color:#B4B4B4;color:white;><b>" + FooterTotal(dt, "ShippingPrice", isMoney: true) + "</b></td>");
        sb.AppendLine("<td align=right style=background-color:#B4B4B4;color:white;><b>" + FooterTotal(dt, "ServiceLengthPrice", isMoney: true) + "</b></td>");
        sb.AppendLine("<td align=right style=background-color:#B4B4B4;color:white;><b>" + FooterTotal(dt, "AirtimePrice", isMoney: true) + "</b></td>");
        sb.AppendLine("<td align=right style=background-color:#B4B4B4;color:white;><b>" + FooterTotal(dt, "DataBundlePrice", isMoney: true) + "</b></td>");
        sb.AppendLine("<td align=right style=background-color:#B4B4B4;color:white;><b>" + FooterTotal(dt, "Total", isMoney: true) + "</b></td>");
        sb.AppendLine("<td align=right style=background-color:#B4B4B4;color:white;><b>" + totalBilling.ToString("0.00") + "</b></td>");
        sb.AppendLine("<td align=right style=background-color:#B4B4B4;color:white;><b>" + totalPPC.ToString("0.00") + "</b></td>");
        sb.AppendLine("</tr>");

        sb.AppendLine("</table>");

        sb.AppendLine("<Br/><Br/>");

        return sb.ToString();
    }

    private double GetBillingAmount(DateTime dateTime, DataTable dtBilling)
    {
        if (dtBilling != null && dtBilling.Rows.Count > 0)
        {
            foreach (DataRow dr in dtBilling.Rows)
            {
                if (Convert.ToDateTime(dr["invoicedate"]).Date == dateTime.Date)
                {
                    return Convert.ToDouble(dr["TotalAmount"]);
                }
            }
        }

        return 0;
    }

    private string FooterTotal(DataTable dt, string columnName, bool isMoney = false)
    {
        double total = 0;

        foreach (DataRow dr in dt.Rows)
        {
            total += Convert.ToDouble(dr[columnName]);
        }

        return isMoney ? total.ToString("0.00") : ((int)total).ToString();
    }
}