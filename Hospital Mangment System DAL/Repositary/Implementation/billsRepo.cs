using Hospital_Mangment_System_DAL.DB;
using Hospital_Mangment_System_DAL.Entites;
using Hospital_Mangment_System_DAL.Repositary.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_DAL.Repositary.Implementation
{
    public class billsRepo : IbillsRepo
    {
        private readonly ApplicationDBcontext _DBcontext;
        public billsRepo(ApplicationDBcontext DBcontext)
        {
            _DBcontext = DBcontext;
        }
        public bool add( bill bill)
        {
            var result = _DBcontext.bills.Add(bill);
            

            if (result != null)
            {
                _DBcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

      

        public bool delete(int id)
        {
            var result = _DBcontext.bills.Where(p => p.ID == id).FirstOrDefault(); //don't forget frist or defualt 


            if (result != null)
            {
                result.IsDeleted = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Entites.bill> getAll()
        {
            return _DBcontext.bills.ToList();
        }

        public Entites.bill getbyId(int id)
        {
            return _DBcontext.bills.Where(p => p.ID == id).FirstOrDefault(); //don't forget frist or defualt 

        }

        public bool update(bill bill)
        {
            var result = _DBcontext.bills.Where(p => p.ID == bill.ID).FirstOrDefault(); //don't forget frist or defualt 



            if (result != null)
            {

                result.Amount= bill.Amount;
                

                _DBcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
