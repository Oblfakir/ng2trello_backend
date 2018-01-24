using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ng2trello_backend
{
  public class AuthOptions
  {
    public const string ISSUER = "AuthenticationServer";
    public const string AUDIENCE = "http://localhost:4200/";
    const string KEY = "xxxX_sekretniy_kluch_228_Xxx";
    public const int LIFETIME = 60;
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
      return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }

    public static TokenValidationParameters GetValidationParameters()
    {
      return new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidIssuer = AuthOptions.ISSUER,
        ValidateAudience = true,
        ValidAudience = AuthOptions.AUDIENCE,
        ValidateLifetime = true,
        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
        ValidateIssuerSigningKey = true
      };
    }
  }
}
