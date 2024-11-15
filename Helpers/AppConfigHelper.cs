// AppConfigHelper.cs
using Microsoft.Extensions.Configuration;
using System;

public static class AppConfigHelper
{
    private static IConfiguration _configuration;

    // Initialize with the configuration instance (should be called in Program.cs)
    public static void Initialize(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // Method to get the JWT Key
    public static string GetJwtKey()
    {
        return GetConfigValue("Jwt:Key", AppConfigMessages.JwtKeyMissing);
    }

    // Method to get the JWT Issuer
    public static string GetJwtIssuer()
    {
        return GetConfigValue("Jwt:Issuer", AppConfigMessages.JwtIssuerMissing);
    }

    // Method to get the JWT Audience
    public static string GetJwtAudience()
    {
        return GetConfigValue("Jwt:Audience", AppConfigMessages.JwtAudienceMissing);
    }

    // Private helper method to retrieve a configuration value with error handling
    private static string GetConfigValue(string key, string errorMessage)
    {
        var value = _configuration[key];
        if (string.IsNullOrEmpty(value))
        {
            throw new Exception(errorMessage);
        }
        return value;
    }
}
