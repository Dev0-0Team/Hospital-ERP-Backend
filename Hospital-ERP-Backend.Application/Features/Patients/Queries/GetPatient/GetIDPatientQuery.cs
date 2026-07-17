using System;


namespace Hospital_ERP_Backend.Application.Features.Patients.Queries.GetIDPatient
{
    public record GetIDPatientQuery
    {
        public int PersonId { get; set; }

        public string? BloodType { get; set; }

    }
}
