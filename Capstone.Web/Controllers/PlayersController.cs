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
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayersController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            var result = _playerRepository.ReadAll();

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _playerRepository.ReadById(id);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(PlayerModel model)
        {
            Player player = new Player
            {
                PlayerId = model.PlayerId,
                Name = model.Name,
                Phone = model.Phone,
                Email = model.Email,
                City = model.City
            };

            var result = _playerRepository.Create(player);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [Authorize]
        [HttpPut]
        public IActionResult Edit(PlayerModel model)
        {
            Player player = new Player()
            {
                PlayerId = model.PlayerId,
                Name = model.Name,
                Phone = model.Phone,
                Email = model.Email,
                City = model.City
            };

            var result = _playerRepository.Update(player);

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
            var result = _playerRepository.Delete(id);

            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }
    }
}
