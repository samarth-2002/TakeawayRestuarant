using Food_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Food_App.Services
{
    public class ProductCategoryService : IProductCategoryRepository
    {

        public static readonly string baseURL = "https://posapi.lazzatt.com/api";
        public async Task<List<ProductCategory>> GetCategoryList()
        {
                var client = new HttpClient();
                string url = baseURL + "/ProductCategory";
                client.BaseAddress = new Uri(url);

                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    List<ProductCategory> categoryList = JsonConvert.DeserializeObject<List<ProductCategory>>(responseContent);
                    return categoryList;
                }
                else
                {
                    return null;
                }
            
        }
    }
}