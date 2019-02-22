using Application.Entities.Product.Create;
using Application.Entities.Product.Update;
using Application.Utilities.Exception.Input;
using Application.Utilities.Validation.Product.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Utilities.Validation.Product
{
    public class ProductValidator : IProductValidator
    {
        public void ValidateProductCreateInput(ProductCreateInputModel productCreateInput)
        {
            if(productCreateInput == null)
            {
                throw new InputNullException(Resource.Exception.ExceptionMessage.InputIsNull);
            }
        }

        public void ValidateProductUpdateInput(ProductUpdateInputModel productUpdateInput)
        {
            if (productUpdateInput == null)
            {
                throw new InputNullException(Resource.Exception.ExceptionMessage.InputIsNull);
            }
        }
    }
}
