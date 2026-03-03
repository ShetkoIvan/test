using Microsoft.EntityFrameworkCore;
using PatientService.Domain.Entities;

namespace PatientService.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Patient> Patients => Set<Patient>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<Patient>().OwnsOne(x => x.Name);
        }
    }
}
