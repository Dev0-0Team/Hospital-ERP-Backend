using MediatR;

namespace Hospital_ERP_Backend.Application.Features.EmergencyContacts.Queries.GetAllEmergencyContacts
{
    public record GetAllEmergencyContactsRequest : IRequest<IEnumerable<GetAllEmergencyContactsResponse>>
    {
        public int Page { get; set; }

    }
}