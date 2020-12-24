using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINIC.Models
{
    public class CLINICTimetable
    {
        public int id_timetable { get; set; }
        public int id_time_doc { get; set; }
        public int id_card { get; set; }

        public CLINICTimetable() {}
    }
}
