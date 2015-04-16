using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for FinanceDataAccess
/// </summary>
public class FinanceDataAccess
{
	public FinanceDataAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    string connString = @"Data Source=CTACCSQLINDEB\MYSQL2008EXPR2;Initial Catalog=aac34; user id=sa; pwd=W/g.QsiL!y*Z";

    # region user defined variables
    string fromdt = string.Empty;

    public string Fromdt
    {
        get { return fromdt; }
        set { fromdt = value; }
    }

    string todt = string.Empty;
    public string Todt
    {
        get {return todt; }
        set {todt = value; }
    }

    string finid = string.Empty;

    public string Finid
    {
        get { return finid; }
        set { finid = value; }
    }

    string ledgerid = string.Empty;
    public string Ledgerid
    {
        get { return ledgerid; }
        set { ledgerid = value; }
    }

    #endregion

    public DataTable GetPlData(string fromdt, string todt,string finid)
    {
        DataTable dt = new DataTable();
        SqlCommand com = new SqlCommand("spu_RepProfitLoss", new SqlConnection(connString));
        com.CommandType = CommandType.StoredProcedure;
        com.CommandTimeout = 36000;
        com.Parameters.Add(new SqlParameter("@FIN_ID",finid));
        com.Parameters.Add(new SqlParameter("@GROUP_ID", "0"));
        com.Parameters.Add(new SqlParameter("@FDATE",fromdt));
        com.Parameters.Add(new SqlParameter("@TDATE",todt));
        com.Parameters.Add(new SqlParameter("@INC_ZERO","1"));
        com.Parameters.Add(new SqlParameter("@LEVEL",2));
        com.Parameters.Add(new SqlParameter("@REP_TYPE",1));
        com.Parameters.Add(new SqlParameter("@USER_ID",1));
        SqlDataAdapter da=new SqlDataAdapter(com);
        da.Fill(dt);
        return dt;
    }
    public string getFinYear(string fromdt,string todt)
    {
        try
        {
            string tempfinid = string.Empty;
            SqlConnection con = new SqlConnection(connString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand com = new SqlCommand("select fin_id from fin_year where (fdate<='" + fromdt + "' and tdate>= '" + fromdt + "')", con);

            com.CommandType = CommandType.Text;
            tempfinid = com.ExecuteScalar().ToString();
            return tempfinid;
            con.Close();
            SqlConnection.ClearPool(con);
        }
        catch (Exception)
        {
            
            throw;
        }
        
    }
    public DataTable GetVoucherBreakup(string ledgerid, string fromdt, string todt)
    {
        try
        {
            DataTable dt = new DataTable();
            string sql = string.Empty;
            //sql = "select POSTVCH_ID,pv.POST_ID,DR_AMT,CR_AMT,VCH_REMARK,CONVERT(VARCHAR(10), DOC_DATE, 105) as DOC_DATE,party.PA_NAME from POSTVCH pv inner join POST on pv.POST_ID=post.POST_ID";
            //sql += " inner join PARTY party on pv.LEDGER_ID=party.PA_ID where pv.LEDGER_ID='" + ledgerid + "' and post.DOC_DATE between '" + fromdt + "' and '" + todt + "' order by post.DOC_DATE";
            sql += "select POSTVCH_ID,pv.POST_ID,pv.DR_AMT,pv.CR_AMT,pv.VCH_REMARK,CONVERT(VARCHAR(10), DOC_DATE, 105) as DOC_DATE,party.PA_NAME from POSTVCH pv"; 
            sql+=" inner join PARTY party on pv.LEDGER_ID=party.PA_ID inner join POST post on pv.POST_ID=post.POST_ID and post.DOC_DATE between '" + fromdt + "' and '" + todt + "'";
            sql += " and pv.POST_ID in (select POST_ID from POSTVCH pv where pv.LEDGER_ID='" + ledgerid + "') and pv.CR_AMT<>0 order by post.DOC_DATE,post_id";            
            SqlConnection con = new SqlConnection(connString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandTimeout = 36000;
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            return dt;
            con.Close();
            SqlConnection.ClearPool(con);
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
        
    }
    public DataTable GetNetworkList()
    {
        try
        {
            DataTable dt = new DataTable();
            string sql = "select networkid,networkname from NETWORKMAST where isActive=1";
            SqlConnection con = new SqlConnection(connString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandTimeout = 36000;
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            return dt;
            con.Close();
            SqlConnection.ClearPool(con);
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
    public DataTable GetNetworkPurchase(string fromdt, string todt, string networkid,string reptype)
    {
        DataTable dt = new DataTable();
        SqlCommand com = new SqlCommand("sp_party_purchase", new SqlConnection(connString));
        com.CommandType = CommandType.StoredProcedure;
        com.CommandTimeout = 36000;
        com.Parameters.Add(new SqlParameter("@fromdt", fromdt));
        com.Parameters.Add(new SqlParameter("@todate", todt));
        com.Parameters.Add(new SqlParameter("@partyid", networkid));
        com.Parameters.Add(new SqlParameter("@reptype", reptype));
        SqlDataAdapter da = new SqlDataAdapter(com);
        da.Fill(dt);
        return dt;
    }
    
}