using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory54.Models
{
    public class ShiftSchedule
    {
        public int ShiftID { get; set; }
        public int EmpID { get; set; }
        public Nullable<int>  StartTime { get; set; }
        public Nullable<int>  EndTime { get; set; }

        public DateTime Date { get; set; }


    }
}