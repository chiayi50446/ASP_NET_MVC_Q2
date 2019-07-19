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
        public List<ProductDetail> Get()
        {
            String PATH = String.Format(@"{0}\Content\data.json", System.AppDomain.CurrentDomain.BaseDirectory);
            string json = System.IO.File.ReadAllText(PATH);
            string str = json.Replace("\n", "").Replace("\r", "").Replace(" ", "");
            return JsonConvert.DeserializeObject<List<ProductDetail>>(json);
        }

        public ProductDetail CurrencyConversion(ProductDetail product)
        {
            string cultureName = GetCultureName(product.Locale);
            double doubleResult;
            if (double.TryParse(product.Price, out doubleResult))
            {
                product.Price = doubleResult.ToString("C", new System.Globalization.CultureInfo(cultureName));
            }
            else
            {
                product.Price = "-";
            }

            if (double.TryParse(product.Promote_Price, out doubleResult))
            {
                product.Promote_Price = doubleResult.ToString("C", new System.Globalization.CultureInfo(cultureName));
            }
            else
            {
                product.Promote_Price = "-";
            }
            return product;
        }

        public string GetCultureName(string locale)
        {
            string cultureName = "";
            switch (locale)
            {
                case "US":
                    cultureName = "en-US";
                    break;
                case "DE":
                    cultureName = "de-DE";
                    break;
                case "CA":
                    cultureName = "en-CA";
                    break;
                case "ES":
                    cultureName = "es-ES";
                    break;
                case "FR":
                    cultureName = "fr-FR";
                    break;
                case "JP":
                    cultureName = "ja-JP";
                    break;
                default:
                    cultureName = "-";
                    break;
            }
            return cultureName;
        }
    }
}