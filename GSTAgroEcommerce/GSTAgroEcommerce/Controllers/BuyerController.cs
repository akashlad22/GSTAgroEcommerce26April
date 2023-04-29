using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using System.Web.WebPages;
using AgroEcommerceLibrary.Buyer;
using System.Web.Security;
using System.Threading.Tasks;
using System.Net;
using GoogleAuthentication.Services;
using System.Web.Script.Serialization;
using System.Security.Cryptography;

namespace GSTAgroEcommerce.Controllers
{
    public class BuyerController : Controller
    {
        BALBuyer obj = new BALBuyer();
        string Code;
        // GET: Buyer
      
        //Prathamesh Start..............//
        public ActionResult Index()
        {                                                   // summerProducts
            Buyer objU = new Buyer();
            int Months = Convert.ToInt32(DateTime.Now.Month.ToString());
            if (Months >= 2 && Months <= 5)
            {
                BALBuyer objBa = new BALBuyer();
                DataSet DS1 = new DataSet();
                DS1 = objBa.GetSUmmerProducts();

                List<Buyer> listBuy1 = new List<Buyer>();
                for (int i = 0; i < DS1.Tables[0].Rows.Count; i++)
                {
                    Buyer ObjB = new Buyer();
                    ObjB.ProductName = DS1.Tables[0].Rows[i]["ProductName"].ToString();
                    ObjB.MRP = Convert.ToInt32(DS1.Tables[0].Rows[i]["MRP"].ToString());
                    ObjB.ProductCode = DS1.Tables[0].Rows[i]["ProductCode"].ToString();
                    ObjB.Quantity = Convert.ToInt32(DS1.Tables[0].Rows[i]["Quantity"].ToString());
                    string Image = DS1.Tables[0].Rows[i]["MainImage"].ToString();
                    string path = "/Content/Images/Product/";
                    ObjB.MainImage = string.Concat(path, Image);
                    listBuy1.Add(ObjB);
                }
                objU.Season = listBuy1;
                //return View(objU);

            }
            else if (Months >= 6 && Months <= 9)
            {                                              //WinterProducts
                BALBuyer objBa = new BALBuyer();
                DataSet DS1 = new DataSet();
                DS1 = objBa.GetWinterProducts();
                // Buyer objU = new Buyer();
                List<Buyer> listBuy1 = new List<Buyer>();
                for (int i = 0; i < DS1.Tables[0].Rows.Count; i++)
                {
                    Buyer ObjB = new Buyer();
                    ObjB.ProductName = DS1.Tables[0].Rows[i]["ProductName"].ToString();
                    ObjB.MRP = Convert.ToInt32(DS1.Tables[0].Rows[i]["MRP"].ToString());
                    ObjB.ProductCode = DS1.Tables[0].Rows[i]["ProductCode"].ToString();
                    ObjB.Quantity = Convert.ToInt32(DS1.Tables[0].Rows[i]["Quantity"].ToString());
                    string Img = DS1.Tables[0].Rows[i]["MainImage"].ToString();
                    string path = "/Content/Images/Product/";
                    ObjB.MainImage = string.Concat(path, Img);
                    listBuy1.Add(ObjB);
                }
                objU.Season = listBuy1;
                // return View(objU);

            }
            else if (Months >= 10 && Months <= 1)
            {                                                  //RainyProducts
                BALBuyer objBa = new BALBuyer();
                DataSet DS1 = new DataSet();
                DS1 = objBa.GetRainyProducts();
                //  Buyer objU = new Buyer();
                List<Buyer> listBuy1 = new List<Buyer>();
                for (int i = 0; i < DS1.Tables[0].Rows.Count; i++)
                {
                    Buyer ObjB = new Buyer();
                    ObjB.ProductName = DS1.Tables[0].Rows[i]["ProductName"].ToString();
                    ObjB.MRP = Convert.ToInt32(DS1.Tables[0].Rows[i]["MRP"].ToString());
                    ObjB.ProductCode = DS1.Tables[0].Rows[i]["ProductCode"].ToString();
                    ObjB.Quantity = Convert.ToInt32(DS1.Tables[0].Rows[i]["Quantity"].ToString());
                    string Image = DS1.Tables[0].Rows[i]["MainImage"].ToString();
                    string path = "/Content/Images/Product/";
                    ObjB.MainImage = string.Concat(path, Image);
                    listBuy1.Add(ObjB);
                }
                objU.Season = listBuy1;
                // return View(objU);

            }
            //ProductsDetails
            BALBuyer OBjA = new BALBuyer();
            DataSet DSB = new DataSet();
            DSB = OBjA.GetProductDetails();  /////////////Get Top Selling Products
            // Buyer objBUY = new Buyer();
            List<Buyer> listBuy = new List<Buyer>();
            for (int i = 0; i < DSB.Tables[0].Rows.Count; i++)
            {
                Buyer ObjB = new Buyer();
                ObjB.ProductName = DSB.Tables[0].Rows[i]["ProductName"].ToString();
                ObjB.MRP = Convert.ToInt32(DSB.Tables[0].Rows[i]["MRP"].ToString());
                ObjB.ProductCode =DSB.Tables[0].Rows[i]["ProductCode"].ToString();
                ObjB.Quantity = Convert.ToInt32(DSB.Tables[0].Rows[i]["Quantity"].ToString());
                string Image = DSB.Tables[0].Rows[i]["MainImage"].ToString();
                string path = "/Content/Images/Product/";
                ObjB.MainImage = string.Concat(path, Image);



                listBuy.Add(ObjB);


            }
            objU.BestSeller = listBuy;
            return View(objU);



        }
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //----------------Prathamesh End----------------//

