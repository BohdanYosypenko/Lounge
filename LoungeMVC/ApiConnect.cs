using LoungeMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LoungeMVC
{
    class ApiConnect
    {
        private static ApiConnect instance;

        private ApiConnect()
        { }

        public static ApiConnect getInstance()
        {
            if (instance == null)
                instance = new ApiConnect();
            return instance;
        }

        public IEnumerable<Tobacco> GetTobacco()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44382/");
                //HTTP GET
                var responseTask = client.GetAsync("api/tobacco");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Tobacco[]>();
                    readTask.Wait();

                    var tobacco = readTask.Result;

                    return tobacco;
                }
            }
            return null;
        }
        public void CreateTobacco(string name, string image, string taste, int weight,string description)
        {
            Tobacco tobacco = new Tobacco { Name = name, Image = image, Taste = taste, Weight = weight, Description = description };
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44382/");

                var postTask = client.PostAsJsonAsync<Tobacco>("api/tobacco", tobacco);
                postTask.Wait();

                var result = postTask.Result;
                
            }
            

        }
    }
}
