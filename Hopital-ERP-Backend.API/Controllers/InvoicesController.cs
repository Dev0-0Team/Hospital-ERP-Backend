using Hospital_ERP_Backend.Application.Features.Invoices.Commands.CreateInvoice;
using Hospital_ERP_Backend.Application.Features.Invoices.Commands.DeleteInvoice;
using Hospital_ERP_Backend.Application.Features.Invoices.Commands.UpdateInvoice;
using Hospital_ERP_Backend.Application.Features.Invoices.Queries.GetAllInvoices;
using Hospital_ERP_Backend.Application.Features.Invoices.Queries.GetInvoice;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/Invoices")]
    [ApiController]
    [Authorize]
    public class InvoicesController : BaseController
    {
        private readonly ISender _sender;

        public InvoicesController(ISender sender)
        {
            _sender = sender;
        }

        [HasPermission<BillingPermissions>(BillingPermissions.InvoicesRead)]
        [HttpGet(Name = "GetAllInvoicesAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllInvoicesResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllInvoicesRequest request = new()
            {
                Page = page
            };

            var list = await _sender.Send(request);
            return CreateResponse<IEnumerable<GetAllInvoicesResponse>?>(list, StatusCodes.Status200OK, $"Row: {list.Count()}");
        }

        [HasPermission<BillingPermissions>(BillingPermissions.InvoicesRead)]
        [HttpGet("{ID}", Name = "GetInvoiceByID")]
        public async Task<ActionResult<ApiResponse<GetInvoiceResponse?>>> GetByIDAsync([FromRoute] int ID)
        {
            GetInvoiceRequest request = new()
            {
                Id = ID
            };
            var response = await _sender.Send(request);
            return CreateResponse<GetInvoiceResponse?>(response, StatusCodes.Status200OK, "Found Successfully!");
        }

        [HasPermission<BillingPermissions>(BillingPermissions.InvoicesCreate)]
        [HttpPost(Name = "CreateInvoiceAsync")]
        public async Task<ActionResult<ApiResponse<CreateInvoiceResponse>>> CreateAsync([FromBody] CreateInvoiceRequest request)
        {
            var success = await _sender.Send(request);
            return CreatedAtRoute("GetInvoiceByID",
                new { ID = success!.Id },
                new ApiResponse<CreateInvoiceResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    message = "Invoice Created Successfully!",
                    data = success
                });
        }

        [HasPermission<BillingPermissions>(BillingPermissions.InvoicesUpdate)]
        [HttpPut(Name = "UpdateInvoiceAsync")]
        public async Task<ActionResult<ApiResponse<UpdateInvoiceResponse>>> UpdateAsync([FromBody] UpdateInvoiceRequest request)
        {
            var response = await _sender.Send(request);
            return CreateResponse<UpdateInvoiceResponse>(response, StatusCodes.Status200OK, "Invoice Updated Successfully!");
        }

        [HasPermission<BillingPermissions>(BillingPermissions.InvoicesDelete)]
        [HttpDelete("{ID}", Name = "DeleteInvoiceAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeleteInvoiceRequest request = new()
            {
                Id = ID
            };
            var success = await _sender.Send(request);
            return CreateResponse<bool>(success, StatusCodes.Status200OK, "Invoice Deleted Successfully!");
        }
    }
}