using MediatR;
using PatientService.Domain.Enums;

namespace PatientService.Application.Patients.Commands
{
    public record UpdatePatientCommand(Guid Id,
    string Family,
    List<string> Given,
    string Use,
    Gender Gender,
    DateTime BirthDate,
    Active Active) : IRequest;
}
