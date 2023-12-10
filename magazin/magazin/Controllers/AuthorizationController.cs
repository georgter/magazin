
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using magazin.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using magazin.ModelDto.User;
using magazin.Servis;

namespace magazin.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        
        private readonly IAuthorizationServis _authorizationServis;

        public AuthorizationController(IAuthorizationServis authorizationServis)
        {
            _authorizationServis = authorizationServis;
        }

        [HttpPost("/authorization")]
        public async Task<IActionResult> Authorization([FromBody] AuthorizationUserDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { errorText = "Invalid model" });
            }

            var t = await _authorizationServis.AuthenticateUser(model.UserName, model.Password);
            if (t.UserName != null)
            {
               var identity = GetIdentity(t.UserName, t.Role);
               var now = DateTime.UtcNow;
               var jwt = Jwt(now, identity);
               var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

               var response = new
               {
                   access_token = encodedJwt,
                   username = identity.Name,
                   role = t.Role,
               };

               return Ok(response);
            }
            
            return BadRequest(new { errorText = t.Message });
        }

        [HttpPost("/registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationUserDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { errorText = "Invalid model" });
            }

            var t = await _authorizationServis.RegisterUser(model);
            if (t.UserName != null)
            {
                var identity = GetIdentity(t.UserName, t.Role);
                var now = DateTime.UtcNow;
                var jwt = Jwt(now, identity);
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                var response = new
                {
                    access_token = encodedJwt,
                    username = identity.Name,
                    role = t.Role,
                };

                return Ok(response);
            }

            return BadRequest(new { errorText = t.Message });
        }

        private  JwtSecurityToken Jwt( DateTime now , ClaimsIdentity identity)
        {
            return new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        }

        private ClaimsIdentity GetIdentity(string name, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
            };
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
