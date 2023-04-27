using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroEcommerceLibrary.Admin
{
    public class BALAdmin
    {

      //  SqlConnection con = new SqlConnection("Data Source=AKASH\\SQLEXPRESS;Initial Catalog=GSTAgroE-Commerce;Integrated Security=True");
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-G0RI5B8;Initial Catalog=GSTAgroE-Commerce;Integrated Security=True");

        /////////-----------Prathmesh Start-----------////////
        public DataSet GetProductAdmin()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetProductAdminPN");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
            con.Close();
        }
        public DataSet GetSearchbyCategory(int CategoryId)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SearchByCategoryPN");
            cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
            con.Close();
        }
        public DataSet GetCatergory()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "CategorynamePN");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
            con.Close();
        }
        public DataSet GetSearchbySeller(int SellerId)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SearchBySellerPN");
            cmd.Parameters.AddWithValue("@SellerId", SellerId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
            con.Close();
        }
        public DataSet GetsellerName()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SellerNamePN");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
            con.Close();
        }
        //////----------Prathmesh Start-----------////////
    }
}
