using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.ContactDtos;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;


namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;
        public ContactsController(ApiContext apiContext)
        {
            _context = apiContext;
        }


        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _context.Contact.ToList();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto dto)
        {
            Contact contact = new Contact();
            contact.MapLocation = dto.MapLocation;
            contact.Address = dto.Address;
            contact.Phone = dto.Phone;
            contact.Email = dto.Email;
            contact.OpenHours = dto.OpenHours;

            _context.Contact.Add(contact);
            _context.SaveChanges();

            return Ok("eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contact.Find(id);

            _context.Contact.Remove(value!);
            _context.SaveChanges();

            return Ok("silindi");
        }

        [HttpGet]
        public IActionResult GetContact(int id)
        {
            var value = _context.Contact.Find(id);

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto dto)
        {
            Contact contact = new Contact();
            contact.ContactId = dto.ContactId;
            contact.MapLocation = dto.MapLocation;
            contact.Address = dto.Address;
            contact.Phone = dto.Phone;
            contact.Email = dto.Email;
            contact.OpenHours = dto.OpenHours;

            _context.Contact.Update(contact);
            _context.SaveChanges();

            return Ok("güncellendi");
        }
    }
}