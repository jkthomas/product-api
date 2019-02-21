using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DAL.Entities.Product;
using Application.Data.UnitOfWork.Interface;
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
        //TODO: Change to product input models as arguments.
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return Json("");
        }

        //TODO: Add model validation.
        //TODO: Add operation validation.
        //TODO: Change to product input models as arguments.
        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]string value)
        {
        }

        //TODO: Add operation validation.
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {

        }
    }
}
