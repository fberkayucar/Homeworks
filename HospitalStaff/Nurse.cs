using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalStaff
{
    public class Nurse : Staff
    {
        public override string Username { get; set; }
        public override string Password { get; set; }
        public override string Name { get; set; }
        public override string Surname { get; set; }
        public override long IdNumber { get; set; }
        public string PossibleSpecialty { get; set; }

        private static readonly Dictionary<string, Nurse> nurseList = new();
        public static List<Nurse> GetNurseList => nurseList.Values.ToList();
        public static int GetNurseCount => nurseList.Count;
        public static List<string> GetNurseUsernameList => nurseList.Keys.ToList();

        //yönetici için geçerli olan çoğu şey burada da geçerli ekstra bir yetki yok

        public Nurse(string username, string password, string name, string surname, long id, string possibleSpecialty)
        {
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
            IdNumber = id;
            PossibleSpecialty = possibleSpecialty;

            try
            {
                nurseList.Add(username, this);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{ex.Source}] => {ex.Message}");
            }
        }

        public override void GetInfo(string username)
        {
            if (nurseList.ContainsKey(username))
            {
                nurseList.TryGetValue(username, out var nurse);

                Console.WriteLine("Nurse Name: " + nurse.Name);
                Console.WriteLine("Nurse Surname: " + nurse.Surname);
                Console.WriteLine("Nurse Id Number: " + nurse.IdNumber);
                Console.WriteLine("Nurse Possible Specialty: " + nurse.PossibleSpecialty);
                
            }
        }
        
        public static Nurse GetNurse(string username)
        {
            return nurseList[username];
        }
    }
}
