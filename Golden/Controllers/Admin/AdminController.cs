using Golden.Model;
using Golden.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using static Golden.Model.ClientLoginModel;

namespace Golden.Controllers.Admin
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class AdminController:ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly ISuperVisorService _supervisorservice;

       

        public AdminController(ApplicationDbContext db, ISuperVisorService supervisorservice, ILogger<AdminController> logger)
        {

            _db = db;
            _supervisorservice = supervisorservice;
            _logger = logger;
            //_localization = localization;

        }
        [HttpPost]
        [AllowAnonymous]
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


            var AccessToken = GenerateAccessToken(obj1.AdminId);
            obj1.Token = AccessToken;

            _db.SaveChanges();

            var dto = new LoginDto()
            {
                AccessToken = AccessToken,

            };


            return Ok(dto);

        }

        private string GenerateAccessToken(int userId)
        {

            var TokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("hdscjasjfhklasjfhSSdfjfjsdjr884237hwd58W73R3QWEJD");
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        //new Claim(ClaimTypes.Role,role),
                        new Claim(ClaimTypes.Name,userId.ToString()),

                }),
                Expires = DateTime.UtcNow.AddDays(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),


            };
            var token = TokenHandler.CreateToken(tokenDescription);

            return TokenHandler.WriteToken(token);


        }

        [HttpGet()]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var Result = await _supervisorservice.GetAllAsync();
            return Ok(Result);
        }



        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get([FromRoute] int id)
        {
            var Result = _supervisorservice.Get(id);
            return Ok(Result);
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> Create([FromForm] SuperVisorModel model)
        //{
        //    try
        //    {
        //        await _supervisorservice.CreateAsync(model);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        //    }


        //}

        //[HttpPost]
        //public async Task<IActionResult> Create([FromForm] SuperVisorModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
        //        await _supervisorservice.CreateAsync(model);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log the exception
        //        _logger.LogError(ex, "Error in Create action");
        //        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        //    }
        //}





        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] SuperVisorUpdate model)
        {

            try
            {
                await _supervisorservice.Update(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {

            _supervisorservice.Delete(id);
            return Ok();
        }

    }
}
