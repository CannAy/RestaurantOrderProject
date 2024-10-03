using BusinessLayer.Abstract;
using DtoLayer.MenuTableDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;

        public MenuTablesController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());
        }

		[HttpGet]
		public IActionResult MenuTableList()
		{
			var values = _menuTableService.TGetListAll();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)  // create için dışarından parametre alması gerekli methodun
		{
			MenuTable menuTable = new MenuTable()
			{
				Name = createMenuTableDto.Name,
				Status = false
			};
			_menuTableService.TAdd(menuTable); // about'u döndürmek için üst satırdaki gibi tanımladık.
			return Ok("Masa başarılı bir şekilde eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);
			_menuTableService.TDelete(value);
			return Ok("Masa Silindi");
		}

		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
			MenuTable menuTable = new MenuTable()
			{
				MenuTableId = updateMenuTableDto.MenuTableId,
				Name = updateMenuTableDto.Name,
				Status = false
			};
			_menuTableService.TUpdate(menuTable); //abaout parametresini veriyoruz burada, yukarıdaki satıda tanımladığımız için.
			return Ok("Masa Bilgisi güncellendi");
		}

		[HttpGet("{id}")]
		public IActionResult GetMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);
			return Ok(value);
		}
	}
}
