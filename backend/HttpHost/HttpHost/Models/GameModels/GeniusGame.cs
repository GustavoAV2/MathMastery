using HttpHost.Interfaces;
using HttpHost.Models.Enums;
using HttpHost.Models.GameModels;

namespace HttpHost.Models
{
    public class GeniusGame : IGame
    {
        public override int MaxNumber { get; set; }
        public override int ChallengesSolve { get; set; }
        public override int ChallengesUnsolved { get; set; }
        public override Challenge? Challenge { get; set; }
        public override List<ChallengeOperation> Operations { get; set; }

        public GeniusGame(int challengesSolve, int challengesUnsolved)
        {
            MaxNumber = 2000;
            ChallengesSolve = challengesSolve;
            ChallengesUnsolved = challengesUnsolved;
            Operations = new List<ChallengeOperation>() {
                ChallengeOperation.Sum, ChallengeOperation.Subtract,
                ChallengeOperation.Multiply, ChallengeOperation.Division
            };
        }
    }

}
