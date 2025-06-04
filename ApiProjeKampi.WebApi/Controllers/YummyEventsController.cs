using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;


namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class YummyEventsController : ControllerBase
    {
        private readonly ApiContext _context;
        public YummyEventsController(ApiContext apiContext)
        {
            _context = apiContext;
        }


        [HttpPost]
        public IActionResult CreateYummyEvent(YummyEvent YummyEvent)
        {
            _context.YummyEvent.Add(YummyEvent);
            _context.SaveChanges();

            return Ok("eklendi");
        }

        [HttpGet]
        public IActionResult YummyEventList()
        {
            var values = _context.YummyEvent.ToList();

            return Ok(values);
        }

        [HttpDelete]
        public IActionResult DeleteYummyEvent(int id)
        {
            var value = _context.YummyEvent.Find(id)!;
            _context.YummyEvent.Remove(value);
            _context.SaveChanges();

            return Ok("silindi");
        }

        [HttpGet]
        public IActionResult GetYummyEvent(int id)
        {
            var value = _context.YummyEvent.Find(id);

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateYummyEvent(YummyEvent YummyEvent)
        {
            _context.YummyEvent.Update(YummyEvent);
            _context.SaveChanges();

            return Ok("güncellendi");
        }
    }
}
