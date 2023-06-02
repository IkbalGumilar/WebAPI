using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;
using WebAPI.Services.CharacterService;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KarakterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public KarakterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Respon<List<AmbilKarakterDto>>>> Get()
        {
            var respon = await _characterService.GetAllKarakters();
            if (respon.Data != null)
            {
                return Ok(respon);
            }
            else
            {
                return NotFound(respon);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Respon<List<AmbilKarakterDto>>>> GetSingle(int id)
        {
            var respon = await _characterService.GetKarakterById(id);
            if (respon.Data != null)
            {
                return Ok(respon);
            }
            else
            {
                return NotFound(respon);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Respon<AmbilKarakterDto>>> TambahKarakter(TambahKarakterDto addkarakter)
        {
            var respon = await _characterService.TambahKarakter(addkarakter);
            if (respon.Data != null)
            {
                return Ok(respon);
            }
            else
            {
                return NotFound(respon);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Respon<AmbilKarakterDto>>> UpdateKarakter(UpdateKarakterDto upkarakter)
        {
            var respon = await _characterService.UpdateKarakter(upkarakter);
            if (respon.Data != null)
            {
                return Ok(respon);
            }
            else
            {
                return NotFound(respon);
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Respon<List<AmbilKarakterDto>>>> HapusKarakter(int id)
        {
            var respon = await _characterService.HapusKarakter(id);
            if (respon.Data != null)
            {
                return Ok(respon);
            }
            else
            {
                return NotFound(respon);
            }
        }
    }
}
