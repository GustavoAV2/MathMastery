using HttpHost.Domain.Abstractions;
using HttpHost.Domain.Models.Enums;
using System.Collections.Generic;

namespace HttpHost.Domain.Models
{
    public class GeniusGame : IGame
    {
        public GeniusGame(int challengesSolve, int challengesUnsolved)
        {
            MaxNumber = 2000;
            ChallengesSolve = challengesSolve;
            ChallengesUnsolved = challengesUnsolved;
            Difficulty = GameDifficulty.Genius;
            Operations = new List<ChallengeOperation>() {
                ChallengeOperation.Sum, ChallengeOperation.Subtract,
                ChallengeOperation.Multiply, ChallengeOperation.Division
            };
        }
    }

}
