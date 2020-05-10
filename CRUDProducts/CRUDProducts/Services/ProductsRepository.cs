using CRUDProducts.DbContexts;
using CRUDProducts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDProducts.Services
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductLibraryContext _context;
        public ProductsRepository(ProductLibraryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }        

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList<Product>();
        }
        public Product GetProduct(int productId)
        {
            return _context.Products.FirstOrDefault(x => x.Id == productId);
        }

        public void AddProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            
        }

        public void DeleteProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.Products.Remove(product);
        }

        public bool ProductExist(int productId)
        {
            return _context.Products.Any(x => x.Id == productId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
