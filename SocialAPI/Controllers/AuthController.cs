using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SocialAPI.Models.Requests;

namespace SocialAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpGet("login")]
    // [Authorize]
    public ActionResult Login([Required][FromBody] UserLogin user)
    {
        if (user.Username == "admin" && user.Password == "password")
        {
            var token = GenerateJwtToken(user.Username);
            return Ok(new { token });
        }
        return Unauthorized();
    }
    
    private string GenerateJwtToken(string username)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = JwtConst.Key;
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: JwtConst.Issuer,
            audience: JwtConst.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    [HttpGet("test")]
    [Authorize]
    public ActionResult Test()
    {
        return Ok();
    }
}