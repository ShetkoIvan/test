using Microsoft.EntityFrameworkCore;
using PatientService.Application.Patients;
using PatientService.Domain.Entities;
using PatientService.Infrastructure.Persistence;

namespace PatientService.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {

        private readonly AppDbContext _db;

        public IQueryable<Patient> Query() => _db.Patients;

        public PatientRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task AddAsync(Patient patient, CancellationToken ct)
        {
            _db.Add(patient);
            await _db.SaveChangesAsync(ct);
        }

        public async Task<Patient?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var result = await _db.Patients.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: ct);

            return result;
        }

        public async Task<List<Patient>> ExecuteAsync(IQueryable<Patient> query, CancellationToken ct)
        {
            return await query.AsNoTracking().ToListAsync(ct);
        }

        public async Task<List<Patient>> GetAllAsync(CancellationToken ct)
        {
            return await _db.Patients.ToListAsync(ct);
        }

        public async Task SaveChangesAsync(CancellationToken ct)
        {
            await _db.SaveChangesAsync(ct);
        }

        public void Remove(Patient patient)
        {
            _db.Patients.Remove(patient);
        }
    }
}
