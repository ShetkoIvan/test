using MediatR;
using PatientService.Application.Patients.Dtos;

namespace PatientService.Application.Patients.Queries
{
    public record SearchPatientsQuery(string? BirthDate)
    : IRequest<List<PatientDto>>;
}
