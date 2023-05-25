using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using BarracksAllStarsCrudOperationCorePractice.Models;
using BarracksAllStarsCrudOperationCorePractice.PlayerData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarracksAllStarsCrudOperationCorePractice.Controllers
{
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private IPlayerData _playerData;
        public PlayersController(IPlayerData playerData)
        {
            _playerData = playerData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetPlayers()
        {
            return Ok(_playerData.GetPlayers());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetPlayer(Guid id)
        {
            var player = _playerData.GetPlayer(id);
            if(player != null)
            {
                return (Ok(player));
            }
            return NotFound($"Player with Id: {id} was not found.");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetPlayer(Player player)
        {
            _playerData.AddPlayer(player);
            return Created(HttpContext.Request.Scheme + HttpContext.Request.Path + "/" + player.Id, player);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeletePlayer(Guid id)
        {
            var player = _playerData.GetPlayer(id);
            if(player != null)
            {
                _playerData.DeletePlayer(player);
                return Ok();
            }
            return NotFound($"Player with Id: {id} was not found.");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditPlayer(Guid id, Player player)
        {
            var existing_player = _playerData.GetPlayer(id);
            if (existing_player != null)
            {
                player.Id = existing_player.Id;
                _playerData.EditPlayer(player);
            }
            return Ok(player);
        }
    }
}
