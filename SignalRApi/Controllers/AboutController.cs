using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.AboutDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var value = _aboutService.TGetListAll();
            return Ok(_mapper.Map<List<ResultAboutDto>>(value)); //mapping işlemi
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)  // create için dışarından parametre alması gerekli methodun
        {
            var value = _mapper.Map<About>(createAboutDto);       
            _aboutService.TAdd(value); 
            return Ok("Hakkımda kısmı başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımda Alanı silindi");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var value = _mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(value); //abaout parametresini veriyoruz burada, yukarıdaki satıda tanımladığımız için.
            return Ok("Hakkımda alanı güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(_mapper.Map<GetAboutDto>(value));
        }

    }
}
