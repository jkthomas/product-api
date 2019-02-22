using Application.DAL.Context;
using Application.Data.Repository.Interface;
using Application.Entities.Product.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ProductDbContext _productDbContext;

        public ProductRepository(ProductDbContext productDbContext)
        {
            this._productDbContext = productDbContext;
        }

        public IEnumerable<Product> GetAll()
        {
            return this._productDbContext.Products;
        }

        public Product Get(Guid id)
        {
            return this._productDbContext.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public void Create(Product product)
        {
            this._productDbContext.Add(product);
        }

        public void Delete(Product product)
        {
            this._productDbContext.Remove(product);
        }

        public void Update(Product product)
        {
            this._productDbContext.Update(product);
        }

        public void Save()
        {
            this._productDbContext.SaveChanges();
        }
    }
}
