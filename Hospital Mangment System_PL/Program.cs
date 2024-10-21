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
using Microsoft.AspNetCore.Identity.UI.Services;
using IEmailSender = Hospital_Mangment_System_BLL.Service.Abstrsction.IEmailSender;

namespace Hospital_Mangment_System_PL
{
    public class Program
    {
        private static void ConfigurePasswordOptions(IdentityOptions options)
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
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
                    options.AccessDeniedPath = "/Account/AccessDenied";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Cookie expiration
                    options.SlidingExpiration = true;
                });

            // Identity configuration
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                ConfigurePasswordOptions(options);
                options.SignIn.RequireConfirmedAccount = false; // Email confirmation
            })
            .AddEntityFrameworkStores<ApplicationDBcontext>()
            .AddDefaultTokenProviders(); // For email confirmation, password resets, etc.

            // Configure email sender for confirmation emails (you can use services like SendGrid or SMTP)
            builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
            builder.Services.AddTransient<IEmailSender, EmailSender>();
            builder.Services.AddHttpContextAccessor();
            // Add Google authentication
            //builder.Services.AddAuthentication()
            //        .AddGoogle(options =>
            //        {
            //            options.ClientId = "931759170237-j6volpkukte1jg9ki7c8vrr5kru540cb.apps.googleusercontent.com";
            //            options.ClientSecret = "OCSPX-KbaGmZCZeIz1bWT0jHkHHk8V47dN";
            //        });
                    //.AddFacebook(options =>
                    //{
                    //    options.AppId = "YOUR_FACEBOOK_APP_ID";
                    //    options.AppSecret = "YOUR_FACEBOOK_APP_SECRET";
                    //});

            builder.Services.AddControllersWithViews();
            // Register repositories and services
            builder.Services.AddScoped<IPatientsRepo, PatientsRepo>();
            builder.Services.AddScoped<IPatientService, PatientService>();
            builder.Services.AddScoped<IappointmentRepo, appointmentRepo>();
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IbillsRepo, billsRepo>();
            builder.Services.AddScoped<IBillService, BillService>();
            builder.Services.AddScoped<IMedicalEquipmentService, MedicalEquipmentService>();
            builder.Services.AddScoped<IMedicalEquipmentRepo, MedicalEquipmentRepo>();
            builder.Services.AddScoped<INurseRepo, NurseRepo>();
            builder.Services.AddScoped<INurseService, NurseService>();
            builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
            builder.Services.AddScoped<IDoctorService, DoctorService>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            // Add AutoMapper for object mapping
            builder.Services.AddAutoMapper(x => x.AddProfile(new MyProfile()));
            //add session to show user name afterlogin
            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();

            // Authentication & Authorization middleware
            app.UseAuthentication();
            app.UseAuthorization();

            // Ensure roles exist
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                CreateRoles(roleManager).Wait(); // Ensure roles are created
            }

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        // Ensure roles exist
        private static async Task CreateRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Doctor", "Nurse", "Patient" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }

}
