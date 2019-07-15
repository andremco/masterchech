using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace ZueroTopBot.Middlewares
{
    public class APIKeyMiddleware
    {
        private readonly RequestDelegate _next;

        private IConfiguration _configuration;

        IConfiguration GetValidKeyAppSettings()
        {
            return Program.ConfigurationBuilder();
        }

        public async Task Invoke(HttpContext context)
        {
            _configuration = GetValidKeyAppSettings();

            bool validKey = false;

            var apiKeyValid = _configuration["ApiKeyValid"];

            if (apiKeyValid == null)
            {
                throw new NullReferenceException();
            }

            StringValues requestHeaders;
            bool checkApiKeyExists = context.Request.Headers.TryGetValue("APIKey", out requestHeaders);

            if (checkApiKeyExists)
            {
                if (requestHeaders.ToArray().FirstOrDefault().Equals(apiKeyValid))
                {
                    validKey = true;
                }
            }

            if (!validKey)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Something wrong with your request. Possible Api Key! :(");
                return;
            }

            await _next(context);
        }
    }
}
