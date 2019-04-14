using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace B2CWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET: api/values
        [HttpGet]
        [Authorize(Policy = "ReadPolicy")]
        public IActionResult Get()
        {
            //if(1 == 1)
            //    return Ok(new string[] { "value1", "value2", "value3", "value4" });
            //else
            //    return Unauthorized();
            try
            {
                var response = new string[] { "value1", "value2", "value3", "value4" };
                if(response != null)
                {
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception e)
            {
                //_logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var scopes = HttpContext.User.FindFirst("http://schemas.microsoft.com/identity/claims/scope")?.Value;
            if (!string.IsNullOrEmpty(Startup.ScopeRead) && scopes != null
                    && scopes.Split(' ').Any(s => s.Equals(Startup.ScopeRead)))
                return Ok("value1");
            else
                return Unauthorized();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            var scopes = HttpContext.User.FindFirst("http://schemas.microsoft.com/identity/claims/scope")?.Value;
            if (!string.IsNullOrEmpty(Startup.ScopeWrite) && scopes != null
                    && scopes.Split(' ').Any(s => s.Equals(Startup.ScopeWrite)))
                // TODO: Post
                return Ok();
            else
                return Unauthorized();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            var scopes = HttpContext.User.FindFirst("http://schemas.microsoft.com/identity/claims/scope")?.Value;
            if (!string.IsNullOrEmpty(Startup.ScopeWrite) && scopes != null
                    && scopes.Split(' ').Any(s => s.Equals(Startup.ScopeWrite)))
                // TODO: Put
                return Ok();
            else
                return Unauthorized();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var scopes = HttpContext.User.FindFirst("http://schemas.microsoft.com/identity/claims/scope")?.Value;
            if (!string.IsNullOrEmpty(Startup.ScopeWrite) && scopes != null
                    && scopes.Split(' ').Any(s => s.Equals(Startup.ScopeWrite)))
                // TODO: Delete
                return Ok();
            else
                return Unauthorized();
        }
    }
}
