using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

public partial class MISReport_rptYearWiseSaleBilling : System.Web.UI.Page
{
    Clay.Invoice.Bll.Report objSaleBillingReport = new Clay.Invoice.Bll.Report();

    #region Vairable Define

    int AprSale = 0;
    int MaySale = 0;
    int JunSale = 0;
    int JulSale = 0;
    int AugSale = 0;
    int SepSale = 0;
    int OctSale = 0;
    int NovSale = 0;
    int DecSale = 0;
    int JanSale = 0;
    int FebSale = 0;
    int MarSale = 0;

    int TotalSale = 0;


    Int64 AprBill = 0;
    Int64 MayBill = 0;
    Int64 JunBill = 0;
    Int64 JulBill = 0;
    Int64 AugBill = 0;
    Int64 SepBill = 0;
    Int64 OctBill = 0;
    Int64 NovBill = 0;
    Int64 DecBill = 0;
    Int64 JanBill = 0;
    Int64 FebBill = 0;
    Int64 MarBill = 0;

    Int64 TotalBill = 0;

    int AprSaleRow = 0;
    int MaySaleRow = 0;
    int JunSaleRow = 0;
    int JulSaleRow = 0;
    int AugSaleRow = 0;
    int SepSaleRow = 0;
    int OctSaleRow = 0;
    int NovSaleRow = 0;
    int DecSaleRow = 0;
    int JanSaleRow = 0;
    int FebSaleRow = 0;
    int MarSaleRow = 0;

    int TotalSaleRow = 0;


    Int64 AprBillRow = 0;
    Int64 MayBillRow = 0;
    Int64 JunBillRow = 0;
    Int64 JulBillRow = 0;
    Int64 AugBillRow = 0;
    Int64 SepBillRow = 0;
    Int64 OctBillRow = 0;
    Int64 NovBillRow = 0;
    Int64 DecBillRow = 0;
    Int64 JanBillRow = 0;
    Int64 FebBillRow = 0;
    Int64 MarBillRow = 0;

    Int64 TotalBillRow = 0;


    int AprSaleUS = 0;
    int MaySaleUS = 0;
    int JunSaleUS = 0;
    int JulSaleUS = 0;
    int AugSaleUS = 0;
    int SepSaleUS = 0;
    int OctSaleUS = 0;
    int NovSaleUS = 0;
    int DecSaleUS = 0;
    int JanSaleUS = 0;
    int FebSaleUS = 0;
    int MarSaleUS = 0;

    int TotalSaleUS = 0;


    Int64 AprBillUS = 0;
    Int64 MayBillUS = 0;
    Int64 JunBillUS = 0;
    Int64 JulBillUS = 0;
    Int64 AugBillUS = 0;
    Int64 SepBillUS = 0;
    Int64 OctBillUS = 0;
    Int64 NovBillUS = 0;
    Int64 DecBillUS = 0;
    Int64 JanBillUS = 0;
    Int64 FebBillUS = 0;
    Int64 MarBillUS = 0;

    Int64 TotalBillUS = 0;



    int AprSaleUK = 0;
    int MaySaleUK = 0;
    int JunSaleUK = 0;
    int JulSaleUK = 0;
    int AugSaleUK = 0;
    int SepSaleUK = 0;
    int OctSaleUK = 0;
    int NovSaleUK = 0;
    int DecSaleUK = 0;
    int JanSaleUK = 0;
    int FebSaleUK = 0;
    int MarSaleUK = 0;

    int TotalSaleUK = 0;


    Int64 AprBillUK = 0;
    Int64 MayBillUK = 0;
    Int64 JunBillUK = 0;
    Int64 JulBillUK = 0;
    Int64 AugBillUK = 0;
    Int64 SepBillUK = 0;
    Int64 OctBillUK = 0;
    Int64 NovBillUK = 0;
    Int64 DecBillUK = 0;
    Int64 JanBillUK = 0;
    Int64 FebBillUK = 0;
    Int64 MarBillUK = 0;

    Int64 TotalBillUK = 0;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        checkSession();

