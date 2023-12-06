namespace FootballHub.Application.Interfaces
{
    using FootballHub.Application.Models.DTOs;

    public interface IShopService
    {
        Task CreateProduct(ProductFormDto form);
    }
}
