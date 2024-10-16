using Hospital_Mangment_System_BLL.Mapping;
using Hospital_Mangment_System_BLL.Service.Abstraction;
using Hospital_Mangment_System_BLL.Service.Implementation;
using Hospital_Mangment_System_BLL.View_model;
using Hospital_Mangment_System_BLL.View_model.patientVM;
using Hospital_Mangment_System_DAL.DB;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;
using Hospital_Mangment_System_DAL.Repositary.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Hospital_Mangment_System_BLL.Service.Abstrsction;

namespace Hospital_Mangment_System_PL
{
    public class Program
    {
        // just a method to reduce the redundant of the code mn 3mk 3bnaser
        private static void ConfigurePasswordOptions(IdentityOptions options)
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 8;
            options.Password.RequiredUniqueChars = 0;
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register the DbContext service
            builder.Services.AddDbContext<ApplicationDBcontext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Authentication configuration
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = "/Account/Login";
                });

           
  
            //  Doctor,patient,nurse IDentity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                ConfigurePasswordOptions(options);// the password
                options.SignIn.RequireConfirmedAccount = true;
            })
            .AddEntityFrameworkStores<ApplicationDBcontext>()
            .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);

            // Register repositories and services
            //patient Service
            builder.Services.AddScoped<IPatientsRepo, PatientsRepo>();
            builder.Services.AddScoped<IPatientService, PatientService>();
            //Appointment Service
            builder.Services.AddScoped<IappointmentRepo, appointmentRepo>();
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            //Department Service
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            //bills Service
            builder.Services.AddScoped<IbillsRepo, billsRepo>();
            builder.Services.AddScoped<IBillService, BillService>();
            //medical Service
            builder.Services.AddScoped<IMedicalEquipmentService, MedicalEquipmentService>();
            builder.Services.AddScoped<IMedicalEquipmentRepo, MedicalEquipmentRepo>();
            //Nurse Service
            builder.Services.AddScoped<INurseRepo, NurseRepo>();
            builder.Services.AddScoped<INurseService, NurseService>();

            // Mapping service
            builder.Services.AddAutoMapper(x => x.AddProfile(new MyProfile()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
