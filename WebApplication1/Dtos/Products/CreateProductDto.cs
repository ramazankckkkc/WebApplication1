namespace ProjectPatisserie.Dtos.Products
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string BarcodeNumber { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public string CategoryId { get; set; } = default!;

    }
}
