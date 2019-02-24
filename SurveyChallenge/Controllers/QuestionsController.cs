using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SurveyChallenge.Controllers
{
    public class QuestionsController : Controller
    {
        public IActionResult New(int id)
        {
            return View(id);
        }
    }
}