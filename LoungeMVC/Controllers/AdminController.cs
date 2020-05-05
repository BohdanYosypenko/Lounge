using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoungeMVC.Client;
using LoungeMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoungeMVC.Controllers
{
    public class AdminController : Controller
    {
        private WebApiClient<Tobacco> tobaccoApiClient = WebApiClient<Tobacco>.GetInstance();
        public IActionResult Admin()
        {

            return View(tobaccoApiClient.Get("tobacco"));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            return View(tobaccoApiClient.Get("tobacco", id));
        }

        [HttpPost]
        public IActionResult Edit(int id, string name, string image, string taste, int weight, string description)
        {

            Tobacco tobacco = new Tobacco { Id = id, Name = name, Image = image, Taste = taste, Weight = weight, Description = description };

            tobaccoApiClient.Put("tobacco", tobacco);
            return Redirect("Admin");
        }

        // Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, string image, string taste, int weight, string description)
        {

            Tobacco tobacco = new Tobacco { Name = name, Image = image, Taste = taste, Weight = weight, Description = description };

            tobaccoApiClient.Post("tobacco", tobacco);
            return Redirect("Index");
        }

        // Delete

        public IActionResult DeleteTobacco(int id)
        {
            tobaccoApiClient.Delete("tobacco", id);
            return Redirect("~/Home/Index");
        }

    }
}