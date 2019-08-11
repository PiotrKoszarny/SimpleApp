using SimpleApp.Infrastructure.Query.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.BLL.Product.Query.GetProduct
{
    public class GetProductQuery : IQuery
    {
        public int ProductId { get; set; }
    }

    public class GetProductQueryResult: IQueryResult
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }

}
