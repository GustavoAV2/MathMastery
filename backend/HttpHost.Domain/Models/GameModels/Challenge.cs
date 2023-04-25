using HttpHost.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HttpHost.Domain.Models
{
    public class Challenge
    {
        private int MaxNumber { get; set; }

        public Random _random;
        public int FirstNumber { get; set; }
        public int LastNumber { get; set; }
        public ChallengeOperation Operation { get; set; }

        public Challenge(ChallengeOperation operation, int maxNumber, int firstNumber = 0, int lastNumber = 0)
        {
            _random = new Random();
            Operation = operation;
            MaxNumber = maxNumber;
            FirstNumber = firstNumber > 0 ? firstNumber : GenerateValueByOperation(MaxNumber);
            LastNumber = lastNumber > 0 ? lastNumber : GenerateValueByOperation(FirstNumber);
        }
        public float ActualResult
        {
            get
            {
                switch (Operation)
                {
                    case ChallengeOperation.Sum:
                        return FirstNumber + LastNumber;
                    case ChallengeOperation.Subtract:
                        return FirstNumber - LastNumber;
                    case ChallengeOperation.Division:
                        return FirstNumber / LastNumber;
                    case ChallengeOperation.Multiply:
                        return FirstNumber * LastNumber;
                    default:
                        return FirstNumber + LastNumber;
                }
            }
        }
        public bool VerifySolution(float number)
        {
            return ActualResult == number;
        }
        private int GenerateValueByOperation(int maxNumber)
        {
            return _random.Next(1, maxNumber);
        }

        public IOrderedEnumerable<float> GeneratorResultsWithFakes()
        {
            var list = new List<float>()
            {
                ActualResult + _random.Next(1000),
                ActualResult + _random.Next(100),
                ActualResult - _random.Next(100),
                ActualResult
            };
            return list.OrderBy(item => _random.Next());
        }
    }
}
