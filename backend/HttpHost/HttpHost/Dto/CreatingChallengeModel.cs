using HttpHost.Models.Enums;

namespace HttpHost.Models
{
    public class CreateChallengeModel
    {
        public GameDifficulty Difficulty { get; set; }
        public bool MultipleChoice { get; set; }
    }
}
