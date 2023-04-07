using Microsoft.AspNetCore.Mvc;

namespace HttpHost.Domain.Dto.Headers
{
    public class AuthHeaderDto
    {
        [FromHeader]
        public string Authorization { get; set; } = string.Empty;
    }
}