        public async Task<ActionResult> SearchProducts(string prosearch)////Search Product In Search engin////
        {
            DataSet ds = new DataSet();
            ds = obj.SearchData(prosearch);
            Buyer objU = new Buyer();
            List<Buyer> productlist = new List<Buyer>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                productlist.Add(new Buyer
                {

                    ProductName = dr["ProductName"].ToString(),
                    ProductCode = dr["ProductCode"].ToString(),
                    MRP = Convert.ToInt32(dr["MRP"].ToString()),
                    MainImage = dr["MainImage"].ToString(),
                    StatusId = Convert.ToInt32(dr["StatusId"].ToString()),
                    Quantity = Convert.ToInt32(dr["Quantity"].ToString()),

                });

                objU.products = productlist;
            }
           

            return await Task.Run(()=> View(objU));
        }
        public async Task <ActionResult> ShowProdDetails(Buyer buyer)/////Show Product Details///
        {
            // Buyer buyer = new Buyer();
            string productcode =buyer.ProductCode;
            DataSet ds = new DataSet();
            ds = obj.ViewProductDetails(buyer);
            List<Buyer> prodDetails = new List<Buyer>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Buyer objU = new Buyer();
                objU.ProductCode = dr["ProductCode"].ToString();
                objU.ProductName = dr["ProductName"].ToString();
                objU.MainImage = dr["MainImage"].ToString();
                objU.Image1 = dr["Image1"].ToString();
                objU.Image2 = dr["Image2"].ToString();
                objU.Image3 = dr["Image3"].ToString();
                objU.MRP = Convert.ToInt32(dr["MRP"].ToString());
                objU.Description = dr["Description"].ToString();
                objU.ProductWeight = dr["ProductWeight"].ToString();
                objU.IsproductExpirable = dr["IsproductExpirable"].ToString() == "True";
                objU.IsProductReturnable = dr["IsProductReturnable"].ToString() == "True";
                objU.StatusId = Convert.ToInt32(dr["StatusId"].ToString());
                objU.Quantity = Convert.ToInt32(dr["Quantity"].ToString());
                prodDetails.Add(objU);
            }
            buyer.products = prodDetails;

