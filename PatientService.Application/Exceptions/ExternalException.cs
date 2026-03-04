namespace PatientService.Application.Exceptions
{
    public class ExternalException : Exception
    {
        public ExternalException(string message) : base(message) 
        {
        }
    }
}
