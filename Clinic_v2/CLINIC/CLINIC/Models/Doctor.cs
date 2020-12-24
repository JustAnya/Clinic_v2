using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINIC.Models
{
    public static class DOC
    {
        public static int id_doc;
        public static int id_spec;
        public static string init_doc;
    }

    public class CLINICDoctor
    {
        public int id_doc {get;set;}
        public string about_doc { get; set; }
        public int id_spec { get; set; }
        public int id_us { get; set; }
        public string init_doc { get; set; }

        public CLINICDoctor(){ }

        public CLINICDoctor(string init_doc)
        {
            this.init_doc = init_doc;
        }

        public CLINICDoctor(int id_spec, int id_doc,int id_us, string init_doc, string about_doc)
        {
            this.id_spec = id_spec;
            DOC.id_spec = id_spec;
            this.id_doc = id_doc;
            DOC.id_doc = id_doc;
            this.init_doc = init_doc;
            DOC.init_doc = init_doc;
            this.id_us = id_us;
            this.about_doc = about_doc;
        }
        //public CLINICDoctor(int Id_us)
        //{
        //    this.Id_us = Id_us;
        //    this.Access = Access;
        //}

        public override string ToString()
        {
            return about_doc;
        }

        //public override string ToString()
        //{
        //    return init_doc;
        //}

    }
}
