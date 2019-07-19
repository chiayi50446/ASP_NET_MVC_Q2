using MVC_Q2.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PagedList;
using MVC_Q2.ViewModels;

namespace MVC_Q2.Controllers
{
    public class ProductController : Controller
    {
        private int pageSize = 5;
        private ProductDetailViewModel data;
        private DataRepository dataRepository;
        public ProductController()
        {
            this.data = new ProductDetailViewModel();
            this.dataRepository = new DataRepository();
        }
        // GET: Product
        public ActionResult Index(int page = 1)
        {
            var dataList = dataRepository.DataConversion();
            data.productList = dataList.OrderBy(x => x.Id).ToPagedList(page, pageSize);
            return View(data);
        }

        public ActionResult Detail(int id)
        {
            var dataList = dataRepository.Get();
            data.productDetail = dataRepository.CurrencyConversion(dataList.Find(x => x.Id == id));
            return View(data);
        }
    }
}