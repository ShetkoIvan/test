namespace PatientService.Application.Patients.Dtos
{
    public record PatientDto(
        Guid Id,
        string Family,
        List<string> Given,
        string Gender,
        DateTime BirthDate,
        bool Active);
}
