using Azure;
using HttpHost.Models.Enums;
using HttpHost.Models.GameModels;

namespace HttpHost.Interfaces
{
    public abstract class IGame
    {
        public int MaxChallenges = 5;
        public int ChallengesPlayed
        {
            get
            {
                return ChallengesSolve + ChallengesUnsolved;
            }
        }
        public abstract int MaxNumber { get; set; }
        public abstract List<ChallengeOperation> Operations { get; set; }
        public abstract int ChallengesSolve { get; set; }
        public abstract int ChallengesUnsolved { get; set; }
        public abstract Challenge? Challenge { get; set; }

        public void GenerateNewChallenge()
        {
            Random rnd = new Random();
            int index = rnd.Next(Operations.Count);
            Challenge = new Challenge(operation: Operations[index], maxNumber: MaxNumber);
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