        try
        {
            if (!IsPostBack)
            {
                loadYear();
            }


             AprSale = 0;
             MaySale = 0;
             JunSale = 0;
             JulSale = 0;
             AugSale = 0;
             SepSale = 0;
             OctSale = 0;
             NovSale = 0;
             DecSale = 0;
             JanSale = 0;
             FebSale = 0;
             MarSale = 0;

             TotalSale = 0;


             AprBill = 0;
             MayBill = 0;
             JunBill = 0;
             JulBill = 0;
             AugBill = 0;
             SepBill = 0;
             OctBill = 0;
             NovBill = 0;
             DecBill = 0;
             JanBill = 0;
             FebBill = 0;
             MarBill = 0;

             TotalBill = 0;

             AprSaleRow = 0;
             MaySaleRow = 0;
             JunSaleRow = 0;
             JulSaleRow = 0;
             AugSaleRow = 0;
             SepSaleRow = 0;
             OctSaleRow = 0;
             NovSaleRow = 0;
             DecSaleRow = 0;
             JanSaleRow = 0;
             FebSaleRow = 0;
             MarSaleRow = 0;

             TotalSaleRow = 0;


             AprBillRow = 0;
             MayBillRow = 0;
             JunBillRow = 0;
             JulBillRow = 0;
             AugBillRow = 0;
             SepBillRow = 0;
             OctBillRow = 0;
             NovBillRow = 0;
             DecBillRow = 0;
             JanBillRow = 0;
             FebBillRow = 0;
             MarBillRow = 0;

             TotalBillRow = 0;


             AprSaleUS = 0;
             MaySaleUS = 0;
             JunSaleUS = 0;
             JulSaleUS = 0;
             AugSaleUS = 0;
             SepSaleUS = 0;
             OctSaleUS = 0;
             NovSaleUS = 0;
             DecSaleUS = 0;
             JanSaleUS = 0;
             FebSaleUS = 0;
             MarSaleUS = 0;

             TotalSaleUS = 0;


             AprBillUS = 0;
             MayBillUS = 0;
             JunBillUS = 0;
             JulBillUS = 0;
             AugBillUS = 0;
             SepBillUS = 0;
             OctBillUS = 0;
             NovBillUS = 0;
             DecBillUS = 0;
             JanBillUS = 0;
             FebBillUS = 0;
             MarBillUS = 0;

             TotalBillUS = 0;



             AprSaleUK = 0;
             MaySaleUK = 0;
             JunSaleUK = 0;
             JulSaleUK = 0;
             AugSaleUK = 0;
             SepSaleUK = 0;
             OctSaleUK = 0;
             NovSaleUK = 0;
             DecSaleUK = 0;
             JanSaleUK = 0;
             FebSaleUK = 0;
             MarSaleUK = 0;

             TotalSaleUK = 0;


             AprBillUK = 0;
             MayBillUK = 0;
             JunBillUK = 0;
             JulBillUK = 0;
             AugBillUK = 0;
             SepBillUK = 0;
             OctBillUK = 0;
             NovBillUK = 0;
             DecBillUK = 0;
             JanBillUK = 0;
             FebBillUK = 0;
             MarBillUK = 0;

             TotalBillUK = 0;
        }
        catch (Exception ex)
        {
            err.Text = ex.Message.ToString();
        }
    }

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

        for (int i = 2010; i <= DateTime.Now.AddYears(1).Year; i++)
        {
            drYear = dsYear.Tables[0].NewRow();
            drYear["yearVal"] = i;
            drYear["yearTxt"] = i.ToString() + "-" + (Convert.ToInt32(i) + 1).ToString() ;
            dsYear.Tables[0].Rows.InsertAt(drYear, i + 1 - 2010);
        }

        ddlFromYear.DataSource = dsYear.Tables[0];
        ddlFromYear.DataTextField = "yearTxt";
        ddlFromYear.DataValueField = "yearVal";
        ddlFromYear.DataBind();
        ddlFromYear.SelectedIndex = 0;

        ddlCompareYear.DataSource = dsYear.Tables[0];
        ddlCompareYear.DataTextField = "yearTxt";
        ddlCompareYear.DataValueField = "yearVal";
        ddlCompareYear.DataBind();
        ddlCompareYear.SelectedIndex = 0; 
        

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
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        if (chkCompare.Checked == false)
        {
            if (ddlReportType.SelectedValue == "1")
            {
                DataSet DSBranchWise = objSaleBillingReport.SaleBillingReportBranchWise(Convert.ToInt32(ddlFromYear.SelectedValue));
                grdBranchWise.DataSource = DSBranchWise.Tables[0];
                grdBranchWise.DataBind();

                grdCountryWiseRow.DataSource = null;
                grdCountryWiseRow.DataBind();
                grdCountryWiseUsa.DataSource = null;
                grdCountryWiseUsa.DataBind();
                grdCountryWiseUk.DataSource = null;
                grdCountryWiseUk.DataBind();

                grdBranchWise.Visible = true;

                grdCountryWiseRow.Visible = false;
                grdCountryWiseUsa.Visible = false;
                grdCountryWiseUk.Visible = false;

            }
            else if (ddlReportType.SelectedValue == "2")
            {

                grdCountryWiseRow.Visible = true;
                grdCountryWiseUsa.Visible = true;
                grdCountryWiseUk.Visible = true;

                grdBranchWise.DataSource = null;
                grdBranchWise.DataBind();

                grdBranchWise.Visible = false;




                DataSet DSCountryWise = objSaleBillingReport.SaleBillingReportCountryWise(Convert.ToInt32(ddlFromYear.SelectedValue));


                Session["ds"] = DSCountryWise;
                grdCountryWiseRow.DataSource = DSCountryWise.Tables["CountryWiseRow"];
                grdCountryWiseRow.DataBind();

                grdCountryWiseUsa.DataSource = DSCountryWise.Tables["CountryWiseUsa"];
                grdCountryWiseUsa.DataBind();

                grdCountryWiseUk.DataSource = DSCountryWise.Tables["CountryWiseUk"];
                grdCountryWiseUk.DataBind();


            }
        }
        else
        {
            if (ddlReportType.SelectedValue == "1")
            {
                DataSet DSBranchWise = objSaleBillingReport.SaleBillingReportBranchWiseCompare(Convert.ToInt32(ddlFromYear.SelectedValue), Convert.ToInt32(ddlCompareYear.SelectedValue));
                grdBranchWise.DataSource = DSBranchWise.Tables[0];
                grdBranchWise.DataBind();

                grdCountryWiseRow.DataSource = null;
                grdCountryWiseRow.DataBind();
                grdCountryWiseUsa.DataSource = null;
                grdCountryWiseUsa.DataBind();
                grdCountryWiseUk.DataSource = null;
                grdCountryWiseUk.DataBind();

                grdBranchWise.Visible = true;

                grdCountryWiseRow.Visible = false;
                grdCountryWiseUsa.Visible = false;
                grdCountryWiseUk.Visible = false;

            }
            else if (ddlReportType.SelectedValue == "2")
            {
                grdCountryWiseRow.Visible = true;
                grdCountryWiseUsa.Visible = true;
                grdCountryWiseUk.Visible = true;

                grdBranchWise.DataSource = null;
                grdBranchWise.DataBind();

                grdBranchWise.Visible = false;


                DataSet DSCountryWise = objSaleBillingReport.SaleBillingReportCountryWiseComapre(Convert.ToInt32(ddlFromYear.SelectedValue), Convert.ToInt32(ddlCompareYear.SelectedValue));
                grdCountryWiseRow.DataSource = DSCountryWise.Tables["CountryWiseRow"];
                grdCountryWiseRow.DataBind();

                grdCountryWiseUsa.DataSource = DSCountryWise.Tables["CountryWiseUsa"];
                grdCountryWiseUsa.DataBind();

                grdCountryWiseUk.DataSource = DSCountryWise.Tables["CountryWiseUk"];
                grdCountryWiseUk.DataBind();
               
            }

        }
            
    }
    protected void grdBranchWise_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (chkCompare.Checked == false)
        {
           // double AprSale = Convert.ToDouble(e.Row.Cells[1].Text);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                AprSale += Convert.ToInt32(e.Row.Cells[1].Text);
                MaySale += Convert.ToInt32(e.Row.Cells[3].Text);
                JunSale += Convert.ToInt32(e.Row.Cells[5].Text);
                JulSale += Convert.ToInt32(e.Row.Cells[7].Text);
                AugSale += Convert.ToInt32(e.Row.Cells[9].Text);
                SepSale += Convert.ToInt32(e.Row.Cells[11].Text);
                OctSale += Convert.ToInt32(e.Row.Cells[13].Text);
                NovSale += Convert.ToInt32(e.Row.Cells[15].Text);
                DecSale += Convert.ToInt32(e.Row.Cells[17].Text);
                JanSale += Convert.ToInt32(e.Row.Cells[19].Text);
                FebSale += Convert.ToInt32(e.Row.Cells[21].Text);
                MarSale += Convert.ToInt32(e.Row.Cells[23].Text);
                TotalSale += Convert.ToInt32(e.Row.Cells[25].Text);


                AprBill += Convert.ToInt64(e.Row.Cells[2].Text);
                MayBill += Convert.ToInt64(e.Row.Cells[4].Text);
                JunBill += Convert.ToInt64(e.Row.Cells[6].Text);
                JulBill += Convert.ToInt64(e.Row.Cells[8].Text);
                AugBill += Convert.ToInt64(e.Row.Cells[10].Text);
                SepBill += Convert.ToInt64(e.Row.Cells[12].Text);
                OctBill += Convert.ToInt64(e.Row.Cells[14].Text);
                NovBill += Convert.ToInt64(e.Row.Cells[16].Text);
                DecBill += Convert.ToInt64(e.Row.Cells[18].Text);
                JanBill += Convert.ToInt64(e.Row.Cells[20].Text);
                FebBill += Convert.ToInt64(e.Row.Cells[22].Text);
                MarBill += Convert.ToInt64(e.Row.Cells[24].Text);
                TotalBill += Convert.ToInt64(e.Row.Cells[26].Text);

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[0].Text = "Total";


                e.Row.Cells[1].Text = AprSale.ToString() ;
                e.Row.Cells[3].Text = MaySale.ToString();
                e.Row.Cells[5].Text = JunSale.ToString();
                e.Row.Cells[7].Text = JulSale.ToString();
                e.Row.Cells[9].Text = AugSale.ToString();
                e.Row.Cells[11].Text = SepSale.ToString() ;
                e.Row.Cells[13].Text = OctSale.ToString();
                e.Row.Cells[15].Text = NovSale.ToString();
                e.Row.Cells[17].Text = DecSale.ToString();
                e.Row.Cells[19].Text = JanSale.ToString();
                e.Row.Cells[21].Text = FebSale.ToString();
                e.Row.Cells[23].Text = MarSale.ToString();

                e.Row.Cells[25].Text = TotalSale.ToString();
                


                e.Row.Cells[2].Text = AprBill.ToString() ;
                e.Row.Cells[4].Text = MayBill.ToString() ;
                e.Row.Cells[6].Text = JunBill.ToString() ;
                e.Row.Cells[8].Text = JulBill.ToString() ;
                e.Row.Cells[10].Text = AugBill.ToString() ;
                e.Row.Cells[12].Text = SepBill.ToString() ;
                e.Row.Cells[14].Text = OctBill.ToString() ;
                e.Row.Cells[16].Text = NovBill.ToString() ;
                e.Row.Cells[18].Text = DecBill.ToString() ;
                e.Row.Cells[20].Text = JanBill.ToString();
                e.Row.Cells[22].Text = FebBill.ToString() ;
                e.Row.Cells[24].Text = MarBill.ToString() ;
                e.Row.Cells[26].Text = TotalBill.ToString() + "<br/>";
            }
        }
        else
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    AprSale += Convert.ToInt32(e.Row.Cells[1].Text);
            //    MaySale += Convert.ToInt32(e.Row.Cells[3].Text);
            //    JunSale += Convert.ToInt32(e.Row.Cells[5].Text);
            //    JulSale += Convert.ToInt32(e.Row.Cells[7].Text);
            //    AugSale += Convert.ToInt32(e.Row.Cells[9].Text);
            //    SepSale += Convert.ToInt32(e.Row.Cells[11].Text);
            //    OctSale += Convert.ToInt32(e.Row.Cells[13].Text);
            //    NovSale += Convert.ToInt32(e.Row.Cells[15].Text);
            //    DecSale += Convert.ToInt32(e.Row.Cells[17].Text);
            //    JanSale += Convert.ToInt32(e.Row.Cells[19].Text);
            //    FebSale += Convert.ToInt32(e.Row.Cells[21].Text);
            //    MarSale += Convert.ToInt32(e.Row.Cells[23].Text);
            //    TotalSale += Convert.ToInt32(e.Row.Cells[25].Text);


            //    AprBill += Convert.ToInt64(e.Row.Cells[2].Text);
            //    MayBill += Convert.ToInt64(e.Row.Cells[4].Text);
            //    JunBill += Convert.ToInt64(e.Row.Cells[6].Text);
            //    JulBill += Convert.ToInt64(e.Row.Cells[8].Text);
            //    AugBill += Convert.ToInt64(e.Row.Cells[10].Text);
            //    SepBill += Convert.ToInt64(e.Row.Cells[12].Text);
            //    OctBill += Convert.ToInt64(e.Row.Cells[14].Text);
            //    NovBill += Convert.ToInt64(e.Row.Cells[16].Text);
            //    DecBill += Convert.ToInt64(e.Row.Cells[18].Text);
            //    JanBill += Convert.ToInt64(e.Row.Cells[20].Text);
            //    FebBill += Convert.ToInt64(e.Row.Cells[22].Text);
            //    MarBill += Convert.ToInt64(e.Row.Cells[24].Text);
            //    TotalBill += Convert.ToInt64(e.Row.Cells[26].Text);

            //}
            //else if (e.Row.RowType == DataControlRowType.Footer)
            //{

            //    e.Row.Cells[0].Text = "Total";


            //    e.Row.Cells[1].Text = AprSale.ToString();
            //    e.Row.Cells[3].Text = MaySale.ToString();
            //    e.Row.Cells[5].Text = JunSale.ToString();
            //    e.Row.Cells[7].Text = JulSale.ToString();
            //    e.Row.Cells[9].Text = AugSale.ToString();
            //    e.Row.Cells[11].Text = SepSale.ToString();
            //    e.Row.Cells[13].Text = OctSale.ToString();
            //    e.Row.Cells[15].Text = NovSale.ToString();
            //    e.Row.Cells[17].Text = DecSale.ToString();
            //    e.Row.Cells[19].Text = JanSale.ToString();
            //    e.Row.Cells[21].Text = FebSale.ToString();
            //    e.Row.Cells[23].Text = MarSale.ToString();

            //    e.Row.Cells[25].Text = TotalSale.ToString();



            //    e.Row.Cells[2].Text = AprBill.ToString();
            //    e.Row.Cells[4].Text = MayBill.ToString();
            //    e.Row.Cells[6].Text = JunBill.ToString();
            //    e.Row.Cells[8].Text = JulBill.ToString();
            //    e.Row.Cells[10].Text = AugBill.ToString();
            //    e.Row.Cells[12].Text = SepBill.ToString();
            //    e.Row.Cells[14].Text = OctBill.ToString();
            //    e.Row.Cells[16].Text = NovBill.ToString();
            //    e.Row.Cells[18].Text = DecBill.ToString();
            //    e.Row.Cells[20].Text = JanBill.ToString();
            //    e.Row.Cells[22].Text = FebBill.ToString();
            //    e.Row.Cells[24].Text = MarBill.ToString();
            //    e.Row.Cells[26].Text = TotalBill.ToString();
            //}
        }
    }
    protected void grdCountryWiseRow_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (chkCompare.Checked == false)
        {
            // double AprSale = Convert.ToDouble(e.Row.Cells[1].Text);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                AprSaleRow += Convert.ToInt32(e.Row.Cells[1].Text);
                MaySaleRow += Convert.ToInt32(e.Row.Cells[3].Text);
                JunSaleRow += Convert.ToInt32(e.Row.Cells[5].Text);
                JulSaleRow += Convert.ToInt32(e.Row.Cells[7].Text);
                AugSaleRow += Convert.ToInt32(e.Row.Cells[9].Text);
                SepSaleRow += Convert.ToInt32(e.Row.Cells[11].Text);
                OctSaleRow += Convert.ToInt32(e.Row.Cells[13].Text);
                NovSaleRow += Convert.ToInt32(e.Row.Cells[15].Text);
                DecSaleRow += Convert.ToInt32(e.Row.Cells[17].Text);
                JanSaleRow += Convert.ToInt32(e.Row.Cells[19].Text);
                FebSaleRow += Convert.ToInt32(e.Row.Cells[21].Text);
                MarSaleRow += Convert.ToInt32(e.Row.Cells[23].Text);
                TotalSaleRow += Convert.ToInt32(e.Row.Cells[25].Text);


                AprBillRow += Convert.ToInt64(e.Row.Cells[2].Text);
                MayBillRow += Convert.ToInt64(e.Row.Cells[4].Text);
                JunBillRow += Convert.ToInt64(e.Row.Cells[6].Text);
                JulBillRow += Convert.ToInt64(e.Row.Cells[8].Text);
                AugBillRow += Convert.ToInt64(e.Row.Cells[10].Text);
                SepBillRow += Convert.ToInt64(e.Row.Cells[12].Text);
                OctBillRow += Convert.ToInt64(e.Row.Cells[14].Text);
                NovBillRow += Convert.ToInt64(e.Row.Cells[16].Text);
                DecBillRow += Convert.ToInt64(e.Row.Cells[18].Text);
                JanBillRow += Convert.ToInt64(e.Row.Cells[20].Text);
                FebBillRow += Convert.ToInt64(e.Row.Cells[22].Text);
                MarBillRow += Convert.ToInt64(e.Row.Cells[24].Text);
                TotalBillRow += Convert.ToInt64(e.Row.Cells[26].Text);

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[0].Text = "Total";


                e.Row.Cells[1].Text = AprSaleRow.ToString();
                e.Row.Cells[3].Text = MaySaleRow.ToString();
                e.Row.Cells[5].Text = JunSaleRow.ToString();
                e.Row.Cells[7].Text = JulSaleRow.ToString();
                e.Row.Cells[9].Text = AugSaleRow.ToString();
                e.Row.Cells[11].Text = SepSaleRow.ToString();
                e.Row.Cells[13].Text = OctSaleRow.ToString();
                e.Row.Cells[15].Text = NovSaleRow.ToString();
                e.Row.Cells[17].Text = DecSaleRow.ToString();
                e.Row.Cells[19].Text = JanSaleRow.ToString();
                e.Row.Cells[21].Text = FebSaleRow.ToString();
                e.Row.Cells[23].Text = MarSaleRow.ToString();

                e.Row.Cells[25].Text = TotalSaleRow.ToString();



                e.Row.Cells[2].Text = AprBillRow.ToString();
                e.Row.Cells[4].Text = MayBillRow.ToString();
                e.Row.Cells[6].Text = JunBillRow.ToString();
                e.Row.Cells[8].Text = JulBillRow.ToString();
                e.Row.Cells[10].Text = AugBillRow.ToString();
                e.Row.Cells[12].Text = SepBillRow.ToString();
                e.Row.Cells[14].Text = OctBillRow.ToString();
                e.Row.Cells[16].Text = NovBillRow.ToString();
                e.Row.Cells[18].Text = DecBillRow.ToString();
                e.Row.Cells[20].Text = JanBillRow.ToString();
                e.Row.Cells[22].Text = FebBillRow.ToString();
                e.Row.Cells[24].Text = MarBillRow.ToString();
                e.Row.Cells[26].Text = TotalBillRow.ToString();
            }
        }
    }
    protected void grdCountryWiseUsa_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (chkCompare.Checked == false)
        {
            // double AprSale = Convert.ToDouble(e.Row.Cells[1].Text);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                AprSaleUS += Convert.ToInt32(e.Row.Cells[1].Text);
                MaySaleUS += Convert.ToInt32(e.Row.Cells[3].Text);
                JunSaleUS += Convert.ToInt32(e.Row.Cells[5].Text);
                JulSaleUS += Convert.ToInt32(e.Row.Cells[7].Text);
                AugSaleUS += Convert.ToInt32(e.Row.Cells[9].Text);
                SepSaleUS += Convert.ToInt32(e.Row.Cells[11].Text);
                OctSaleUS += Convert.ToInt32(e.Row.Cells[13].Text);
                NovSaleUS += Convert.ToInt32(e.Row.Cells[15].Text);
                DecSaleUS += Convert.ToInt32(e.Row.Cells[17].Text);
                JanSaleUS += Convert.ToInt32(e.Row.Cells[19].Text);
                FebSaleUS += Convert.ToInt32(e.Row.Cells[21].Text);
                MarSaleUS += Convert.ToInt32(e.Row.Cells[23].Text);
                TotalSaleUS += Convert.ToInt32(e.Row.Cells[25].Text);


                AprBillUS += Convert.ToInt64(e.Row.Cells[2].Text);
                MayBillUS += Convert.ToInt64(e.Row.Cells[4].Text);
                JunBillUS += Convert.ToInt64(e.Row.Cells[6].Text);
                JulBillUS += Convert.ToInt64(e.Row.Cells[8].Text);
                AugBillUS += Convert.ToInt64(e.Row.Cells[10].Text);
                SepBillUS += Convert.ToInt64(e.Row.Cells[12].Text);
                OctBillUS += Convert.ToInt64(e.Row.Cells[14].Text);
                NovBillUS += Convert.ToInt64(e.Row.Cells[16].Text);
                DecBillUS += Convert.ToInt64(e.Row.Cells[18].Text);
                JanBillUS += Convert.ToInt64(e.Row.Cells[20].Text);
                FebBillUS += Convert.ToInt64(e.Row.Cells[22].Text);
                MarBillUS += Convert.ToInt64(e.Row.Cells[24].Text);
                TotalBillUS += Convert.ToInt64(e.Row.Cells[26].Text);

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[0].Text = "Total";


                e.Row.Cells[1].Text = AprSaleUS.ToString();
                e.Row.Cells[3].Text = MaySaleUS.ToString();
                e.Row.Cells[5].Text = JunSaleUS.ToString();
                e.Row.Cells[7].Text = JulSaleUS.ToString();
                e.Row.Cells[9].Text = AugSaleUS.ToString();
                e.Row.Cells[11].Text = SepSaleUS.ToString();
                e.Row.Cells[13].Text = OctSaleUS.ToString();
                e.Row.Cells[15].Text = NovSaleUS.ToString();
                e.Row.Cells[17].Text = DecSaleUS.ToString();
                e.Row.Cells[19].Text = JanSaleUS.ToString();
                e.Row.Cells[21].Text = FebSaleUS.ToString();
                e.Row.Cells[23].Text = MarSaleUS.ToString();

                e.Row.Cells[25].Text = TotalSaleUS.ToString();



                e.Row.Cells[2].Text = AprBillUS.ToString();
                e.Row.Cells[4].Text = MayBillUS.ToString();
                e.Row.Cells[6].Text = JunBillUS.ToString();
                e.Row.Cells[8].Text = JulBillUS.ToString();
                e.Row.Cells[10].Text = AugBillUS.ToString();
                e.Row.Cells[12].Text = SepBillUS.ToString();
                e.Row.Cells[14].Text = OctBillUS.ToString();
                e.Row.Cells[16].Text = NovBillUS.ToString();
                e.Row.Cells[18].Text = DecBillUS.ToString();
                e.Row.Cells[20].Text = JanBillUS.ToString();
                e.Row.Cells[22].Text = FebBillUS.ToString();
                e.Row.Cells[24].Text = MarBillUS.ToString();
                e.Row.Cells[26].Text = TotalBillUS.ToString();
            }
        }
    }
    protected void grdCountryWiseUk_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (chkCompare.Checked == false)
        {
            // double AprSale = Convert.ToDouble(e.Row.Cells[1].Text);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                AprSaleUK += Convert.ToInt32(e.Row.Cells[1].Text);
                MaySaleUK += Convert.ToInt32(e.Row.Cells[3].Text);
                JunSaleUK += Convert.ToInt32(e.Row.Cells[5].Text);
                JulSaleUK += Convert.ToInt32(e.Row.Cells[7].Text);
                AugSaleUK += Convert.ToInt32(e.Row.Cells[9].Text);
                SepSaleUK += Convert.ToInt32(e.Row.Cells[11].Text);
                OctSaleUK += Convert.ToInt32(e.Row.Cells[13].Text);
                NovSaleUK += Convert.ToInt32(e.Row.Cells[15].Text);
                DecSaleUK += Convert.ToInt32(e.Row.Cells[17].Text);
                JanSaleUK += Convert.ToInt32(e.Row.Cells[19].Text);
                FebSaleUK += Convert.ToInt32(e.Row.Cells[21].Text);
                MarSaleUK += Convert.ToInt32(e.Row.Cells[23].Text);
                TotalSaleUK += Convert.ToInt32(e.Row.Cells[25].Text);


                AprBillUK += Convert.ToInt64(e.Row.Cells[2].Text);
                MayBillUK += Convert.ToInt64(e.Row.Cells[4].Text);
                JunBillUK += Convert.ToInt64(e.Row.Cells[6].Text);
                JulBillUK += Convert.ToInt64(e.Row.Cells[8].Text);
                AugBillUK += Convert.ToInt64(e.Row.Cells[10].Text);
                SepBillUK += Convert.ToInt64(e.Row.Cells[12].Text);
                OctBillUK += Convert.ToInt64(e.Row.Cells[14].Text);
                NovBillUK += Convert.ToInt64(e.Row.Cells[16].Text);
                DecBillUK += Convert.ToInt64(e.Row.Cells[18].Text);
                JanBillUK += Convert.ToInt64(e.Row.Cells[20].Text);
                FebBillUK += Convert.ToInt64(e.Row.Cells[22].Text);
                MarBillUK += Convert.ToInt64(e.Row.Cells[24].Text);
                TotalBillUK += Convert.ToInt64(e.Row.Cells[26].Text);

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[0].Text = "Total";


                e.Row.Cells[1].Text = AprSaleUK.ToString();
                e.Row.Cells[3].Text = MaySaleUK.ToString();
                e.Row.Cells[5].Text = JunSaleUK.ToString();
                e.Row.Cells[7].Text = JulSaleUK.ToString();
                e.Row.Cells[9].Text = AugSaleUK.ToString();
                e.Row.Cells[11].Text = SepSaleUK.ToString();
                e.Row.Cells[13].Text = OctSaleUK.ToString();
                e.Row.Cells[15].Text = NovSaleUK.ToString();
                e.Row.Cells[17].Text = DecSaleUK.ToString();
                e.Row.Cells[19].Text = JanSaleUK.ToString();
                e.Row.Cells[21].Text = FebSaleUK.ToString();
                e.Row.Cells[23].Text = MarSaleUK.ToString();

                e.Row.Cells[25].Text = TotalSaleUK.ToString();



                e.Row.Cells[2].Text = AprBillUK.ToString();
                e.Row.Cells[4].Text = MayBillUK.ToString();
                e.Row.Cells[6].Text = JunBillUK.ToString();
                e.Row.Cells[8].Text = JulBillUK.ToString();
                e.Row.Cells[10].Text = AugBillUK.ToString();
                e.Row.Cells[12].Text = SepBillUK.ToString();
                e.Row.Cells[14].Text = OctBillUK.ToString();
                e.Row.Cells[16].Text = NovBillUK.ToString();
                e.Row.Cells[18].Text = DecBillUK.ToString();
                e.Row.Cells[20].Text = JanBillUK.ToString();
                e.Row.Cells[22].Text = FebBillUK.ToString();
                e.Row.Cells[24].Text = MarBillUK.ToString();
                e.Row.Cells[26].Text = TotalBillUK.ToString();


            }
        }
    }
    protected void grdBranchWise_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (chkCompare.Checked == true)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    int i = 0;
            //}
            //if (e.Row.RowType == DataControlRowType.Footer)
            //{

            //    GridViewRow footerRow = new GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Insert);
                
            //    TableCell cell = new TableCell();
            //    cell.Text = "Total " + ddlCompareYear.SelectedItem.Text;
            //    cell.HorizontalAlign = HorizontalAlign.Right;                
            //    footerRow.Cells.Add(cell);


            //    cell = new TableCell();
            //    Label lbl = new Label();
            //    lbl.ID = "lblFooterAmount";
            //    lbl.Text = "Another Footer";
            //    cell.Controls.Add(lbl);
            //    cell.HorizontalAlign = HorizontalAlign.Right;

            //    footerRow.Cells.Add(cell);
            //    grdBranchWise.Controls[0].Controls.Add(footerRow);
            //}
        }
        
    }
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        if (ddlReportType.SelectedValue == "2")
        {
            Response.Clear();
            Response.Buffer = true;

            Response.AddHeader("content-disposition",
             "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);


            Table tb = new Table();

            TableRow tr1 = new TableRow();

            TableCell cell1 = new TableCell();
            cell1.Controls.Add(grdCountryWiseRow);
            tr1.Cells.Add(cell1);

            TableCell cell3 = new TableCell();
            cell3.Controls.Add(grdCountryWiseUsa);

            TableCell cell2 = new TableCell();
            cell2.Text = "&nbsp;";
            TableRow tr2 = new TableRow();
            tr2.Cells.Add(cell2);


            TableCell cell5 = new TableCell();
            cell2.Text = "&nbsp;";
            TableRow tr5 = new TableRow();
            tr5.Cells.Add(cell5);

            TableCell cell4 = new TableCell();
            cell4.Controls.Add(grdCountryWiseUk);

            TableRow tr4 = new TableRow();
            tr4.Cells.Add(cell4);

            TableRow tr3 = new TableRow();
            tr3.Cells.Add(cell3);
            tb.Rows.Add(tr1);
            tb.Rows.Add(tr2);
            tb.Rows.Add(tr3);
            tb.Rows.Add(tr5);
            tb.Rows.Add(tr4);

            tb.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();            
        }
        else if(ddlReportType.SelectedValue == "1")
        {
            Response.Clear();
            Response.Buffer = true;

            Response.AddHeader("content-disposition",
             "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);


            Table tb = new Table();

            TableRow tr1 = new TableRow();

            TableCell cell1 = new TableCell();
            cell1.Controls.Add(grdBranchWise);
            tr1.Cells.Add(cell1);


            TableCell cell2 = new TableCell();
            cell2.Text = "&nbsp;";
            TableRow tr2 = new TableRow();
            tr2.Cells.Add(cell2);


            tb.Rows.Add(tr1);
            tb.Rows.Add(tr2);
            
            tb.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End(); 
        }

        


        //ExcelHelper.ToExcel((DataSet)Session["ds"], "test.xls", Page.Response);   
    }

     public override void VerifyRenderingInServerForm(Control control)
    {
    /* Verifies that the control is rendered */
    }




    protected void PrepareForExport(GridView Gridview)
    {

        Gridview.AllowPaging = false;

        Gridview.DataBind();



        //Change the Header Row back to white color

        Gridview.HeaderRow.Style.Add("background-color", "#FFFFFF");



        //Apply style to Individual Cells

        for (int k = 0; k < Gridview.HeaderRow.Cells.Count; k++)
        {

            Gridview.HeaderRow.Cells[k].Style.Add("background-color", "green");

        }



        for (int i = 0; i < Gridview.Rows.Count; i++)
        {

            GridViewRow row = Gridview.Rows[i];



            //Change Color back to white

            row.BackColor = System.Drawing.Color.White;



            //Apply text style to each Row

            row.Attributes.Add("class", "textmode");



            //Apply style to Individual Cells of Alternating Row

            if (i % 2 != 0)
            {

                for (int j = 0; j < Gridview.Rows[i].Cells.Count; j++)
                {

                    row.Cells[j].Style.Add("background-color", "#C2D69B");

                }

            }

        }

    }







}

