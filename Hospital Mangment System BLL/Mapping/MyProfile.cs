﻿using AutoMapper;

using Hospital_Mangment_System_BLL.View_model;
using Hospital_Mangment_System_BLL.View_model.AppointmentVM;
using Hospital_Mangment_System_BLL.View_model.BillVM;
using Hospital_Mangment_System_BLL.View_model.DepartmentVM;
using Hospital_Mangment_System_BLL.View_model.DoctorVM;
using Hospital_Mangment_System_BLL.View_model.NurseVM;
using Hospital_Mangment_System_BLL.View_model.patientVM;
using Hospital_Mangment_System_DAL.Entites;

namespace Hospital_Mangment_System_BLL.Mapping
{
    public class MyProfile : Profile //profile exist in AutoMapper
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
            CreateMap<Department, GetDepartmentByIdVM>()
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctors.Select(d => d.UserName)))
            .ForMember(dest => dest.NurseName, opt => opt.MapFrom(src => src.nurses.Select(n => n.UserName)));
            CreateMap<UpdateDepartmentVM, Department>();
            CreateMap<Department, GetAllDepartmentsVM>()
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctors.Select(d => d.UserName)))
            .ForMember(dest => dest.NurseName, opt => opt.MapFrom(src => src.nurses.Select(n => n.UserName)));


            CreateMap<Bill, GetBillByIdVM>();
            CreateMap<Bill, GetAllBillsVM>();
            CreateMap<CreateBillVM, Bill>();
            CreateMap<UpdateBillVM, Bill>();


            CreateMap<CreateNurseVM, Nurse>();
            CreateMap<Nurse, GetNurseByIdVM>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Dname));
            CreateMap<UpdateNurseVM, Nurse>();
            CreateMap<Nurse, GetAllNursesVM>()
           .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Dname));



            CreateMap<CreateDoctorVM, Doctor>();
            CreateMap<Doctor, GetDoctorByIdVM>();
            CreateMap<Doctor, GetAllDoctorVM>();
            CreateMap<UpdateDoctorVM, Doctor>();

            CreateMap<Medical_equipment, GetEquipmentByIdVM>();
            CreateMap<Medical_equipment, GetAllEquipmentVM>();
            CreateMap<CreateEquipmentVM, Medical_equipment>();
            CreateMap<UpdateEquipmentVM, Medical_equipment>();




        }




    }
}
