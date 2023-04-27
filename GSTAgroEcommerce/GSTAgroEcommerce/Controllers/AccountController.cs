using AgroEcommerceLibrary.AccountUser;
using AgroEcommerceLibrary.Buyer;
using GoogleAuthentication.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GSTAgroEcommerce.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        BALAccountUser obj = new BALAccountUser();
        [HttpGet]
        public ActionResult Login()
        {
            var clientId = "737816805057-5ks6319c89hhsh7k5mffdq8qn3gq1l1p.apps.googleusercontent.com\r\n\r\n";
            var url = "http://localhost:53017/Account/Googlelogin";
            var response = GoogleAuth.GetAuthUrl(clientId, url);
            ViewBag.response = response;
            return View();
        }

        [HttpPost]

        [AllowAnonymous]
        [Authorize]
        public async Task<ActionResult> Login(AccountUser user)///////Local LogIn///
        {

            SqlDataReader dr;
            dr = obj.LogIn(user);
            if (dr.HasRows)
            {


                while (dr.Read())
                {
                    FormsAuthentication.SetAuthCookie(user.EmailId, true);
                    user.BuyerCode = dr["BuyerCode"].ToString();
                    user.EmailId = dr["EmailId"].ToString();
                    user.Password = dr["Password"].ToString();
                    user.BuyerFullName = dr["BuyerFullName"].ToString();



                    Session["BuyerCode"] = user.BuyerCode.ToString();
                    Session["EmailId"] = user.EmailId.ToString();
                    Session["Password"] = user.Password.ToString();
                    Session["BuyerFullName"] = user.BuyerFullName.ToString();

                    return RedirectToAction("Index", "Buyer");
                }

            }
           
            if (dr.HasRows==false)
            {
                dr.Close();
                SqlDataReader dr1;
                dr1 = obj.LogInSeller(user);
                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {

                        FormsAuthentication.SetAuthCookie(user.EmailId, true);
                        user.SellerCode = dr1["SellerCode"].ToString();
                        user.EmailId = dr1["EmailId"].ToString();
                        user.Password = dr1["Password"].ToString();
                        user.SellerFullName = dr1["SellerFullName"].ToString();



                        Session["SellerCode"] = user.SellerCode.ToString();
                        Session["SellerEmailId"] = user.EmailId.ToString();
                        Session["SellerPassword"] = user.Password.ToString();
                        Session["SellerFullName"] = user.SellerFullName.ToString();
                        return RedirectToAction("Index", "Seller");
                    }

                }

                if(dr1.HasRows==false)
                {
                    dr1.Close();
                    SqlDataReader dr2;
                    dr2 = obj.LogInAdmin(user);
                    if (dr2.Read())
                    {
                        FormsAuthentication.SetAuthCookie(user.EmailId, true);
                        user.AdminId = Convert.ToInt32(dr2["AdminId"].ToString());
                        user.EmailId = dr2["EmailId"].ToString();
                        user.Password = dr2["Password"].ToString();
                        user.AdminFullName = dr2["AdminFullName"].ToString();



                        Session["AdminId"] = user.AdminId.ToString();
                        Session["AdminEmailId"] = user.EmailId.ToString();
                        Session["AdminPassword"] = user.Password.ToString();
                        Session["AdminFullName"] = user.AdminFullName.ToString();
                        return await Task.Run(()=> RedirectToAction("Index", "Admin"));

                    }
                     else
                    {
                        TempData["ErrorMessage"] = "Incorrect Login Details";
                        return await Task.Run(() => RedirectToAction("Index", "Admin"));
                    }
                }
               


            }

            //else
            //{
            //    ViewBag.LogInErrorMessage = "Incorrect Login Details";
            //    return await Task.Run(() => RedirectToAction("Index", "Admin"));
            //}


            return await Task.Run(() => View());
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Buyer");
        }

        public async Task<ActionResult> Googlelogin(string code, string emailid)////Extranal Google Login///
        {
            AccountUser obj1 = new AccountUser();
            var clientId = "737816805057-5ks6319c89hhsh7k5mffdq8qn3gq1l1p.apps.googleusercontent.com";
            var url = "http://localhost:53017/Account/Googlelogin";
            var clientsecret = "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";
            var token = await GoogleAuth.GetAuthAccessToken(code, clientId, clientsecret, url);
            var buyerprofile = await GoogleAuth.GetProfileResponseAsync(token.AccessToken.ToString());

            string[] profile = buyerprofile.Split(':', ',');
            AccountUser user = new AccountUser();
            for (int i = 0; i < profile.Length; i++)
            {

                string id = profile[1].ToString();
                user.BuyerCode = id.Replace("\"", "").TrimStart();

                string email = profile[3].ToString();
                user.EmailId = email.Replace("\"", "").TrimStart();

                string name = profile[7].ToString();
                user.BuyerFullName = name.Replace("\"", "").TrimStart();
            }

            SqlDataReader dr;
            dr = obj.ExtrnalLogIn(user);///////Check Already Extranal LogedIn or Not 
            if (dr.Read())
            {
                FormsAuthentication.SetAuthCookie(emailid, true);
                obj1.BuyerCode = dr["BuyerCode"].ToString();
                obj1.EmailId = dr["EmailId"].ToString();
                obj1.BuyerFullName = dr["BuyerFullName"].ToString();

                Session["BuyerCode"] = obj1.BuyerCode.ToString();
                Session["BuyerFullName"] = obj1.BuyerFullName.ToString();

                return RedirectToAction("Index", "Buyer");
            }
            dr.Close();

            Buyer objU = new Buyer();
            user.RegistrationDate = DateTime.Now;
            obj.ResisterExtrnalLogIn(user);///Extrnal Login Registration

            Session["BuyerCode"] = user.BuyerCode.ToString();
            Session["BuyerFullName"] = user.BuyerFullName.ToString();

            return RedirectToAction("Index", "Buyer");

            //return View();
        }

    }
}