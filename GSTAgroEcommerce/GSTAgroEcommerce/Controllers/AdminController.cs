using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AgroEcommerceLibrary.Admin;


namespace GSTAgroEcommerce.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Form()
        {
            return View();
        }

         //-------------------Prathmesh Start---------------- 
        public async Task<ActionResult> ProductGrid()
        {


            CategoryName();
            SellerName();
            //if (categoryId == null)
            //{    
            BALAdmin OBjP = new BALAdmin();
            DataSet DSB = new DataSet();
            DSB = OBjP.GetProductAdmin();
            Admin objBUY = new Admin();
            List<Admin> listP = new List<Admin>();
            for (int i = 0; i < DSB.Tables[0].Rows.Count; i++)
            {
                Admin ObjB = new Admin();
                ObjB.SellerFullName = DSB.Tables[0].Rows[i]["SellerFullName"].ToString(); 
                ObjB.ProductName = DSB.Tables[0].Rows[i]["ProductName"].ToString();
                ObjB.MainImage = DSB.Tables[0].Rows[i]["MainImage"].ToString();
                ObjB.Quantity = Convert.ToInt32(DSB.Tables[0].Rows[i]["Quantity"].ToString());
                ObjB.CategoryName = DSB.Tables[0].Rows[i]["CategoryName"].ToString();
                ObjB.Status = DSB.Tables[0].Rows[i]["Status"].ToString();
                ObjB.ManufacturerName = DSB.Tables[0].Rows[i]["ManufacturerName"].ToString();

                listP.Add(ObjB);

            }
            objBUY.admins = listP;
            return await Task.Run(() => View(objBUY));





        }
        [HttpGet]
        public JsonResult SearchByCategory(int CategoryId)
        {

            if (CategoryId == 1)
            {
                BALAdmin OBjP = new BALAdmin();
                DataSet DSB = new DataSet();
                DSB = OBjP.GetProductAdmin();
                Admin objBUY = new Admin();
                List<Admin> listP = new List<Admin>();
                for (int i = 0; i < DSB.Tables[0].Rows.Count; i++)
                {
                    Admin ObjB = new Admin();
                    ObjB.SellerFullName = DSB.Tables[0].Rows[i]["SellerFullName"].ToString();
                    ObjB.ProductName = DSB.Tables[0].Rows[i]["ProductName"].ToString();
                    string photo = DSB.Tables[0].Rows[i]["MainImage"].ToString();
                    ObjB.Quantity = Convert.ToInt32(DSB.Tables[0].Rows[i]["Quantity"].ToString());
                    ObjB.CategoryName = DSB.Tables[0].Rows[i]["CategoryName"].ToString();
                    ObjB.Status = DSB.Tables[0].Rows[i]["Status"].ToString();
                    ObjB.ManufacturerName = DSB.Tables[0].Rows[i]["ManufacturerName"].ToString();
                    string Path = "/Content/Images/Product/";
                    ObjB.MainImage = string.Concat(Path, photo);
                    listP.Add(ObjB);

                }
                objBUY.admins = listP;
                return Json(listP, JsonRequestBehavior.AllowGet);

            }
            else
            {
                BALAdmin OBjS = new BALAdmin();
                DataSet DSB = new DataSet();
                DSB = OBjS.GetSearchbyCategory(CategoryId);
                Admin objBUY = new Admin();
                List<Admin> listS = new List<Admin>();
                for (int i = 0; i < DSB.Tables[0].Rows.Count; i++)
                {
                    Admin ObjB = new Admin();
                    ObjB.SellerFullName = DSB.Tables[0].Rows[i]["SellerFullName"].ToString();
                    ObjB.ProductName = DSB.Tables[0].Rows[i]["ProductName"].ToString();
                    string Photo = DSB.Tables[0].Rows[i]["MainImage"].ToString();
                    ObjB.Quantity = Convert.ToInt32(DSB.Tables[0].Rows[i]["Quantity"].ToString());
                    ObjB.CategoryName = DSB.Tables[0].Rows[i]["CategoryName"].ToString();
                    ObjB.Status = DSB.Tables[0].Rows[i]["Status"].ToString();
                    ObjB.ManufacturerName = DSB.Tables[0].Rows[i]["ManufacturerName"].ToString();
                    string Path = "/Content/Images/Product/";
                    ObjB.MainImage = string.Concat(Path, Photo);

                    listS.Add(ObjB);

                }
                //ViewBag.CategoryName = objBUY.CategoryName;
                objBUY.admins = listS;
                return Json(listS, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult CategoryName()
        {
            BALAdmin OBjC = new BALAdmin();
            DataSet DSB1 = new DataSet();
            DSB1 = OBjC.GetCatergory();
            Admin objBUY2 = new Admin();
            List<SelectListItem> listC = new List<SelectListItem>();
            foreach (DataRow dr in DSB1.Tables[0].Rows)
            {
                listC.Add(new SelectListItem
                {
                    Text = dr["CategoryName"].ToString(),
                    Value = dr["CategoryId"].ToString()
                });
            }
            //objBUY2.Category = listC;
            ViewBag.Category = listC;

            return Json(listC, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SearchBySeller(int SellerId)
        {

            BALAdmin OBjS = new BALAdmin();
            DataSet DSB = new DataSet();
            DSB = OBjS.GetSearchbySeller(SellerId);
            Admin objBUY = new Admin();
            List<Admin> listS = new List<Admin>();
            for (int i = 0; i < DSB.Tables[0].Rows.Count; i++)
            {
                Admin ObjB = new Admin();
                ObjB.SellerFullName = DSB.Tables[0].Rows[i]["SellerFullName"].ToString();
                ObjB.ProductName = DSB.Tables[0].Rows[i]["ProductName"].ToString();
                string Photo = DSB.Tables[0].Rows[i]["MainImage"].ToString();
                ObjB.Quantity = Convert.ToInt32(DSB.Tables[0].Rows[i]["Quantity"].ToString());
                ObjB.CategoryName = DSB.Tables[0].Rows[i]["CategoryName"].ToString();
                ObjB.Status = DSB.Tables[0].Rows[i]["Status"].ToString();
                ObjB.ManufacturerName = DSB.Tables[0].Rows[i]["ManufacturerName"].ToString();
                string Path = "/Content/Images/Product/";
                ObjB.MainImage = string.Concat(Path, Photo);

                listS.Add(ObjB);

            }
            //ViewBag.CategoryName = objBUY.CategoryName;
            objBUY.admins = listS;
            return Json(listS, JsonRequestBehavior.AllowGet);

        }
        public JsonResult SellerName()
        {
            BALAdmin OBjC = new BALAdmin();
            DataSet DSB1 = new DataSet();
            DSB1 = OBjC.GetsellerName();
            Admin objBUY2 = new Admin();
            List<SelectListItem> listC = new List<SelectListItem>();
            foreach (DataRow dr in DSB1.Tables[0].Rows)
            {
                listC.Add(new SelectListItem
                {
                    Text = dr["SellerFullName"].ToString(),
                    Value = dr["SellerId"].ToString()
                });
            }
            //objBUY2.Category = listC;
            // listC.Insert(0,new SelectListItem { Text = "-- Please Select --" });
            ViewBag.Seller = listC;

            return Json(listC, JsonRequestBehavior.AllowGet);
        }
        //-------------------Prathmesh End---------------- 

    }
}