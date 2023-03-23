using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace HospitalStaff
{
    public class Manager : Staff
    {
        public override string Username { get;  set; }
        public override string Password { get; set; }
        public override string Name { get; set; }
        public override string Surname { get; set; }
        public override long IdNumber { get; set; }

        private static readonly Dictionary<string, Manager> managerList = new();

        //kamsülleme kullanarak yöneticiler ile ilgili sadece belirli bilgilere ulaşılmasını sağlıyoruz ve değişikliğe izin vermiyoruz
        public static Manager[] GetManagerList => managerList.Values.ToArray();
        public static int GetManagerCount => managerList.Count;
        public static string[] GetManagerUsernameList => managerList.Keys.ToArray();

        //ne zaman yeni bir yönetici nesnesi oluşturulsa onu bu method ile yönetici listesine aktarıyoruz
        public Manager(string username, string password, string name, string surname, long idNumber)
        {
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
            IdNumber = idNumber;

            try
            {
                managerList.Add(Username, this);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{ex.Source}] => {ex.Message}");
            }
        }

        //sadece bir yönetici getirmek istediğimizde kullanıyoruz
        public static Manager GetManager(string username)
        {
            return managerList[username];
        }

        //yönetici eklemek için gerekli kontroller
        public void AddManager(string userName, string password, string name, string surName, long id)
        {
            foreach (var item in managerList.Values)
            {
                if (item.IdNumber == id)
                {
                    Console.WriteLine("ID number cannot be the same");
                    return;
                }
            }

            foreach (var item in managerList.Keys)
            {
                if (item == userName)
                {
                    Console.WriteLine("Username cannot be the same");
                    return;
                }
            }

            _ = new Manager(userName, password, name, surName, id);
        }        

        //yönetici bilgilerini getiren fonksiyon
        public override void GetInfo(string userName)
        {
            if (managerList.ContainsKey(userName))
            {
                managerList.TryGetValue(userName, out var manager);

                Console.WriteLine("Manager name: " + manager.Name);
                Console.WriteLine("Manager surname: " + manager.Surname);
                Console.WriteLine("Manager id number: " + manager.IdNumber);
            }
        }

        //doktor ekliyoruz
        public void AddDoctor(string username, string password, string name, string surname, long id, string specialty, int pwz)
        {
            foreach (var item in Doctor.GetDoctorList)
            {
                if (item.IdNumber == id)
                {
                    Console.WriteLine("ID number cannot be the same");
                    return;
                }
            }

            foreach (var item in Doctor.GetDoctorUsernameList)
            {
                if (item == username)
                {
                    Console.WriteLine("Username cannot be the same");
                    return;
                }
            }

            _ = new Doctor(username, password, name, surname, id, specialty, pwz);
        }

        //hemşire ekliyoruz
        public void AddNurse(string username, string password, string name, string surname, long id, string possibleSpecialty)
        {
            foreach (var item in Nurse.GetNurseList)
            {
                if (item.IdNumber == id)
                {
                    Console.WriteLine("ID number cannot be the same");
                    return;
                }
            }

            foreach (var item in Nurse.GetNurseUsernameList)
            {
                if (item == username)
                {
                    Console.WriteLine("Username cannot be the same");
                    return;
                }
            }

            _ = new Nurse(username, password, name, surname, id, possibleSpecialty);
        }

        readonly Random n = new();

        

        public static readonly Dictionary<int, string> monthdays = new();
        public static readonly SortedList<int, List<Doctor>> doctorPlan = new();
        public static readonly SortedList<int, List<Nurse>> nursePlan = new();

        //ayın hergününe denk gelen günleri burada denk getiriyoruz
        //ayın pazartesiden başladığını var sayarak günleri 30 gün boyunca döngüye alıyoruz
        private void AddMonthDays()
        {
            int dayCounter = 0;
            string[] days = new string[] { "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday" };

            for (int i = 1; i <= 30; i++)
            {
                monthdays.Add(i, days[dayCounter]);
                dayCounter++;

                dayCounter = dayCounter == days.Length ? 0 : dayCounter++;
            }
        }

        //doktorların nöbet planını oluşturuyoruz
        private void MonthlySentryDoctorPlan()
        {            
            var doctorList = Doctor.GetDoctorList;

            List<Doctor> plansDoctor;

            foreach (var doctor in doctorList)
            {
                for (int j = 0; j < 10;)
                {
                    int day = n.Next(0, 31);
                    if (doctorPlan.ContainsKey(day))
                    {
                        if (doctorPlan.TryGetValue(day, out var list))
                        {
                            if (list.Contains(doctor))
                                continue;
                        }

                        if (doctorPlan.TryGetValue(day, out var doctors))
                        {
                            bool specialty = false;

                            foreach (var item in doctors)
                            {
                                if (item.Specialty == doctor.Specialty)
                                {
                                    specialty = true;
                                    break;
                                }
                            }
                            if (!specialty)
                            {
                                doctors.Add(doctor);
                                doctorPlan[day] = doctors;
                                j++;
                            }
                        }                        
                    }                    
                    else if (!doctorPlan.ContainsKey(day + 1) && !doctorPlan.ContainsKey(day - 1))
                    {
                        plansDoctor = new();
                        plansDoctor.Add(doctor);
                        doctorPlan.Add(day, plansDoctor);
                        j++;
                    }
                }
            }
            
        }
        //hemşirelerin nöbet planını oluşturuyoruz
        private void MonthlySentryNursePlan()
        {
            var nurseList = Nurse.GetNurseList;

            List<Nurse> plansNurse;

            foreach (var nurse in nurseList)
            {
                for (int j = 0; j < 10;)
                {
                    int day = n.Next(0, 31);
                    if (nursePlan.ContainsKey(day))
                    {
                        if (nursePlan.TryGetValue(day, out var list))
                        {
                            if (list.Contains(nurse))
                                continue;
                        }

                        if (nursePlan.TryGetValue(day, out var nurses))
                        {
                            bool specialty = false;

                            foreach (var item in nurses)
                            {
                                if (item.PossibleSpecialty == nurse.PossibleSpecialty)
                                {
                                    specialty = true;
                                    break;
                                }
                            }
                            if (!specialty)
                            {
                                nurses.Add(nurse);
                                nursePlan[day] = nurses;
                                j++;
                            }
                        }
                    }
                    else if (!doctorPlan.ContainsKey(day + 1) && !doctorPlan.ContainsKey(day - 1))
                    {
                        plansNurse = new();
                        plansNurse.Add(nurse);
                        nursePlan.Add(day, plansNurse);
                        j++;
                    }
                }
            }

        }

        //planlamak için gerekli olan methodları tek tek çağırmak yerine burada tek method ile hepsini çağırabilmek için oluşturlmuş bir fonksiyon
        public void CreateMonthlySentryPlan()
        {
            AddMonthDays();
            MonthlySentryDoctorPlan();
            MonthlySentryNursePlan();
        }
    }
}
