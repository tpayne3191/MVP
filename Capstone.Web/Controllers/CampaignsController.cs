using Capstone.Core.Entities;
using Capstone.Core.Interfaces;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {
        private readonly ICampaignRepository _campaignRepository;

        public CampaignsController(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            var result = _campaignRepository.ReadAll();

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _campaignRepository.ReadById(id);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(CampaignModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Data not valid");
            }
            Campaign campaign = new Campaign
            {
                Id = model.id,
                Name = model.Name,
                DateStarted = model.DateStarted,
                DateEnded = model.DateEnded
            };

            var result = _campaignRepository.Create(campaign);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [Authorize]
        [HttpPut]
        public IActionResult Edit(CampaignModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Data not valid");
            }
            Campaign campaign = new Campaign()
            {
                Id = model.id,
                Name = model.Name,
                DateStarted = model.DateStarted,
                DateEnded = model.DateEnded
            };

            var result = _campaignRepository.Update(campaign);

            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _campaignRepository.Delete(id);

            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }
    }
}
