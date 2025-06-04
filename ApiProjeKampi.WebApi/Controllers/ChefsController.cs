using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;


namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly ApiContext _context;
        public ChefsController(ApiContext apiContext)
        {
            _context = apiContext;
        }


        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        {
            _context.Chef.Add(chef);
            _context.SaveChanges();

            return Ok("eklendi");
        }

        [HttpGet]
        public IActionResult ChefList()
        {
            var values = _context.Chef.ToList();

            return Ok(values);
        }

        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var value = _context.Chef.Find(id);
            _context.Chef.Remove(value);
            _context.SaveChanges();

            return Ok("silindi");
        }

        [HttpGet]
        public IActionResult GetChef(int id)
        {
            var value = _context.Chef.Find(id);

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateChef(Chef chef)
        {
            _context.Chef.Update(chef);
            _context.SaveChanges();

            return Ok("güncellendii");
        }
    }
}