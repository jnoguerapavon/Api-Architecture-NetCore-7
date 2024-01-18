using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Entities
{
    public  class employee : BaseEntity
    {

      
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public DateTime dob { get; set; }

        public string gender { get; set; }

        public string education { get; set; }

        public string company { get; set; }

        public int experience { get; set; }

        public int package { get; set; }

        public CatCompany CatCompany { get; set; }

        public int CatCompanyId { get; set; }

        public CatEducation CatEducation { get; set; }

        public int CatEducationId { get; set; }


    }
}
