namespace AFORO255.MS.TEST.Security.DTOs;

public class AuthResponse
{
    public AuthResponse(string token, string expiration)
    {
        Token = token;
        Expiration = expiration;
    }

    public string? Token { get; set; }
    public string? Expiration { get; set; }
}
