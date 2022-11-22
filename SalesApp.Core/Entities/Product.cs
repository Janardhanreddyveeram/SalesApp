using SalesApp.Core.Entities.Base;

namespace SalesApp.Core.Entities
{
    public class Product : Entity
    {

        public override int Id { get; set; }
        public string Brand { get; set; }
        public string ModelName { get; set; }
        public string Description { get; set; }
        public decimal ReceivingPrice { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public string ImageUrl { get; set; }

    }
}

