using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;


namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class InvoiceQueryRepository : BaseQueryRepository<Invoice>
    {
        protected override string GetAllSpName => "invoices.SP_GetAllInvoices";
        protected override string GetByIdSpName => "invoices.SP_GetInvoiceById";

        public InvoiceQueryRepository(IOptions<MySetting> setting) : base(setting) { }
    }
}
