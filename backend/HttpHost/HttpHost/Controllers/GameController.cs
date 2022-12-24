using HttpHost.Dto;
using HttpHost.Data;
using HttpHost.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HttpHost.Interfaces;

namespace AutomationsAPI.HttpHost.Controllers
{
    [ApiController]
    [Route("/game")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserDb _userDb;

        public GameController(ILogger<UserController> logger, UserDb userDb)
        {
            _logger = logger;
            _userDb = userDb;
        }

        [HttpGet]
        [Route("/game/create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateGame(GameDto gameDto)
        {
            var game = GenerateGame(gameDto);
            game.GenerateNewChallenge();
            return Ok(game);
        }

        [HttpPost]
        [Route("/game/next")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult NextChallenge(GameDto gameDto)
        {
            var game = GenerateGame(gameDto);
            game.GenerateNewChallenge();
            return Ok(game);
        }

        public IGame GenerateGame(GameDto gameDto)
        {
            if (gameDto.Difficulty == "normal")
            {
                return new NormalGame(0, 0);
            }
            else if (gameDto.Difficulty == "hard")
            {
                return new HardGame(0, 0);
            }
            else if (gameDto.Difficulty == "genius")
            {
                return new GeniusGame(0, 0);
            }
            else
            {
                return new EasyGame(0, 0);
            }
        }
    }
}
