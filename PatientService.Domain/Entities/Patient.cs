using PatientService.Domain.Enums;
using PatientService.Domain.ValueObjects;

namespace PatientService.Domain.Entities
{
    public class Patient
    {
        public Guid Id { get; set; }

        public HumanName Name { get; set; } = default!;

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public Active Active { get; set; }

        public void SetBirthDate(DateTime birthDate)
        {
            if (birthDate == default)
                throw new ArgumentException("BirthDate is required");

            BirthDate = birthDate;
        }

        public void SetGender(Gender gender)
        {
            Gender = gender;
        }

        public void SetActive(Active active)
        {
            Active = active;
        }

        public void ChangeName(HumanName newName)
        {
            if (newName is null)
                throw new ArgumentNullException(nameof(newName));

            if (string.IsNullOrWhiteSpace(newName.Family))
                throw new ArgumentException("Family name is required");

            Name = newName;
        }
    }
}
