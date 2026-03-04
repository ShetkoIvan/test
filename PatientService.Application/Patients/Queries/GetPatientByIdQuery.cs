using MediatR;
using PatientService.Application.Patients.Dtos;

namespace PatientService.Application.Patients.Queries
{
    public record GetPatientByIdQuery(Guid Id) : IRequest<PatientDto>;
}