//public class ExcelHelper
//{
//    //Row limits older Excel version per sheet
//        const int rowLimit = 65000;

//        private static string getWorkbookTemplate()
//        {
//            var sb = new StringBuilder();
//            sb.Append("<xml version>\r\n<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n");
//            sb.Append(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n xmlns:x=\"urn:schemas- microsoft-com:office:excel\"\r\n xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">\r\n");
//            sb.Append(" <Styles>\r\n <Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n		<Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>");
//            sb.Append("\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>\r\n		<Protection/>\r\n </Style>\r\n		<Style ss:ID=\"BoldColumn\">\r\n <Font ");
//            sb.Append("x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n </Style>\r\n		<Style ss:ID=\"s62\">\r\n <NumberFormat");
//            sb.Append(" ss:Format=\"@\"/>\r\n </Style>\r\n		<Style ss:ID=\"Decimal\">\r\n		<NumberFormat ss:Format=\"0.0000\"/>\r\n </Style>\r\n ");
//            sb.Append("<Style ss:ID=\"Integer\">\r\n		<NumberFormat ss:Format=\"0\"/>\r\n </Style>\r\n		<Style ss:ID=\"DateLiteral\">\r\n <NumberFormat ");
//            sb.Append("ss:Format=\"mm/dd/yyyy;@\"/>\r\n </Style>\r\n		<Style ss:ID=\"s28\">\r\n");
//            sb.Append("<Alignment ss:Horizontal=\"Left\" ss:Vertical=\"Top\"		ss:ReadingOrder=\"LeftToRight\" ss:WrapText=\"1\"/>\r\n");            sb.Append("<Font x:CharSet=\"1\" ss:Size=\"9\"		ss:Color=\"#808080\" ss:Underline=\"Single\"/>\r\n");

