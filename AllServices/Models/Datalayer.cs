using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AllServices.Models;
using System.Data;
using System.Web.Helpers;
using System.Web.Services.Description;
using System.Xml.Linq;
using System.Drawing;
using System.IO;

namespace AllServices.Models
{
    public class Datalayer
    {
       string connectionstring=("Data Source=DESKTOP-N0O3B2D\\MSSQLSERVER02;Initial Catalog=Allservice;Integrated Security=True");



        private DataTable executeProcedureForDataTableWithOutParameter(string procedureName, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    DataTable dataTable = new DataTable();

                    connection.Open();

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                    }

                    return dataTable;
                }
            }
        }


        public bool regster(AllDetails reg)
        {
            {
                SqlConnection con = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand("usp_InsertRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@First_Name", reg.First_Name);
                cmd.Parameters.AddWithValue("@Last_Name", reg.Last_Name);
                cmd.Parameters.AddWithValue("@Email_Id", reg.Email_Id);
                cmd.Parameters.AddWithValue("@Mobile", reg.Mobile);
                cmd.Parameters.AddWithValue("@Password", reg.Password);
                cmd.Parameters.AddWithValue("@Re_Password", reg.Re_Password);
                cmd.Parameters.AddWithValue("@DateTime",DateTime.Now);
                cmd.Parameters.AddWithValue("@IsActive", 1);
              
                con.Open();
                int i=cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return true;
                }
                else 
                { 
                    return false;
                }

            }
        }



        public bool Contact(Contactus contactus) 
        {
            {
               SqlConnection conn = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand("INSERT_CONTACT", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", contactus.Name);
                cmd.Parameters.AddWithValue("@Email", contactus.Email);
                cmd.Parameters.AddWithValue("@Message", contactus.Message);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal DataTable Getstate(string procedure)
        {
            SqlParameter[] par = new SqlParameter[0];
            return executeProcedureForDataTableWithOutParameter(procedure, par);
        }

        internal DataTable getDistrictByState(string state)
        {
            return executeProcedureForDataTableWithParameter("proc_district", state);
        }
        public DataTable executeProcedureForDataTableWithParameter(string procedure, string state)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                using (SqlCommand cmd = new SqlCommand(procedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@stateid", state);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }

                conn.Close();
            }

            return dt;
        }

        internal DataTable getcitybyDistrict(string district)
        {

            return executeProcedureForDataTableWithparameter("proc_city", district);
        }

        public DataTable executeProcedureForDataTableWithparameter(string procedure, string district)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                using (SqlCommand cmd = new SqlCommand(procedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@districtid", district);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
                conn.Close();
            }
            return dataTable;
        }

        public bool uploadservices(AllDetails ad)
        {
            {

                SqlConnection con = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand("Proc_UploadServices", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ShopName", ad.ShopName);
                cmd.Parameters.AddWithValue("@State", ad.State);
                cmd.Parameters.AddWithValue("@District", ad.District);
                cmd.Parameters.AddWithValue("@City", ad.City);
                cmd.Parameters.AddWithValue("@OpeningTime", ad.OpeningTime);
                cmd.Parameters.AddWithValue("@ClosingTime", ad.ClosingTime);
                cmd.Parameters.AddWithValue("@MobileNumber", ad.MobileNumber);
                cmd.Parameters.AddWithValue("@Image","path");
                cmd.Parameters.AddWithValue("@Services", ad.Services);
                cmd.Parameters.AddWithValue("@IsActive", 1);
                con.Open();
                int i=cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                con.Close();
            }
        }
    }
}

