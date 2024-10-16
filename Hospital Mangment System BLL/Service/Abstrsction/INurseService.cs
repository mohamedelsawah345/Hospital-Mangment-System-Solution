using Hospital_Mangment_System_BLL.View_model.DepartmentVM;
using Hospital_Mangment_System_BLL.View_model.NurseVM;

namespace Hospital_Mangment_System_BLL.Service.Abstrsction
{
    public interface INurseService
    {
        public bool add(CreateNurseVM department);
        public bool delete(string NurseID);
        public bool update(UpdateNurseVM department);
        public GetNurseByIdVM getbyId(string NurseID);
        public List<GetAllNursesVM> getAll();
    }
}
