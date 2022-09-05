using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DTOs;
using Persistence.Database;

namespace Service
{
    public interface IClientService
    {
        Task<ClientDto> GetById(int id);
        Task Create(ClientCreateDto model);
    }

    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClientService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ClientDto> GetById(int id)
        {
            return _mapper.Map<ClientDto>(
                await _context.Clients.SingleAsync(x => x.ClientId == id)
            );
        }

        public async Task Create(ClientCreateDto model)
        {
            var entry = new Client
            {
                Name = model.Name,
            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();
        }
    }
}
