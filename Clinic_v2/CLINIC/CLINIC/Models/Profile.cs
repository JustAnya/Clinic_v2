using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINIC.Models
{

    public static class PROF
    {
        public static int id_us;
        public static string init;
        public static int id_prof;
        public static string img;
        public static string name;
        public static string surname;
        public static int age;
    }
    public class CLINICProf
    {
        public int id_profile { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public string phone_numb { get; set; }
        public string address { get; set; }
        public int id_us { get; set; }
        public string img { get; set; }
        public string init { get; set; }

        public CLINICProf() { }
        public CLINICProf(int id_profile, string name, string surname, int age, string phone_numb, string address, int id_us, string img, string init )
        {
            this.id_profile = id_profile;
            PROF.id_prof = id_profile;
            this.name = name;
            PROF.name = name;
            this.surname = surname;
            PROF.surname = surname;
            this.age = age;
            PROF.age = age;
            this.phone_numb = phone_numb;
            this.address = address;
            this.id_us = id_us;
            PROF.id_us = id_us;
            this.img = img;
            PROF.img = img;
            this.init = init;
            PROF.init = init;
        }
        public CLINICProf(int Id_us)
        {
            this.init = init;
            this.id_profile = id_profile;
            this.img = img;
        }
    }
}