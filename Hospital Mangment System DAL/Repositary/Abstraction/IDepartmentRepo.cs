using Hospital_Mangment_System_DAL.Entites;
namespace Hospital_Mangment_System_DAL.Repositary.Abstraction
{
    public interface IDepartmentRepo
    {
        public bool add(Department department);
        public bool delete(int Dnum);
        public bool update(Department department);
        public Department getbyId(int Dnum);
        public List<Department> getAll();
    }
}
