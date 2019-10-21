using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Plan_Calculator.Models;

namespace Plan_Calculator.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([Bind("price,purchaseDate")] Plan plan)
        {
            ViewBag.plans = new List<Plan>();
            if (plan.price >= 10000 || plan.price< 100)
            {
                ViewBag.Message = "Plans not offered"; 
                
            }else if (plan.price >= 100 && plan.price < 1000)
            {
                Plan planA = new Plan();
                planA.price = plan.price;
                planA.purchaseDate = plan.purchaseDate;
                planA.initDepositeRate = 0.2;
                planA.installmentInterval = 15;
                planA.installments = 5;
                ViewBag.plans.Add(planA);

                Plan planB = new Plan();
                planB.price = plan.price;
                planB.purchaseDate = plan.purchaseDate;
                planB.initDepositeRate = 0.3;
                planB.installmentInterval = 15;
                planB.installments = 4;
                ViewBag.plans.Add(planB);
            }
            else if (plan.price >= 1000 && plan.price < 10000)
            {
                Plan planA = new Plan();
                planA.price = plan.price;
                planA.purchaseDate = plan.purchaseDate;
                planA.initDepositeRate = 0.25;
                planA.installmentInterval = 30;
                planA.installments = 4;
                ViewBag.plans.Add(planA);
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
