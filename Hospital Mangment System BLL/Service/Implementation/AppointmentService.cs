using AutoMapper;
using Hospital_Mangment_System_BLL.Service.Abstraction;
using Hospital_Mangment_System_BLL.View_model.AppointmentVM;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;
using System.Collections.Generic;
using System.Linq;

namespace Hospital_Mangment_System_BLL.Service.Implementation
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IappointmentRepo _appointmentsRepo;
        private readonly IMapper _mapper;

        public AppointmentService(IappointmentRepo appointmentsRepo, IMapper mapper)
        {
            _appointmentsRepo = appointmentsRepo;
            _mapper = mapper;
        }

        public bool Add(AddAppointmentVM appointmentVM)
        {
            if (appointmentVM != null)
            {
                var appointment = _mapper.Map<Appointment>(appointmentVM);
                _appointmentsRepo.add(appointment);
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            return _appointmentsRepo.delete(id);
        }

        public List<GetAllAppointmentVM> GetAll()
        {
            var appointments = _appointmentsRepo.getAll().ToList();
            return _mapper.Map<List<GetAllAppointmentVM>>(appointments);
        }

        public GetAppointmentByIDVM GetById(int id)
        {
            var appointment = _appointmentsRepo.getbyId(id);
            return _mapper.Map<GetAppointmentByIDVM>(appointment);
        }

        public bool Update(UpdateAppointmentVM appointmentVM)
        {
            if (appointmentVM != null)
            {
                var appointment = _mapper.Map<Appointment>(appointmentVM);
                _appointmentsRepo.update(appointment);
                return true;
            }
            return false;
        }

        public bool Update(AddAppointmentVM appointmentVM)
        {
            throw new NotImplementedException();
        }

        GetAllAppointmentVM IAppointmentService.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
