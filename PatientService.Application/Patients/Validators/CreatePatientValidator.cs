using FluentValidation;
using PatientService.Application.Patients.Commands;

namespace PatientService.Application.Patients.Validators
{
    public class CreatePatientValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientValidator() 
        {
            RuleFor(x => x.Family).NotEmpty();
            RuleFor(x => x.BirthDate).NotEmpty();
        }
    }
}
