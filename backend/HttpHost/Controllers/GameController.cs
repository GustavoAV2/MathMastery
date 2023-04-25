using HttpHost.Domain.Dto;
using HttpHost.Domain.Models;
using HttpHost.Database.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using HttpHost.Domain.Abstractions;
using Microsoft.AspNetCore.Authorization;
using HttpHost.Services.Services;

namespace HttpHost.Services.Controllers
{
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly GameService _gameService;

        public GameController(ILogger<UserController> logger)
        {
            _logger = logger;
            _gameService = new GameService();
        }

        [HttpGet]
        [Route("/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Home()
        {
            return Ok("Api em funcionamento!");
        }

        [HttpGet]
        [Route("/game/create/{difficulty}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateGame(string difficulty)
        {
            var game = GenerateGame(difficulty);
            game.GenerateNewChallenge();
            return Ok(game);
        }

        [HttpPost]
        [Route("/game/next")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult NextChallenge(GameDto gameDto)
        {
            var game = _gameService.NextChallenge(gameDto);
            return Ok(game);
        }
    }
}
