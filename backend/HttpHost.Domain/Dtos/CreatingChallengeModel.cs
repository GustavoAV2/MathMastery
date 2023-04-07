using HttpHost.Domain.Models.Enums;

namespace HttpHost.Domain.Dto
{
    public class CreateChallengeModel
    {
        public GameDifficulty Difficulty { get; set; }
        public bool MultipleChoice { get; set; }
    }
}
