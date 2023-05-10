using HttpHost.Domain.Abstractions;
using HttpHost.Domain.Models.Enums;
using System;
using System.Collections.Generic;

namespace HttpHost.Domain.Models
{
    public class NormalGame : IGame
    {
        public NormalGame(int challengesSolve, int challengesUnsolved)
        {
            ChallengesSolve = challengesSolve;
            ChallengesUnsolved = challengesUnsolved;
            Difficulty = GameDifficulty.Normal;
            MaxNumber = 1000;
            Operations = new List<ChallengeOperation>() {
                ChallengeOperation.Sum, ChallengeOperation.Subtract
            };
        }
    }
}
