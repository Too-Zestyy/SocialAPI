using Microsoft.IdentityModel.Tokens;

namespace SocialAPI;

public static class JwtConst
{
    private static readonly string AppDomain = "cs-notes.com";
    public static readonly string Issuer = AppDomain;
    public static readonly string Audience = AppDomain;
    
    // TODO: Replace with key from file (ideally asymmetric)
    public static readonly SymmetricSecurityKey Key = new (new byte[256]);
}