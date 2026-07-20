using MediatR;

namespace Hospital_ERP_Backend.Application.Features.EmergencyContacts.Commands.DeleteEmergencyContact
{
    public record DeleteEmergencyContactRequest() : IRequest<bool>
    {
        public int Id { get; set; }
    }
}