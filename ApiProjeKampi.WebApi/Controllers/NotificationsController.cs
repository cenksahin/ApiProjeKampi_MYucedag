using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.NotificationDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public NotificationsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _context.Notification.ToList();

            var sonuc = _mapper.Map<List<ResultNotificationDto>>(values);

            return Ok(sonuc);
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto dto)
        {
            var value = _mapper.Map<Notification>(dto);

            _context.Notification.Add(value);
            _context.SaveChanges();

            return Ok("eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteNotification(int id)
        {
            var value = _context.Notification.Find(id);
            _context.Notification.Remove(value);
            _context.SaveChanges();

            return Ok("silindi");
        }

        [HttpGet]
        public IActionResult GetNotification(int id)
        {
            var values = _context.Notification.Find(id);
            var sonuc = _mapper.Map<GetByIdNotificationDto>(values);

            return Ok(sonuc);
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto dto)
        {
            var value = _mapper.Map<Notification>(dto);
            _context.Notification.Update(value);
            _context.SaveChanges();

            return Ok("güncellendi");
        }
    }
}
