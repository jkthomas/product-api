using Application.Entities.Product.Create;
using Application.Entities.Product.Update;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Utilities.Validation.Product.Interface
{
    public interface IProductValidator
    {
        void ValidateProductCreateInput(ProductCreateInputModel productCreateInput);
        void ValidateProductUpdateInput(ProductUpdateInputModel productUpdateInput);
    }
}
