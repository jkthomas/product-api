using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DAL.Entities.Product;
using Application.Data.UnitOfWork.Interface;
using Application.Web.Models.Product.Create;
using Application.Web.Models.Product.Update;
using Microsoft.AspNetCore.Mvc;

namespace Application.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Product> products = null;
            products = _unitOfWork.ProductRepository.GetAll();

            return Json(products);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Product product = null;
            product = _unitOfWork.ProductRepository.Get(id);
            return Json(product);
        }

        //TODO: Add model validation.
        //TODO: Add mapper
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]ProductCreateInputModel productCreateInput)
        {
            Product product = new Product()
            {
                Name = productCreateInput.Name,
                Price = productCreateInput.Price
            };
            _unitOfWork.ProductRepository.Create(product);
            _unitOfWork.ProductRepository.Save();

            return Json(product.Id);
        }

        //TODO: Add model validation.
        //TODO: Add operation validation.
        //TODO: Add mapper
        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put([FromBody]ProductUpdateInputModel productUpdateInput)
        {
            Product product = new Product()
            {
                Id = productUpdateInput.Id,
                Name = productUpdateInput.Name,
                Price = productUpdateInput.Price
            };
            _unitOfWork.ProductRepository.Update(product);
            _unitOfWork.ProductRepository.Save();
        }

        //TODO: Add operation validation.
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            Product product = _unitOfWork.ProductRepository.Get(id);
            _unitOfWork.ProductRepository.Delete(product);
            _unitOfWork.ProductRepository.Save();
        }
    }
}
