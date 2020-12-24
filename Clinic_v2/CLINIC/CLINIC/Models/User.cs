using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINIC.Models
{
    public static class MY
    {
        public static int id_us;
        public static int access;
    }

    public class CLINICUser
    {
        public int Id_us { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Access{ get; set; }

        public CLINICUser() { }
        public CLINICUser(int access, string Login, string Password)
        {
            this.Access = access;
            MY.access = access;
            this.Login = Login;
            MY.id_us = Id_us;
            this.Id_us = Id_us;
            this.Password = Password;
        }
        public CLINICUser(int Id_us)
        {
            this.Id_us = Id_us;
            this.Access = Access;
        }

      
        //public override string ToString()
        //{
        //    return Login;
        //}
    }
}
