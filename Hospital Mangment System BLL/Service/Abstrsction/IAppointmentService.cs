using Hospital_Mangment_System_BLL.View_model.AppointmentVM;
using System.Collections.Generic;

namespace Hospital_Mangment_System_BLL.Service.Abstraction
{
    public interface IAppointmentService
    {
        bool Add(AddAppointmentVM appointment);
        bool Delete(int id);
        bool Update(UpdateAppointmentVM appointment);
        GetAllAppointmentVM GetById(int id);
        List<GetAllAppointmentVM> GetAll();
        bool Update(AddAppointmentVM appointmentVM);
    }
}
