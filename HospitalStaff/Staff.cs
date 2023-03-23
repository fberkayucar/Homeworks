using System.IO;
using System.Collections.Generic;
using System.Text;
using System;

namespace HospitalStaff
{
    abstract public class Staff
    {
        //genel olarak personellerin ortak özellikleri burada soyut olarak tanımlıyoruz
        public abstract string Username { get; set; }
        public abstract string Password { get; set; }
        public abstract string Name { get; set; }
        public abstract string Surname { get; set; }
        public abstract long IdNumber { get; set; }

        //sanal olarak tanımlanmış
        public virtual int PWZ { get; set; }

        public abstract void GetInfo(string userName);         
            
    }
}
