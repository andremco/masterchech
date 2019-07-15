using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace ZueroTopBot.Middlewares
{
    public class APIKeyMiddleware
    {
        private IConfiguration _configuration;

        private readonly RequestDelegate _next;

        public APIKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        IConfiguration GetValidKeyAppSettings()
        {
            return Program.ConfigurationBuilder();
        }

        public Task Invoke(HttpContext context)
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
                var json = JsonConvert.SerializeObject(new { result = "Something wrong with your request. Possible Api Key! :(" });
                context.Response.StatusCode = 403;
                context.Response.WriteAsync(json);

                return Task.FromResult<object>(null);
            }

            return _next(context);
        }
    }
}
