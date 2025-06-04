using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.ProductDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IValidator<Product> _validator;
        private readonly IMapper _mapper;
        public ProductsController(ApiContext context, IValidator<Product> validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _context.Product.ToList();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Product.Add(product);
                _context.SaveChanges();

                return Ok("Eklendi");
            }
        }

        [HttpPost]
        public IActionResult CreateProductWithCategory(CreateProductDto product)
        {
            var value = _mapper.Map<Product>(product);
            _context.Product.Add(value);
            _context.SaveChanges();

            return Ok("eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Product.Find(id)!;
            _context.Product.Remove(value);
            _context.SaveChanges();

            return Ok("silindi");
        }

        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            var value = _context.Product.Find(id);

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Product.Update(product);
                _context.SaveChanges();

                return Ok("güncellendi");
            }
        }

        [HttpGet]
        public IActionResult ProductListWithCategory()
        {
            var value = _context.Product.Include(x => x.Category).ToList();
            var sonuc = _mapper.Map<List<ResultProductWithCategoryDto>>(value);

            return Ok(sonuc);
        }
    }
}