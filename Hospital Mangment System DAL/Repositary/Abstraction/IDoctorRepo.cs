using Hospital_Mangment_System_DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Repositary.Abstraction
{
    public interface IDoctorRepo
    {
        public bool add(Doctor patient);
        public bool delete(int id);

        public bool update(Doctor patient);

        public Doctor getbyId(int id);

        public List<Doctor> getAll();
    }
}
