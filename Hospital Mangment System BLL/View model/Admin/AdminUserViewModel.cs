using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.View_model.Admin
{
    public class AdminUserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public bool IsDeleted { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsLockedOut { get; set; }
    }
}
