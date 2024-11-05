using AutoMapper;
using Edenmao.Core.DTOs.Articulo;
using Edenmao.Core.DTOs.Categoria;
using Edenmao.Core.DTOs.Cliente;
using Edenmao.Core.DTOs.Personificacion;
using Edenmao.Core.DTOs.Rol;
using Edenmao.Domain.Entities;
using Edenmao.Infrastructure.Repositories;

namespace Edenmao.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Articulo, ArticuloDTO>().
                ForMember(d => d.NombreCategoria, o => o.MapFrom(c => c.IdCategoriaNav.Nombre)).ReverseMap();
            CreateMap<CUArticuloDTO, Articulo>();
            CreateMap<Articulo, ArticuloResponseDTO>();

            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<CUCategoriaDTO, Categoria>();

            CreateMap<Cliente, ClienteDTO>().
                ForMember(d => d.RegistradoPor, o => o.MapFrom(c => c.IdUsuarioNav.Nombre)).ReverseMap();
            CreateMap<CUClienteDTO, Cliente>();
            CreateMap<Cliente, ClienteResponseDTO>();

            CreateMap<Personificacion, PersonificacionDTO>().ReverseMap();
            CreateMap<CUPersonificacionDTO, Personificacion>();

            CreateMap<Rol, RolDTO>().ReverseMap();
            CreateMap<CURolDTO, Rol>();
        }
    }
}
