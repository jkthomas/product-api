using Application.DAL.Context;
using Application.Data.Repository;
using Application.Data.Repository.Interface;
using Application.Data.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IProductRepository _productRepository;

        public UnitOfWork(ProductDbContext productDbContext)
        {
            this._productRepository = new ProductRepository(productDbContext);
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository;
            }
        }

    }
}
