using AutoMapper;
using MediatR;
using PatientService.Application.Exceptions;
using PatientService.Application.Patients.Dtos;

namespace PatientService.Application.Patients.Queries
{
    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, PatientDto>
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;

        public GetPatientByIdQueryHandler(
            IPatientRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PatientDto> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var patient = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (patient == null)
                throw new NotFoundException("Patient not found");

            return _mapper.Map<PatientDto>(patient);
        }
    }
}
