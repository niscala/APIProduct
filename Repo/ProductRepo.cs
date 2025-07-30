using APIProduct.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace APIProduct.Repo
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDBContext _context;

        public ProductRepo(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetFilteredProducts(string? name, decimal? minPrice, decimal? maxPrice)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name)) query = query.Where(p => p.Name.Contains(name));   
            if (minPrice.HasValue) query = query.Where(p => p.Price >= minPrice.Value);
            if (maxPrice.HasValue) query = query.Where(p => p.Price <= maxPrice.Value);
            
            return await query.OrderByDescending(p => p.CreatedAt).ToListAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

    }
}
