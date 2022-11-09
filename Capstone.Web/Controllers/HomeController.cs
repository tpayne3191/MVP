using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;


namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("/")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {
            return Redirect("http://localhost:4200/login");
        }
    }
}
