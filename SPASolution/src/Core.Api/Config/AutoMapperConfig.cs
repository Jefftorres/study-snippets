using AutoMapper;
using Model;
using Model.DTOs;
using Service.Commons;

namespace Core.Api.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<DataCollection<Client>, DataCollection<ClientDto>>();
        }
    }
}
