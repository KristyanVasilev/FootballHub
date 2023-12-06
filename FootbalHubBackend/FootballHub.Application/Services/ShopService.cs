namespace FootballHub.Application.Services
{
    using FootballHub.Application.Interfaces;
    using FootballHub.Application.Models.DTOs;
    using FootballHub.Application.Repositories;
    using FootballHub.Domain;

    public class ShopService : IShopService
    {
        private readonly IRepository<Product> _repository;

        public ShopService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task CreateProduct(ProductFormDto form)
        {

            // Create a new product instance
            var newProduct = new Product
            {
                Name = form.ProductName,
                Description = form.Description,
                Price = form.Price,
                CreatedOn = DateTime.Now,
            };

            // If an image was provided, handle it appropriately (save to storage, etc.)
            if (form.Image != null)
            {
                // Handle image processing here
                // You might want to save it to a file storage service or cloud storage
                // and save the URL in the database

                // Example: Save image to the server
                var imagePath = Path.Combine("wwwroot/images", Guid.NewGuid().ToString() + Path.GetExtension(form.Image.FileName));
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await form.Image.CopyToAsync(stream);
                }

                newProduct.ImageUrl = imagePath.Replace("wwwroot", "");
            }

            // Save the product to the database
            await this._repository.AddAsync(newProduct);
            await this._repository.SaveChangesAsync();

        }
    }
}
