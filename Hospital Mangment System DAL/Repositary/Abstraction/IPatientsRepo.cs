using Hospital_Mangment_System_DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Repositary.Abstraction
{
    public interface IPatientsRepo
    {
        public bool add(patient patient);
        public bool delete(int id);

        public bool update(patient patient);

        public patient getbyId(int id);

        public List< patient> getAll();

    }
}
