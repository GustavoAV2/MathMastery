using HttpHost.Domain.Abstractions;
using HttpHost.Domain.Dto;
using HttpHost.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpHost.Services.Services
{
    public class GameService
    {
        public IGame NextChallenge(GameDto gameDto)
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
            return game;
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
