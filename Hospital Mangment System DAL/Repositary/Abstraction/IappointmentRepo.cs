using Hospital_Mangment_System_DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Repositary.Abstraction
{
    public interface IappointmentRepo
    {
        public bool add(Appointment appointment);
        public bool delete(int id);

        public bool update(Appointment appointment);

        public Appointment getbyId(int id);

        public List<Appointment> getAll();

    }
}

    
