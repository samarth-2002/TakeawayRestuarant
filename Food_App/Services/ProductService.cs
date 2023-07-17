﻿using Food_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_App.Services
{
    public class ProductService : IProductRepository
    {
        public static readonly string baseURL = "https://posapi.lazzatt.com/api";
        public async Task<List<Product>> GetProductList(string id)
        {
            HttpClient httpClient = new HttpClient();

            var data = new { ProductTypeID = id };

            var jsonData = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync("https://posapi.lazzatt.com/api/Product", content);
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                List<Product> types = JsonConvert.DeserializeObject<List<Product>>(responseContent);
                return types;
            }
            else
            {
                return null;
            }
        }
    }
}
