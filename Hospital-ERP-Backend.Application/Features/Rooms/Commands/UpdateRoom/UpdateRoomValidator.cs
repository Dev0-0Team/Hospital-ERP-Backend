using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Rooms.Commands.UpdateRoom
{
    internal class UpdateRoomValidator : AbstractValidator<UpdateRoomRequest>
    {
        public UpdateRoomValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).WithMessage("Department Id must be greater than 0.");

            RuleFor(x => x.RoomTypeId)
                .GreaterThan(0).WithMessage("Room type Id must be greater than 0.");

            RuleFor(x => x.RoomNumber)
                .NotEmpty().WithMessage("Room number is required.")
                .MaximumLength(20).WithMessage("Room number must not exceed 20 characters.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Must(BeValidStatus).WithMessage("Status must be Available, Occupied, or Maintenance.");
        }

        private bool BeValidStatus(string Status)
        {
            var allowed = new[] { "Available", "Occupied", "Maintenance" };
            return allowed.Contains(Status);
        }
    }
}