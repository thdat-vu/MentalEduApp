using System;
using Microsoft.Extensions.Configuration;

namespace MentalEdu.BlazorApp.Client.Services
{
    public class AppConfigurationService
    {
        private readonly IConfiguration _configuration;

        public AppConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ApiBaseUrl => _configuration["ApiBaseUrl"] ?? "https://localhost:7276";
    }
}