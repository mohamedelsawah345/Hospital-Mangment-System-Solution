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

    public class IMedicalEquipRepo : Abstraction.IMedicalEquipRepo
    {
        private readonly ApplicationDBcontext _DBcontext;
        public IMedicalEquipRepo(ApplicationDBcontext DBcontext)
        {
            _DBcontext = DBcontext;
        }
        public bool add(Medical_equipment medical_Equipment)
        {
            var result = _DBcontext.medical_Equipment.Add(medical_Equipment);


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

            var result = _DBcontext.medical_Equipment.Where(p => p.Equipment_Id == id).FirstOrDefault(); //don't forget frist or defualt 


            if (result != null)
            {
                _DBcontext.Remove(result);
                _DBcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }


        }

        public List<Medical_equipment> getAll()
        {

            return _DBcontext.medical_Equipment.ToList();

        }

        public Medical_equipment getbyId(int Equipment_id)
        {
            return _DBcontext.medical_Equipment.Where(a => a.Equipment_Id == Equipment_id).FirstOrDefault();  


        }

        public bool update(Medical_equipment medical_Equipment)
        {
            var result = _DBcontext.medical_Equipment.Where(p => p.Equipment_Id == medical_Equipment.Equipment_Id).FirstOrDefault();



            if (result != null)
            {

                result.Department = medical_Equipment.Department;
                result.Maintence_date = medical_Equipment.Maintence_date;
                result.Dnum = medical_Equipment.Dnum;
                result.Equip_name = medical_Equipment.Equip_name;



                _DBcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        Bill Abstraction.IMedicalEquipRepo.getbyId(int Equipment_Id)
        {
            throw new NotImplementedException();
        }
    }
}