using HttpHost.Dto;
using HttpHost.Data;
using HttpHost.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HttpHost.Interfaces;
using HttpHost.Middlewares.Identification;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace HttpHost.Controllers
{
    [ApiController]
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
            var game = GenerateGame(
                    gameDto.Difficulty, gameDto.ChallengesSolve, gameDto.ChallengesUnsolved
                );
            game.SetChallenge(gameDto.FirstNumber, gameDto.LastNumber, gameDto.Operation);

            if (game.Challenge.VerifySolution(gameDto.Result))
                game.ChallengesSolve += 1;
            else
                game.ChallengesUnsolved += 1;

            game.GenerateNewChallenge();
            return Ok(game);
        }

        private IGame GenerateGame(string difficulty, int challengeSolve = 0, int challengeUnsolved = 0)
        {
            if (difficulty == "normal")
            {
                return new NormalGame(challengeSolve, challengeUnsolved);
            }
            else if (difficulty == "hard")
            {
                return new HardGame(challengeSolve, challengeUnsolved);
            }
            else if (difficulty == "genius")
            {
                return new GeniusGame(challengeSolve, challengeUnsolved);
            }
            else
            {
                return new EasyGame(challengeSolve, challengeUnsolved);
            }
        }
    }
}
