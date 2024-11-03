using AutoMapper;
using Edenmao.Core.DTOs.Rol;
using Edenmao.Domain.Entities;

namespace Edenmao.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Rol, RolDTO>().ReverseMap();
            CreateMap<CURol, Rol>();
        }
    }
}
