using MediatR;

namespace Hospital_ERP_Backend.Application.Features.EmergencyContacts.Commands.CreateEmergencyContact
{
    public class CreateEmergencyContactRequest : IRequest<CreateEmergencyContactResponse>
    {
        public int PatientId { get; set; }

        public string Name { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Relationship { get; set; } = null!;
    }
}