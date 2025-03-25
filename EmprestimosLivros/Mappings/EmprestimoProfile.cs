using AutoMapper;
using EmprestimosLivros.Models;
using EmprestimosLivros.Dto;

public class EmprestimoProfile : Profile
{
    public EmprestimoProfile()
    {
        CreateMap<EmprestimoModel, EmprestimoDTOResponse>()
            .ForMember(dest => dest.Livro, opt => opt.MapFrom(src => src.Livro)) 
            .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente)); 

        CreateMap<LivroModel, LivroDTO>();
        CreateMap<ClienteModel, ClienteDTO>();

        CreateMap<EmprestimoDTORequest, EmprestimoModel>();
    }
}
