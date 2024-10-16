using Hospital_Mangment_System_DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Repositary.Abstraction
{
    public interface INurseRepo
    {
        public bool add(Nurse nurse);
        public bool delete(string NurseID);
        public bool update(Nurse nurse);
        public Nurse getbyId(string NurseID);
        public List<Nurse> getAll();
    }
}
