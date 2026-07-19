using Hospital_ERP_Backend.Domain.Entities;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Allergys.Commamds.DeleteAllergy
{
    public record DeleteAllergyRequest : IRequest<bool>
    {
        public int Id { get; set; }

  



    }
}
