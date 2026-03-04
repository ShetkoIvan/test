using AutoMapper;
using MediatR;
using PatientService.Application.Patients.Dtos;

namespace PatientService.Application.Patients.Queries
{
    public class SearchPatientsHandler : IRequestHandler<SearchPatientsQuery, IReadOnlyList<PatientDto>>
    {
        private readonly IPatientRepository _rep;
        private readonly IMapper _mapper;

        public SearchPatientsHandler(IPatientRepository rep, IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<PatientDto>> Handle(SearchPatientsQuery request, CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(request.BirthDate))
            {
                var all = await _rep.GetAllAsync(ct);
                return _mapper.Map<IReadOnlyList<PatientDto>>(all);
            }

            var query = _rep.Query();

            var dateFilter = ApplyBirthDate.GetQuery(query, request.BirthDate);

            var patients = await _rep.ExecuteAsync(dateFilter, ct);

            return _mapper.Map<IReadOnlyList<PatientDto>>(patients);
        }
    }
}
