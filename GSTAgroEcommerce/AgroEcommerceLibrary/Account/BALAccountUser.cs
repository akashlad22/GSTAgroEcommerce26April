﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroEcommerceLibrary.AccountUser
{
    public class BALAccountUser
    {
        SqlConnection con = new SqlConnection("Data Source=AKASH\\SQLEXPRESS;Initial Catalog=GSTAgroE-Commerce;Integrated Security=True");

        public SqlDataReader LogIn(AccountUser user)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "login");
            cmd.Parameters.AddWithValue("@emailid", user.EmailId);
            cmd.Parameters.AddWithValue("@password", user.Password);
            //cmd.Parameters.AddWithValue("@buyerfullname", buyername);
            //cmd.Parameters.AddWithValue("@buyercode", buyercode);

            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
            con.Close(); 

        }
        public SqlDataReader LogInSeller(AccountUser user)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "loginseller");
            cmd.Parameters.AddWithValue("EmailId", user.EmailId);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            //cmd.Parameters.AddWithValue("@buyerfullname", buyername);
            //cmd.Parameters.AddWithValue("@buyercode", buyercode);

            SqlDataReader dr1 = cmd.ExecuteReader();
            return dr1;
            con.Close();

        }
        public SqlDataReader LogInAdmin(AccountUser user)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "loginadmin");
            cmd.Parameters.AddWithValue("@EmailId", user.EmailId);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            //cmd.Parameters.AddWithValue("@buyerfullname", buyername);
            //cmd.Parameters.AddWithValue("@buyercode", buyercode);

            SqlDataReader dr2 = cmd.ExecuteReader();
            return dr2;
            con.Close();

        }
        public SqlDataReader ExtrnalLogIn(AccountUser user)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "CheckExtranalLogin");
            cmd.Parameters.AddWithValue("@emailid", user.EmailId);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }

        public void ResisterExtrnalLogIn(AccountUser user)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "RegisterExtrLogin");
            cmd.Parameters.AddWithValue("@emailid", user.EmailId);
            cmd.Parameters.AddWithValue("@buyercode", user.BuyerCode);
            cmd.Parameters.AddWithValue("@buyerfullname", user.BuyerFullName);
            cmd.Parameters.AddWithValue("@registrationdate", user.RegistrationDate);
            cmd.ExecuteNonQuery();

        }
    }
}
