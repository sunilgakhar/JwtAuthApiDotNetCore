// AppConfigMessages.cs
public static class AppConfigMessages
{
    public const string JwtKeyMissing = "JWT Key configuration is missing.";
    public const string JwtIssuerMissing = "JWT Issuer configuration is missing.";
    public const string JwtAudienceMissing = "JWT Audience configuration is missing.";
    public const string InvalidCredentials = "Invalid credentials.";
    public const string PublicEndPoint = "This endpoint is public and does not require authorization.";
    public const string ProtectedEndPoint = "This is a protected endpoint, accessible only to authenticated users.";
}
