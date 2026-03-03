using AutoMapper;
using PatientService.Application.Patients.Dtos;
using PatientService.Domain.Entities;

namespace PatientService.Application.Patients.Mapping
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientDto>()
                .ForMember(dest => dest.Family, opt => opt.MapFrom(src => src.Name.Family))
                .ForMember(dest => dest.Given, opt => opt.MapFrom(src => src.Name.Given))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()));
        }
    }
}
