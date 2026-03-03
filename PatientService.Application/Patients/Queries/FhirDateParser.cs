using PatientService.Domain.Entities;
using System;
namespace PatientService.Application.Patients.Queries
{
    public static class FhirDateParser
    {
        public static IQueryable<Patient> Apply(IQueryable<Patient> q, string value)
        {
            var prefix = value[..2];
            var date = DateTime.Parse(value[2..]);

            return prefix switch
            {
                "eq" => q.Where(x => x.BirthDate.Date == date.Date),
                "gt" => q.Where(x => x.BirthDate > date),
                "lt" => q.Where(x => x.BirthDate < date),
                "ge" => q.Where(x => x.BirthDate >= date),
                "le" => q.Where(x => x.BirthDate <= date),
                _ => q
            };
        }
    }
}
