using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class MISReport_rptCDRRowData : System.Web.UI.Page
{
    Clay.Invoice.Bll.Report objGetGroup = new Clay.Invoice.Bll.Report();
    DataSet dsgRoup = new DataSet();
    int[] daysBR = new int[35];
    int[] daysBRSecond = new int[35];

    protected void Page_Load(object sender, EventArgs e)
    {
        checkSession();

        try
        {
            if (!IsPostBack)
            {
                loadYear();
                loadGroup();
            }
        }
        catch (Exception ex)
        {
            //err.Text = ex.Message.ToString();
        }
    }

    private void loadGroup()
    {
        dsgRoup = objGetGroup.rptGroupProviderGetAll();
        ddlProvider.DataSource = dsgRoup.Tables[0];
        ddlProvider.DataTextField = "groupname";
        ddlProvider.DataValueField = "groupid";
        ddlProvider.DataBind();
        ddlProvider.Items.Insert(0, "Select Provider");
    }

    private void loadCallType()
    {
        Clay.Invoice.Bll.Report o = new Clay.Invoice.Bll.Report();
        DataSet ds = o.rptCallTypeByGroupProvider(Convert.ToInt32(ddlProvider.SelectedValue));

        ddlCallType.DataSource = ds.Tables[0];
        ddlCallType.DataTextField = "calltypenamedisplay";
        ddlCallType.DataValueField = "calltypename";
        ddlCallType.DataBind();
        ddlCallType.Items.Insert(0, "Select Call type");

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
            drYear["yearTxt"] = i;
            dsYear.Tables[0].Rows.InsertAt(drYear, i + 1 - 2010);
        }

        ddlFromYear.DataSource = dsYear.Tables[0];
        ddlFromYear.DataTextField = "yearVal";
        ddlFromYear.DataValueField = "yearTxt";
        ddlFromYear.DataBind();
        ddlFromYear.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;

        ddlYearTo.DataSource = dsYear.Tables[0];
        ddlYearTo.DataTextField = "yearVal";
        ddlYearTo.DataValueField = "yearTxt";
        ddlYearTo.DataBind();
        ddlYearTo.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;

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

    protected void RAFRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblBranchName = e.Item.FindControl("lblcalltype") as Label;

            //if (lblBranchName.Text.Contains("Total"))
            //{
            //    //HtmlTableRow row = (HtmlTableRow)e.Item.FindControl("drow");
            //    //row.Attributes.Add("style", "background-color:gray;color:White;font-weight:bold");

            Label lbls1 = (Label)e.Item.FindControl("lbls1");
            Label lbls2 = (Label)e.Item.FindControl("lbls2");
            Label lbls3 = (Label)e.Item.FindControl("lbls3");
            Label lbls4 = (Label)e.Item.FindControl("lbls4");
            Label lbls5 = (Label)e.Item.FindControl("lbls5");
            Label lbls6 = (Label)e.Item.FindControl("lbls6");
            Label lbls7 = (Label)e.Item.FindControl("lbls7");
            Label lbls8 = (Label)e.Item.FindControl("lbls8");
            Label lbls9 = (Label)e.Item.FindControl("lbls9");
            Label lbls10 = (Label)e.Item.FindControl("lbls10");
            Label lbls11 = (Label)e.Item.FindControl("lbls11");
            Label lbls12 = (Label)e.Item.FindControl("lbls12");
            Label lbls13 = (Label)e.Item.FindControl("lbls13");
            Label lbls14 = (Label)e.Item.FindControl("lbls14");
            Label lbls15 = (Label)e.Item.FindControl("lbls15");
            Label lbls16 = (Label)e.Item.FindControl("lbls16");
            Label lbls17 = (Label)e.Item.FindControl("lbls17");
            Label lbls18 = (Label)e.Item.FindControl("lbls18");
            Label lbls19 = (Label)e.Item.FindControl("lbls19");
            Label lbls20 = (Label)e.Item.FindControl("lbls20");
            Label lbls21 = (Label)e.Item.FindControl("lbls21");
            Label lbls22 = (Label)e.Item.FindControl("lbls22");
            Label lbls23 = (Label)e.Item.FindControl("lbls23");
            Label lbls24 = (Label)e.Item.FindControl("lbls24");
            Label lbls25 = (Label)e.Item.FindControl("lbls25");
            Label lbls26 = (Label)e.Item.FindControl("lbls26");
            Label lbls27 = (Label)e.Item.FindControl("lbls27");
            Label lbls28 = (Label)e.Item.FindControl("lbls28");
            Label lbls29 = (Label)e.Item.FindControl("lbls29");
            Label lbls30 = (Label)e.Item.FindControl("lbls30");
            Label lbls31 = (Label)e.Item.FindControl("lbls31");

            Label lbltotal = (Label)e.Item.FindControl("lbltotal");
            Label lblbillingtotal = (Label)e.Item.FindControl("lblbillingtotal");
            Label lblDifference = (Label)e.Item.FindControl("lblDifference");

            daysBR[1] += Convert.ToInt32(lbls1.Text);
            daysBR[2] += Convert.ToInt32(lbls2.Text);
            daysBR[3] += Convert.ToInt32(lbls3.Text);
            daysBR[4] += Convert.ToInt32(lbls4.Text);
            daysBR[5] += Convert.ToInt32(lbls5.Text);
            daysBR[6] += Convert.ToInt32(lbls6.Text);
            daysBR[7] += Convert.ToInt32(lbls7.Text);
            daysBR[8] += Convert.ToInt32(lbls8.Text);
            daysBR[9] += Convert.ToInt32(lbls9.Text);
            daysBR[10] += Convert.ToInt32(lbls10.Text);
            daysBR[11] += Convert.ToInt32(lbls11.Text);
            daysBR[12] += Convert.ToInt32(lbls12.Text);
            daysBR[13] += Convert.ToInt32(lbls13.Text);
            daysBR[14] += Convert.ToInt32(lbls14.Text);
            daysBR[15] += Convert.ToInt32(lbls15.Text);
            daysBR[16] += Convert.ToInt32(lbls16.Text);
            daysBR[17] += Convert.ToInt32(lbls17.Text);
            daysBR[18] += Convert.ToInt32(lbls18.Text);
            daysBR[19] += Convert.ToInt32(lbls19.Text);
            daysBR[20] += Convert.ToInt32(lbls20.Text);

            daysBR[21] += Convert.ToInt32(lbls21.Text);
            daysBR[22] += Convert.ToInt32(lbls22.Text);
            daysBR[23] += Convert.ToInt32(lbls23.Text);
            daysBR[24] += Convert.ToInt32(lbls24.Text);
            daysBR[25] += Convert.ToInt32(lbls25.Text);

            daysBR[26] += Convert.ToInt32(lbls26.Text);
            daysBR[27] += Convert.ToInt32(lbls27.Text);
            daysBR[28] += Convert.ToInt32(lbls28.Text);
            daysBR[29] += Convert.ToInt32(lbls29.Text);
            daysBR[30] += Convert.ToInt32(lbls30.Text);
            daysBR[31] += Convert.ToInt32(lbls31.Text);

            daysBR[32] += Convert.ToInt32(lbltotal.Text);
            daysBR[33] += Convert.ToInt32(lblbillingtotal.Text);
            daysBR[34] += Convert.ToInt32(lblDifference.Text);
        }

        if (e.Item.ItemType == ListItemType.Footer)
        {

            HtmlTableRow row = (HtmlTableRow)e.Item.FindControl("drow");
            row.Attributes.Add("style", "background-color:gray;color:White;font-weight:bold");

            Label lbls1footer = (Label)e.Item.FindControl("lbls1footer");
            Label lbls2footer = (Label)e.Item.FindControl("lbls2footer");
            Label lbls3footer = (Label)e.Item.FindControl("lbls3footer");
            Label lbls4footer = (Label)e.Item.FindControl("lbls4footer");
            Label lbls5footer = (Label)e.Item.FindControl("lbls5footer");
            Label lbls6footer = (Label)e.Item.FindControl("lbls6footer");
            Label lbls7footer = (Label)e.Item.FindControl("lbls7footer");
            Label lbls8footer = (Label)e.Item.FindControl("lbls8footer");
            Label lbls9footer = (Label)e.Item.FindControl("lbls9footer");
            Label lbls10footer = (Label)e.Item.FindControl("lbls10footer");
            Label lbls11footer = (Label)e.Item.FindControl("lbls11footer");
            Label lbls12footer = (Label)e.Item.FindControl("lbls12footer");
            Label lbls13footer = (Label)e.Item.FindControl("lbls13footer");
            Label lbls14footer= (Label)e.Item.FindControl("lbls14footer");
            Label lbls15footer = (Label)e.Item.FindControl("lbls15footer");
            Label lbls16footer = (Label)e.Item.FindControl("lbls16footer");
            Label lbls17footer = (Label)e.Item.FindControl("lbls17footer");
            Label lbls18footer = (Label)e.Item.FindControl("lbls18footer");
            Label lbls19footer = (Label)e.Item.FindControl("lbls19footer");
            Label lbls20footer = (Label)e.Item.FindControl("lbls20footer");
            Label lbls21footer = (Label)e.Item.FindControl("lbls21footer");
            Label lbls22footer = (Label)e.Item.FindControl("lbls22footer");
            Label lbls23footer = (Label)e.Item.FindControl("lbls23footer");
            Label lbls24footer = (Label)e.Item.FindControl("lbls24footer");
            Label lbls25footer = (Label)e.Item.FindControl("lbls25footer");
            Label lbls26footer = (Label)e.Item.FindControl("lbls26footer");
            Label lbls27footer = (Label)e.Item.FindControl("lbls27footer");
            Label lbls28footer = (Label)e.Item.FindControl("lbls28footer");
            
            Label lbls29footer = (Label)e.Item.FindControl("lbls29footer");
            Label lbls30footer = (Label)e.Item.FindControl("lbls30footer");
            Label lbls31footer = (Label)e.Item.FindControl("lbls31footer");

            Label lbltotalFooter = (Label)e.Item.FindControl("lbltotalfooter");
            Label lblbillingtotalFooter = (Label)e.Item.FindControl("lblbillingtotalfooter");
            Label lblDifferenceFooter = (Label)e.Item.FindControl("lblDifferencefooter");

            lbls1footer.Text = daysBR[1].ToString();
            lbls2footer.Text = daysBR[2].ToString();
            lbls3footer.Text = daysBR[3].ToString();
            lbls4footer.Text = daysBR[4].ToString();
            lbls5footer.Text = daysBR[5].ToString();
            lbls6footer.Text = daysBR[6].ToString();
            lbls7footer.Text = daysBR[7].ToString();
            lbls8footer.Text = daysBR[8].ToString();
            lbls9footer.Text = daysBR[9].ToString();
            lbls10footer.Text = daysBR[10].ToString();
            lbls11footer.Text = daysBR[11].ToString();
            lbls12footer.Text = daysBR[12].ToString();
            lbls13footer.Text = daysBR[13].ToString();
            lbls14footer.Text = daysBR[14].ToString();
            lbls15footer.Text = daysBR[15].ToString();
            lbls16footer.Text = daysBR[16].ToString();
            lbls17footer.Text = daysBR[17].ToString();
            lbls18footer.Text = daysBR[18].ToString();
            lbls19footer.Text = daysBR[19].ToString();
            lbls20footer.Text = daysBR[20].ToString();
            lbls21footer.Text = daysBR[21].ToString();
            lbls22footer.Text = daysBR[22].ToString();
            lbls23footer.Text = daysBR[23].ToString();
            lbls24footer.Text = daysBR[24].ToString();
            lbls25footer.Text = daysBR[25].ToString();
            lbls26footer.Text = daysBR[26].ToString();
            lbls27footer.Text = daysBR[27].ToString();
            lbls28footer.Text = daysBR[28].ToString();
            lbls29footer.Text = daysBR[29].ToString();
            lbls30footer.Text = daysBR[30].ToString();
            lbls31footer.Text = daysBR[31].ToString();

            lbltotalFooter.Text = daysBR[32].ToString();
            lblbillingtotalFooter.Text = daysBR[33].ToString();
            lblDifferenceFooter.Text = daysBR[34].ToString();
        }
    }

    protected void rptSecond_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblBranchName = e.Item.FindControl("lblcalltype") as Label;

            //if (lblBranchName.Text.Contains("Total"))
            //{
            //    //HtmlTableRow row = (HtmlTableRow)e.Item.FindControl("drow");
            //    //row.Attributes.Add("style", "background-color:gray;color:White;font-weight:bold");

            Label lbls1 = (Label)e.Item.FindControl("lbls1");
            Label lbls2 = (Label)e.Item.FindControl("lbls2");
            Label lbls3 = (Label)e.Item.FindControl("lbls3");
            Label lbls4 = (Label)e.Item.FindControl("lbls4");
            Label lbls5 = (Label)e.Item.FindControl("lbls5");
            Label lbls6 = (Label)e.Item.FindControl("lbls6");
            Label lbls7 = (Label)e.Item.FindControl("lbls7");
            Label lbls8 = (Label)e.Item.FindControl("lbls8");
            Label lbls9 = (Label)e.Item.FindControl("lbls9");
            Label lbls10 = (Label)e.Item.FindControl("lbls10");
            Label lbls11 = (Label)e.Item.FindControl("lbls11");
            Label lbls12 = (Label)e.Item.FindControl("lbls12");
            Label lbls13 = (Label)e.Item.FindControl("lbls13");
            Label lbls14 = (Label)e.Item.FindControl("lbls14");
            Label lbls15 = (Label)e.Item.FindControl("lbls15");
            Label lbls16 = (Label)e.Item.FindControl("lbls16");
            Label lbls17 = (Label)e.Item.FindControl("lbls17");
            Label lbls18 = (Label)e.Item.FindControl("lbls18");
            Label lbls19 = (Label)e.Item.FindControl("lbls19");
            Label lbls20 = (Label)e.Item.FindControl("lbls20");
            Label lbls21 = (Label)e.Item.FindControl("lbls21");
            Label lbls22 = (Label)e.Item.FindControl("lbls22");
            Label lbls23 = (Label)e.Item.FindControl("lbls23");
            Label lbls24 = (Label)e.Item.FindControl("lbls24");
            Label lbls25 = (Label)e.Item.FindControl("lbls25");
            Label lbls26 = (Label)e.Item.FindControl("lbls26");
            Label lbls27 = (Label)e.Item.FindControl("lbls27");
            Label lbls28 = (Label)e.Item.FindControl("lbls28");
            Label lbls29 = (Label)e.Item.FindControl("lbls29");
            Label lbls30 = (Label)e.Item.FindControl("lbls30");
            Label lbls31 = (Label)e.Item.FindControl("lbls31");

            Label lbltotal = (Label)e.Item.FindControl("lbltotal");
            Label lblbillingtotal = (Label)e.Item.FindControl("lblbillingtotal");
            Label lblDifference = (Label)e.Item.FindControl("lblDifference");

            daysBRSecond[1] += Convert.ToInt32(lbls1.Text);
            daysBRSecond[2] += Convert.ToInt32(lbls2.Text);
            daysBRSecond[3] += Convert.ToInt32(lbls3.Text);
            daysBRSecond[4] += Convert.ToInt32(lbls4.Text);
            daysBRSecond[5] += Convert.ToInt32(lbls5.Text);
            daysBRSecond[6] += Convert.ToInt32(lbls6.Text);
            daysBRSecond[7] += Convert.ToInt32(lbls7.Text);
            daysBRSecond[8] += Convert.ToInt32(lbls8.Text);
            daysBRSecond[9] += Convert.ToInt32(lbls9.Text);
            daysBRSecond[10] += Convert.ToInt32(lbls10.Text);
            daysBRSecond[11] += Convert.ToInt32(lbls11.Text);
            daysBRSecond[12] += Convert.ToInt32(lbls12.Text);
            daysBRSecond[13] += Convert.ToInt32(lbls13.Text);
            daysBRSecond[14] += Convert.ToInt32(lbls14.Text);
            daysBRSecond[15] += Convert.ToInt32(lbls15.Text);
            daysBRSecond[16] += Convert.ToInt32(lbls16.Text);
            daysBRSecond[17] += Convert.ToInt32(lbls17.Text);
            daysBRSecond[18] += Convert.ToInt32(lbls18.Text);
            daysBRSecond[19] += Convert.ToInt32(lbls19.Text);
            daysBRSecond[20] += Convert.ToInt32(lbls20.Text);

            daysBRSecond[21] += Convert.ToInt32(lbls21.Text);
            daysBRSecond[22] += Convert.ToInt32(lbls22.Text);
            daysBRSecond[23] += Convert.ToInt32(lbls23.Text);
            daysBRSecond[24] += Convert.ToInt32(lbls24.Text);
            daysBRSecond[25] += Convert.ToInt32(lbls25.Text);

            daysBRSecond[26] += Convert.ToInt32(lbls26.Text);
            daysBRSecond[27] += Convert.ToInt32(lbls27.Text);
            daysBRSecond[28] += Convert.ToInt32(lbls28.Text);
            daysBRSecond[29] += Convert.ToInt32(lbls29.Text);
            daysBRSecond[30] += Convert.ToInt32(lbls30.Text);
            daysBRSecond[31] += Convert.ToInt32(lbls31.Text);

            daysBRSecond[32] += Convert.ToInt32(lbltotal.Text);
            daysBRSecond[33] += Convert.ToInt32(lblbillingtotal.Text);
            daysBRSecond[34] += Convert.ToInt32(lblDifference.Text);
        }

        if (e.Item.ItemType == ListItemType.Footer)
        {

            HtmlTableRow row = (HtmlTableRow)e.Item.FindControl("drow");
            row.Attributes.Add("style", "background-color:gray;color:White;font-weight:bold");

            Label lbls1footer = (Label)e.Item.FindControl("lbls1footer");
            Label lbls2footer = (Label)e.Item.FindControl("lbls2footer");
            Label lbls3footer = (Label)e.Item.FindControl("lbls3footer");
            Label lbls4footer = (Label)e.Item.FindControl("lbls4footer");
            Label lbls5footer = (Label)e.Item.FindControl("lbls5footer");
            Label lbls6footer = (Label)e.Item.FindControl("lbls6footer");
            Label lbls7footer = (Label)e.Item.FindControl("lbls7footer");
            Label lbls8footer = (Label)e.Item.FindControl("lbls8footer");
            Label lbls9footer = (Label)e.Item.FindControl("lbls9footer");
            Label lbls10footer = (Label)e.Item.FindControl("lbls10footer");
            Label lbls11footer = (Label)e.Item.FindControl("lbls11footer");
            Label lbls12footer = (Label)e.Item.FindControl("lbls12footer");
            Label lbls13footer = (Label)e.Item.FindControl("lbls13footer");
            Label lbls14footer = (Label)e.Item.FindControl("lbls14footer");
            Label lbls15footer = (Label)e.Item.FindControl("lbls15footer");
            Label lbls16footer = (Label)e.Item.FindControl("lbls16footer");
            Label lbls17footer = (Label)e.Item.FindControl("lbls17footer");
            Label lbls18footer = (Label)e.Item.FindControl("lbls18footer");
            Label lbls19footer = (Label)e.Item.FindControl("lbls19footer");
            Label lbls20footer = (Label)e.Item.FindControl("lbls20footer");
            Label lbls21footer = (Label)e.Item.FindControl("lbls21footer");
            Label lbls22footer = (Label)e.Item.FindControl("lbls22footer");
            Label lbls23footer = (Label)e.Item.FindControl("lbls23footer");
            Label lbls24footer = (Label)e.Item.FindControl("lbls24footer");
            Label lbls25footer = (Label)e.Item.FindControl("lbls25footer");
            Label lbls26footer = (Label)e.Item.FindControl("lbls26footer");
            Label lbls27footer = (Label)e.Item.FindControl("lbls27footer");
            Label lbls28footer = (Label)e.Item.FindControl("lbls28footer");

            Label lbls29footer = (Label)e.Item.FindControl("lbls29footer");
            Label lbls30footer = (Label)e.Item.FindControl("lbls30footer");
            Label lbls31footer = (Label)e.Item.FindControl("lbls31footer");

            Label lbltotalFooter = (Label)e.Item.FindControl("lbltotalfooter");
            Label lblbillingtotalFooter = (Label)e.Item.FindControl("lblbillingtotalfooter");
            Label lblDifferenceFooter = (Label)e.Item.FindControl("lblDifferencefooter");

            lbls1footer.Text = daysBRSecond[1].ToString();
            lbls2footer.Text = daysBRSecond[2].ToString();
            lbls3footer.Text = daysBRSecond[3].ToString();
            lbls4footer.Text = daysBRSecond[4].ToString();
            lbls5footer.Text = daysBRSecond[5].ToString();
            lbls6footer.Text = daysBRSecond[6].ToString();
            lbls7footer.Text = daysBRSecond[7].ToString();
            lbls8footer.Text = daysBRSecond[8].ToString();
            lbls9footer.Text = daysBRSecond[9].ToString();
            lbls10footer.Text = daysBRSecond[10].ToString();
            lbls11footer.Text = daysBRSecond[11].ToString();
            lbls12footer.Text = daysBRSecond[12].ToString();
            lbls13footer.Text = daysBRSecond[13].ToString();
            lbls14footer.Text = daysBRSecond[14].ToString();
            lbls15footer.Text = daysBRSecond[15].ToString();
            lbls16footer.Text = daysBRSecond[16].ToString();
            lbls17footer.Text = daysBRSecond[17].ToString();
            lbls18footer.Text = daysBRSecond[18].ToString();
            lbls19footer.Text = daysBRSecond[19].ToString();
            lbls20footer.Text = daysBRSecond[20].ToString();
            lbls21footer.Text = daysBRSecond[21].ToString();
            lbls22footer.Text = daysBRSecond[22].ToString();
            lbls23footer.Text = daysBRSecond[23].ToString();
            lbls24footer.Text = daysBRSecond[24].ToString();
            lbls25footer.Text = daysBRSecond[25].ToString();
            lbls26footer.Text = daysBRSecond[26].ToString();
            lbls27footer.Text = daysBRSecond[27].ToString();
            lbls28footer.Text = daysBRSecond[28].ToString();
            lbls29footer.Text = daysBRSecond[29].ToString();
            lbls30footer.Text = daysBRSecond[30].ToString();
            lbls31footer.Text = daysBRSecond[31].ToString();

            lbltotalFooter.Text = daysBRSecond[32].ToString();
            lblbillingtotalFooter.Text = daysBRSecond[33].ToString();
            lblDifferenceFooter.Text = daysBRSecond[34].ToString();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Clay.Invoice.Bll.Report objRep = new Clay.Invoice.Bll.Report();

            int grpProvider = 0;
            string callTypeName = string.Empty;

            try
            {
                grpProvider = Convert.ToInt32(ddlProvider.SelectedValue);
            }
            catch (Exception ex)
            {
            }

            try
            {
                callTypeName = Convert.ToString(ddlCallType.SelectedValue);
            }
            catch (Exception ex)
            {
            }
            if (callTypeName == "Select Call type")
            {
                callTypeName = "";
            }

            DataSet ds = objRep.rptGetCDRRowData(Convert.ToInt32(ddlFromYear.SelectedValue), Convert.ToInt32(ddlFromMonth.SelectedValue), grpProvider, callTypeName);

            DataSet dsSecond = objRep.rptGetCDRRowData(Convert.ToInt32(ddlYearTo.SelectedValue), Convert.ToInt32(ddlMonthTo.SelectedValue), grpProvider, callTypeName);

            DataTable dtOne = ds.Tables[0]; // bindData(ds);

            if (dtOne.Rows.Count > 0)
            {
                RAFRepeater.DataSource = dtOne;
                RAFRepeater.DataBind();
                RAFRepeater.Visible = true;
                lbltop.Visible = false;
            }
            else
            {
                lbltop.Visible = true;
                lbltop.Text = "Records not found for the Selected Year-Month--" + ddlFromMonth.SelectedItem.Text + "-" + ddlFromYear.SelectedValue;
                RAFRepeater.Visible = false;
            }
            DataTable dtSecond = dsSecond.Tables[0]; //bindData(dsSecond);
            if (dtSecond.Rows.Count > 0)
            {
                rptSecond.Visible = true;
                lblSecond.Visible = false;
                rptSecond.DataSource = dtSecond;
                rptSecond.DataBind();
            }
            else
            {
                lblSecond.Visible = true;
                lblSecond.Text = "Records not found for the Selected Year-Month--" + ddlMonthTo.SelectedItem.Text + "-" + ddlYearTo.SelectedValue;
                rptSecond.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }

    private DataTable bindData(DataSet dsData)
    {

        DataTable dtNewData = new DataTable();

        int grpProviderID = 0;
        try
        {
            dsgRoup = objGetGroup.rptGroupProviderGetAll();
            if (dsgRoup.Tables.Count > 0)
            {
                for (int i = 0; i < dsgRoup.Tables[0].Rows.Count; i++)
                {
                    grpProviderID = Convert.ToInt32(dsgRoup.Tables[0].Rows[i]["groupid"]);

                    DataTable dtTemp = getCDRRow(grpProviderID, dsData.Tables[0]);

                    int[] days = new int[35];

                    if (dtTemp.Rows.Count > 0)
                    {
                        dtNewData.Merge(dtTemp);

                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            for (int iA = 1; iA <= 34; iA++)
                            {
                                int cdrRow = 0;
                                if (iA == 32)
                                {
                                    cdrRow = Convert.ToInt32(dr["stotal"]);
                                }
                                else if (iA == 33)
                                {
                                    cdrRow = Convert.ToInt32(dr["stotalbilling"]);
                                }
                                else if (iA == 34)
                                {
                                    cdrRow = Convert.ToInt32(dr["sdifference"]);
                                }
                                else
                                {
                                    cdrRow = Convert.ToInt32(dr["s" + iA]);
                                }
                                days[iA] += cdrRow;

                            }

                        }

                        dtNewData.Rows.Add(0, 0, "", 0, "Total", days[1], days[2], days[3], days[4], days[5], days[6], days[7], days[8], days[9], days[10], days[11], days[12], days[13], days[14], days[15], days[16], days[17], days[18], days[19], days[20], days[21], days[22], days[23], days[24], days[25], days[26], days[27], days[28], days[29], days[30], days[31], days[32], days[33], days[34]);
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }

        return dtNewData;
    }

    private DataTable getCDRRow(int grpPRoviderID, DataTable dsAll)
    {
        DataTable ds = new DataTable();
        try
        {
            DataRow[] foundRows;
            foundRows = dsAll.Select("providerid=" + grpPRoviderID);
            int i = 0;

            ds = dsAll.Clone();
            for (i = 0; i < foundRows.Length; i++)
            {
                ds.ImportRow(foundRows[i]);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    protected void ddlProvider_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlProvider.SelectedIndex > 0)
            {
                loadCallType();
            }
            else
            {
                ddlCallType.Items.Clear();
            }
        }
        catch (Exception x)
        {
        }
    }
}