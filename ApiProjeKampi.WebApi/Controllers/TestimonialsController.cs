using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;


namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ApiContext _context;
        public TestimonialsController(ApiContext apiContext)
        {
            _context = apiContext;
        }


        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial Testimonial)
        {
            _context.Testimonial.Add(Testimonial);
            _context.SaveChanges();

            return Ok("eklendi");
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _context.Testimonial.ToList();

            return Ok(values);
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _context.Testimonial.Find(id)!;
            _context.Testimonial.Remove(value);
            _context.SaveChanges();

            return Ok("silindi");
        }

        [HttpGet]
        public IActionResult GetTestimonial(int id)
        {
            var value = _context.Testimonial.Find(id);

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial Testimonial)
        {
            _context.Testimonial.Update(Testimonial);
            _context.SaveChanges();

            return Ok("güncellendi");
        }
    }
}
