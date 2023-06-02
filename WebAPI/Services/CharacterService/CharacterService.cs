using AutoMapper;
using WebAPI.Model;

namespace WebAPI.Services.CharacterService
{
    public class CharacterService : ICharacterService
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
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }


        public async Task<Respon<List<AmbilKarakterDto>>> TambahKarakter(TambahKarakterDto addkarakter)
        {
            var respon = new Respon<List<AmbilKarakterDto>>();
            var karakter1 = _mapper.Map<Karakter>(addkarakter);
            karakter1.Id = Karakter.Max(c => c.Id) + 1;
            Karakter.Add(karakter1);
            respon.Data = Karakter.Select(c => _mapper.Map<AmbilKarakterDto>(c)).ToList();
            return respon;
        }


        public async Task<Respon<List<AmbilKarakterDto>>> GetAllKarakters()
        {
            var Respon = new Respon<List<AmbilKarakterDto>>();
            Respon.Data = Karakter.Select(c => _mapper.Map<AmbilKarakterDto>(c)).ToList();
            return Respon;
        }

        public async Task<Respon<AmbilKarakterDto>> GetKarakterById(int id)
        {
            var Respon = new Respon<AmbilKarakterDto>();
            var karakter = Karakter.FirstOrDefault(c => c.Id == id);
            Respon.Data = _mapper.Map<AmbilKarakterDto>(karakter);
            return Respon;
        }

        public async Task<Respon<AmbilKarakterDto>> UpdateKarakter(UpdateKarakterDto upkarakter)
        {
            var respon = new Respon<AmbilKarakterDto>();
            var karakter = Karakter.FirstOrDefault(c => c.Id == upkarakter.Id);

            if (karakter != null)
            {
                _mapper.Map(upkarakter, karakter);
                karakter.name = upkarakter.name;
                karakter.email = upkarakter.email;
                karakter.password = upkarakter.password;

                respon.Data = _mapper.Map<AmbilKarakterDto>(karakter);
            }
            else
            {
                respon.Berhasil = false;
                respon.Pesan = "Karakter not found";
            }

            return respon;
        }

        public async Task<Respon<List<AmbilKarakterDto>>> HapusKarakter(int id)
        {
            var respon = new Respon<List<AmbilKarakterDto>>();
            var karakter = Karakter.FirstOrDefault(c => c.Id == id);

            if (karakter != null)
            {
               Karakter.Remove(karakter);
               

                respon.Data = Karakter.Select(c => _mapper.Map<AmbilKarakterDto>(c)).ToList();
            }
            else
            {
                respon.Berhasil = false;
                respon.Pesan = "Karakter not found";
            }

            return respon;
        }
    }
}
