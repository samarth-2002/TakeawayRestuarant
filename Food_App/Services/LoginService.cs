using Food_App.Models;
using Newtonsoft.Json;
using Org.Apache.Http.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Food_App.Services
{
    public class LoginService : ILoginRepository
    {
        //public async Task<UserInfo> Login(string username, string password)
        //{
        //    //var userInfo = new List<UserInfo>();
        //    //var client = new HttpClient();

        //    //string url = "http://192.16.1.107:8099/api/Login/" + username + "/" + password + "/";
        //    //client.BaseAddress = new Uri(url);                           
        //    //HttpResponseMessage response = await client.GetAsync("");



        //    var httpClient = new HttpClient();


        //    var data = new { operatorName = username, Password = password };

        //    // Convert the data to JSON
        //    var jsonData = JsonConvert.SerializeObject(data);
        //    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        //    // Send the POST request
        //     HttpResponseMessage response = await httpClient.PostAsync("https://posapi.lazzatt.com/api/Login", content);


        //    //if (response.IsSuccessStatusCode)
        //    //{
        //    //    string content = response.Content.ReadAsStringAsync().Result;

        //    //    //my API is returning List for that i have taken List

        //    //    userInfo = JsonConvert.DeserializeObject<List<UserInfo>>(content);

        //    //    return await Task.FromResult(userInfo.FirstOrDefault());
        //    //}

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string content1 = response.Content.ReadAsStringAsync().Result;

        //        UserInfo userInfo = JsonConvert.DeserializeObject<UserInfo>(content1);

        //        return await Task.FromResult(userInfo);
        //    }


        //    else
        //    {
        //        return null;
        //    }
        //}

        public async Task<string> LoginAsync(string username, string password)
        {
            var httpClient = new HttpClient();
            var data = new { operatorName = username, Password = password };

            // Convert the data to JSON
            var jsonData = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Send the POST request
            HttpResponseMessage response = await httpClient.PostAsync("https://posapi.lazzatt.com/api/Login", content);

            if (response.IsSuccessStatusCode)
            {
                return "Hello";
                
            }
            else
            {
                return null;
            }
        }


    }
}


