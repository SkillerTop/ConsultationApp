using System;
using ConsultationApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConsultationApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var products = new[] { "JavaScript", "C#", "Java", "Python", "Основи" };
            ViewBag.ProductList = new SelectList(products);

            return View();
        }

        [HttpPost]
        public ActionResult RegisterConsultation(ConsultationRegistrationModel model)
        {
            if (!ModelState.IsValid)
            {

                return View("Index", model);
            }

            if (String.Equals(model.SelectedProduct, "Основи", StringComparison.OrdinalIgnoreCase) && model.PreferredDate.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError("PreferredDate", "Консультації з продукту 'Основи' не можуть проходити по понеділках.");
                return View("Index", model);
            }

            return RedirectToAction(nameof(RegistrationSuccess));
        }

        public ActionResult RegistrationSuccess()
        {

            return View();
        }
    }
}
