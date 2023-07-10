//using CoreData;
using Food_App.Models;
using MongoDB.Driver.Core.WireProtocol.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Food_App.Services
{
    public class ManagerService : IManagerService
    {

        public static readonly string baseURL = "http://192.16.1.107:8099/api";
        public async Task<List<ManagerInfo>> GetManagerList()
        {
            var managerInfo = new List<ManagerInfo>();
            var client = new HttpClient();

            string url = baseURL + "/Login/";

            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");

            if (response.IsSuccessStatusCode)
            {
                managerInfo = await response.Content.ReadFromJsonAsync<List<ManagerInfo>>();
               
                return await Task.FromResult(managerInfo);
            }
            else
            {
                return null;
            }


        }
    }
}
