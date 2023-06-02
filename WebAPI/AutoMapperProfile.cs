using AutoMapper;
using WebAPI.Model;

namespace WebAPI
{
    public class AutoMapperProfile : Profile    
    {
        public AutoMapperProfile()
        {
            CreateMap<Karakter, AmbilKarakterDto>();
            CreateMap<TambahKarakterDto, Karakter>();
            CreateMap<UpdateKarakterDto, Karakter>();
        }
    }
}
