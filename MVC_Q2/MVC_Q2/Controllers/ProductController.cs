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

namespace MVC_Q2.Controllers
{
    public class ProductController : Controller
    {
        private int pageSize = 5;
        private DataModel data;
        public ProductController()
        {
            this.data = new DataModel();
        }
        // GET: Product
        public ActionResult Index(int page = 1)
        {
            var dataList = data.readJson();
            var result = dataList.OrderBy(x => x.Id).ToPagedList(page, pageSize);
            return View(result);
        }

        public ActionResult Detail(int id)
        {
            var dataList = data.readJson();
            var result = dataList.Find(x => x.Id == id);
            if (result == null) { };
            return View(result);
        }
    }
}