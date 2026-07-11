using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    public class DrugInteractionsRepository : BaseQueryRepository<DrugInteraction>
    {

        protected override string GetAllSpName => "drug_interactions.SP_GetAllDrugInteractions";
        protected override string GetByIdSpName => "drug_interactions.SP_GetDrugInteractionById";

        public DrugInteractionsRepository(IOptions<MySetting> mySetting) : base(mySetting) { }
    }
}
