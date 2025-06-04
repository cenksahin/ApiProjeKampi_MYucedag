using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.MessageDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public MessagesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _context.Message.ToList();

            var sonuc = _mapper.Map<List<ResultMessageDto>>(values);

            return Ok(sonuc);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto dto)
        {
            var value = _mapper.Map<Message>(dto);

            _context.Message.Add(value);
            _context.SaveChanges();

            return Ok("eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Message.Find(id);
            _context.Message.Remove(value);
            _context.SaveChanges();

            return Ok("silindi");
        }

        [HttpGet]
        public IActionResult GetMessage(int id)
        {
            var values = _context.Message.Find(id);
            var sonuc = _mapper.Map<GetByIdMessageDto>(values);

            return Ok(sonuc);
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto dto)
        {
            var value = _mapper.Map<Message>(dto);
            _context.Message.Update(value);
            _context.SaveChanges();

            return Ok("güncellendi");
        }

        [HttpGet]
        public IActionResult MessageListByIsReadFalse()
        {
            var values = _context.Message.Where(x => x.IsRead == false).ToList();

            var sonuc = _mapper.Map<List<ResultMessageDto>>(values);

            return Ok(sonuc);
        }
    }
}