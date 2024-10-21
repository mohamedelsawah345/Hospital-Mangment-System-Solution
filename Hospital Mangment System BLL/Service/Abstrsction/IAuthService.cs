using Hospital_Mangment_System_BLL.View_model.AuthenticationVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.Service.Abstrsction
{
    public interface IAuthService
    {
        Task<bool> RegisterDoctorAsync(RegisterVM model);
        Task<bool> RegisterNurseAsync(RegisterVM model);
        Task<bool> RegisterPatientAsync(RegisterVM model);
        Task<string> LoginAsync(LoginVM model);
        
        //Task<IdentityResult> RegisterUserAsync(RegisterVM model);
    }
}
