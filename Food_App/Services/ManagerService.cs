//using CoreData;
using Food_App.Models;
using GoogleGson;
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

        public static readonly string baseURL = "https://posapi.lazzatt.com/api";
        //public async Task<List<List<ManagerInfo>>> GetManagerList()
        //{
        //    //var managerInfo = new List<ManagerInfo>();
        //    var client = new HttpClient();

        //    string url = baseURL + "/Login";

        //    client.BaseAddress = new Uri(url);
        //    HttpResponseMessage response = await client.GetAsync("");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        //managerInfo = await response.Content.ReadFromJsonAsync<List<ManagerInfo>>();

        //        //string responseContent = await response.Content.ReadAsStringAsync();
        //        //Console.WriteLine(responseContent);

        //        //List<ManagerInfo> jsonString = await response.Content.ReadAsStringAsync();
        //        //var list1 = JsonConvert.DeserializeObject<List<List<ManagerInfo>>>(jsonString);

        //        //return list1;


        //        string responseContent = await response.Content.ReadAsStringAsync();
        //        Console.WriteLine(responseContent);

        //        List<List<ManagerInfo>> managerList = JsonConvert.DeserializeObject<List<List<ManagerInfo>>>(responseContent);

        //        return managerList;

        //    }
        //    else
        //    {
        //        Console.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
        //        return null;
        //    }


        //}

        public async Task<List<ManagerInfo>> GetManagerList()
        {
            var client = new HttpClient();
            string url = baseURL + "/Login";
            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = await client.GetAsync("");

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);

                try
                {
                    List<ManagerInfo> managerList = JsonConvert.DeserializeObject<List<ManagerInfo>>(responseContent);



                    //IEnumerable<ManagerInfo> managerList = JsonConvert.DeserializeObject<IEnumerable<ManagerInfo>>(responseContent);

                    return managerList;
                }
                catch (JsonSerializationException ex)
                {
                    Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                    return null; // Or handle the exception as per your requirement
                }
            }
            else
            {
                Console.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                return null;
            }
        }

    }
}
