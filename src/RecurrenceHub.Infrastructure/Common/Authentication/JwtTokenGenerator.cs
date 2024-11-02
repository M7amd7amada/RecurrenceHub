using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.IdentityModel.Tokens;

using RecurrenceHub.Application.Common.Interfaces.Authentication;

namespace RecurrenceHub.Infrastructure.Common.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
        var singingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(firstName)),
            SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>()
        {
            new (JwtRegisteredClaimNames.Sub, userId.ToString()),
            new (JwtRegisteredClaimNames.GivenName, firstName),
            new (JwtRegisteredClaimNames.FamilyName, lastName),
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: "7amada",
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: singingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
