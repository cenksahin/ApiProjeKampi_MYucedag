using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.FeatureDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public FeaturesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _context.Feature.ToList();

            var sonuc = _mapper.Map<List<ResultFeatureDto>>(values);

            return Ok(sonuc);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto dto)
        {
            var value = _mapper.Map<Feature>(dto);

            _context.Feature.Add(value);
            _context.SaveChanges();

            return Ok("eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _context.Feature.Find(id);
            _context.Feature.Remove(value);
            _context.SaveChanges();

            return Ok("silindi");
        }

        [HttpGet]
        public IActionResult GetFeature(int id)
        {
            var values = _context.Feature.Find(id);
            var sonuc = _mapper.Map<GetByIdFeatureDto>(values);

            return Ok(sonuc);
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto dto)
        {
            var value = _mapper.Map<Feature>(dto);
            _context.Feature.Update(value);
            _context.SaveChanges();

            return Ok("güncellendi");
        }
    }
}