//            sb.Append("<Interior ss:Color=\"#FFFFFF\" ss:Pattern=\"Solid\"/>		</Style>\r\n</Styles>\r\n {0}</Workbook>");
//            return sb.ToString();
//        }

//        private static string replaceXmlChar(string input)
//        {
//            input = input.Replace("&", "&");
//            input = input.Replace("<", "<");
//            input = input.Replace(">", ">");
//            input = input.Replace("\"", "");
//            input = input.Replace("'", "&apos;");
//            return input;
//        }

//        private static string getWorksheets(DataSet source)
//        {
//            var sw = new StringWriter();
//            if (source == null || source.Tables.Count == 0)
//            {
//                sw.Write("<Worksheet ss:Name=\"Sheet1\"><Table><Row>		<Cell  ss:StyleID=\"s62\"><Data ss:Type=\"String\"></Data>		</Cell></Row></Table></Worksheet>");
//                return sw.ToString();
//            }
//            foreach (DataTable dt in source.Tables)
//            {
//                if (dt.Rows.Count == 0)
//                    sw.Write("<Worksheet ss:Name=\"" + replaceXmlChar(dt.TableName) +	"\"><Table><Row><Cell  ss:StyleID=\"s62\">			<Data ss:Type=\"String\"></Data></Cell></Row>			</Table></Worksheet>");
//                else
//                {
//                    //write each row data
//                    var sheetCount = 0;
//                    for (int i = 0; i < dt.Rows.Count; i++)
//                    {
//                        if ((i % rowLimit) == 0)
//                        {
//                            //add close tags for previous sheet of the same data table
//                            if ((i / rowLimit) > sheetCount)
//                            {
//                                sw.Write("</Table></Worksheet>");
//                                sheetCount = (i / rowLimit);
//                            }
//                            sw.Write("<Worksheet ss:Name=\"" +
//                replaceXmlChar(dt.TableName) +
//                                     (((i / rowLimit) == 0) ? "" :
//                Convert.ToString(i / rowLimit)) + "\"><Table>");
//                            //write column name row
//                            sw.Write("<Row>");
//                            foreach (DataColumn dc in dt.Columns)
//                                sw.Write(string.Format("<Cell ss:StyleID=\"BoldColumn\"> <Data ss:Type=\"String\">{0}</Data></Cell>",sw.Write("</Row>\r\n")));
//                        }
//                        sw.Write("<Row>\r\n");
//                        foreach (DataColumn dc in dt.Columns)
//                            sw.Write(
//                                string.Format("<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\"> {0}</Data></Cell>",replaceXmlChar(dt.Rows[i][dc.ColumnName].ToString())));
//                        sw.Write("</Row>\r\n");
//                    }
//                    sw.Write("</Table></Worksheet>");
//                }
//            }

