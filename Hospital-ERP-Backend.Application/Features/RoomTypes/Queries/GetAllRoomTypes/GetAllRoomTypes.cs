using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Persons.Queries.GetAllPersons;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Queries.GetAllRoomTypes
{
    public record GetAllRoomTypesRequest : IRequest<IEnumerable<GetAllRoomTypesResponse>>
    {
        public int Page { get; set; }
    }
}