            Session["url"] = HttpContext.Request.Url.AbsoluteUri;      ///// Get page url
            //Session["ProductCodeForWishList"] = obj1PD.ProductCode;
            return await Task.Run(()=> View(buyer));
        }
        public async Task <ActionResult> AddToWishList(string jsonproductcode, int qty)/////Add to WishList/////
        {
            try
            {
                if (Session["BuyerCode"] != null)
                {
                    //var serializer = new JavaScriptSerializer();
                    //dynamic productcode = serializer.Deserialize(jsonproductcode, typeof(object));
                    //Get your variables here from AJAX call
                    // var productcode = Convert.ToInt32(jsondata["id"]);

                    Buyer obj1 = new Buyer();
                    obj1.BuyerCode = Session["BuyerCode"].ToString();
                    obj1.ProductCode = jsonproductcode;
                   
                    obj1.OrderStatusId = 18;
                    SqlDataReader dr;
                    dr = obj.CheckProductInwishList(obj1);
                    if (dr.Read())
                    {
                        obj1.BuyerCode = dr["BuyerCode"].ToString();
                        obj1.ProductCode = dr["ProductCode"].ToString();
                        obj1.OrderStatusId = Convert.ToInt32(dr["OrderStatusId"].ToString());
                        obj1.OrderCode = dr["OrderCode"].ToString();
                    }
                   // Session["OrderCodeShowWishlistProduct"] = obj1.OrderCode;

                    dr.Close();
                    if (obj1.OrderCode != null)
                    {
                        string ordercode = obj1.OrderCode;

                        obj.RemoveFromWishList(obj1);

                        return await Task.Run(()=> Json(new { status = "false", msg = "Remove From WishList" }));
                    }
                    if (obj1.OrderCode == null)
                    {
                        SqlDataReader dr1;
                        dr1 = obj.GenerateOrderCode();
                        while (dr1.Read())
                        {
                            int generatecode = Convert.ToInt32(dr1["Id"].ToString());
                            generatecode = generatecode + 1;
                            string Id = "OD0";
                            Code = Id + generatecode;
                        }
                        dr1.Close();

                        obj1.OrderCode = Code;
                        string addordercode = obj1.OrderCode;
                        bool isnotify;
                        isnotify = obj1.IsNotify;
                        if (qty == 0)        ////////////////////////Update IsNotify when Product OutOf Stock
                        {
                            obj1.IsNotify = true;
                            obj.AddToWishList(obj1);
                            ////Add Product In WishList with Notify
                        }
                        else
                        {
                            obj1.IsNotify = false;
                            obj.AddToWishList(obj1);
                            ////Add Product In WishList with Notify
                        }

                        return await Task.Run(()=>Json(new { status = "true", msg = "Add To WishList" }));
                    }
                    //Session["OrderCodeForWishList"] = obj1.OrderCode;

                    //Session["OrderStatusForWishList"] = 18;


                }
                else
                {
                    //var result = new { data = "error" };
                    //return Json (result,JsonRequestBehavior.AllowGet);
                    return await Task.Run(()=> RedirectToAction("Login"));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return await Task.Run(()=> View());
        }
        
        public async Task<ActionResult> WishListGrid(Buyer buyers)////// Buyer WishList View////
        {
            if (Session["BuyerCode"] != null)
            {
               buyers.BuyerCode = Session["BuyerCode"].ToString();
                DataSet ds = new DataSet();
                ds = obj.WishList(buyers);
                Buyer prdDetails = new Buyer();
                List<Buyer> LstProducts = new List<Buyer>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Buyer obj1 = new Buyer();

                    obj1.MainImage = (ds.Tables[0].Rows[i]["MainImage"].ToString());
                    obj1.ProductCode = (ds.Tables[0].Rows[i]["ProductCode"].ToString());
                    obj1.ProductName = (ds.Tables[0].Rows[i]["ProductName"].ToString());
                    obj1.MRP = Convert.ToInt32(ds.Tables[0].Rows[i]["MRP"].ToString());
                    obj1.StatusId = Convert.ToInt32(ds.Tables[0].Rows[i]["StatusId"].ToString());
                    obj1.Quantity = Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"].ToString());
                    LstProducts.Add(obj1);

                }
                prdDetails.products = LstProducts;

               
                return await Task.Run(()=> View(prdDetails));
            }
            else
            {
                return  await Task.Run(()=> RedirectToAction("Login"));
            }
        }

        [HttpGet]
        public async Task<ActionResult> DeleteFromWishList(string productcode)/////Delete From WishList///
        {
            if (Session["BuyerCode"] != null)
            {
                Buyer obj1 = new Buyer();
                string buyercode = Session["BuyerCode"].ToString();

                obj.DeleteWishlist(buyercode, productcode);
            }
            var result = new { data = "Delete" };
           // return RedirectToAction("WishListGrid");
           return await Task.Run(()=> Json(result,JsonRequestBehavior.AllowGet));
        }

        public async Task< ActionResult> AddToCart(string productcode)//////Add to Cart////
        {
            if (Session["BuyerCode"] != null)
            {
                Buyer obj1 = new Buyer();
                obj1.BuyerCode = Session["BuyerCode"].ToString();
                obj1.ProductCode = productcode;
                SqlDataReader dr = obj.CheckProductInOrder(obj1);

                if (dr.Read())
                {
                    obj1.BuyerCode = dr["BuyerCode"].ToString();
                    obj1.OrderCode = dr["OrderCode"].ToString();
                    obj1.ProductCode = dr["ProductCode"].ToString();
                    obj1.OrderStatusId = Convert.ToInt32(dr["OrderStatusId"].ToString());
                }
                dr.Close();
                if (obj1.OrderStatusId == 18)
                {
                    SqlDataReader dr2 = obj.CheckProductInCart(obj1);
                    if (dr2.Read())
                    {
                        obj1.BuyerCode = dr2["BuyerCode"].ToString();
                        obj1.OrderCode = dr2["OrderCode"].ToString();
                        obj1.ProductCode = dr2["ProductCode"].ToString();
                        obj1.OrderStatusId = Convert.ToInt32(dr2["OrderStatusId"].ToString());
                    }
                    dr2.Close();
                    if (obj1.OrderStatusId == 19)
                    {
                        return await Task.Run(()=> Json(new { status = "true", msg = "Already In Cart" }));

                    }
                    if (obj1.OrderStatusId == 18)
                    {
                      
                        //int orderstatusid = 19;
                        obj.UpdateStatusAndAddToCart(obj1);
                        return await Task.Run(()=> Json(new { status = "New", msg = "Add To Cart" }));
                    }

                }
                if (obj1.OrderStatusId == 19)
                {
                    return await Task.Run(()=>Json(new { status = "true", msg = "Already In Cart" }));
                }
                if (obj1.OrderCode == null)
                {
                    SqlDataReader dr1;
                    dr1 = obj.GenerateOrderCode();
                    while (dr1.Read())
                    {
                        int generatecode = Convert.ToInt32(dr1["Id"].ToString());
                        generatecode = generatecode + 1;
                        string Id = "OD0";
                        Code = Id + generatecode;
                    }
                    dr1.Close();

                    obj1.OrderCode = Code;
                   // string addordercode = obj1.OrderCode;
                   // int orderstatusid = 19;
                    obj1.OrderStatusId = 19;
                    obj.AddToCart(obj1);

                    return await Task.Run(()=> Json(new { status = "New", msg = "Add To Cart" }));
                }


            }
            else
            {
                return await Task.Run(()=> RedirectToAction("Login"));
            }
            return await Task.Run(()=> View());
        }

        public async Task<ActionResult> SideBarShop(int? id, string prosearch)////Gallary///
        {
            DataSet ds = new DataSet();
            ds = obj.CategoeryShow();
            Buyer objU = new Buyer();
            List<Buyer> categorylist = new List<Buyer>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                categorylist.Add(new Buyer
                {
                    CategoryName = dr["CategoryName"].ToString(),
                    CategoryId = Convert.ToInt32(dr["CategoryId"].ToString())

                });
                objU.category = categorylist;

            }
            if (id == null)
            {
                DataSet ds1 = new DataSet();
                ds1 = obj.ShowAllProducts();
                // Buyer objU = new Buyer();

                List<Buyer> prodlist = new List<Buyer>();
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    prodlist.Add(new Buyer
                    {
                        ProductName = dr["ProductName"].ToString(),
                        ProductCode = dr["ProductCode"].ToString(),
                        MRP = Convert.ToInt32(dr["MRP"].ToString()),
                        MainImage = dr["MainImage"].ToString(),
                        StatusId = Convert.ToInt32(dr["StatusId"].ToString()),
                        Quantity = Convert.ToInt32(dr["Quantity"].ToString()),
                    });
                }

                objU.products = prodlist;
            }
            else
            {
                DataSet ds2 = new DataSet();
                ds2 = obj.ShowCatProducts((int)id);
                // Buyer objU = new Buyer();
                List<Buyer> prodlist = new List<Buyer>();
                foreach (DataRow dr in ds2.Tables[0].Rows)
                {
                    prodlist.Add(new Buyer
                    {
                        ProductName = dr["ProductName"].ToString(),
                        ProductCode = dr["ProductCode"].ToString(),
                        MRP = Convert.ToInt32(dr["MRP"].ToString()),
                        MainImage = dr["MainImage"].ToString(),
                        StatusId = Convert.ToInt32(dr["StatusId"].ToString()),
                        Quantity = Convert.ToInt32(dr["Quantity"].ToString()),
                    });
                }

                objU.products = prodlist;
            }
            if (prosearch != null)
            {
                DataSet ds3 = new DataSet();
                ds3 = obj.SearchData(prosearch);

                List<Buyer> productlist = new List<Buyer>();
                foreach (DataRow dr in ds3.Tables[0].Rows)
                {
                    productlist.Add(new Buyer
                    {
                        ProductName = dr["ProductName"].ToString(),
                        ProductCode = dr["ProductCode"].ToString(),
                        MRP = Convert.ToInt32(dr["MRP"].ToString()),
                        MainImage = dr["MainImage"].ToString(),
                        StatusId = Convert.ToInt32(dr["StatusId"].ToString()),
                        Quantity = Convert.ToInt32(dr["Quantity"].ToString()),

                    });
                }
                objU.products = productlist;
            }

            return await Task.Run(()=> View(objU));
        }

      

    }
}