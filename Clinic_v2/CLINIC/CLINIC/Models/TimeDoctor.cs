using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINIC.Models
{
    public static class TimeDoc
    {
        public static int id_time_doc;
        public static int id_time;
        public static int day;
        public static int id_doc;
    }
    public class CLINICTimeDoctor
    {
        public int id_time_doc { get; set; }
        public int id_time { get; set; }
        public int day { get; set; }
        public int id_doc { get; set; }

        public CLINICTimeDoctor() { }
        public CLINICTimeDoctor(int id_time_doc, int id_time, int day, int id_doc)
        {
            this.id_time_doc = id_time_doc;
            TimeDoc.id_time_doc = id_time_doc;
            this.id_time = id_time;
            TimeDoc.id_time = id_time;
            this.day = day;
            TimeDoc.day = day;
            this.id_doc = id_doc;
            TimeDoc.id_doc = id_doc;
        }
        public CLINICTimeDoctor(int Id_us)
        {
            this.id_time_doc = id_time_doc;
            this.id_time = id_time;
            this.day = day;
            this.id_doc = id_doc;
        }
    }
}
