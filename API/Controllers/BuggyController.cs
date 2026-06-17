using API.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : BaseApiController
    {
        [HttpGet("not-found")]
        //IActionResult doesn't return a specific type
        public IActionResult GetNotFounnd()
        {
            return NotFound();
        }
        [HttpGet("bad-request")]
        public IActionResult GetBadRequest()
        {
            return BadRequest();
        }
        
         [HttpGet("unauthorized")]
        public IActionResult GetUnauthorized()
        {
            return Unauthorized();
        }  
        
         [HttpGet("validation-error")]
        public IActionResult GetValidationeError()
        {
            ModelState.AddModelError("Porblem1", "This is the first error");
            ModelState.AddModelError("Porblem2", "This is the second error");
            return ValidationProblem();
        } 
        
         [HttpGet("server-error")]
        public IActionResult GetServerError()
        {
           
            throw new Exception("this is a server error");
        }
    }
}