//            return sw.ToString();
//        }
//        public static string GetExcelXml(DataTable dtInput, string filename)
//        {
//            var excelTemplate = getWorkbookTemplate();
//            var ds = new DataSet();
//            ds.Tables.Add(dtInput.Copy());
//            var worksheets = getWorksheets(ds);
//            var excelXml = string.Format(excelTemplate, worksheets);
//            return excelXml;
//        }

//        public static string GetExcelXml(DataSet dsInput, string filename)
//        {
//            var excelTemplate = getWorkbookTemplate();
//            var worksheets = getWorksheets(dsInput);
//            var excelXml = string.Format(excelTemplate, worksheets);
//            return excelXml;
//        }

//        public static void ToExcel
//        (DataSet dsInput, string filename, HttpResponse response)
//        {
//            var excelXml = GetExcelXml(dsInput, filename);
//            response.Clear();
//            response.AppendHeader("Content-Type", "application/vnd.ms-excel");
//            response.AppendHeader
//        ("Content-disposition", "attachment; filename=" + filename);
//            response.Write(excelXml);
//            response.Flush();
//            response.End();
//        }

//        public static void ToExcel
//        (DataTable dtInput, string filename, HttpResponse response)
//        {
//            var ds = new DataSet();
//            ds.Tables.Add(dtInput.Copy());
//            ToExcel(ds, filename, response);
//        }
//    }


