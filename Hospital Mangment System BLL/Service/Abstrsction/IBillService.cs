using Hospital_Mangment_System_BLL.View_model.BillVM;
using Hospital_Mangment_System_DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.Service.Abstrsction
{
    public interface IBillService
    {

        public bool add(CreateBillVM bill);
        public bool delete(int id);

        public bool update(UpdateBillVM bill);

        public GetBillByIdVM getbyId(int  id);

        public List<GetAllBillsVM> getAll();

    }
}
