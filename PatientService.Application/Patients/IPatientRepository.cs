using PatientService.Domain.Entities;

namespace PatientService.Application.Patients
{
    public interface IPatientRepository
    {
        Task AddAsync(Patient patient, CancellationToken ct);
        Task<Patient?> GetByIdAsync(Guid id, CancellationToken ct);
        IQueryable<Patient> Query();
        Task<List<Patient>> ExecuteAsync(IQueryable<Patient> query, CancellationToken ct);
        Task<List<Patient>> GetAllAsync(CancellationToken ct);
        Task SaveChangesAsync(CancellationToken ct);
        void Remove(Patient patient);
    }
}
