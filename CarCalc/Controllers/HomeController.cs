using CarCalc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarCalc.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Calculator()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(CalculatorModel model)
        {
            double dealerFee = 399;
            double taxableCost = model.Cost + dealerFee;
            double tax = 0;

            // Calculate tax based on tax rate
            if (model.TaxRate == 7)
            {
                tax = (0.06 * taxableCost) + 50;
            }
            else if (model.TaxRate == 6.5)
            {
                tax = (0.06 * taxableCost) + 25;
            }
            else if (model.TaxRate == 6)
            {
                tax = 0.06 * taxableCost;
            }

            // Calculate total cost
            model.TotalCost = model.Cost + dealerFee + tax + model.TagFee;

            return View("Calculator", model); // Return to the Calculator view with the result
        }
    }
}