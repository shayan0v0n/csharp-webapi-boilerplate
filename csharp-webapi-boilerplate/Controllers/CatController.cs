using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace csharp_webapi_boilerplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        [HttpGet]
        public string[] GetCats()
        {
            string[] cats = { "cat1", "cat2" };
            return cats;
        }
    }
}
