using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Standard.Models.Enum;

namespace Standard.Models.Data
{
    public class Table { }

    public class Employee
    {
        public UnitDivision _unitDivision;

        public string Id { get; set; }
        public int Number { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public UnitDivision UnitDivision
        {
            get { return UnitDivision; }
            set { UnitDivision = value; }
        }
    }
}
