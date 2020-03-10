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
        private WebApiClient<Tobacco> webApiClient = WebApiClient<Tobacco>.GetInstance("https://localhost:44382/");

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View(webApiClient.Get("tobacco"));
        }

        [HttpPost]
        public IActionResult Index(string name, string image, string taste, int weight, string description)
        {
            Tobacco tobacco = new Tobacco { Name = name, Image = image, Taste = taste, Weight = weight, Description = description };

            webApiClient.Post("tobacco", tobacco);
            return View(webApiClient.Get("tobacco"));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
               
            return View(webApiClient.Get("tobacco",id));
        }

        [HttpPost]
        public IActionResult Edit(int id,string name, string image, string taste, int weight, string description)
        {

            Tobacco tobacco = new Tobacco {Id=id, Name = name, Image = image, Taste = taste, Weight = weight, Description = description };

            webApiClient.Put("tobacco", tobacco);
            return Redirect("Index");
        }

        public IActionResult DeleteTobacco(int id)
        {
            webApiClient.Delete("tobacco", id);
;            return Redirect("~/Home/Index");
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
