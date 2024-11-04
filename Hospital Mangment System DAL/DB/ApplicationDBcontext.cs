using Hospital_Mangment_System_DAL.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Mangment_System_DAL.DB
{
    public class ApplicationDBcontext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options)
        {


        }
        //test1

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
            base.OnModelCreating(modelBuilder);
            // Doctor-ApplicationUser relationship
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.ApplicationUser)
                .WithOne(au => au.Doctor)
                .HasForeignKey<Doctor>(d => d.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Nurse-ApplicationUser relationship
            modelBuilder.Entity<Nurse>()
                .HasOne(n => n.ApplicationUser)
                .WithOne(au => au.Nurse)
                .HasForeignKey<Nurse>(n => n.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Patient-ApplicationUser relationship
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.ApplicationUser)
                .WithOne(au => au.Patient)
                .HasForeignKey<Patient>(p => p.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Bill>()
                .HasOne(a => a.patient)
                .WithMany(d => d.Bills)
                .HasForeignKey(a => a.patientId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Appointment>()
                .HasOne(p => p.patient)
                .WithMany(a => a.Appointments)
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
                 .HasOne(n => n.Department)
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

            public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is ApplicationUser && e.State == EntityState.Deleted);

            foreach (var entry in entries)
            {
                entry.State = EntityState.Modified;
                ((ApplicationUser)entry.Entity).IsDeleted = true;
            }

            return base.SaveChanges();
        }
    }


}


