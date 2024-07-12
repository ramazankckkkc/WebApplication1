using ProjectPatisserie.Bases;

namespace ProjectPatisserie.Entities
{
    public class Product : BaseEntity<string>
    {
        public Product()
        {
            Id = Ulid.NewUlid().ToString();
        }
        public string Name { get; set; }
        public string BarcodeNumber { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public string CategoryId { get; set; } = default!;
        public Category? Category { get; set; }
    }
}
