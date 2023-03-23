using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalStaff
{
    public class Doctor : Staff
    {
        public override string Username { get; set; }
        public override string Password { get; set; }
        public override string Name { get; set; }
        public override string Surname { get; set; }
        public override long IdNumber { get; set; }
        public string Specialty { get; set; }
        public override int PWZ  { get; set; }

        private static readonly Dictionary<string, Doctor> doctorList = new();

        //yönetici için geçerli olan çoğu şey burada da geçerli ekstra bir yetki yok
        public static List<Doctor> GetDoctorList => doctorList.Values.ToList();
        public static int GetDoctorCount  => doctorList.Count;
        public static string[] GetDoctorUsernameList => doctorList.Keys.ToArray();

        public Doctor(string username, string password, string name, string surname, long id, string specialty, int pwz)
        {
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
            IdNumber = id;
            Specialty = specialty;
            PWZ = pwz;

            try
            {
                doctorList.Add(username, this);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{ex.Source}] => {ex.Message}");
            }
        }

        public override void GetInfo(string username)
        {
            if (doctorList.ContainsKey(username))
            {
                doctorList.TryGetValue(username, out var doctor);

                Console.WriteLine("Doctor Name: " + doctor.Name);
                Console.WriteLine("Doctor Surname: " + doctor.Surname);
                Console.WriteLine("Doctor Id Number: " + doctor.IdNumber);
                Console.WriteLine("Doctor Specialty: " + doctor.Specialty);
                Console.WriteLine("Doctor PWZ: " + doctor.PWZ);
            }
        }

        public static Doctor GetDoctor(string username)
        {
            return doctorList[username];
        }
    }
}
