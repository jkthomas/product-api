using Application.Entities.Product.DAL;
using System;
using System.Collections.Generic;

namespace Application.Data.Repository.Interface
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product Get(Guid id);

        void Create(Product product);
        void Update(Product product);
        void Delete(Product product);
        void Save();
    }
}
