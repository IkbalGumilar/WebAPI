using AutoMapper;

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
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task<Respon<List<AmbilKarakterDto>>> TambahKarakter(TambahKarakterDto addkarakter)
        {
            var respon = new Respon<List<AmbilKarakterDto>>();
            var dbkarakter = _mapper.Map<Karakter>(addkarakter);

            await _context.karakters.AddAsync(dbkarakter);
            await _context.SaveChangesAsync();

            respon.Data = await _context.karakters
                .Select(c => _mapper.Map<AmbilKarakterDto>(c))
                .ToListAsync();

            return respon;
        }


        public async Task<Respon<List<AmbilKarakterDto>>> GetAllKarakters()
        {
            var Respon = new Respon<List<AmbilKarakterDto>>();
            var dbKarakter = await _context.karakters.ToArrayAsync();
            Respon.Data = dbKarakter.Select(c => _mapper.Map<AmbilKarakterDto>(c)).ToList();
            return Respon;
        }

        public async Task<Respon<AmbilKarakterDto>> GetKarakterById(int id)
        {
            var Respon = new Respon<AmbilKarakterDto>();
            var dbKarakter = await _context.karakters.FirstOrDefaultAsync(c => c.Id == id);
            Respon.Data = _mapper.Map<AmbilKarakterDto>(dbKarakter);
            return Respon;
        }

        public async Task<Respon<AmbilKarakterDto>> UpdateKarakter(UpdateKarakterDto upkarakter)
        {
            var respon = new Respon<AmbilKarakterDto>();
            var dbkarakter = await _context.karakters.FirstOrDefaultAsync(c => c.Id == upkarakter.Id);

            if (dbkarakter != null)
            {
                _mapper.Map(upkarakter, dbkarakter);
                dbkarakter.name = upkarakter.name;
                dbkarakter.email = upkarakter.email;
                dbkarakter.password = upkarakter.password;

                respon.Data = _mapper.Map<AmbilKarakterDto>(dbkarakter);
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
            var dbkarakter = await _context.karakters.FirstOrDefaultAsync(c => c.Id == id);

            if (dbkarakter != null)
            {
                Karakter.Remove(dbkarakter);


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
