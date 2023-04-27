using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroEcommerceLibrary.Buyer
{

    public class BALBuyer
    {
        // SqlConnection con = new SqlConnection("Data Source=AKASH\\SQLEXPRESS;Initial Catalog=GSTAgroE-Commerce;Integrated Security=True");
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-G0RI5B8;Initial Catalog=GSTAgroE-Commerce;Integrated Security=True");

        //public SqlDataReader LogIn(Buyer buyer)
        //{
        //    if (con.State == System.Data.ConnectionState.Closed)
        //    {
        //        con.Open();
        //    }

        //    SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@flag", "login");
        //    cmd.Parameters.AddWithValue("@emailid", buyer.EmailId);
        //    cmd.Parameters.AddWithValue("@password", buyer.Password);
        //    //cmd.Parameters.AddWithValue("@buyerfullname", buyername);
        //    //cmd.Parameters.AddWithValue("@buyercode", buyercode);

        //    SqlDataReader dr = cmd.ExecuteReader();
        //    return dr;
        //    con.Close();

        //}
        //public SqlDataReader ExtrnalLogIn(Buyer buyers)
        //{
        //    if (con.State == System.Data.ConnectionState.Closed)
        //    {
        //        con.Open();
        //    }

        //    SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@flag", "CheckExtranalLogin");
        //    cmd.Parameters.AddWithValue("@emailid",buyers.EmailId);
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    return dr;
        //    con.Close();
        //}

        //public void ResisterExtrnalLogIn(Buyer buyers)
        //{
        //    if (con.State == System.Data.ConnectionState.Closed)
        //    {
        //        con.Open();
        //    }
        //    SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@flag", "RegisterExtrLogin");
        //    cmd.Parameters.AddWithValue("@emailid",buyers.EmailId);
        //    cmd.Parameters.AddWithValue("@buyercode",buyers.BuyerCode);
        //    cmd.Parameters.AddWithValue("@buyerfullname", buyers.BuyerFullName );
        //    cmd.Parameters.AddWithValue("@registrationdate",buyers.RegistrationDate);
        //    cmd.ExecuteNonQuery();

        //}

        public void AddToWishList(Buyer buyers)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AddToCartAndWishList");
            cmd.Parameters.AddWithValue("@OrderCode",buyers.OrderCode );
            cmd.Parameters.AddWithValue("@buyercode",buyers.BuyerCode );
            cmd.Parameters.AddWithValue("@productcode",buyers.ProductCode);
            cmd.Parameters.AddWithValue("@OrderStatusId",buyers.OrderStatusId);
            cmd.Parameters.AddWithValue("@IsNotify",buyers.IsNotify);

            cmd.ExecuteNonQuery();

        }

        public void AddToCart(Buyer buyers)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AddToCartAndWishList");
            cmd.Parameters.AddWithValue("@OrderCode",buyers.OrderCode );
            cmd.Parameters.AddWithValue("@buyercode",buyers.BuyerCode );
            cmd.Parameters.AddWithValue("@productcode",buyers.ProductCode );
            cmd.Parameters.AddWithValue("@OrderStatusId",buyers.OrderStatusId);
            cmd.ExecuteNonQuery();

        }
        public void UpdateStatusAndAddToCart(Buyer buyers) 
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "UpdateOrderAndToCart");
            cmd.Parameters.AddWithValue("@buyercode",buyers.BuyerCode);
            cmd.Parameters.AddWithValue("@productcode",buyers.ProductCode);
            //cmd.Parameters.AddWithValue("@OrderStatusId", orderstatusid);
            cmd.ExecuteNonQuery();

        }

        public SqlDataReader CheckProductInwishList(Buyer buyers)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "CheckProductInWishList");
            cmd.Parameters.AddWithValue("@buyercode",buyers.BuyerCode);
            cmd.Parameters.AddWithValue("@productcode", buyers.ProductCode);

            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }
            public SqlDataReader CheckProductInCart(Buyer buyers) 
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flag", "CheckProductInCart");
                cmd.Parameters.AddWithValue("@buyercode", buyers.BuyerCode );
                cmd.Parameters.AddWithValue("@productcode",buyers.ProductCode);

                SqlDataReader dr2 = cmd.ExecuteReader();
                return dr2;
                con.Close();
            }

            public void RemoveFromWishList(Buyer buyer)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RemoveFromWishList");
            cmd.Parameters.AddWithValue("@OrderCode", buyer.OrderCode);
            cmd.Parameters.AddWithValue("@buyercode",buyer.BuyerCode);
            cmd.Parameters.AddWithValue("@productcode",buyer.ProductCode);
            cmd.Parameters.AddWithValue("@OrderStatusId", buyer.OrderStatusId);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public SqlDataReader GenerateOrderCode()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GenerateOrderCode");
            SqlDataReader dr1;
            dr1 = cmd.ExecuteReader();
            return dr1;
            con.Close();


        }

        public SqlDataReader CheckProductInOrder(Buyer buyers) 
        {
            if (con.State==System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "CheckPoductInOrder");
            ////Check Product in Order Table And Update OrderStatusId And set product in Cart  
            cmd.Parameters.AddWithValue("@buyercode",buyers.BuyerCode);
            cmd.Parameters.AddWithValue("@productcode",buyers.ProductCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
        }

       
        public DataSet SearchData(string prosearch)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "SerarchWithImage");
            cmd.Parameters.AddWithValue("@productname", prosearch);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();

        }
        public DataSet CategoeryShow()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {

                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetCategory");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
            con.Close();


        }
        ///All Product Show\\\
        public DataSet ShowAllProducts()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ShowAllProducts");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();

        }
       
        public DataSet ShowCatProducts(int id)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ShowCatProd");
            cmd.Parameters.AddWithValue("@categoryid", id);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }

        
        //////View Product Details
        public DataSet ViewProductDetails(Buyer buyer)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ViewProductDetails");
            cmd.Parameters.AddWithValue("@productcode", buyer.ProductCode);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }


     

        /// //GET CATEGORY

        public DataSet GetCategory()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetCategory");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();


        }

        public DataSet WishList(Buyer buyers)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "WishList");
            cmd.Parameters.AddWithValue("@BuyerCode",buyers.BuyerCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

            con.Close();
        }
        public void AddCart(string buyercode, string productcode)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "Cart");
            cmd.Parameters.AddWithValue("@BuyerCode", buyercode);
            cmd.Parameters.AddWithValue("@ProductCode", productcode);
            cmd.ExecuteNonQuery();
            con.Close();




        }
        public void DeleteWishlist( string buyercode,string productcode)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RemoveFromWishList");
            cmd.Parameters.AddWithValue("@ProductCode", productcode);
            cmd.Parameters.AddWithValue("@buyercode", buyercode);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        //Prathamesh Start//
        public DataSet GetProductDetails()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetProductDetailPN");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
            con.Close();
        }

        //SummerProducts
        public DataSet GetSUmmerProducts()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetSummerPN");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
            con.Close();
        }

        //WinterProducts
        public DataSet GetWinterProducts()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetWinterProductPN");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
            con.Close();
        }

        //RainyProducts
        public DataSet GetRainyProducts()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetRainyProductPN");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
            con.Close();
        }
        //Prathamesh End//
        ///Dhanashri start
        ///
         /////Dhanashri start
        public DataSet OrderHistory(Buyer obj)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RemainingOrders");
            cmd.Parameters.AddWithValue("@BuyerCode", obj.BuyerCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();

        }
        public DataSet FilterButtons()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "StatusWiseFilter");

            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();

        }
        public DataSet ShowStatusWiseOrders(Buyer obj, int StatusId)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ShowStatusWiseOrders");
            cmd.Parameters.AddWithValue("@BuyerCode", obj.BuyerCode);
            cmd.Parameters.AddWithValue("@OrderStatusId", StatusId);

            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();

        }
        public SqlDataReader TrackOrder(Buyer obj)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "TrackOrder");
            cmd.Parameters.AddWithValue("@OrderCode", obj.OrderNo);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

            con.Close();

        }
        public SqlDataReader OrderDetails(Buyer obj)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "fetchOrderDetails");
            cmd.Parameters.AddWithValue("@OrderCode", obj.OrderNo);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

            con.Close();

        }
        public void CancelOrder(string OrderNo, string buyercode, string RejectionReason)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "CancelOrder");
            cmd.Parameters.AddWithValue("@OrderCode", OrderNo);
            cmd.Parameters.AddWithValue("@RejectedByUserCode", buyercode);
            cmd.Parameters.AddWithValue("@RejectionReason", RejectionReason);
            cmd.Parameters.AddWithValue("@ProcessDate", DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void RefundRequest(Buyer obj)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RefundRequest");
            cmd.Parameters.AddWithValue("@OrderCode", obj.OrderNo);
            cmd.Parameters.AddWithValue("@ProcessDate", DateTime.Now);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public SqlDataReader WalletCount(Buyer obj)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "WalletCount");
            cmd.Parameters.AddWithValue("@BuyerCode", obj.BuyerCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

            con.Close();

        }
        public DataSet MyWallet(Buyer obj)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "MyWallet");
            cmd.Parameters.AddWithValue("@BuyerCode", obj.BuyerCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();

        }
        public SqlDataReader ViewTandC()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ViewTandC");
            // cmd.Parameters.AddWithValue("@BuyerCode", buyercode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

            con.Close();

        }
        ///Dhanashri End
    }
}
