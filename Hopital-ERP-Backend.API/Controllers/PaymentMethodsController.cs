using Hospital_ERP_Backend.Application.Features.PaymentMethods.Commands.CreatePaymentMethod;
using Hospital_ERP_Backend.Application.Features.PaymentMethods.Commands.DeletePaymentMethod;
using Hospital_ERP_Backend.Application.Features.PaymentMethods.Commands.UpdatePaymentMethod;
using Hospital_ERP_Backend.Application.Features.PaymentMethods.Queries.GetAllPaymentMethods;
using Hospital_ERP_Backend.Application.Features.PaymentMethods.Queries.GetPaymentMethod;
using Hospital_ERP_Backend.Application.Security.Authorization;
using Hospital_ERP_Backend.Domain.Enums.PermissionBits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/PaymentMethods")]
    [ApiController]
    [Authorize]
    public class PaymentMethodsController : BaseController
    {
        private readonly ISender _sender;

        public PaymentMethodsController(ISender sender)
        {
            _sender = sender;
        }

        [HasPermission<BillingPermissions>(BillingPermissions.PaymentMethodsRead)]
        [HttpGet(Name = "GetAllPaymentMethodsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllPaymentMethodsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllPaymentMethodsRequest newRequest = new GetAllPaymentMethodsRequest()
            {
                Page = page
            };

            var list = await _sender.Send(newRequest);
            return CreateResponse<IEnumerable<GetAllPaymentMethodsResponse>?>(list, StatusCodes.Status200OK, $"Row: {list.Count()}");
        }

        [HasPermission<BillingPermissions>(BillingPermissions.PaymentMethodsRead)]
        [HttpGet("{ID}", Name = "GetPaymentMethodByID")]
        public async Task<ActionResult<ApiResponse<GetPaymentMethodResponse?>>> GetByIDAsync([FromRoute] int ID)
        {
            GetPaymentMethodRequest newRequest = new GetPaymentMethodRequest
            {
                Id = ID
            };
            var response = await _sender.Send(newRequest);
            return CreateResponse<GetPaymentMethodResponse?>(response, StatusCodes.Status200OK, "Found Successfully!");
        }
        [HasPermission<BillingPermissions>(BillingPermissions.PaymentMethodsCreate)]
        [HttpPost(Name = "CreatePaymentMethodAsync")]
        public async Task<ActionResult<ApiResponse<CreatePaymentMethodResponse>>> CreateAsync([FromBody] CreatePaymentMethodRequest request)
        {

            var success = await _sender.Send(request);
            return CreatedAtRoute("GetPaymentMethodByID", new { ID = success!.Id },
                new ApiResponse<CreatePaymentMethodResponse>
                {
                    statusCode = StatusCodes.Status201Created,
                    Message = "Payment Method Created Successfully!",
                    Data = success
                });
        }

        [HasPermission<BillingPermissions>(BillingPermissions.PaymentMethodsUpdate)]
        [HttpPut(Name = "UpdatePaymentMethodAsync")]
        public async Task<ActionResult<ApiResponse<UpdatePaymentMethodResponse>>> UpdateAsync([FromBody] UpdatePaymentMethodRequest request)
        {
            var response = await _sender.Send(request);
            return CreateResponse<UpdatePaymentMethodResponse>(response, StatusCodes.Status200OK, "Payment Method Updated Successfully!");
        }

        [HasPermission<BillingPermissions>(BillingPermissions.PaymentMethodsDelete)]
        [HttpDelete("{ID}", Name = "DeletePaymentMethodAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeletePaymentMethodRequest newRequest = new DeletePaymentMethodRequest
            {
                Id = ID
            };
            var success = await _sender.Send(newRequest);
            return CreateResponse<bool>(success, StatusCodes.Status200OK, "Payment Method Deleted Successfully!");
        }
    }
}
