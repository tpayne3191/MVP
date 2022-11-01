using Capstone.Core.Entities;
using Capstone.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponsController : ControllerBase
    {
        private readonly IWeaponRepository _WeaponRepository;

        public WeaponsController(IWeaponRepository WeaponRepository)
        {
            _WeaponRepository = WeaponRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            var result = _WeaponRepository.ReadAll();

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _WeaponRepository.ReadById(id);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(Weapon model)
        {
            var result = _WeaponRepository.Create(model);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [Authorize]
        [HttpPut]
        public IActionResult Edit(Weapon model)
        {
            var result = _WeaponRepository.Update(model);

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
            var result = _WeaponRepository.Delete(id);

            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }
    }
}
