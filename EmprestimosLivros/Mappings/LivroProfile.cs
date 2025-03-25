using AutoMapper;
using EmprestimosLivros.Models;
using EmprestimosLivros.Dto;
public class LivroProfile : Profile
{
    public LivroProfile()
    {
        CreateMap<LivroModel, LivroDTOResponse>();
        CreateMap<LivroDTORequest, LivroModel>();
    }
}