using HttpHost.Domain.Models.Enums;
using HttpHost.Domain.Models;
using System.Collections.Generic;
using System;

namespace HttpHost.Domain.Abstractions
{
    public abstract class IGame
    {
        public int MaxChallenges = 5;
        public List<int> RandomResults { get; set; }
        public int ChallengesPlayed
        {
            get
            {
                return ChallengesSolve + ChallengesUnsolved;
            }
        }
        public int MaxNumber { get; set; }
        public List<ChallengeOperation> Operations { get; set; }
        public int ChallengesSolve { get; set; }
        public int ChallengesUnsolved { get; set; }
        public GameDifficulty Difficulty { get; set; }
        public Challenge? Challenge { get; set; }

        public void GenerateNewChallenge()
        {
            Random rnd = new Random();
            int index = rnd.Next(Operations.Count);
            Challenge = new Challenge(operation: Operations[index], maxNumber: MaxNumber);
            RandomResults = Challenge.GeneratorResultsWithFakes();
        }

        public void SetChallenge(int firstNumber, int lastNumber, string operation)
        {
            Enum.TryParse(operation, out ChallengeOperation enumOperation);
            Challenge = new Challenge(enumOperation, 0, firstNumber, lastNumber);
        }

        public int TotalChallenges()
        {
            return ChallengesSolve + ChallengesUnsolved;
        }
    }
}
