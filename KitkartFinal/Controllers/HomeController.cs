using KitkartFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KitkartFinal.Controllers
{

    [Route("/")]
    public class HomeController : Controller
    {
       


        DbContextfile context = new DbContextfile();
        List<Product> product = new List<Product>();

        public HomeController()
        {
            product = context.Product.ToList();
        }


        public IActionResult Index()
        {
            return View(product);
        }
    }
   }

