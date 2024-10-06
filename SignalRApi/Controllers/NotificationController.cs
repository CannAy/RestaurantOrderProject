using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.NotificationDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;
		private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
		public IActionResult NotificationList()
		{
			var values = _notificationService.TGetListAll();
			return Ok(_mapper.Map<List<ResultNotificationDto>>(values));
		}

		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			return Ok(_notificationService.TNotificationCountByStatusFalse());
		}

		[HttpGet("GetAllNotificationByFalse")]
		public IActionResult GetAllNotificationByFalse()
		{
			return Ok(_notificationService.TGetAllNotificationByFalse());
		}

		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
		{
			createNotificationDto.Status =false;
			createNotificationDto.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			var value = _mapper.Map<Notification>(createNotificationDto);
			_notificationService.TAdd(value);
			return Ok("Ekleme işlemi başarıyla yapıldı");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteNotification(int id)
		{
			var value = _notificationService.TGetById(id);
			_notificationService.TDelete(value);
			return Ok("Bildirim Silindi");
		}

		[HttpGet("{id}")]
		public IActionResult GetNotification(int id)
		{
			var value = _notificationService.TGetById(id);
			return Ok(value);

		}

		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			Notification notification = new Notification()
			{
				NotificationId = updateNotificationDto.NotificationId,
				Description = updateNotificationDto.Description,
				Icon = updateNotificationDto.Icon,
				Status = updateNotificationDto.Status,
				Type = updateNotificationDto.Type,
				Date = updateNotificationDto.Date
			};
			_notificationService.TUpdate(notification);
			return Ok("Güncelleme işlemi başarıyla yapıldı");
		}

		[HttpGet("NotificationStatusChangeToFalse/{id}")]
		public IActionResult NotificationStatusChangeToFalse(int id)
		{
			_notificationService.TNotificationStatusChangeToFalse(id);
			return Ok("Güncelleme yapıldı");
		}

        [HttpGet("NotificationStatusChangeToTrue/{id}")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            _notificationService.TNotificationStatusChangeToTrue(id);
            return Ok("Güncelleme yapıldı");
        }


    }
}
