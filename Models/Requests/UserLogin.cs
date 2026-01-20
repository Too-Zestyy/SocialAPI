namespace SocialAPI.Models.Requests;

public class UserLogin
{
    public required String Username { get; set; }
    public required String Password { get; set; }
}