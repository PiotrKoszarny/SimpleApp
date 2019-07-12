using System.ComponentModel.DataAnnotations;

namespace SimpleApp.DAL.Entities
{
    public class ProductEntity
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}
