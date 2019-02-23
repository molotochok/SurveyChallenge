using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SurveyChallenge.Controllers
{
    public class SurveyController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}