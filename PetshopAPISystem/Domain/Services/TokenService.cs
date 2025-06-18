using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PetshopAPISystem.Domain.Contexts;
using PetshopAPISystem.Domain.Models;
using PetshopAPISystem.infra.Configs;

namespace PetshopAPISystem.Domain.Services;

public class TokenService
{
    public static string KEY = Configuration.PrivateKey;
    
    public string GenerateToken(Tutor tutor)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        
        var key = Encoding.ASCII.GetBytes(KEY);

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key), 
            SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GenerateClaimsIdentity(tutor),
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(2),
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(token);
    }

    public static ClaimsIdentity GenerateClaimsIdentity(Tutor tutor)
    {
        var claimsIdentity = new ClaimsIdentity();
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, tutor.Email));
        foreach (var role in tutor.Roles)
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.ToString()));
        return claimsIdentity;
    }
}