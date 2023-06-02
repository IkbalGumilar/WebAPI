using Microsoft.AspNetCore.Mvc;
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
            return Ok(await _characterService.GetAllKarakters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Respon<List<AmbilKarakterDto>>>> GetSingle(int id)
        {
            return Ok(await _characterService.GetKarakterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Respon<AmbilKarakterDto>>> TambahKarakter(TambahKarakterDto addkarakter)
        {
            return Ok(await _characterService.TambahKarakter(karakter));
        }

        [HttpPut]
        public async Task<ActionResult<Respon<AmbilKarakterDto>>> UpdateKarakter(UpdateKarakterDto upkarakter)
        {
            return Ok(await _characterService.UpdateKarakter(upkarakter));
        }
    }
}
