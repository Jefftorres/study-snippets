using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DTOs;
using Persistence.Database;
using Service.Commons;
using Service.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IOrderService
    {
        Task<DataCollection<OrderDto>> GetAll(int page, int take);
        Task<OrderDto> GetById(int id);
        Task<OrderDto> Create(OrderCreateDto model);
    }

    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataCollection<OrderDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<OrderDto>>(
                await _context.Orders.OrderByDescending(x => x.OrderId)
                    .AsQueryable()
                    .PagedAsync(page, take)
            );
        }

        public async Task<OrderDto> GetById(int id)
        {
            return _mapper.Map<OrderDto>(
                await _context.Orders.SingleAsync(x => x.OrderId == id)
            );
        }

        public async Task<OrderDto> Create(OrderCreateDto model)
        {
            var entry = _mapper.Map<Order>(model);
            return null;
        }
    }
}
