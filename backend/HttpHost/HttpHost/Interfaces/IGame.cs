using HttpHost.Models.Enums;
using HttpHost.Models.GameModels;
using System.Collections.Generic;

namespace HttpHost.Interfaces
{
    public abstract class IGame
    {
        public int MaxChallenges = 5;
        public abstract int MaxNumber { get; set; }
        public abstract List<Operation> Operations { get; set; }
        public abstract int ChallengesPlayed { get; set; }
        public abstract int ChallengesSolve { get; set; }
        public abstract int ChallengesUnsolved { get; set; }
        public abstract Challenge? Challenge { get; set; }

        public void GenerateNewChallenge()
        {
            Random rnd = new Random();
            int index = rnd.Next(Operations.Count);
            Challenge = new Challenge(operation: Operations[index], maxNumber: MaxNumber);
        }
        public int TotalChallenges()
        {
            return ChallengesSolve + ChallengesUnsolved;
        }
    }
}
