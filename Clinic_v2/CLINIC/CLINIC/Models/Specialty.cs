using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINIC.Models
{

    public static class Spec
    {
        public static string about_spec;
        public static int id_spec_doc;
    }
    public class CLINICSpecialty
    {
        public int id_spec { get; set; }
        public string name_spec { get; set; }
        public string about_spec { get; set; }
      

        public CLINICSpecialty() { }
        public CLINICSpecialty(int id_spec, string name_spec, string about_spec)
        {
            this.id_spec = id_spec;
            Spec.id_spec_doc = id_spec;
            this.about_spec = about_spec;
            Spec.about_spec = about_spec;
            this.name_spec = name_spec;
        }
        public CLINICSpecialty(int Id_us)
        {
            this.id_spec = id_spec;
            this.about_spec = about_spec;
        }
        public CLINICSpecialty(string ab)
        {
            this.about_spec = about_spec;
        }
        public override string ToString()
        {
            return about_spec;
        }
    }
}
