﻿using System;
using NorthwindEntitiesLib;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindMVC.Models;
using NorthwindMvc.Models;

namespace NorthwindMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Northwind db;
        public HomeController(ILogger<HomeController> logger,
        Northwind injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                VisitorCount = (new Random()).Next(1, 1001),

                Categories = db.Categories.ToList(),
                Products = db.Products.ToList()
            };

            return View(model); // pass model to view
        }

        [Route("private_route")]
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
