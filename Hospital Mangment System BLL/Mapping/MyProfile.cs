using AutoMapper;
using Hospital_Mangment_System_BLL.View_model.DepartmentVM;
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
            CreateMap<Patient, GetAllPatientsVM>();
            CreateMap<UpdatePatientVM, Patient>();

            CreateMap<CreateDepartmentVM, Department>();
            CreateMap<Department, GetDepartmentByIdVM>(); 
            CreateMap<Department, GetAllDepartmentsVM>();
            CreateMap<UpdateDepartmentVM, Department>();


        }


    }
}
