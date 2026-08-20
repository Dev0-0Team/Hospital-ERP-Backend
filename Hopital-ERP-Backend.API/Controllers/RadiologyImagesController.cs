using Azure;
using Hospital_ERP_Backend.Application.Features.RadiologyImages.Commands.CreateRadiologyImage;
using Hospital_ERP_Backend.Application.Features.RadiologyImages.Commands.DeleteRadiologyImage;
using Hospital_ERP_Backend.Application.Features.RadiologyImages.Commands.UpdateRadiologyImage;
using Hospital_ERP_Backend.Application.Features.RadiologyImages.Queries.GetAllRadiologyImages;
using Hospital_ERP_Backend.Application.Features.RadiologyImages.Queries.GetRadiologyImage;
using MediatR;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/RadiologyImages")]
    [ApiController]
    [Authorize]
    public class RadiologyImagesController : BaseController
    {
        private readonly ISender _sender;
        public RadiologyImagesController(ISender sender)
        {
            _sender = sender;
        }

        [HasPermission<RadiologyPermissions>(RadiologyPermissions.RadiologyImagesRead)]
        [HttpGet(Name = "GetAllRadiologyImagesAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllRadiologyImagesResponse>?>>> GetAllAsync(
            [FromQuery] int page = 1)
        {
            GetAllRadiologyImagesRequest request = new()
            {
                Page = page
            };

            var list = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllRadiologyImagesResponse>?>(
                list,
                StatusCodes.Status200OK,
                $"Rows: {list.Count()}");
        }

        [HasPermission<RadiologyPermissions>(RadiologyPermissions.RadiologyImagesRead)]
        [HttpGet("{ID:int}", Name = "GetRadiologyImageByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetRadiologyImageResponse?>>> GetByIdAsync(
            [FromRoute] int ID)
        {
            GetRadiologyImageRequest request = new()
            {
                Id = ID
            };

            var image = await _sender.Send(request);

            return CreateResponse<GetRadiologyImageResponse?>(
                image,
                StatusCodes.Status200OK,
                "Radiology Image found Successfully!");
        }

        [HasPermission<RadiologyPermissions>(RadiologyPermissions.RadiologyImagesCreate)]
        [HttpPost(Name = "CreateRadiologyImageAsync")]
        public async Task<ActionResult<ApiResponse<CreateRadiologyImageResponse>>> CreateAsync(
            [FromBody] CreateRadiologyImageRequest request)
        {
            var result = await _sender.Send(request);

            return CreatedAtRoute(
                "GetRadiologyImageByIdAsync",
                new
                {
                    ID = result.Id
                },
                new ApiResponse<CreateRadiologyImageResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    Message = "Radiology Image Created Successfully!",
                    Data = result
                });
        }

        [HasPermission<RadiologyPermissions>(RadiologyPermissions.RadiologyImagesUpdate)]
        [HttpPut(Name = "UpdateRadiologyImageAsync")]
        public async Task<ActionResult<ApiResponse<UpdateRadiologyImageResponse>>> UpdateAsync(
            [FromBody] UpdateRadiologyImageRequest request)
        {
            var result = await _sender.Send(request);

            return CreateResponse(
                result,
                StatusCodes.Status200OK,
                "Radiology Image Updated Successfully!");
        }

        [HasPermission<RadiologyPermissions>(RadiologyPermissions.RadiologyImagesDelete)]
        [HttpDelete("{ID:int}", Name = "DeleteRadiologyImageAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync(
            [FromRoute] int ID)
        {
            DeleteRadiologyImageRequest request = new()
            {
                Id = ID
            };

            var result = await _sender.Send(request);

            return CreateResponse(
                result,
                StatusCodes.Status200OK,
                "Radiology Image Deleted Successfully!");
        }
    }

}
