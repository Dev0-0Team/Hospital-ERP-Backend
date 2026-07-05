using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;

namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Queries.GetAllRoomTypes
{
    public record GetAllRoomTypesRequest
    {
        public int Page { get; set; }
    }
}


