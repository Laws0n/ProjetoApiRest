using AutoMapper;
using Clientes.Crud.Data.Dtos;
using Clientes.Crud.Models;

namespace Clientes.Crud.Profiles
{
    public class ClienteProfile : Profile

    {
        public ClienteProfile()
        {
            CreateMap<CreateClienteDto, Cliente>();
            CreateMap<UpdateClienteDto, Cliente>();
            CreateMap<UpdateClienteDto, Cliente>();
            CreateMap<Cliente, ReadCLienteDto>();
        }
    }
}
