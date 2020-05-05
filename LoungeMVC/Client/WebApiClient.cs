using LoungeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LoungeMVC.Client
{
    public class WebApiClient<T>
    {

        private static WebApiClient<T> instance;
        private static string HttpString;
        private HttpClient client = new HttpClient();

        public static WebApiClient<T> GetInstance()
        {
           
            if (instance == null)
            {
                instance = new WebApiClient<T>();
            }
            return instance;
        }
        public static void SetConnectionString(string httpString)
        {
            HttpString = httpString;
        }

        public  IEnumerable<T> Get(string apiName)
        {
            using (HttpClient client = new HttpClient()) {
                client.BaseAddress = new Uri(HttpString);
                //HTTP GET
                var responseTask = client.GetAsync($"api/{apiName}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<T[]>();
                    readTask.Wait();

                    var apiResult = readTask.Result;

                    return apiResult;
                }
                return null;
            }
        }
        public T Get( string apiName,int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(HttpString);
                //HTTP GET
                var responseTask = client.GetAsync($"api/{apiName}/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<T>();
                    readTask.Wait();

                    var apiResult = readTask.Result;

                    return apiResult;
                }
                
            }
            return default;
        }
        

        public T Post(string apiName, T responceApi)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(HttpString);

                var postTask = client.PostAsJsonAsync<T>($"api/{apiName}", responceApi);

                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<T>();
                    readTask.Wait();

                    var apiResult = readTask.Result;

                    return apiResult;
                }
                
            }
            return default;
        }



        public void Put(string apiName, T responceApi)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(HttpString);
                
                var postTask = client.PutAsJsonAsync<T>($"api/{apiName}", responceApi);
                postTask.Wait();

                var result = postTask.Result;
            }
        }

        public void Delete(string apiName, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(HttpString);

                var postTask = client.DeleteAsync($"api/{apiName}/{id}" );
                postTask.Wait();

                var result = postTask.Result;
            }
        }

    }
}
