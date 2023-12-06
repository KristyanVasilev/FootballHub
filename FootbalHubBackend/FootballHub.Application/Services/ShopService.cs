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

            var newProduct = new Product
            {
                Name = form.ProductName,
                Description = form.Description,
                Price = form.Price,
                CreatedOn = DateTime.Now,
            };

            if (form.Image != null)
            {
                var imagePath = Path.Combine("wwwroot/images", Guid.NewGuid().ToString() + Path.GetExtension(form.Image.FileName));
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await form.Image.CopyToAsync(stream);
                }

                newProduct.ImageUrl = imagePath.Replace("wwwroot", "");
            }

            await this._repository.AddAsync(newProduct);
            await this._repository.SaveChangesAsync();

        }

        public IEnumerable<Product> GetAllProducts()
        {

            var products = this._repository.AllAsNoTracking();
            return products;
        }

        public Product GetProductById(int productId)
        {

            var product = _repository.AllAsNoTracking()
                           .FirstOrDefault(x => x.Id == productId)
                           ?? throw new ArgumentException("Product not found!", nameof(productId));

            return product;
        }

        public async Task DeleteProduct(int productId)
        {
            var productToDelete = _repository.AllAsNoTracking()
                           .FirstOrDefault(x => x.Id == productId)
                           ?? throw new ArgumentException("Product not found!", nameof(productId));

            if (!string.IsNullOrEmpty(productToDelete.ImageUrl))
            {
                var imagePath = Path.Combine("wwwroot", productToDelete.ImageUrl);
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }
            }

            _repository.Delete(productToDelete);
            await _repository.SaveChangesAsync();
        }

        public async Task EditProduct(EditProductFormDto form, int productId)
        {
            var productToEdit = _repository.AllAsNoTracking()
                           .FirstOrDefault(x => x.Id == productId)
                           ?? throw new ArgumentException("Product not found!", nameof(productId));

            productToEdit.Price = form.Price;
            productToEdit.Description = form.Description;
            productToEdit.Name = form.ProductName;
            productToEdit.ModifiedOn = DateTime.Now;

            _repository.Update(productToEdit);
            await _repository.SaveChangesAsync();
        }
    }
}
