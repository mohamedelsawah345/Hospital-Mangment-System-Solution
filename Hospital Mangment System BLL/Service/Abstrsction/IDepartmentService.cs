using Hospital_Mangment_System_BLL.View_model.DepartmentVM;
namespace Hospital_Mangment_System_BLL.Service.Abstrsction
{
    public interface IDepartmentService
    {
        public bool add(CreateDepartmentVM department);
        public bool delete(int Dnum);
        public bool update(UpdateDepartmentVM department);
        public GetDepartmentByIdVM getbyId(int Dnum);
        public List<GetAllDepartmentsVM> getAll();
    }
}
