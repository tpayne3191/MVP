using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Core.Interfaces;

namespace Capstone.Web.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IReportRepository _reportRepository;

        public ReportsController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        [Route("reports")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("reports/largesthealthpools")]
        [HttpGet]
        public IActionResult LargestHealthPools()
        {
            var result = _reportRepository.GetCharactersByHealthPool();

            if (result.Success) return View(result.Data);

            throw new Exception(result.Message);
        }

        [Route("reports/longestcampaigns")]
        [HttpGet]
        public IActionResult LongestCampaigns()
        {
            var result = _reportRepository.GetLongestCampaigns();

            if (result.Success) return View(result.Data);

            throw new Exception(result.Message);
        }
    }
}
