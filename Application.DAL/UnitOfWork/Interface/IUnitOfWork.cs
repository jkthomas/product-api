using Application.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
    }
}
