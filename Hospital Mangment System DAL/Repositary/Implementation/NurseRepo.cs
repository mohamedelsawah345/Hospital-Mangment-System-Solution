using Hospital_Mangment_System_DAL.DB;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Mangment_System_DAL.Repositary.Implementation
{
    public class NurseRepo : INurseRepo
    {
        private readonly ApplicationDBcontext _DBcontext;
        public NurseRepo(ApplicationDBcontext DBcontext)
        {
            _DBcontext = DBcontext;
        }


        public bool add(Nurse nurse)
        {
            var result = _DBcontext.nurses.Add(nurse);


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

        public bool delete(string NurseID)
        {
            var result = _DBcontext.nurses.Where(p => p.Id == NurseID).FirstOrDefault(); //don't forget first or default 
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

        public List<Nurse> getAll()                  //need to add department name 
        {

            var result = _DBcontext.nurses.Include(n => n.Department).ToList();
            return result;
        }


        public Nurse getbyId(string NurseID)
        {
            return _DBcontext.nurses.Include(n => n.Department).Where(p => p.Id == NurseID).FirstOrDefault(); //don't forget first or default 


        }

        public bool update(Nurse nurse)
        {
            var result = _DBcontext.nurses.Where(p => p.Id == nurse.Id).FirstOrDefault(); //don't forget first or default 
            var DepartmentName = from Nurse in _DBcontext.nurses
                                 join Department in _DBcontext.departments
                                 on nurse.Dnum equals Department.Dnum
                                 select new
                                 {
                                     NurseName = nurse.UserName,
                                     DepartmentName = Department.Dname
                                 };
            if (result != null)
            {
                result.UserName = nurse.UserName;
                result.phones = nurse.phones;


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

