using System;


namespace Hospital_ERP_Backend.Application.Features.Patients.Queries.GetAllPatients
{
    public record GetAllPatientQuery
    {
        public int PersonId { get; set; }

        public string? BloodType { get; set; }

    }
}
