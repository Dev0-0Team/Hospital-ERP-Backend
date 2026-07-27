using Hospital_ERP_Backend.Application.Features.Payments.Commands.CreatePayment;
using Hospital_ERP_Backend.Application.Features.Payments.Commands.DeletePayment;
using Hospital_ERP_Backend.Application.Features.Payments.Commands.UpdatePayment;
using Hospital_ERP_Backend.Application.Features.Payments.Queries.GetAllPayments;
using Hospital_ERP_Backend.Application.Features.Payments.Queries.GetPayment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_ERP_Backend.API.Controllers
{
    [Route("api/Payments")]
    [ApiController]
    public class PaymentsController : BaseController
    {
        private readonly ISender _sender;

        public PaymentsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet(Name = "GetAllPaymentsAsync")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllPaymentsResponse>?>>> GetAllAsync([FromQuery] int page = 1)
        {
            GetAllPaymentsRequest newRequest = new GetAllPaymentsRequest()
            {
                Page = page
            };

            var list = await _sender.Send(newRequest);
            return CreateResponse<IEnumerable<GetAllPaymentsResponse>?>(list, StatusCodes.Status200OK, $"Row: {list.Count()}");
        }


        [HttpGet("{ID}", Name = "GetPaymentByID")]
        public async Task<ActionResult<ApiResponse<GetPaymentResponse?>>> GetByIDAsync([FromRoute] int ID)
        {
            GetPaymentRequest newRequest = new GetPaymentRequest
            {
                Id = ID
            };
            var response = await _sender.Send(newRequest);
            return CreateResponse<GetPaymentResponse?>(response, StatusCodes.Status200OK, "Found Successfully!");
        }

        [HttpPost(Name = "CreatePaymentAsync")]
        public async Task<ActionResult<ApiResponse<CreatePaymentResponse>>> CreateAsync([FromBody] CreatePaymentRequest request)
        {

            var success = await _sender.Send(request);
            return CreatedAtRoute("GetPaymentByID", new { ID = success!.Id }, success);
        }

        [HttpPut(Name = "UpdatePaymentAsync")]
        public async Task<ActionResult<ApiResponse<UpdatePaymentResponse>>> UpdateAsync([FromBody] UpdatePaymentRequest request)
        {
            var response = await _sender.Send(request);
            return CreateResponse<UpdatePaymentResponse>(response, StatusCodes.Status200OK, "Payment Updated Successfully!");
        }

        [HttpDelete("{ID}", Name = "DeletePaymentAsync")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync([FromRoute] int ID)
        {
            DeletePaymentRequest newRequest = new DeletePaymentRequest
            {
                Id = ID
            };
            var success = await _sender.Send(newRequest);
            return CreateResponse<bool>(success, StatusCodes.Status200OK, "Payment Deleted Successfully!");
        }
    }
}
