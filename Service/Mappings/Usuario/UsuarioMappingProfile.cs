using AutoMapper;
using Domain;
using Shared.ViewModels.Usuario;

namespace Service.Mappings
{
    public class UsuarioMappingProfile : Profile
    {
        public UsuarioMappingProfile()
        {
            CreateMap<NovoUsuario, Usuario>().ReverseMap();

            CreateMap<ExibirUsuario, Usuario>().ReverseMap();

            CreateMap<AlterarUsuario, Usuario>().ReverseMap();
        }
    }
}
