using Hospital_Mangment_System_DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Repositary.Abstraction
{
    public interface IbillsRepo
    {

        public bool add(Bill bill);
        public bool delete(int id);

        public bool update(Bill bill);

        public Bill getbyId(int id);

        public List<Bill> getAll();
    }
}
