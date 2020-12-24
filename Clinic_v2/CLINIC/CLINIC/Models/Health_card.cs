using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINIC.Models
{
        public class CLINICHealth_card
        {
        public int id_card { get; set; }
        public int id_us { get; set; }
        public int id_height { get; set; }
        public int id_weight { get; set; }
        public string chronic_disease { get; set; }
        public string test_result { get; set; }
        public string diagnosis { get; set; }
        public string treatment { get; set; }

        public CLINICHealth_card() { }

        public override string ToString()
        {
            return chronic_disease;


        }
    }
}
