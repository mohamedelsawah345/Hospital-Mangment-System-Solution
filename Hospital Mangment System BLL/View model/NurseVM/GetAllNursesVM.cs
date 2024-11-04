using Hospital_Mangment_System_DAL.Entites;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Mangment_System_BLL.View_model.NurseVM
{
    public class GetAllNursesVM
    {
        public string Id { get; set; } // This will be the ApplicationUserId
        [Required]
        [Display(Name = "Full Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public int DepartmentId { get; set; } // Nurse-specific
    }
}

