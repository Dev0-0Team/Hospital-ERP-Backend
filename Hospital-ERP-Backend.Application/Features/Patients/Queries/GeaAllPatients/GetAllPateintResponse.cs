using Hospital_ERP_Backend.Application.Features.Persons.Queries.GetAllPersons;
using System;


namespace Hospital_ERP_Backend.Application.Features.Patients.Queries.GetAllPatients
{
    public record GetAllPateintResponse
    {
        public int PersonId { get; set; }

        public string? BloodType { get; set; }

    }
}
