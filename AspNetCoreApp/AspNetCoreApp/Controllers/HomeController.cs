﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreApp.Models;
using AspNetCoreApp.Services;
using AspNetCoreApp.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGreeter _greeter;
        private readonly IRestaurantData _restaurantData;

        public HomeController(IGreeter greeter, IRestaurantData restaurantData)
        {
            _greeter = greeter;
            _restaurantData = restaurantData;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel()
            {
                MessageOfDay = _greeter.GetGreeting(),
                Restaurants = _restaurantData.GetAll()
            };

            return View("Index", viewModel);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);

            if (model == null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        public IActionResult Create()
        {
            return View("Create");
        }
    }
}
