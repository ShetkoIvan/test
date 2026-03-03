using MediatR;
using PatientService.Domain.Enums;

namespace PatientService.Application.Patients.Commands
{
    public record CreatePatientCommand(
        string Family,
        List<string> Given,
        Gender Gender,
        DateTime BirthDate,
        string Use,
        Active Active) : IRequest<Guid>;
}
