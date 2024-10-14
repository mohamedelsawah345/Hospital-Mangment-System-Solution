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
        public bool add( Bill bill)
        {
            try
            {
                var result = _DBcontext.bills.Add(bill);
                    _DBcontext.SaveChanges();
                    return true;
               
            }
            catch (Exception ex)
            {
                return false ;

            }

      
        }



        public bool delete(int id)
        {
            var result = _DBcontext.bills.Where(p => p.ID == id).FirstOrDefault(); // Find the bill by ID

            if (result != null)
            {
                result.IsDeleted = true; // Mark as deleted
                _DBcontext.SaveChanges(); 
                return true;
            }
            else
            {
                return false; 
            }
        }


        public List<Bill> getAll()
        {
            return _DBcontext.bills.ToList();
        }

        public Bill getbyId(int id)
        {
            try
            {
                return _DBcontext.bills.Where(p => p.ID == id).FirstOrDefault(); //don't forget frist or defualt 
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public bool update(Bill bill)
        {
            try
            {

                var result = _DBcontext.bills.Where(p => p.ID == bill.ID).FirstOrDefault(); //don't forget frist or defualt 

                    result.Amount = bill.Amount;

                    _DBcontext.SaveChanges();
                    return true;
              
            }
            catch (Exception ex)
            {
                return false; 

            }

        
        }
    }
}
