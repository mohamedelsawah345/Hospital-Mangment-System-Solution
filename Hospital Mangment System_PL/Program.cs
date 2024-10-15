using Hospital_Mangment_System_BLL.Mapping;
using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_BLL.Service.Implementation;
using Hospital_Mangment_System_BLL.View_model;
using Hospital_Mangment_System_BLL.View_model.patientVM;
using Hospital_Mangment_System_DAL.DB;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;
using Hospital_Mangment_System_DAL.Repositary.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace Hospital_Mangment_System_PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            //Register the DBContext service
            builder.Services.AddDbContext<ApplicationDBcontext>(
            (options) =>
                 {
                     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                 }
            );

            //Register Repository Service
            //patient service
            builder.Services.AddScoped<IPatientsRepo, PatientsRepo>();
            builder.Services.AddScoped<IPatientService, PatientService>();
            //department service
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            //bill service
            builder.Services.AddScoped<IbillsRepo,billsRepo>();
            builder.Services.AddScoped<IBillService,BillService>();
            //Medical Service
            builder.Services.AddScoped<IMedicalEquipmentService, MedicalEquipmentService>();
            builder.Services.AddScoped<IMedicalEquipmentRepo, MedicalEquipmentRepo>();

            // maping service
            builder.Services.AddAutoMapper(x => x.AddProfile(new MyProfile()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
