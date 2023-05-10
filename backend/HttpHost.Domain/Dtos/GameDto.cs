using HttpHost.Domain.Models.Enums;

namespace HttpHost.Domain.Dto
{
    public class GameDto
    {
        public int ChallengesSolve { get; set; }
        public int ChallengesUnsolved { get; set; }
        public string Operation { get; set; }
        public int FirstNumber { get; set; }
        public int LastNumber { get; set; }
        public int Result { get; set; }
        public GameDifficulty Difficulty { get; set; }
    }
}
