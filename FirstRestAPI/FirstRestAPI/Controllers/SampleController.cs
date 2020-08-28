using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstRestAPI.Controllers
{
    /// <summary>
    /// This is my Sample Controller for test project
    /// </summary>
    [Route("api/sample")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        /// <summary>
        /// This is the endpoint for testing greeting
        /// </summary>
        /// <returns>Returns a greeting</returns>
        [HttpGet]
        [Route("greet")]
        public ActionResult<string> Greet()
        {
            return Ok("Hello REST API");
        }

        /// <summary>
        /// This endpoint is for returing states info
        /// </summary>
        /// <returns>List of states</returns>
        [HttpGet]
        [Route("states")]
        public ActionResult<List<string>> GetStates()
        {
            var states = new List<string>() { "NJ", "PA", "NY", "RI" };

            return Ok(states);
        }

        /// <summary>
        /// This is will return hello message
        /// </summary>
        /// <param name="name">Given the name</param>
        /// <returns>Retur hello message</returns>
        [HttpGet]
        [Route("hello")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<string> SayHello(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }

            return Ok($"Hello {name} from API On : {DateTime.Now.ToLongDateString()}");
        }

        [HttpGet]
        [Route("results/{id?}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<string> GetResults(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            return Ok("Created");
        }


        [HttpPost]
        [Route("save")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<bool> Save(string name, string email)
        {
            return Ok(true);
        }
    }
}
