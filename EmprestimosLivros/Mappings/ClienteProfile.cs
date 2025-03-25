using AutoMapper;
using EmprestimosLivros.Models;
using EmprestimosLivros.Dto;
public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<ClienteModel, ClienteDTOResponse>();
        CreateMap<ClienteDTORequest, ClienteModel>();
    }
}