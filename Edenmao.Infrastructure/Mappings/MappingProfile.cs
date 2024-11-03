using AutoMapper;
using Edenmao.Core.DTOs.Articulo;
using Edenmao.Core.DTOs.Categoria;
using Edenmao.Core.DTOs.Rol;
using Edenmao.Domain.Entities;
using Edenmao.Infrastructure.Repositories;

namespace Edenmao.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Rol, RolDTO>().ReverseMap();
            CreateMap<CURolDTO, Rol>();

            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<CUCategoriaDTO, Categoria>();

            CreateMap<Articulo, ArticuloDTO>().
                ForMember(d => d.NombreCategoria, o => o.MapFrom(c => c.IdCategoriaNav.Nombre)).ReverseMap();

        }
    }
}
