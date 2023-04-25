using HttpHost.Domain.Abstractions;
using HttpHost.Domain.Models.Enums;
using System.Collections.Generic;

namespace HttpHost.Domain.Models
{
    public class NormalGame : IGame
    {
        public override int MaxNumber { get; set; }
        public override int ChallengesSolve { get; set; }
        public override int ChallengesUnsolved { get; set; }
        public override Challenge? Challenge { get; set; }
        public override List<ChallengeOperation> Operations { get; set; }

        public NormalGame(int challengesSolve, int challengesUnsolved)
        {
            ChallengesSolve = challengesSolve;
            ChallengesUnsolved = challengesUnsolved;
            MaxNumber = 1000;
            Operations = new List<ChallengeOperation>() {
                ChallengeOperation.Sum, ChallengeOperation.Subtract
            };
        }
    }
}
