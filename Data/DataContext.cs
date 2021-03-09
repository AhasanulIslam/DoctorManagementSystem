using DoctorManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorManagement.Data
{

public class DataContext : DbContext{
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

            public DbSet<Doctor> Doctors {get; set; }
            public DbSet<Users> User {get; set;}  
            public DbSet<Patient> Patients { get; set; }
            public DbSet<Appointment> Appointments { get; set; }


    }
}