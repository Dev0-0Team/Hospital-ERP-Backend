using MediatR;

namespace Hospital_ERP_Backend.Application.Features.EmergencyContacts.Queries.GetEmergencyContact
{
    public record GetEmergencyContactRequest : IRequest<GetEmergencyContactResponse>
    {
        public int Id { get; set; }

    }
}