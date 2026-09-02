using Hospital_ERP_Backend.Application.Features.Notifications.Commands.CreateNotification;
using Hospital_ERP_Backend.Application.Features.Notifications.Commands.DeleteNotification;
using Hospital_ERP_Backend.Application.Features.Notifications.Commands.UpdateNotification;
using Hospital_ERP_Backend.Application.Features.Notifications.Queries.GetAllNotifications;
using Hospital_ERP_Backend.Application.Features.Notifications.Queries.GetNotification;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/Notifications")]
    [ApiController]
    [Authorize]
    public class NotificationsController : BaseController
    {
        private readonly ISender _sender;

        public NotificationsController(ISender sender)
        {
            _sender = sender;
        }


        [HasPermission<NotificationPermissions>(NotificationPermissions.NotificationsRead)]
        [HttpGet(Name = "GetAllNotificationsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllNotificationsResponse>?>>> GetAllAsync(
            [FromQuery] int page = 1)
        {
            GetAllNotificationsRequest request = new()
            {
                Page = page
            };

            var notifications = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllNotificationsResponse>?>(
                notifications,
                StatusCodes.Status200OK,
                $"Rows: {notifications.Count()}");
        }

        [HasPermission<NotificationPermissions>(NotificationPermissions.NotificationsRead)]
        [HttpGet("{ID:int}", Name = "GetNotificationByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetNotificationResponse?>>> GetByIdAsync(
            [FromRoute] int ID)
        {
            GetNotificationRequest request = new()
            {
                Id = ID
            };

            var notification = await _sender.Send(request);

            return CreateResponse<GetNotificationResponse?>(
                notification,
                StatusCodes.Status200OK,
                "Notification found successfully!");
        }

        [HasPermission<NotificationPermissions>(NotificationPermissions.NotificationsCreate)]
        [HttpPost(Name = "CreateNotificationAsync")]
        public async Task<ActionResult<ApiResponse<CreateNotificationResponse>>> CreateAsync(
            [FromBody] CreateNotificationRequest request)
        {
            var result = await _sender.Send(request);

            return CreatedAtRoute(
                "GetNotificationByIdAsync",
                new
                {
                    ID = result.Id
                },
                new ApiResponse<CreateNotificationResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    message = "bed Created Successfully!",
                    data = result
                });
        }

        [HasPermission<NotificationPermissions>(NotificationPermissions.NotificationsUpdate)]
        [HttpPut(Name = "UpdateNotificationAsync")]
        public async Task<ActionResult<ApiResponse<UpdateNotificationResponse>>> UpdateAsync(
            [FromBody] UpdateNotificationRequest request)
        {
            var result = await _sender.Send(request);

            return CreateResponse<UpdateNotificationResponse>(
                result,
                StatusCodes.Status200OK,
                "Notification updated successfully!");
        }


        [HasPermission<NotificationPermissions>(NotificationPermissions.NotificationsDelete)]
        [HttpDelete("{ID:int}", Name = "DeleteNotificationAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync(
            [FromRoute] int ID)
        {
            DeleteNotificationRequest request = new()
            {
                Id = ID
            };

            var result = await _sender.Send(request);

            return CreateResponse<bool>(
                result,
                StatusCodes.Status200OK,
                "Notification deleted successfully!");
        }
    }
}