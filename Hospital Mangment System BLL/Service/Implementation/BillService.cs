using AutoMapper;
using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_BLL.View_model.BillVM;
using Hospital_Mangment_System_BLL.View_model.DepartmentVM;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;


namespace Hospital_Mangment_System_BLL.Service.Implementation
{
    public class BillService : IBillService
    {
        private readonly IbillsRepo _billService;
        private readonly IMapper _mapper;

        public BillService(IbillsRepo BillsRepo, IMapper mapper)
        {
            _billService = BillsRepo;
            this._mapper = mapper;
        }

        public bool add(CreateBillVM bill)
        {
            if (bill != null)
            {

                var result = _mapper.Map<Bill>(bill);

                _billService.add(result);
                return true;
            }
            else return false;

        }

        public bool delete(int id)
        {
         if(_billService.delete(id)) return true;
         return false;
        }

        public List<GetAllBillsVM> getAll()
        {
            var result = _billService.getAll().Where(a=>a.IsDeleted!=true).ToList();
            var newData = _mapper.Map<List<GetAllBillsVM>>(result);
            return newData;

        }


        public GetBillByIdVM getbyId(int  id)
        {
            var res = _billService.getbyId(id); // Assuming this returns a single Bill object
            var newData = _mapper.Map<GetBillByIdVM>(res); // Map to a single GetBillByIdVM
            return newData;
        }

        public bool update(UpdateBillVM bill)
        {
            // Map from UpdateBillVM to Bill entity
            var billEntity = _mapper.Map<Bill>(bill);
            return _billService.update(billEntity);
        }

    }
}
