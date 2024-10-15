using AutoMapper;

using Hospital_Mangment_System_BLL.View_model;
using Hospital_Mangment_System_BLL.View_model.AppointmentVM;
using Hospital_Mangment_System_BLL.View_model.BillVM;
using Hospital_Mangment_System_BLL.View_model.DepartmentVM;
using Hospital_Mangment_System_BLL.View_model.NurseVM;
using Hospital_Mangment_System_BLL.View_model.patientVM;
using Hospital_Mangment_System_DAL.Entites;

namespace Hospital_Mangment_System_BLL.Mapping
{
    public class MyProfile :Profile //profile exist in AutoMapper
    {
        public MyProfile()
        {
            CreateMap<CreatePatientVM, Patient>();
            CreateMap<Patient, GetPatientByIdVM>(); // Don't forger this to tell auto mapper how work
            CreateMap<Patient, GetAllPatientssVM>();
            CreateMap<UpdatePatientVM, Patient>();

            CreateMap<AddAppointmentVM, Appointment>();
            CreateMap<Appointment, GetAppointmentByIDVM>();
            CreateMap<Appointment, GetAllAppointmentVM>();
            CreateMap<UpdateAppointmentVM, Appointment>();


            CreateMap<CreateDepartmentVM, Department>();
            CreateMap<Department, GetDepartmentByIdVM>(); 
            CreateMap<Department, GetAllDepartmentsVM>();
            CreateMap<UpdateDepartmentVM, Department>();


            CreateMap<Bill, GetBillByIdVM>();
            CreateMap<Bill, GetAllBillsVM>();
            CreateMap<CreateBillVM, Bill>();
            CreateMap<UpdateBillVM, Bill>();


            CreateMap<CreateNurseVM, Nurse>();
            CreateMap<Nurse, GetNurseByIdVM>();
            CreateMap<UpdateNurseVM, Nurse>();
            CreateMap<Nurse, GetAllNursesVM>()
           .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Dname));

        }




    }
}
