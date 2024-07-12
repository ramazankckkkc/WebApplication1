namespace ProjectPatisserie.Dtos.Products
{
    public class CreateProductResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string BarcodeNumber { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public string CategoryId { get; set; } = default!;
    }
}
