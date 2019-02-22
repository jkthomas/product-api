using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entities.Product.Update
{
    public class ProductUpdateInputModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
