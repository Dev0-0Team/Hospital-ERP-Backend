using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;


namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class PaymentQueryRepository : BaseQueryRepository<Payment>
    {
        protected override string GetAllSpName => "payments.SP_GetAllPayments";
        protected override string GetByIdSpName => "payments.SP_GetPaymentById";

        public PaymentQueryRepository(IOptions<MySetting> setting) : base(setting) { }
    }
}
