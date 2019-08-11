using AutoMapper;
using SimpleApp.DAL.Entities;
using SimpleApp.DAL.Repository;
using SimpleApp.Infrastructure.Query.CQRS;
using System.Threading.Tasks;

namespace SimpleApp.BLL.Product.Query.GetProduct
{
    public class GetProductQueryHandler : IQueryHandler<GetProductQuery, GetProductQueryResult>
    {
        private readonly IGenericRepo<ProductEntity> _repo;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IGenericRepo<ProductEntity> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<GetProductQueryResult> HandleAsync(GetProductQuery query)
        {
            var result = await _repo.GetItem(query.ProductId);
            return _mapper.Map<GetProductQueryResult>(result);
        }
    }
}
