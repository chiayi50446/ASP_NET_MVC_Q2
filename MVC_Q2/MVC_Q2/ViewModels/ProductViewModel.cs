﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Q2.ViewModels
{
    public class ProductViewModel
    {
        public IPagedList<Product> productList { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Locale { get; set; }
        public string Product_Name { get; set; }
        public string Create_Date { get; set; }
    }

}