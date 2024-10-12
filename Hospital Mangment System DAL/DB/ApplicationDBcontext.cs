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

       public DbSet<patient> patients { get; set; }
       public DbSet<bill> bills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<bill>()
                .HasOne(a => a.patient)
                .WithMany(d => d.bills)
                .HasForeignKey(a => a.patientId)
                .OnDelete(DeleteBehavior.NoAction);



        }






    }

}
