using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;


namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;
        public CategoriesController(ApiContext apiContext)
        {
            _context = apiContext;
        }


        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();

            return Ok("eklendi");
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _context.Category.ToList();

            return Ok(values);
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Category.Find(id);
            _context.Category.Remove(value);
            _context.SaveChanges();

            return Ok("silindi");
        }

        [HttpGet]
        public IActionResult GetCategory(int id)
        {
            var value = _context.Category.Find(id);

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            _context.Category.Update(category);
            _context.SaveChanges();

            return Ok("güncellendi");
        }
    }
}