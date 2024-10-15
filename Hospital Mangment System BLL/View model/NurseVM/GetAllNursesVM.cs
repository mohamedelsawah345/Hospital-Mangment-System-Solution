using Hospital_Mangment_System_DAL.Entites;

namespace Hospital_Mangment_System_BLL.View_model.NurseVM
{
    public class GetAllNursesVM
    {
        public int NurseID { get; set; }
        public string? Name { get; set; }
        public long? phones { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Dnum { get; set; }
        public Department? Department { get; set; }
        public string? DepartmentName { get; set; }
    }
}
