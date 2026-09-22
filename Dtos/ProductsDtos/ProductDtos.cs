namespace Flower_Shop.Dtos.ProductsDtos
{
    public class CreateProductDto
    {
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; set; }
    }

    public class UpdateProductDto : CreateProductDto
    {
        public int Id { get; set; }
        public string UID { get; set; } = "";
    }

    public class ProductDto : UpdateProductDto
    {
        public string? CategoryName { get; set; }
    }
}