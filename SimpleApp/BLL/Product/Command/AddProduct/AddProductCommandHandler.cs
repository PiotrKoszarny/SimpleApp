using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleApp.DAL.Entities;
using SimpleApp.DAL.Repository;
using SimpleApp.Infrastructure.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.BLL.Product.Command.AddProduct
{
    public class AddProductCommandHandler : ICommandHandler<AddProductCommand, AddProductCommandResult>
    {
        private readonly IGenericRepo<ProductEntity> _repo;
        private readonly IMapper _mapper;

        public AddProductCommandHandler(IGenericRepo<ProductEntity> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<AddProductCommandResult> Execute(AddProductCommand command)
        {
            ProductEntity product = _mapper.Map<ProductEntity>(command);
            var result = await _repo.Add(product);
            return _mapper.Map<AddProductCommandResult>(result);
        }
    }
}
