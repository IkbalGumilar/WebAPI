namespace WebAPI.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<Respon<List<AmbilKarakterDto>>> GetAllKarakters();
        Task<Respon<AmbilKarakterDto>> GetKarakterById(int id);
        Task<Respon<List<AmbilKarakterDto>>> TambahKarakter(TambahKarakterDto addkarakter);
        Task<Respon<AmbilKarakterDto>> UpdateKarakter(UpdateKarakterDto upkarakter);
        Task<Respon<List<AmbilKarakterDto>>> HapusKarakter(int id);
    }
}
