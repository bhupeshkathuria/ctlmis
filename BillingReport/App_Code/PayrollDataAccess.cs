using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for PayrollDataAccess
/// </summary>
public class PayrollDataAccess
{
	public PayrollDataAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    string connString = @"Data Source=CTACCSQLINDEB\MYSQL2008EXPR2;Initial Catalog=FB45; user id=sa; pwd=W/g.QsiL!y*Z";

    public DataTable GetDeptSalary()
    {
        try
        {
            SqlConnection con = new SqlConnection(connString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "select emp.dept as deptid,allmst.field_name as deptname,SUM(emps.amount) as TotalSal from EMP inner join EMPS on emp.EMP_ID=emps.EMP_ID inner join ALLMST on emp.DEPT=ALLMST.ID and ALLMST.TABLE_NAME='DEPT' where emp.DOR is null group by emp.dept,ALLMST.FIELD_NAME order by allmst.field_name";
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            return dt;
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public DataTable GetEmpSalary(string deptid)
    {
        try
        {
            SqlConnection con = new SqlConnection(connString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string sql = "select emp.EMP_CODE,emp.EMP_NAME,loc.LOCATION,SUM(emps.amount) as TotalSal from EMP inner join EMPS on emp.EMP_ID=emps.EMP_ID inner join ALLMST on emp.DEPT=ALLMST.ID and ALLMST.TABLE_NAME='DEPT' inner join LOCATION loc on loc.ID=emp.LOCATION where emp.DEPT='" + deptid + "' and emp.DOR is null group by emp.emp_code,emp.EMP_NAME,loc.LOCATION order by loc.location,emp.emp_name";
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            return dt;
        }
        catch (Exception)
        {

            throw;
        }
    }
}