//ExcelHelper.cs

public class ExcelHelper
{
    //Row limits older Excel version per sheet
        const int rowLimit = 65000;

        private static string getWorkbookTemplate()
        {
            var sb = new StringBuilder();
            sb.Append("<xml version>\r\n<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n");
            sb.Append(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n xmlns:x=\"urn:schemas- microsoft-com:office:excel\"\r\n xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">\r\n");
            sb.Append(" <Styles>\r\n <Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n <Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>");
            sb.Append("\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>\r\n <Protection/>\r\n </Style>\r\n <Style ss:ID=\"BoldColumn\">\r\n <Font ");
            sb.Append("x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n </Style>\r\n <Style ss:ID=\"s62\">\r\n <NumberFormat");
            sb.Append(" ss:Format=\"@\"/>\r\n </Style>\r\n <Style ss:ID=\"Decimal\">\r\n <NumberFormat ss:Format=\"0.0000\"/>\r\n </Style>\r\n ");
            sb.Append("<Style ss:ID=\"Integer\">\r\n <NumberFormat ss:Format=\"0\"/>\r\n </Style>\r\n <Style ss:ID=\"DateLiteral\">\r\n <NumberFormat ");
            sb.Append("ss:Format=\"mm/dd/yyyy;@\"/>\r\n </Style>\r\n <Style ss:ID=\"s28\">\r\n");
            sb.Append("<Alignment ss:Horizontal=\"Left\" ss:Vertical=\"Top\" ss:ReadingOrder=\"LeftToRight\" ss:WrapText=\"1\"/>\r\n");
            sb.Append("<Font x:CharSet=\"1\" ss:Size=\"9\" ss:Color=\"#808080\" ss:Underline=\"Single\"/>\r\n");
            sb.Append("<Interior ss:Color=\"#FFFFFF\" ss:Pattern=\"Solid\"/> </Style>\r\n</Styles>\r\n {0}</Workbook>");
            return sb.ToString();
        }

        private static string replaceXmlChar(string input)
        {
            input = input.Replace("&", "&");
            input = input.Replace("<", "<");
            input = input.Replace(">", ">");
            input = input.Replace("\"", "");
            input = input.Replace("'", "'");
            return input;
        }

        private static string getWorksheets(DataSet source)
        {
            var sw = new StringWriter();
            if (source == null || source.Tables.Count == 0)
            {
                sw.Write("<Worksheet ss:Name=\"Sheet1\"><Table><Row> <Cell  ss:StyleID=\"s62\"><Data ss:Type=\"String\"></Data> </Cell></Row></Table></Worksheet>");
                return sw.ToString();
            }
            foreach (DataTable dt in source.Tables)
            {
                if (dt.Rows.Count == 0)
                    sw.Write("<Worksheet ss:Name=\"" + replaceXmlChar(dt.TableName) + "\"><Table><Row><Cell  ss:StyleID=\"s62\"> <Data ss:Type=\"String\"></Data></Cell></Row> </Table></Worksheet>");
                else
                {
                    //write each row data
                    var sheetCount = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((i % rowLimit) == 0)
                        {
                            //add close tags for previous sheet of the same data table
                            if ((i / rowLimit) > sheetCount)
                            {
                                sw.Write("</Table></Worksheet>");
                                sheetCount = (i / rowLimit);
                            }
                            sw.Write("<Worksheet ss:Name=\"" +
				replaceXmlChar(dt.TableName) +
                                     (((i / rowLimit) == 0) ? "" :
				Convert.ToString(i / rowLimit)) + "\"><Table>");
                            //write column name row
                            sw.Write("<Row>");
                            foreach (DataColumn dc in dt.Columns)
                                sw.Write( string.Format( "<Cell ss:StyleID=\"BoldColumn\"> <Data ss:Type=\"String\">{0}</Data></Cell>", replaceXmlChar(dc.ColumnName)));
                            sw.Write("</Row>\r\n");
                        }
                        sw.Write("<Row>\r\n");
                        foreach (DataColumn dc in dt.Columns)
                            sw.Write(
                                string.Format( "<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\"> {0}</Data></Cell>", replaceXmlChar (dt.Rows[i][dc.ColumnName].ToString())));
                        sw.Write("</Row>\r\n");
                    }
                    sw.Write("</Table></Worksheet>");
                }
            }

            return sw.ToString();
        }
        public static string GetExcelXml(DataTable dtInput, string filename)
        {
            var excelTemplate = getWorkbookTemplate();
            var ds = new DataSet();
            ds.Tables.Add(dtInput.Copy());
            var worksheets = getWorksheets(ds);
            var excelXml = string.Format(excelTemplate, worksheets);
            return excelXml;
        }

        public static string GetExcelXml(DataSet dsInput, string filename)
        {
            var excelTemplate = getWorkbookTemplate();
            var worksheets = getWorksheets(dsInput);
            var excelXml = string.Format(excelTemplate, worksheets);
            return excelXml;
        }

        public static void ToExcel
		(DataSet dsInput, string filename, HttpResponse response)
        {
            var excelXml = GetExcelXml(dsInput, filename);
            response.Clear();
            response.AppendHeader("Content-Type", "application/vnd.ms-excel");
            response.AppendHeader
		("Content-disposition", "attachment; filename=" + filename);
            response.Write(excelXml);
            response.Flush();
            response.End();
        }

        public static void ToExcel
		(DataTable dtInput, string filename, HttpResponse response)
        {
            var ds = new DataSet();
            ds.Tables.Add(dtInput.Copy());
            ToExcel(ds, filename, response);
        }
    }

