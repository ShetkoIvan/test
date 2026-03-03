using MediatR;

namespace PatientService.Application.Patients.Commands
{
    public record DeletePatientCommand(Guid Id) : IRequest;
}
