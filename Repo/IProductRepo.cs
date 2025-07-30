using APIProduct.Models;

namespace APIProduct.Repo
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetFilteredProducts(string? name, decimal? minPrice, decimal? maxPrice);
        Task<Product?> GetById(int id);
        Task Create(Product product);
        Task Update(Product product);
        Task Delete(Product product);
    }
}
