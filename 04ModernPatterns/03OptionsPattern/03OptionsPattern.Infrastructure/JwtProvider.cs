using _03OptionsPattern.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace _03OptionsPattern.Infrastructure;

public sealed class JwtProvider(IOptions<JwtOptions> options)
{
    public string CreateToken()
    {
        var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SecretKey));

        JwtSecurityToken securityToken = new(
            issuer: "asdsad",//options.Value.Issuer,
            audience: "23123123",//options.Value.Audience,
            claims: [],
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha512)
            );

        JwtSecurityTokenHandler handler = new();
        var token = handler.WriteToken(securityToken);
        return token;
    }
}
