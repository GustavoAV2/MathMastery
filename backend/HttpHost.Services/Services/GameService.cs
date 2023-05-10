using HttpHost.Domain.Dto;
using HttpHost.Domain.Models;
using HttpHost.Domain.Abstractions;
using HttpHost.Domain.Models.Enums;

namespace HttpHost.Services
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

        public IGame GenerateGame(GameDifficulty difficulty, int challengeSolve = 0, int challengeUnsolved = 0)
        {
            if (difficulty == GameDifficulty.Genius)
            {
                return new GeniusGame(challengeSolve, challengeUnsolved);
            }
            else if (difficulty == GameDifficulty.Hard)
            {
                return new HardGame(challengeSolve, challengeUnsolved);
            }
            else
            {
                return new NormalGame(challengeSolve, challengeUnsolved);
            }
        }
    }
}
