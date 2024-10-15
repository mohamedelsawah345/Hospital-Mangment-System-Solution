using Hospital_Mangment_System_BLL.View_model.AppointmentVM;
using System.Collections.Generic;

namespace Hospital_Mangment_System_BLL.Service.Abstraction
{
    public interface IAppointmentService
    {
       public bool Add(AddAppointmentVM appointment);
        public bool Delete(int id);
        public bool Update(UpdateAppointmentVM appointment);
        public GetAppointmentByIDVM GetById(int id);
        public List<GetAllAppointmentVM> GetAll();
       
    }
}
