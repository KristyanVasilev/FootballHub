namespace FootballHub.Application.Interfaces
{
    using FootballHub.Application.Models.DTOs;
    using FootballHub.Domain;

    public interface IShopService
    {
        Task CreateProduct(ProductFormDto form);

        IEnumerable<Product> GetAllProducts();

        Task DeleteProduct(int productId);
        Task EditProduct(EditProductFormDto form, int productId);

        Product GetProductById(int productId);
    }
}
