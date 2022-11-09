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
    public class WeaponsController : ControllerBase
    {
        private readonly IWeaponRepository _weaponRepository;

        public WeaponsController(IWeaponRepository weaponRepository)
        {
            _weaponRepository = weaponRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            var result = _weaponRepository.ReadAll();

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _weaponRepository.ReadById(id);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(WeaponModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Data not valid");
            }
            Weapon weapon = new Weapon()
            {
                Id = model.id,
                Name = model.Name,
                Description = model.Description,
                Damage = model.Damage,
                Range = model.Range
            };

            var result = _weaponRepository.Create(weapon);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [Authorize]
        [HttpPut]
        public IActionResult Edit(WeaponModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Data not valid");
            }
            Weapon weapon = new Weapon()
            {
                Id = model.id,
                Name = model.Name,
                Description = model.Description,
                Damage = model.Damage,
                Range = model.Range
            };

            var result = _weaponRepository.Update(weapon);

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
            var result = _weaponRepository.Delete(id);

            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }
    }
}
