using Hospital_ERP_Backend.Application.Features.InvoiceItems.Commands.CreateInvoiceItem;
using Hospital_ERP_Backend.Application.Features.InvoiceItems.Commands.DeleteInvoiceItem;
using Hospital_ERP_Backend.Application.Features.InvoiceItems.Commands.UpdateInvoiceItem;
using Hospital_ERP_Backend.Application.Features.InvoiceItems.Queries.GetAllInvoiceItems;
using Hospital_ERP_Backend.Application.Features.InvoiceItems.Queries.GetInvoiceItem;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/InvoiceItems")]
    [ApiController]
    [Authorize]
    public class InvoiceItemsController : BaseController
    {
        private readonly ISender _sender;

        public InvoiceItemsController(ISender sender)
        {
            _sender = sender;
        }

        [HasPermission<BillingPermissions>(BillingPermissions.InvoiceItemsRead)]
        [HttpGet(Name = "GetAllInvoiceItemsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllInvoiceItemsResponse>?>>> GetAllAsync(
            [FromQuery] int page = 1)
        {
            GetAllInvoiceItemsRequest request = new()
            {
                Page = page
            };

            var list = await _sender.Send(request);

            return CreateResponse<IEnumerable<GetAllInvoiceItemsResponse>?>(
                list,
                StatusCodes.Status200OK,
                $"Rows: {list.Count()}");
        }

        [HasPermission<BillingPermissions>(BillingPermissions.InvoiceItemsRead)]
        [HttpGet("{ID:int}", Name = "GetInvoiceItemByIdAsync")]
        public async Task<ActionResult<ApiResponse<GetInvoiceItemResponse?>>> GetByIdAsync(
            [FromRoute] int ID)
        {
            GetInvoiceItemRequest request = new()
            {
                Id = ID
            };

            var invoiceItem = await _sender.Send(request);

            return CreateResponse<GetInvoiceItemResponse?>(
                invoiceItem,
                StatusCodes.Status200OK,
                "Invoice Item found successfully!");
        }

        [HasPermission<BillingPermissions>(BillingPermissions.InvoiceItemsCreate)]
        [HttpPost(Name = "CreateInvoiceItemAsync")]
        public async Task<ActionResult<ApiResponse<CreateInvoiceItemResponse>>> CreateAsync(
            [FromBody] CreateInvoiceItemRequest request)
        {
            var result = await _sender.Send(request);

            return CreatedAtRoute(
                "GetInvoiceItemByIdAsync",
                new
                {
                    ID = result.Id
                },
                new ApiResponse<CreateInvoiceItemResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    Message = "Invoice Item Created Successfully!",
                    Data = result
                });
        }

        [HasPermission<BillingPermissions>(BillingPermissions.InvoiceItemsUpdate)]
        [HttpPut(Name = "UpdateInvoiceItemAsync")]
        public async Task<ActionResult<ApiResponse<UpdateInvoiceItemResponse>>> UpdateAsync(
            [FromBody] UpdateInvoiceItemRequest request)
        {
            var result = await _sender.Send(request);

            return CreateResponse<UpdateInvoiceItemResponse>(
                result,
                StatusCodes.Status200OK,
                "Invoice Item updated successfully!");
        }

        [HasPermission<BillingPermissions>(BillingPermissions.InvoiceItemsDelete)]
        [HttpDelete("{ID:int}", Name = "DeleteInvoiceItemAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync(
            [FromRoute] int ID)
        {
            DeleteInvoiceItemRequest request = new()
            {
                Id = ID
            };

            var result = await _sender.Send(request);

            return CreateResponse<bool>(
                result,
                StatusCodes.Status200OK,
                "Invoice Item deleted successfully!");
        }
    }
}