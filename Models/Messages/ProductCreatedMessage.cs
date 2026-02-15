using WPFBoilerPlate.Models.Dtos.Products;

namespace WPFBoilerPlate.Models.Messages
{
    public record ProductCreatedMessage(ProductDto ProductDto);
}