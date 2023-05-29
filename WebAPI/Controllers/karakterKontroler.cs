using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KarakterController : ControllerBase
    {
        private static List<Karakter> Karakter = new List<Karakter> {
            new Karakter(),

            new Karakter
            {
                Id = 1,
                name = "num",
                email = "num@gmail.com",
                password = "12345678"
            },
            new Karakter
            {
                Id = 2,
                name = "tes",
                email = "tes@gmail.com",
                password = "12345678"
            }
        };

        [HttpGet("GetAll")]
        public ActionResult<List<Karakter>> Get()
        {
            return Ok(Karakter);
        }

        [HttpGet("{id}")]
        public ActionResult<List<Karakter>> GetSingle(int id)
        {
            return Ok(Karakter.FirstOrDefault(c => c.Id == id));
        }
    }
}
