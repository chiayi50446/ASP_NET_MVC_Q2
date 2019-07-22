using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Q2.ViewModels
{
    public class ProductDetailViewModel
    {
        public int Id { get; set; }
        public string Locale { get; set; }
        public string Product_Name { get; set; }
        public string Price { get; set; }
        public string Promote_Price { get; set; }
        public string Create_Date { get; set; }
    }
}