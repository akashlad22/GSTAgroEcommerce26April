using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroEcommerceLibrary.Admin
{
    public class Admin
    {

        public List<Admin> admins { get; set; }
        public List<Admin> Category { get; set; }
        public List<Admin> Products { get; set; }


        public int AdminId { get; set; }
        [DisplayName("Seller Name")]
        public string SellerFullName { get; set; }

        public string EmailId { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string AlternateMobileNo { get; set; }
        public string Photo { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int PinCode { get; set; }
        public int StatusId { get; set; }

      

        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [DisplayName("Image")]
        public string MainImage { get; set; }

        public float Quantity { get; set; }
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        public string Status { get; set; }
        public int CategoryId { get; set; }
        public string SellerName { get; set; }
        [DisplayName("Manufacturer Name")]
        public string ManufacturerName { get; set; }
    }
}
