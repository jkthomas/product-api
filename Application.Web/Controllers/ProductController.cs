using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Application.Data.UnitOfWork.Interface;
using Application.Entities.Product.Create;
using Application.Entities.Product.DAL;
using Application.Entities.Product.Update;
using Application.Utilities.Exception.Input;
using Application.Utilities.Map.Product;
using Application.Utilities.Validation.Product.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IProductValidator _productValidator;

        public ProductController(IUnitOfWork unitOfWork, IProductValidator productValidator)
        {
            this._unitOfWork = unitOfWork;
            this._productValidator = productValidator;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Product> products = null;
            try
            {
                products = _unitOfWork.ProductRepository.GetAll();

                return Json(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Product product = null;
            try
            {
                product = _unitOfWork.ProductRepository.Get(id);

                return Json(product);
            }
            catch (ArgumentNullException ex)
            {
                return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]ProductCreateInputModel productCreateInput)
        {
            try
            {
                this._productValidator.ValidateProductCreateInput(productCreateInput);
                Product product = ProductMapper.Mapper.Map<Product>(productCreateInput);
                _unitOfWork.ProductRepository.Create(product);
                _unitOfWork.ProductRepository.Save();

                return Json(product.Id);
            }
            catch (InputNullException ex)
            {
                return StatusCode(400);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(400);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IActionResult Put([FromBody]ProductUpdateInputModel productUpdateInput)
        {
            try
            {
                this._productValidator.ValidateProductUpdateInput(productUpdateInput);
                Product product = ProductMapper.Mapper.Map<Product>(productUpdateInput);
                _unitOfWork.ProductRepository.Update(product);
                _unitOfWork.ProductRepository.Save();
            }
            catch (InputNullException ex)
            {
                return StatusCode(400);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(400);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

            return StatusCode(204);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Product product = _unitOfWork.ProductRepository.Get(id);
                _unitOfWork.ProductRepository.Delete(product);
                _unitOfWork.ProductRepository.Save();
            }
            catch (SqlException ex)
            {
                return StatusCode(400);
            }
            catch(ArgumentNullException ex)
            {
                return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

            return StatusCode(204);
        }
    }
}
