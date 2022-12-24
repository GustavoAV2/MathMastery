using HttpHost.Interfaces;
using HttpHost.Models.Enums;
using HttpHost.Models.GameModels;

namespace HttpHost.Models
{
    public class HardGame : IGame
    {
        public override int MaxNumber { get; set; }
        public override int ChallengesPlayed { get; set; }
        public override int ChallengesSolve { get; set; }
        public override int ChallengesUnsolved { get; set; }
        public override Challenge? Challenge { get; set; }
        public override List<Operation> Operations { get; set; }

        public HardGame(int challengesSolve, int challengesUnsolved)
        {
            ChallengesSolve = challengesSolve;
            ChallengesUnsolved = challengesUnsolved;
            MaxNumber = 2000;
            Operations = new List<Operation>() {
                Operation.Sum, Operation.Subtract, Operation.Multiply
            };
        }
    }

}
