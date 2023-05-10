using HttpHost.Domain.Abstractions;
using HttpHost.Domain.Models.Enums;
using System.Collections.Generic;

namespace HttpHost.Domain.Models
{
    public class HardGame : IGame
    {
        public HardGame(int challengesSolve, int challengesUnsolved)
        {
            ChallengesSolve = challengesSolve;
            ChallengesUnsolved = challengesUnsolved;
            Difficulty = GameDifficulty.Hard;
            MaxNumber = 2000;
            Operations = new List<ChallengeOperation>() {
                ChallengeOperation.Sum, ChallengeOperation.Subtract, ChallengeOperation.Multiply
            };
        }
    }

}
