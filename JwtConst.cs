using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace SocialAPI;

public static class JwtConst
{
    private static readonly string AppDomain = "cs-notes.com";
    public static readonly string Issuer = AppDomain;
    public static readonly string Audience = AppDomain;
    
    // TODO: Replace with key from file (ideally asymmetric)
    public static readonly SymmetricSecurityKey Key = new (new byte[256]);

    public static readonly ECDsaSecurityKey PublicKey = LoadKey("./public.pem");
    public static readonly ECDsaSecurityKey PrivateKey = LoadKey("./private.pem");

    private static ECDsaSecurityKey LoadKey(string path)
    {
        var ed = ECDsa.Create();

        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"Private key at path {path} was not found.");
        }
        var privateKeyContent = File.ReadAllText(path);
        
        ed.ImportFromPem(privateKeyContent);
        var key = new ECDsaSecurityKey(ed);
        
        return key;

    }
}