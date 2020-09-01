using eCommerceWeb.Contracts;
using eCommerceWeb.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace eCommerceWeb.API.Controllers
{
    [Route("api/eCommerce")]
    [ApiController]
    
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryBusiness categoryBusiness;

        public CategoryController(ICategoryBusiness categoryBusiness)
        {
            this.categoryBusiness = categoryBusiness;
        }

        /// <summary>
        /// Endpoint for testing API
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("categories")]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            await Task.Delay(10000);
            var categories = await this.categoryBusiness.GetAllCategories();
            return Ok(categories);
        }


        /// <summary>
        /// Endpoint for testing API
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("categories/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Category>>> GetCategoryById([FromRoute] int id, [Required] [FromQuery] string name)
        {
            var category = await this.categoryBusiness.GetCategoryById(id);
            if(category == null)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            return Ok(category);
        }

        /// <summary>
        /// Save a new category
        /// </summary>
        /// <param name="category">Given a category</param>
        /// <returns>Returns Id of category created</returns>
        [HttpPost]
        [Route("categories")]
        public async Task<ActionResult<int>> SaveCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input");
            }
            var response = await this.categoryBusiness.AddCategory(category);

            return Ok(response);
        }

        [HttpPut]
        [Route("categories/{id}")]
        public ActionResult<int> UpdateCategory([FromRoute] int id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Inalid model");
            }
            //save it


            return Ok(true);
           
        }
    }
}
