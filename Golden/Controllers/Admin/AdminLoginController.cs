using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Golden.Model.ClientLoginModel;

namespace Golden.Controllers.Admin
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AdminLoginController : ControllerBase
    {
        
        private readonly ApplicationDbContext _db;
       


        public AdminLoginController(ApplicationDbContext db)
        {

            _db = db;
            
            //_localization = localization;

        }

        [HttpPost]
        //[AllowAnonymous]
        public IActionResult Login([FromForm] AdminLoginModel model)
        {

            var obj = _db.admin.FirstOrDefault(u => u.UserName == model.UserName);


            if (obj == null)
            {

                return Unauthorized();

            }

            var obj1 = _db.admin.FirstOrDefault(u => u.Password == model.Password && u.UserName == model.UserName); ;
            if (obj1 == null)
                return BadRequest("wrong password!");


            var AccessToken = GenerateAccessToken(obj1.AdminId,obj1.Role);
            obj1.Token = AccessToken;

            _db.SaveChanges();

            var dto = new LoginDto()
            {
                AccessToken = AccessToken,

            };


            return Ok(dto);

        }

        private string GenerateAccessToken(int userid,string role)
        {

            var TokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("hdscjasjfhklasjfhSSdfjfjsdjr884237hwd58W73R3QWEJD");
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Role,role),
                        new Claim(ClaimTypes.Name,userid.ToString()),

                }),
                Expires = DateTime.UtcNow.AddDays(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),


            };
            var token = TokenHandler.CreateToken(tokenDescription);

            return TokenHandler.WriteToken(token);


        }
    }
}
