using Application.DAL.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.Repository.Interface
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);

        void Create(Product product);
        void Update(Product product);
        void Delete(Product product);
        void Save();
    }
}
