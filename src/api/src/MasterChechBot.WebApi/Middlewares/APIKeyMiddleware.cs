﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace MasterChechBotWebApi.Middlewares
{
    public class APIKeyMiddleware
    {
        private IConfiguration _configuration;

        private readonly RequestDelegate _next;

        public APIKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public Task Invoke(HttpContext context)
        {
            bool validKey = false;

            var apiKeyValid = System.Environment.GetEnvironmentVariable("ApiKeyValid");

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
