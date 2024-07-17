using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
        void addProduct(Product product);
    }
}
