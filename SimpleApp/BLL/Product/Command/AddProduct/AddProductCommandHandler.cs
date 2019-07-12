using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleApp.DAL.Entities;
using SimpleApp.Infrastructure.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.BLL.Product.Command.AddProduct
{
    public class AddProductCommandHandler : ICommandHandler<AddProductCommand, AddProductCommandResult>
    {
        private readonly DbContext _db;
        private readonly IMapper _mapper;

        public AddProductCommandHandler(DbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<AddProductCommandResult> Execute(AddProductCommand command)
        {
            ProductEntity product = _mapper.Map<ProductEntity>(command);
            await _db.Set<ProductEntity>().AddAsync(product);
            await _db.SaveChangesAsync();
            return _mapper.Map<AddProductCommandResult>(product);
        }
    }
}
