using Application.Dtos.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Common.Interface;
using Framework.Settings;
using Application.Dtos.Token;
using System.Security.Cryptography;

namespace Application.Common.Services;

public class TokenService : ITokenService
{
    private readonly JwtSetting _jwtSettings;

    public TokenService(IOptions<JwtSetting> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public TokenDto GenerateToken(UserDetailDto user)
    {
        var claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Username));
        claims.Add(new Claim(ClaimTypes.Name, user.Id.ToString()));
        claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString()));

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(_jwtSettings.Key);
        if (tokenKey.Length < 32)
        {
            throw new ArgumentException("Key size must be at least 256 bits.");
        }
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(_jwtSettings.DurationInDays),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return new TokenDto { Token = tokenHandler.WriteToken(token) };
    }
}
