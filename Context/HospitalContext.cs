using Hospital.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Hospital.Context
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }

            public DbSet<Patient> Patients { get; set; }
            public DbSet<Doctor> Doctors { get; set; }
            public DbSet<Treatment> Treatments { get; set; }
    }
}
