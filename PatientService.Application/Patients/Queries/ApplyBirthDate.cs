using PatientService.Domain.Entities;
using System;
namespace PatientService.Application.Patients.Queries
{
    public class ApplyBirthDate
    {
        public static IQueryable<Patient> GetQuery(IQueryable<Patient> q, string value)
        {
            var prefix = value.Length >= 2 && char.IsLetter(value[0]) ? value[..2] : "eq";
            var raw = prefix == "eq" || prefix == "gt" || prefix == "lt" || prefix == "ge" || prefix == "le" || prefix == "ne"
                ? value[2..]
                : value;

            var d = DateTime.Parse(raw).Date;
            var start = d;
            var end = d.AddDays(1);

            return prefix switch
            {
                // equals "in that day"
                "eq" => q.Where(x => x.BirthDate >= start && x.BirthDate < end),

                // not equals "not in that day"
                "ne" => q.Where(x => x.BirthDate < start || x.BirthDate >= end),

                // strictly less: any datetime before start of the day
                "lt" => q.Where(x => x.BirthDate < start),

                // less or equal: before end of the day
                "le" => q.Where(x => x.BirthDate < end),

                // greater than: on/after end of the day
                "gt" => q.Where(x => x.BirthDate >= end),

                // greater or equal: on/after start of the day
                "ge" => q.Where(x => x.BirthDate >= start),

                // starts at: on/after end of the day
                "sa" => q.Where(x => x.BirthDate >= end),

                // end before: on/after start of the day
                "eb" => q.Where(x => x.BirthDate >= start),

                _ => q
            };
        }
    }
}
