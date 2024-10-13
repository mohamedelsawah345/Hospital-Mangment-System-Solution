using Hospital_Mangment_System_DAL.DB;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;

namespace Hospital_Mangment_System_DAL.Repositary.Implementation
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly ApplicationDBcontext _DBcontext;
        public DepartmentRepo(ApplicationDBcontext DBcontext)
        {
            _DBcontext = DBcontext;
        }


        public bool add(Department department)
        {
            var result = _DBcontext.departments.Add(department);


            if (result != null)
            {
                _DBcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool delete(int Dnum)
        {
            var result = _DBcontext.departments.Where(p => p.Dnum == Dnum).FirstOrDefault(); //don't forget first or default 
            if (result != null)
            {
                result.IsDeleted = !result.IsDeleted;
                _DBcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Department> getAll() => _DBcontext.departments.ToList();


        public Department getbyId(int Dnum)
        {
            return _DBcontext.departments.Where(p => p.Dnum == Dnum).FirstOrDefault(); //don't forget first or default 


        }

        public bool update(Department department)
        {
            var result = _DBcontext.departments.Where(p => p.Dnum == department.Dnum).FirstOrDefault(); //don't forget first or default 

            if (result != null)
            {
                result.Dname = department.Dname;
                result.Location = department.Location;
                _DBcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
