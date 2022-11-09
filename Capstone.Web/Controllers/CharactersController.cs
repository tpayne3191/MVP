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
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterRepository _characterRepository;

        public CharactersController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            var result = _characterRepository.ReadAll();

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _characterRepository.ReadById(id);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(CharacterModel model)
        {
            Character character = new Character
            {
                Id = model.Id,
                PlayerId = model.PlayerId,
                CampaignId = model.CampaignId,
                Name = model.Name,
                Level = model.Level,
                ArmorClass = model.ArmorClass,
                HitPoints = model.HitPoints,
                Race = model.Race,
                Alignment = model.Alignment,
                Class = model.Class,
                Image = model.Image,
                Strength = model.Strength,
                Dexterity = model.Dexterity,
                Constitution = model.Constitution,
                Intelligence = model.Intelligence,
                Wisdom = model.Wisdom,
                Charisma = model.Charisma
            };

            var result = _characterRepository.Create(character);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
        [Authorize]
        [HttpPut]
        public IActionResult Edit(CharacterModel model)
        {
            Character character = new Character()
            {
                Name = model.Name,
                Id = model.Id,
                PlayerId = model.PlayerId,
                CampaignId = model.CampaignId,
                Level = model.Level,
                ArmorClass = model.ArmorClass,
                HitPoints = model.HitPoints,
                Race = model.Race,
                Alignment = model.Alignment,
                Class = model.Class,
                Image = model.Image,
                Strength = model.Strength,
                Dexterity = model.Dexterity,
                Constitution = model.Constitution,
                Intelligence = model.Intelligence,
                Wisdom = model.Wisdom,
                Charisma = model.Charisma
            };

            var result = _characterRepository.Update(character);

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
            var result = _characterRepository.Delete(id);

            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }
    }
}
