using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Controllers
{
    public class CharactersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
