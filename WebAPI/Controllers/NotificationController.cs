
using AutoMapper;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        INotificationService notificationService;
        IMapper mapper;
        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            this.notificationService = notificationService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationsByUserIdAsync(Guid id)
        {
            IEnumerable<Notification> notifications = await notificationService.GetNotificationsByUserIdAsync(id);
            IEnumerable<NotificationDTO> notificationDTOs = mapper.Map<IEnumerable<Notification>, IEnumerable<NotificationDTO>>(notifications);
            return Ok(notificationDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationByIdAsync(Guid id)
        {
            Notification notification = await notificationService.GetNotificationByIdAsync(id);
            NotificationDTO notificationDTO = mapper.Map<Notification, NotificationDTO>(notification);
            return Ok(notificationDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddNotificationAsync(NotificationDTO notificationDTO)
        {
            Notification notification = mapper.Map<NotificationDTO, Notification>(notificationDTO);
            Notification notificationToBeCreated = await notificationService.CreateNotificationAsync(notification);
            NotificationDTO createdNotificationDTO = mapper.Map<Notification, NotificationDTO>(notificationToBeCreated);
            return Ok(createdNotificationDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ReadNotification(Guid id)
        {
            await notificationService.ReadNotificationAsync(id);
            return Ok();
        }
    }
}
