using MediatR;
using PatientService.Domain.Entities;
using PatientService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientService.Application.Patients.Commands
{
    public class CreatePatientHandler : IRequestHandler<CreatePatientCommand, Guid>
    {
        private readonly IPatientRepository _rep;
        public CreatePatientHandler(IPatientRepository rep)
        {
            _rep = rep;
        }

        public async Task<Guid> Handle(CreatePatientCommand cmd, CancellationToken ct)
        {
            var patient = new Patient
            {
                Id = Guid.NewGuid(),
                Name = new HumanName(cmd.Family, cmd.Given, cmd.Use),
                Gender = cmd.Gender,
                BirthDate = cmd.BirthDate,
                Active = cmd.Active
            };

            await _rep.AddAsync(patient, ct);

            return patient.Id;
        }
    }
}
