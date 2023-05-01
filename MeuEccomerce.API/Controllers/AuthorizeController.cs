using MeuEccomerce.API.Application.Mappings;
using MeuEccomerce.API.Application.Models.DTO_s;
using MeuEccomerce.Domain.AggregatesModel.UserAggregate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MeuEccomerce.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthorizeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizeController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                throw new Exception("Password does not match");
            }
            var user = new User { UserName = model.UserName, FullName = model.FullName ,Email = model.Email,PhoneNumber = model.PhoneNumber, AccountCreationDate = DateTime.Now, LastLoginDate = DateTime.Now};
            var result = await _userManager.CreateAsync(user, model.Password);
            
            
            if (result.Succeeded)
            {
                var address = new UserAddress(Guid.Parse(user.Id), model.Address.StreetName, model.Address.City, model.Address.PostalCode, model.Address.Country);

                user.Address = address;
                await _userManager.UpdateAsync(user); 

                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok(GenerateToken(model));
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            if (result.Succeeded)
            {
                return Ok(GenerateToken(model));
            }

            return Unauthorized();
        }

        private UserTokenDTO GenerateToken(UserDTO userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireHours = _configuration["TokenConfiguration:ExpireHours"];
            var expiration = DateTime.UtcNow.AddHours(double.Parse(expireHours.ToString()));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["TokenConfiguration:Issuer"],
                audience: _configuration["TokenConfiguration:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials);

            return new UserTokenDTO()
            {
                Authenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
                Message = "Token ok"
            };
        }
    }
}

