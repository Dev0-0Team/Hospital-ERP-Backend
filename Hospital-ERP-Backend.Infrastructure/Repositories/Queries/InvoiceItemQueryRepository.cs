using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class InvoiceItemQueryRepository : BaseQueryRepository<InvoiceItem>
    {
        protected override string GetAllSpName => "invoice_items.SP_GetAllInvoiceItems";
        protected override string GetByIdSpName => "invoice_items.SP_GetInvoiceItemById";


        public InvoiceItemQueryRepository(IOptions<MySetting> setting) : base(setting) { }
    }
}
