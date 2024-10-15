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
    public  class MedicalEquipmentRepo:IMedicalEquipmentRepo
    {
        private readonly ApplicationDBcontext _DBcontext;

        public MedicalEquipmentRepo(ApplicationDBcontext DBcontext)
        {
            _DBcontext = DBcontext;
        }

        public bool add(Medical_equipment medical_Equipment)
        {
            try
            {
                _DBcontext.medical_Equipment.Add(medical_Equipment);
                _DBcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding equipment: {ex.Message}");
                return false;
            }
        }


        public bool delete(int id)
        {
            try
            {
                var result = _DBcontext.medical_Equipment
                    .FirstOrDefault(p => p.Equipment_Id == id);

                if (result != null)
                {
                    result.IsDeleted = true;
                    _DBcontext.SaveChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine("Equipment not found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting equipment: {ex.Message}");
                return false;
            }
        }

        public List<Medical_equipment> getAll()
        {
            try
            {
                return _DBcontext.medical_Equipment
                    .Where(a => a.IsDeleted != true)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving equipment list: {ex.Message}");
                return null;
            }
        }


        public Medical_equipment getbyId(int Equipment_Id)
        {
            try
            {
                return _DBcontext.medical_Equipment
                    .FirstOrDefault(a => a.Equipment_Id == Equipment_Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving equipment by ID: {ex.Message}");
                return null;
            }
        }

        public bool update(Medical_equipment medical_Equipment)
        {
            try
            {
                var result = _DBcontext.medical_Equipment
                    .FirstOrDefault(p => p.Equipment_Id == medical_Equipment.Equipment_Id);

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
                    Console.WriteLine("Equipment not found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating equipment: {ex.Message}");
                return false;
            }
        }

    }

}

