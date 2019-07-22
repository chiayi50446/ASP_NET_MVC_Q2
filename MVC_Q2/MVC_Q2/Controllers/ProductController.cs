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
        private ProductViewModel product;
        private ProductDetailViewModel productDetail;
        private DataRepository dataRepository;
        public ProductController()
        {
            this.product = new ProductViewModel();
            this.productDetail = new ProductDetailViewModel();
            this.dataRepository = new DataRepository();
        }
        // GET: Product
        public ActionResult Index(int page = 1)
        {
            var dataList = dataRepository.GetList();
            product.productList = dataList.OrderBy(x => x.Id).ToPagedList(page, pageSize);
            return View(product);
        }

        public ActionResult Detail(int id)
        {
            var data = dataRepository.GetById(id);
            return View(data);
        }
    }
}