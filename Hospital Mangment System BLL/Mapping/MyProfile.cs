using AutoMapper;

using Hospital_Mangment_System_BLL.View_model;
using Hospital_Mangment_System_BLL.View_model.AppointmentVM;
using Hospital_Mangment_System_BLL.View_model.BillVM;
using Hospital_Mangment_System_BLL.View_model.DepartmentVM;
using Hospital_Mangment_System_BLL.View_model.DoctorVM;
using Hospital_Mangment_System_BLL.View_model.NurseVM;
using Hospital_Mangment_System_BLL.View_model.patientVM;
using Hospital_Mangment_System_DAL.DB;
using Hospital_Mangment_System_DAL.Entites;

namespace Hospital_Mangment_System_BLL.Mapping
{
    public class MyProfile : Profile //profile exist in AutoMapper
    {
        public MyProfile()
        {
           

            CreateMap<AddAppointmentVM, Appointment>();
            CreateMap<Appointment, GetAppointmentByIDVM>();
            CreateMap<Appointment, GetAllAppointmentVM>();
            CreateMap<UpdateAppointmentVM, Appointment>();


            CreateMap<CreateDepartmentVM, Department>();
            CreateMap<Department, GetDepartmentByIdVM>()
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctors.Select(d => d.ApplicationUser)))
            .ForMember(dest => dest.NurseName, opt => opt.MapFrom(src => src.nurses.Select(n => n.ApplicationUser)));
            CreateMap<UpdateDepartmentVM, Department>();
            CreateMap<Department, GetAllDepartmentsVM>()
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctors.Select(d => d.ApplicationUser)))
            .ForMember(dest => dest.NurseName, opt => opt.MapFrom(src => src.nurses.Select(n => n.ApplicationUser)));
           

            

            CreateMap<Bill, GetBillByIdVM>();
            CreateMap<Bill, GetAllBillsVM>();
            CreateMap<CreateBillVM, Bill>();
            CreateMap<UpdateBillVM, Bill>();


            // Doctor mappings
            CreateMap<CreateDoctorVM, Doctor>();
            CreateMap<Doctor, GetAllDoctorVM>();
            CreateMap<Doctor, GetDoctorByIdVM>();
            CreateMap<UpdateDoctorVM, Doctor>();

            // Nurse mappings
            CreateMap<CreateNurseVM, Nurse>();
            CreateMap<Nurse, GetAllNursesVM>();
            CreateMap<Nurse, GetNurseByIdVM>();
            CreateMap<UpdateNurseVM, Nurse>();

            // Patient mappings
            CreateMap<CreatePatientVM, Patient>();
            CreateMap<Patient, GetAllPatientssVM>();
            CreateMap<Patient, GetPatientByIdVM>();
            CreateMap<UpdatePatientVM, Patient>();

            CreateMap<Medical_equipment, GetEquipmentByIdVM>();
            CreateMap<Medical_equipment, GetAllEquipmentVM>();
            CreateMap<CreateEquipmentVM, Medical_equipment>();
            CreateMap<UpdateEquipmentVM, Medical_equipment>();
            // Mapping between ApplicationUser and the entities
             CreateMap<ApplicationUser, Doctor>()
                .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.Id));
                CreateMap<ApplicationUser, Nurse>()
                    .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.Id));
                CreateMap<ApplicationUser, Patient>()
                    .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.Id));




        }




    }
}
