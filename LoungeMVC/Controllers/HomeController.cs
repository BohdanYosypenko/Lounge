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
using LoungeMVC.Interfaces;

namespace LoungeMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private WebApiClient<Tobacco> tobaccoApiClient = WebApiClient<Tobacco>.GetInstance();
        private WebApiClient<Order> orderApiClient = WebApiClient<Order>.GetInstance();
        List<Tobacco> tobaccoList = new List<Tobacco>();
        //private readonly IGetAllTobacco _allTobacco;
        private readonly ISender _sender;



        public HomeController(ILogger<HomeController> logger, ISender sender)
        {
            _sender = sender;
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
        // Detail

        public IActionResult Detail( int id)
        {
            return View(tobaccoApiClient.Get("tobacco",id));
        }
        // Buy Not Compleate

        [HttpGet]
        public string Buy(int id)
        {
            
          
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
