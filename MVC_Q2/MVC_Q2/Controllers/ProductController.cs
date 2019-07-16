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
        // GET: Product
        public ActionResult Index(int page = 1)
        {
            var dataList = readJson();
            ViewBag.Message = dataList;
            var result = dataList.OrderBy(x => x.Id).ToPagedList(page, pageSize);
            return View(result);
        }

        public ActionResult Detail(int id)
        {
            var dataList = readJson();
            var result = dataList.Find(x => x.Id == id);
            if (result == null) { };
            return View(result);
        }

        public List<DataModel> readJson()
        {
            String PATH = String.Format(@"{0}\Content\data.json", System.AppDomain.CurrentDomain.BaseDirectory);
            string json = System.IO.File.ReadAllText(PATH);
            string str = json.Replace("\n", "").Replace("\r", "").Replace(" ", "");
            return JsonConvert.DeserializeObject<List<DataModel>>(json);
        }
    }
}