using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Caching.Distributed;

namespace HttpHost.Middlewares.Identification
{
    public class AdminMiddleware
    {
        private readonly RequestDelegate _next;

        public AdminMiddleware(RequestDelegate next)
        {
            _next = next;
        }
 
        public async Task Invoke(HttpContext context, IDistributedCache cache)
        {   
            var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
            var attribute = endpoint?.Metadata.GetMetadata<AdminAttribute>();

            var authenticaded = false;

            var authorization = context.Request.Headers["Authorization"];
            //Adicionar comparacao de Bearer Token
            if (!String.IsNullOrWhiteSpace(authorization))
            {
                var cachedAuthorization = cache.GetString(authorization);

                if (string.IsNullOrEmpty(cachedAuthorization))
                {
                    authenticaded = true;
                    cache.SetString(authorization, authorization, new DistributedCacheEntryOptions { AbsoluteExpiration = DateTime.Now.AddMinutes(30) });
                }
                else
                {
                    authenticaded = true;
                }
            }

            if (authenticaded)
                await _next(context);
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                var errorJson = JsonSerializer.Serialize(new { error = "Authorization header should be not empty" });
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(errorJson);
            }
        }
    }
}