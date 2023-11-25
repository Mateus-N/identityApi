using Newtonsoft.Json;
using StackExchange.Redis;
using System.Text;
using System;

namespace ApiGateway;

public class RedisMiddleware
{
    private readonly RequestDelegate next;
    private readonly IDatabase redisDatabase;

    public RedisMiddleware(RequestDelegate next, IConnectionMultiplexer redisDatabase)
    {
        this.next = next;
        this.redisDatabase = redisDatabase.GetDatabase();
    }

    public async Task Invoke(HttpContext context)
    {
        await next(context);

        if (context.Response.StatusCode == StatusCodes.Status200OK && context.Request.Path.StartsWithSegments("/api/login"))
        {
            //var responseContent = context.Response.Body.ToString()!;
            //var loginResponse = JsonConvert.DeserializeObject<TokenModel>(responseContent)!;

            //var login = context.Request.Form["UserName"];
            //var password = context.Request.Form["Password"];
            //var key = $"{login}:{password}";

            //redisDatabase.StringSet(key, loginResponse.Token);
        }
    }
}
