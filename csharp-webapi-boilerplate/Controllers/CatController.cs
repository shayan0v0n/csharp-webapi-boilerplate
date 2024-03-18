using csharp_webapi_boilerplate.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace csharp_webapi_boilerplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        public List<Cats> cats = new List<Cats>
        {
            new Cats { Name = "lucy", IsFavorite = false },
            new Cats { Name = "catty", IsFavorite = true },
            new Cats { Name = "cat3", IsFavorite = false }
        };
        
        [HttpGet]
        public ActionResult GetCats([FromQuery] int count = 999)
        {
            if (!cats.Any())
                return NotFound();
            return Ok(cats.Take(count));
        }

        [HttpPost]
        public ActionResult PostCats([FromBody] Cats newCat)
        {
            cats.Add(newCat);
            return Created("", newCat);
        }
        
        [HttpDelete("{name}")]
        public ActionResult DeleteCat(string name)
        {
            if (name == "")
                return BadRequest();
            cats.RemoveAll(e => e.Name == name);

            return Ok(cats);
        }
    }
}
