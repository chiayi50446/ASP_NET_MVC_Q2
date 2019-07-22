using MVC_Q2.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Q2.Models
{
    public class DataRepository
    {
        public List<ProductDetailViewModel> ReadData()
        {
            String PATH = String.Format(@"{0}\Content\data.json", System.AppDomain.CurrentDomain.BaseDirectory);
            string json = System.IO.File.ReadAllText(PATH);
            string str = json.Replace("\n", "").Replace("\r", "").Replace(" ", "");
            return JsonConvert.DeserializeObject<List<ProductDetailViewModel>>(json);
        }

        public ProductDetailViewModel GetById(int id)
        {
            List<ProductDetailViewModel>  dataList = ReadData();
            return dataList.Find(x => x.Id == id);
        }

        public List<Product> GetList()
        {
            List<ProductDetailViewModel> dataList = ReadData();
            List<Product> result = new List<Product>();
            foreach (var data in dataList)
            {
                Product product = new Product();
                product.Id = data.Id;
                product.Locale = data.Locale;
                product.Product_Name = data.Product_Name;
                product.Create_Date = data.Create_Date;
                result.Add(product);
            }
            return result;
        }
    }
}