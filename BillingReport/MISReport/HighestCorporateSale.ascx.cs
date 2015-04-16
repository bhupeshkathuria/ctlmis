using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

public partial class MISReport_HighestCorporateControl : System.Web.UI.UserControl
{
    public Int32 customerID
    {
        get
        {
            if (ViewState["customerID"] == null)
            {
                return 0;
            }
            return (Int32)ViewState["customerID"];
        }
        set
        {
            ViewState["customerID"] = value;
        }
    }

    public Int32 yearVAl
    {
        get
        {
            if (ViewState["year"] == null)
            {
                return 0;
            }
            return (Int32)ViewState["year"];
        }
        set
        {
            ViewState["year"] = value;
        }
    }

    public Int32 monthVAl
    {
        get
        {
            if (ViewState["month"] == null)
            {
                return 0;
            }
            return (Int32)ViewState["month"];
        }
        set
        {
            ViewState["month"] = value;
        }
    }

    Clay.Invoice.Bll.Report obj = new Clay.Invoice.Bll.Report();
    DataSet dsRep = new DataSet();

    double sum = 0;
    double sum2 = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        BindRadGrid();
    }

    protected void BindRadGrid()
    {

        try
        {
            dsRep = obj.GetTotalSAleByCustomerID(yearVAl, monthVAl, customerID);

            if (dsRep.Tables[0].Rows.Count > 0)
            {
                RadGrid1.DataSource = dsRep;
                RadGrid1.DataBind();
                RadGrid1.Visible = true;
            }
            else
            {
                RadGrid1.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void RadGrid1_PageIndexChanged(object source, GridPageChangedEventArgs e)
    {
        sum = 0;
        sum2 = 0;
        if ((e.NewPageIndex / RadGrid1.PageSize) > RadGrid1.PageCount)
        {
            BindRadGrid();
        }
        else
        {
            BindRadGrid();
        }
    }
    protected void RadGrid1_SortCommand(object source, GridSortCommandEventArgs e)
    {
        sum = 0;
        sum2 = 0;
        BindRadGrid();
    }
    protected void RadGrid1_PageSizeChanged(object source, GridPageSizeChangedEventArgs e)
    {
        sum = 0;
        sum2 = 0;
        BindRadGrid();
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;

            Label lbl1 = item.FindControl("lblsalecount") as Label;
            sum += Convert.ToDouble(lbl1.Text);

            Label lbl2 = item.FindControl("lblTotalAmount") as Label;
            sum2 += Convert.ToDouble(lbl2.Text);

        }
        if (e.Item is GridFooterItem)
        {
            GridFooterItem item = (GridFooterItem)e.Item;
            Label lblgrandtotal = item.FindControl("lblgrandTotalSaleCount") as Label;
            Label lblgrandtotallow = item.FindControl("lblgrandTotalBillAmount") as Label;

            lblgrandtotal.Text = Convert.ToString(sum);
            lblgrandtotallow.Text = ConvertToMoneyFormat(Convert.ToString(sum2));


        }
    }

    protected string ConvertToMoneyFormat(string myval)
    {
        if (myval == "")
        {
            return "0.00";
        }
        else
        {
            return string.Format("{0:0.00}", Convert.ToDouble(myval));
        }
    }

}