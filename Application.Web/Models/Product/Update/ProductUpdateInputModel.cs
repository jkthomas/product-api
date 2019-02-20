using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Web.Models.Product.Update
{
    public class ProductUpdateInputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
