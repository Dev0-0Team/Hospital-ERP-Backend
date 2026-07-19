
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class PaymentMethodQueryRepository : BaseQueryRepository<PaymentMethod>
    {
        protected override string GetAllSpName => "payment_methods.SP_GetAllPaymentMethods";
        protected override string GetByIdSpName => "payment_methods.SP_GetPaymentMethodById";

        public PaymentMethodQueryRepository(IOptions<MySetting> setting) : base(setting) { }
    }
}
