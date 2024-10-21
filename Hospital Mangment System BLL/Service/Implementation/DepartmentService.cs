using AutoMapper;
using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_BLL.View_model.DepartmentVM;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;

namespace Hospital_Mangment_System_BLL.Service.Implementation
{
    public class DepartmentService : IDepartmentService
    {

        private readonly IDepartmentRepo _DepartmentRepo;
        private readonly IMapper _mapper;
        public DepartmentService(IDepartmentRepo departmentRepo, IMapper mapper)
        {
            _DepartmentRepo = departmentRepo;
            _mapper = mapper;
        }

        public bool add(CreateDepartmentVM departmentvm)
        {
            if (departmentvm != null)
            {

                var result = _mapper.Map<Department>(departmentvm);

                _DepartmentRepo.add(result);
                return true;
            }
            else return false;


        }

        public bool delete(int Dnum)
        {

            if (_DepartmentRepo.delete(Dnum))
            {
                return true;
            }
            else return false;

        }

        public List<GetAllDepartmentsVM> getAll()
        {

            var result = _DepartmentRepo.getAll().ToList();
            var newData = _mapper.Map<List<GetAllDepartmentsVM>>(result);

            return newData;

        }

        public GetDepartmentByIdVM getbyId(int id)
        {
            var result = _DepartmentRepo.getbyId(id);
            if (result == null) {
                return null;
            }
            var newdata = _mapper.Map<GetDepartmentByIdVM>(result);

            return newdata;
        }

        public bool update(UpdateDepartmentVM departmentvm)
        {



            if (departmentvm != null)
            {

                var result = _mapper.Map<Department>(departmentvm);

                _DepartmentRepo.update(result);
                return true;
            }
            else return false;


        }
    }

}
