using AutoMapper;
using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_BLL.View_model.DepartmentVM;
using Hospital_Mangment_System_BLL.View_model.NurseVM;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;
using Hospital_Mangment_System_DAL.Repositary.Implementation;

namespace Hospital_Mangment_System_BLL.Service.Implementation
{
    public class NurseService : INurseService
    {
        private readonly INurseRepo _NurseRepo;
        private readonly IMapper _mapper;
        public NurseService(INurseRepo nurseRepo, IMapper mapper)
        {
            _NurseRepo = nurseRepo;
            _mapper = mapper;
        }

        public bool add(CreateNurseVM Nursevm)
        {
            if (Nursevm != null)
            {

                var result = _mapper.Map<Nurse>(Nursevm);

                _NurseRepo.add(result);
                return true;
            }
            else return false;


        }

        public bool delete(string NurseID)
        {

            if (_NurseRepo.delete(NurseID))
            {
                return true;
            }
            else return false;

        }

        public List<GetAllNursesVM> getAll()
        {

            var result = _NurseRepo.getAll().ToList();
            var newData = _mapper.Map<List<GetAllNursesVM>>(result);

            return newData;

        }

        public GetNurseByIdVM getbyId(string NurseID)
        {
            var result = _NurseRepo.getbyId(NurseID);
            var newdata = _mapper.Map<GetNurseByIdVM>(result);

            return newdata;
        }

        public bool update(UpdateNurseVM nursevm)
        {



            if (nursevm != null)
            {

                var result = _mapper.Map<Nurse>(nursevm);

                _NurseRepo.update(result);
                return true;
            }
            else return false;


        }
    }
}

