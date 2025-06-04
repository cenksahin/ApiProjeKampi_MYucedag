using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _context;
        public ServicesController(ApiContext apiContext)
        {
            _context = apiContext;
        }


        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Service.Add(service);
            _context.SaveChanges();

            return Ok("eklendi");
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _context.Service.ToList();

            return Ok(values);
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var value = _context.Service.Find(id);
            _context.Service.Remove(value!);
            _context.SaveChanges();

            return Ok("silindi");
        }

        [HttpGet]
        public IActionResult GetService(int id)
        {
            var value = _context.Service.Find(id);

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _context.Service.Update(service);
            _context.SaveChanges();

            return Ok("güncellendi");
        }
    }
}
