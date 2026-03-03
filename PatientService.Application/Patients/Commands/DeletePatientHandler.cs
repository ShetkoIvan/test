using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientService.Application.Patients.Commands
{
    public class DeletePatientHandler : IRequestHandler<DeletePatientCommand>
    {
        private readonly IPatientRepository _rep;

        public DeletePatientHandler(IPatientRepository rep)
        {
            _rep = rep;
        }


        public async Task Handle(DeletePatientCommand r, CancellationToken ct)
        {
            var patient = await _rep.GetByIdAsync(r.Id, ct);
            if (patient is null)
                throw new Exception($"Patient {r.Id} not found");

            _rep.Remove(patient);
            await _rep.SaveChangesAsync(ct);
        }
    }
}
