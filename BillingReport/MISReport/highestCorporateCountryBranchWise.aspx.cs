using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MISReport_highestCorporateCountryBranchWise : System.Web.UI.Page
{
    double sum = 0;
    double sum2 = 0;

    double sum3 = 0;
    double sum4 = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Clay.Invoice.Bll.Report obj = new Clay.Invoice.Bll.Report();
            DataSet dsRep = new DataSet();

            if (!IsPostBack)
            {
                int month = Convert.ToInt32(Request.QueryString["lmonth"]);
                int year = Convert.ToInt32(Request.QueryString["lyear"]);
                int customerid = Convert.ToInt32(Request.QueryString["customerid"]);
                string strCustNAme = Convert.ToString(Request.QueryString["LedgerName"]);

                lblCustomerName.Text = strCustNAme;

                dsRep = obj.GetTotalSAleByCustomerIDNew(year, month, customerid);

                if (dsRep.Tables[0].Rows.Count > 0)
                {
                    RadGrid1New.DataSource = dsRep.Tables[0];
                    RadGrid1New.DataBind();
                    RadGrid1New.Visible = true;

                    GridView1.DataSource = dsRep.Tables[1];
                    GridView1.DataBind();
                    GridView1.Visible = true;
                }
                else
                {
                    RadGrid1New.Visible = false;
                    GridView1.Visible = false;
                }
            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void RAFRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblsalecount = (Label)e.Item.FindControl("lblSaleCount");
            Label lbltotalamount = (Label)e.Item.FindControl("lblTotalAmount");

            if (lblsalecount.Text != "")
            {
                sum += Convert.ToDouble(lblsalecount.Text);
            }

            if (lbltotalamount.Text != "")
            {
                sum2 += Convert.ToDouble(lbltotalamount.Text);
            }


        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Label lblSaleCountGrand = (Label)e.Item.FindControl("lblSaleCountGrand");
            Label lblTotalAmountGrand = (Label)e.Item.FindControl("lblTotalAmountGrand");

            lblSaleCountGrand.Text = Math.Round(sum).ToString();
            lblTotalAmountGrand.Text = Math.Round(sum2, 2).ToString();

        }
    }
    //protected void RadGrid1New_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        Label lbl1 = e.Row.FindControl("lblSaleCount") as Label;
    //        if (lbl1.Text != "")
    //        {
    //            sum += Convert.ToDouble(lbl1.Text);
    //        }

    //        Label lbl2 = e.Row.FindControl("lblTotalAmount") as Label;
    //        if (lbl2.Text != "")
    //        {
    //            sum2 += Convert.ToDouble(lbl2.Text);
    //        }

    //    }

    //    if (e.Row.RowType == DataControlRowType.Footer)
    //    {
    //        Label lblgrandtotal = e.Row.FindControl("lblSaleCountGrandTotal") as Label;
    //        Label lblgrandtotallow = e.Row.FindControl("lblTotalAmountGrand") as Label;


    //        lblgrandtotal.Text = Convert.ToString(sum);
    //        lblgrandtotallow.Text = Convert.ToString(sum2);

    //    }
    //}

    //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        Label lbl1 = e.Row.FindControl("lblSaleCount") as Label;
    //        if (lbl1.Text != "")
    //        {
    //            sum3 += Convert.ToDouble(lbl1.Text);
    //        }

    //        Label lbl2 = e.Row.FindControl("lblTotalAmount") as Label;
    //        if (lbl2.Text != "")
    //        {
    //            sum4 += Convert.ToDouble(lbl2.Text);
    //        }

    //    }

    //    if (e.Row.RowType == DataControlRowType.Footer)
    //    {
    //        Label lblgrandtotal = e.Row.FindControl("lblSaleCountGrandTotal") as Label;
    //        Label lblgrandtotallow = e.Row.FindControl("lblTotalAmountGrand") as Label;


    //        lblgrandtotal.Text = Convert.ToString(sum3);
    //        lblgrandtotallow.Text = Convert.ToString(sum4);

    //    }
    //}

    protected void GridView1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblsalecount = (Label)e.Item.FindControl("lblSaleCount");
            Label lbltotalamount = (Label)e.Item.FindControl("lblTotalAmount");

            if (lblsalecount.Text != "")
            {
                sum3 += Convert.ToDouble(lblsalecount.Text);
            }

            if (lbltotalamount.Text != "")
            {
                sum4 += Convert.ToDouble(lbltotalamount.Text);
            }


        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Label lblSaleCountGrand = (Label)e.Item.FindControl("lblSaleCountGrandTotal");
            Label lblTotalAmountGrand = (Label)e.Item.FindControl("lblTotalAmountGrand");

            lblSaleCountGrand.Text = Math.Round(sum3).ToString();
            lblTotalAmountGrand.Text = Math.Round(sum4, 2).ToString();

        }
    }
}