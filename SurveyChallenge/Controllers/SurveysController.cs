using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SurveyChallenge.Controllers
{
    public class SurveysController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
        {
            return View();
        }

        public IActionResult Save()
        {
            return RedirectToAction("Index", "Surveys");
        }

        public IActionResult Detail(int id)
        {
            return View(id);
        }
    }
}