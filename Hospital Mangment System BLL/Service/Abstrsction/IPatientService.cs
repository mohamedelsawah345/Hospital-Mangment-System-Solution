using Hospital_Mangment_System_DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.View_model.patientVM
{
    public interface IPatientService
    {
        public bool add(CreatePatientVM patient);
        public bool delete(int id);

        public bool update(UpdatePatientVM patient);

        public GetPatientByIdVM getbyId(int id);

        public List<GetAllPatientssVM> getAll();
    }
}
