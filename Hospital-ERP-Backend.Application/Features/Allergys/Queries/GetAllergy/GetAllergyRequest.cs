using Hospital_ERP_Backend.Domain.Entities;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Allergys.Queries.GetAllergy
{ 
     public record GetAllergyRequest : IRequest<GetAllergyResponse>
    {
        public int Id { get; set; }



    }
}
