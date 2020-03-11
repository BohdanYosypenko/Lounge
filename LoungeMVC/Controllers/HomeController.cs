using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LoungeMVC.Models;
using LoungeMVC.Client;
using Microsoft.Extensions.Configuration;

namespace LoungeMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private WebApiClient<Tobacco> tobaccoApiClient = WebApiClient<Tobacco>.GetInstance("https://localhost:44382/");
        private WebApiClient<Order> orderApiClient = WebApiClient<Order>.GetInstance("https://localhost:44382/");
        List<Tobacco> tobaccoList = new List<Tobacco>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // INDEX

        [HttpGet]
        public IActionResult Index()
        {
            return View(tobaccoApiClient.Get("tobacco"));
        }

        [HttpPost]
        public IActionResult Index(string name, string image, string taste, int weight, string description)
        {
            Tobacco tobacco = new Tobacco { Name = name, Image = image, Taste = taste, Weight = weight, Description = description };

            tobaccoApiClient.Post("tobacco", tobacco);
            return View(tobaccoApiClient.Get("tobacco"));
        }
        // Edit

        [HttpGet]
        public IActionResult Edit(int id)
        {
               
            return View(tobaccoApiClient.Get("tobacco",id));
        }

        [HttpPost]
        public IActionResult Edit(int id,string name, string image, string taste, int weight, string description)
        {

            Tobacco tobacco = new Tobacco {Id=id, Name = name, Image = image, Taste = taste, Weight = weight, Description = description };

            tobaccoApiClient.Put("tobacco", tobacco);
            return Redirect("Index");
        }

        // Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create( string name, string image, string taste, int weight, string description)
        {

            Tobacco tobacco = new Tobacco { Name = name, Image = image, Taste = taste, Weight = weight, Description = description };

            tobaccoApiClient.Post("tobacco", tobacco);
            return Redirect("Index");
        }

        // Delete

        public IActionResult DeleteTobacco(int id)
        {
            tobaccoApiClient.Delete("tobacco", id);
;            return Redirect("~/Home/Index");
        }

        // Buy Not Compleate

        [HttpGet]
        public string Buy(int id)
        {
            
            //if (orderApiClient.Get("order").Contains((orderApiClient.Get("order").FirstOrDefault(x => x.Complete == false))))
            //{
                Order order = (orderApiClient.Get("order").FirstOrDefault(x => x.Complete == false));
                order.Tobaccos.Add(tobaccoApiClient.Get("tobacco", id));
                
            Tobacco tobacco = tobaccoApiClient.Get("tobacco", id);
            Tobacco tobacco1 = tobaccoApiClient.Get("tobacco", id);
            tobaccoList.Add(tobacco);
            tobaccoList.Add(tobacco1);
            string s = null;
            foreach (var tobac in tobaccoList)
            {
                s += tobac.Name.ToString();
            }
            return s;
            //}
            //else
            //{
            //    order = new Order();
            //    var newOrder= orderApiClient.Post("order", order);
            //    newOrder.Tobaccos.Add(tobaccoApiClient.Get("tobacco", id));
            //    return View(newOrder);
            //}
            //return View(order);
        }

        [HttpPost]
        public IActionResult Buy(string name, string image, string taste, int weight, string description)
        {

            
           
            return Redirect("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
