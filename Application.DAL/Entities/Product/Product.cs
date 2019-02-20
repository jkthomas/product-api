using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DAL.Entities.Product
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
