using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_Lippi_API.Data;
using Test_Lippi_API.Models;

namespace Test_Lippi_API.Controllers
{
    // localhost:xxxx/api/products
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly API_DbContext _dbcontext;

        public ProductsController(API_DbContext _dbContext) 
        {
            this._dbcontext = _dbContext;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var allProducts = _dbcontext.Products.ToList();

            if (allProducts.Any())
            {
                return Ok(allProducts);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductByID(int id)
        {
            var product = _dbcontext.Products.Where(i => i.productID.Equals(id)).FirstOrDefault();

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductDto addProductDto)
        {
            if(addProductDto.productName == "")
            {
                ModelState.AddModelError("Name", "El nombre no puede estar vacío");
                return BadRequest(ModelState);
            }
            else if(addProductDto.productPrice <= 0)
            {
                ModelState.AddModelError("Price", "El precio del producto debe ser mayor a cero (0)");
                return BadRequest(ModelState);
            }

            var product = new Product()
            {
                productName = addProductDto.productName,
                productPrice = addProductDto.productPrice,
                productStock = addProductDto.productStock
            };

            _dbcontext.Products.Add(product);
            _dbcontext.SaveChanges();

            return Ok(product);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            var product = _dbcontext.Products.Where(i => i.productID.Equals(id)).FirstOrDefault();

            if(product == null)
            {
                return NotFound();
            }
            else if(updateProductDto.productName == "")
            {
                ModelState.AddModelError("Name", "El nombre no puede estar vacío");
                return BadRequest(ModelState);
            }
            else if (updateProductDto.productPrice <= 0)
            {
                ModelState.AddModelError("Price", "El precio del producto debe ser mayor a cero (0)");
                return BadRequest(ModelState);
            }

            product.productName = updateProductDto.productName;
            product.productPrice = updateProductDto.productPrice;
            product.productStock = updateProductDto.productStock;

            _dbcontext.SaveChanges();

            return Ok(product);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _dbcontext.Products.Where(i => i.productID.Equals(id)).FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            _dbcontext.Products.Remove(product);
            _dbcontext.SaveChanges();

            return Ok(product);
        }
    }
}
