using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Application.Features.PaymentMethods.Queries.GetAllPaymentMethods
{
    public record GetAllPaymentMethodsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
