namespace PatientService.Application.Patients.Dtos
{
    public record PatientDto()
    {
        public Guid Id { get; init; }
        public string Family { get; init; } = default!;
        public List<string> Given { get; init; } = default!;
        public DateTime BirthDate { get; init; }
        public string Gender { get; init; } = default!;
        public string Active { get; init; } = default!;
    }
}
