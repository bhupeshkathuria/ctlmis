using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for DataAccess
/// </summary>
public static class DataAccess
{
    //static string connectionString = @"server=208.74.79.47\SQLEXPRESS2008;uid=sa;pwd=f@LC0N#S@!25@(;Initial Catalog=Clay.Prepaid;Timeout=600;";

    static string connectionString = @"server=119.9.95.40\SQLEXPRESS;uid=sa;pwd=f@LC0N#S@!25@(;Initial Catalog=Clay.Prepaid;Timeout=600;";

   public static DataTable GetYearBusTypeSale(int Year, short BusTypeId)
   {
       DataTable dt = new DataTable();
           SqlCommand cmd = new SqlCommand("GetYearBusTypeSale", new SqlConnection(connectionString));
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.Add(new SqlParameter("@year", Year));
       cmd.Parameters.Add(new SqlParameter("@bustypeid", BusTypeId));
       SqlDataAdapter sda = new SqlDataAdapter(cmd);
       sda.Fill(dt);
       return dt;
   }

   public static DataTable GetBusTypeMonthlySale(int Year, short Month)
   {
       DataTable dt = new DataTable();
       SqlCommand cmd = new SqlCommand("getBusTypeMonthlySale", new SqlConnection(connectionString));
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.Add(new SqlParameter("@year", Year));
       cmd.Parameters.Add(new SqlParameter("@month", Month));
       SqlDataAdapter sda = new SqlDataAdapter(cmd);
       sda.Fill(dt);
       return dt;
   }

   public static DataTable GetBranchWiseMonthlySale(int Year,int month, short BusTypeId)
   {
       DataTable dt = new DataTable();
       SqlCommand cmd = new SqlCommand("GetBranchWiseMonthlySale", new SqlConnection(connectionString));
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.Add(new SqlParameter("@year", Year));
       cmd.Parameters.Add(new SqlParameter("@month", month));
       cmd.Parameters.Add(new SqlParameter("@bustypeid", BusTypeId));
       SqlDataAdapter sda = new SqlDataAdapter(cmd);
       sda.Fill(dt);
       return dt;
   }

   public static DataTable GetRechageSourceWise(int Year, int month, short BusTypeId)
   {
       DataTable dt = new DataTable();
       SqlCommand cmd = new SqlCommand("GetRechageSourceWise", new SqlConnection(connectionString));
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.Add(new SqlParameter("@year", Year));
       cmd.Parameters.Add(new SqlParameter("@month", month));
       cmd.Parameters.Add(new SqlParameter("@bustypeid", BusTypeId));
       SqlDataAdapter sda = new SqlDataAdapter(cmd);
       sda.Fill(dt);
       return dt;
   }
   public static DataTable GetSalesPrepaidBranchAccountManagerWisewithsort(int yearFrom, int yearTo, int _strSaleBranch, int accmgrid)
   {
       DataTable dt = new DataTable();
       try
       {
           SqlCommand cmd = new SqlCommand("sp_get_sale_yearly", new SqlConnection(connectionString));
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.Add(new SqlParameter("@fromyear", yearFrom));
           cmd.Parameters.Add(new SqlParameter("@toyear", yearTo));
           cmd.Parameters.Add(new SqlParameter("@erpbranchid", _strSaleBranch));
           cmd.Parameters.Add(new SqlParameter("@erpemployee", accmgrid));
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           sda.Fill(dt);
       }
       catch (Exception ex)
       {
           ex = null;
       }
       return dt;
   }

}