using HttpHost.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HttpHost.Domain.Models.Enums;

namespace HttpHost.Services.Controllers
{
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;

        public GameController()
        {
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
        [Authorize]
        [Route("/game/create/{difficulty}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateGame(GameDifficulty difficulty)
        {
            try
            {
                var game = _gameService.GenerateGame(difficulty);
                game.GenerateNewChallenge();
                return Ok(game);
            }
            catch (Exception)
            {
                return BadRequest(); ;
            }
        }

        [HttpPost]
        [Authorize]
        [Route("/game/next")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult NextChallenge(GameDto gameDto)
        {
            try
            {
                var game = _gameService.NextChallenge(gameDto);
                return Ok(game);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
