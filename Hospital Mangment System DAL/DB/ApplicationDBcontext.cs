using Hospital_Mangment_System_DAL.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.DB
{
    public class ApplicationDBcontext:DbContext
    {

        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options)
        {

            
        }

       public DbSet<Patient> patients { get; set; }
       public DbSet<Bill> bills { get; set; }
        public DbSet<Addmission> addmissions { get; set; }
        public DbSet<Appointment> appointments { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Nurse> nurses { get; set; }
        public DbSet<Medical_equipment> medical_Equipment { get; set; }
        public DbSet<Lap_test> lap_Tests { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        //abnaser
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Bill>()
                .HasOne(a => a.patient)
                .WithMany(d => d.Bills)
                .HasForeignKey(a => a.patientId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Appointment>()
                .HasOne(p=>p.patient)
                .WithMany(a=>a.Appointments)
                .HasForeignKey(a => a.patient_id)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Addmission>()
                 .HasOne(p => p.patient)
                 .WithMany(a => a.Addmissions)
                 .HasForeignKey(a => a.Patient_Id)
                 .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Lap_test>()
                 .HasOne(p => p.patient)
                 .WithMany(a => a.lap_Tests)
                 .HasForeignKey(a => a.Patient_ID)
                 .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Nurse>()
                 .HasOne(n=>n.Department)
                 .WithMany(a => a.nurses)
                 .HasForeignKey(a => a.Dnum)
                 .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Medical_equipment>()
                 .HasOne(n => n.Department)
                 .WithMany(a => a.medical_Equipments)
                 .HasForeignKey(a => a.Dnum)
                 .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Doctor>()
                 .HasOne(n => n.department)
                 .WithMany(a => a.Doctors)
                 .HasForeignKey(a => a.Dnum)
                 .OnDelete(DeleteBehavior.NoAction);


        }


    }

}
