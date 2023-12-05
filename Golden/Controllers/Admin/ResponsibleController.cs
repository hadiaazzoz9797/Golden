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
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin")]

    public class ResponsibleController:ControllerBase
    {
        private readonly ILogger<ResponsibleController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IResponsibleService _supervisorservice;

       

        public ResponsibleController(ApplicationDbContext db, IResponsibleService supervisorservice, ILogger<ResponsibleController> logger)
        {

            _db = db;
            _supervisorservice = supervisorservice;
            _logger = logger;
            //_localization = localization;

        }
       

        [HttpGet()]
        //[AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var Result = await _supervisorservice.GetAllAsync();
            return Ok(Result);
        }



        [HttpGet("{id}")]
        //[AllowAnonymous]
        public IActionResult Get([FromRoute] int id)
        {
            var Result = _supervisorservice.Get(id);
            return Ok(Result);
        }

        [HttpPost]
        //[AllowAnonymous]
        public async Task<IActionResult> Create([FromForm] ResponsibleModel model)
        {
            try
            {
                await _supervisorservice.CreateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }


        }

  


        [HttpPut("{id}")]
       
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] ResponsibleUpdate model)
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
        //[AllowAnonymous]
        public IActionResult Delete([FromRoute] int id)
        {

            _supervisorservice.Delete(id);
            return Ok();
        }

    }
}
