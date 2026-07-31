using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Infrastructure.Repositories.Queries.Base;
using Hospital_ERP_Backend.Infrastructure.Setting;
using Microsoft.Extensions.Options;

namespace Hospital_ERP_Backend.Infrastructure.Repositories.Queries
{
    internal class RadiologyImageQueryRepository : BaseQueryRepository<RadiologyImage>
    {
        protected override string GetAllSpName => "radiology_images.SP_GetAllRadiologyImages";
        protected override string GetByIdSpName => "radiology_images.SP_GetRadiologyImageById";


        public RadiologyImageQueryRepository(IOptions<MySetting> options) : base(options) { }
    }
}
