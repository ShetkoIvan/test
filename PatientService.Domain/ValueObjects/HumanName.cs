namespace PatientService.Domain.ValueObjects
{
    public class HumanName
    {
        public HumanName(string family, List<string> given, string use)
        {
            Family = family;
            Given = given;
            Use = use;
        }

        public string Use { get; set; } = "official";
        public string Family { get; set; } = default!;
        public List<string> Given { get; set; } = new();
    }
}
