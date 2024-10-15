using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Mangment_System_BLL.View_model.DoctorVM;


namespace Hospital_Mangment_System_BLL.Service.Abstrsction
{
     public interface IDoctorService
    {

        public bool add(CreateDoctorVM doctorvm);
        public bool delete(int id);

        public bool update(UpdateDoctorVM doctorvm);

        public GetDoctorByIdVM getbyId(int id);

        public List<GetAllDoctorVM> getAll();



    }
}
