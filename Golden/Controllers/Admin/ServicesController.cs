using Golden.Model;
using Golden.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Golden.Controllers.Admin
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Authorize(Roles = "Admin")]

    public class ServicesController : ControllerBase
    {

       
        private readonly ApplicationDbContext _db;
        private readonly ISevicesService _servicesservice;

        public ServicesController( ApplicationDbContext db, ISevicesService servicesservice)
        {
            
            _db = db;
            _servicesservice = servicesservice;
        }

        [HttpGet()]
    
        public async Task<IActionResult> GetAll()
        {
            var Result = await _servicesservice.GetAllAsync();
            return Ok(Result);
        }



        [HttpGet("{id}")]
       
        public IActionResult Get([FromRoute] int id)
        {
            var Result = _servicesservice.Get(id);
            return Ok(Result);
        }

        [HttpPost]
        //[AllowAnonymous]
        public async Task<IActionResult> Create([FromForm] ServicesModel model)
        {
            try
            {
                await _servicesservice.CreateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }


        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] ServicesUpdate model)
        {

            try
            {
                await _servicesservice.Update(id, model);
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

            _servicesservice.Delete(id);
            return Ok();
        }

    }
}
