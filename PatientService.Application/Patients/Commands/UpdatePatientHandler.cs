using MediatR;
using PatientService.Domain.ValueObjects;

namespace PatientService.Application.Patients.Commands
{
    public class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand>
    {
        private readonly IPatientRepository _rep;

        public UpdatePatientHandler(IPatientRepository rep)
        {
            _rep = rep;
        }

        public async Task Handle(UpdatePatientCommand r, CancellationToken ct)
        {
            var patient = await _rep.GetByIdAsync(r.Id, ct);
            if (patient is null)
                throw new Exception($"Patient {r.Id} not found");

            patient.ChangeName(new HumanName(r.Family, r.Given, r.Use));
            patient.SetBirthDate(r.BirthDate);
            patient.SetGender(r.Gender);
            patient.SetActive(r.Active);

            await _rep.SaveChangesAsync(ct);
        }
    }
}
