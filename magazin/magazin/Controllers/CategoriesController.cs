using magazin.ModelDto.Categorie;
using magazin.Servis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace magazin.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesServis _categoriesServis;
        public CategoriesController(ICategoriesServis categoriesServis)
        {
            _categoriesServis = categoriesServis;
        }
        [Route("categories")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await _categoriesServis.GetALL();
            return   Ok(user);
        }

        [Route("categories/add")]
        [Authorize(Roles = "2")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]AddCategoryDTO model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest( new { errorText  = "Not Valid Model"});
            }

            await _categoriesServis.Add(model);
            return Ok();
        }
        [Route("categories/update")]
        [Authorize(Roles = "2")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDTO model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new { errorText = "Not Valid Model" });
            }

            await _categoriesServis.Update(model);
            return Ok();
        }
        [Route("categories/delete")]
        [Authorize(Roles = "2")]
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryDTO model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new { errorText = "Not Valid Model" });
            }

            await _categoriesServis.Delete(model);
            return Ok();
        }
    }


}
