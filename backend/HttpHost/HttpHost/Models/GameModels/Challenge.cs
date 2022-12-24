using HttpHost.Models.Enums;
using System;

namespace HttpHost.Models.GameModels
{
    public class Challenge
    {
        private int MaxNumber { get; set; }

        public Random _random;
        public int FirstNumber { get; set; }
        public int LastNumber { get; set; }
        public Operation Operation { get; set; }

        public Challenge(Operation operation, int maxNumber)
        {
            _random = new Random();
            Operation = operation;
            MaxNumber = maxNumber;
            FirstNumber = GenerateValueByOperation(MaxNumber);
            LastNumber = GenerateValueByOperation(FirstNumber);
        }
        public float ActualResult
        {
            get
            {
                switch (Operation)
                {
                    case Operation.Sum:
                        return FirstNumber + LastNumber;
                    case Operation.Subtract:
                        return FirstNumber - LastNumber;
                    case Operation.Division:
                        return FirstNumber / LastNumber;
                    case Operation.Multiply:
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
