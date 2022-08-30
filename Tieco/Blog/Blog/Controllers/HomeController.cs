using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAbouteMeService abouteMeService;
        private readonly IContactUsService contactUsService;
        public HomeController(ILogger<HomeController> logger, IAbouteMeService abouteMeService, IContactUsService contactUsService)
        {
            _logger = logger;
            this.abouteMeService = abouteMeService;
            this.contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("/AbouteUs")]
        public IActionResult AbouteUs()
        {
            var result = abouteMeService.ShowAllAbouteMe();
            return View(result);
        }
        [Route("/ContactUs")]
        public IActionResult ContactUs()
        {
            var result = contactUsService.ShowAllContactUs();
            return View(result);
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
