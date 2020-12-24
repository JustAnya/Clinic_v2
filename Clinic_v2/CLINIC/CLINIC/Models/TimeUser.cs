using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINIC.Models
{
    public static class TU
    {
        public static int id;
        public static string alltime;
        public static string time;
        public static int day;
    }

    public class CLINICTimeUser
    {
        public int id { get; set; }
        public string alltime { get; set; }
        public string time { get; set; }

        public CLINICTimeUser() { }
        public CLINICTimeUser(int id, string alltime, string time)
        {
            this.id = id;
            TU.id = id;
            this.alltime = alltime;
            TU.alltime = alltime;
            this.time = time;
            TU.time = time;
        }
    }
}
