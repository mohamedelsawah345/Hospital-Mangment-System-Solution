﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.View_model.DepartmentVM
{
    public class GetDepartmentByIdVM
    {
        public int? Dnum { get; set; }
        public string? Dname { get; set; }
        public string? Location { get; set; }
        public List<string>? DoctorName { get; set; }
        public List<string>? NurseName { get; set; }
    }
}
