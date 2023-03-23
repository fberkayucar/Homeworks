using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HospitalStaff
{
    public struct Config
    {
        private const string managersPath = "TextFiles\\managers.txt";
        private const string doctorsPath = "TextFiles\\doctors.txt";
        private const string nursesPath = "TextFiles\\nurses.txt";
        private const string doctorsSentryPlanPath = "TextFiles\\doctorsSentryPlan.txt";
        private const string nursesSentryPlanPath = "TextFiles\\nursesSentryPlan.txt";


        //dosyaları oluşturuyoruz
        public static void CreateFile()
        {
            if (!Directory.Exists("TextFiles"))
            {
                Directory.CreateDirectory("TextFiles");
            }

            if (!File.Exists(managersPath))
            {
                File.Create(managersPath);
            }

            if (!File.Exists(doctorsPath))
            {
                File.Create(doctorsPath);
            }

            if (!File.Exists(nursesPath))
            {
                File.Create(nursesPath);
            }

            if (!File.Exists(doctorsSentryPlanPath))
            {
                File.Create(doctorsSentryPlanPath);
            }

            if (!File.Exists(nursesSentryPlanPath))
            {
                File.Create(nursesSentryPlanPath);
            }
        }

        public static void SaveManagers()
        {
            foreach (var manager in Manager.GetManagerList)
            {
                File.AppendAllText(managersPath, manager.Username + "{=}" +
                    manager.Password + "{=}"
                    + manager.Name + "{=}"
                    + manager.Surname + "{=}"
                    + manager.IdNumber + Environment.NewLine);
            }
        }

        

        //yöneticileri programa aktarıyoruz
        public static bool AddRegisteredManager()
        {
            if (File.ReadAllText(managersPath) == null)
            {
                Console.WriteLine("file is empty");
                return true;
            }

            var managerList = File.ReadAllLines(managersPath).ToList();

            foreach (var item in managerList)
            {
                if (item.Split("{=}").Length != 5)
                {
                    Console.WriteLine("The information in the file is not written correctly.");
                    return true;
                }
            }

            foreach (var item in managerList)
            {
                Console.WriteLine(item);
            }

            foreach (var item in managerList)
            {
                var manager = item.Split("{=}");
                int notAdded = 0;
                if (!long.TryParse(manager[4], out var id) || id.ToString().Length != 11)
                {
                    notAdded++;
                    continue;
                }

                if (notAdded != 0)
                {
                    Console.WriteLine($"Couldn't add {notAdded} managers");
                }

                _ = new Manager(manager[0], manager[1], manager[2], manager[3], long.Parse(manager[4]));                
            }
            return false;
        }

        public static void SaveDoctors()
        {
            foreach (var doctor in Doctor.GetDoctorList)
            {
                File.AppendAllText(doctorsPath, doctor.Username + "{=}" +
                    doctor.Password + "{=}"
                    + doctor.Name + "{=}"
                    + doctor.Surname + "{=}"
                    + doctor.IdNumber + "{=}"
                    + doctor.Specialty + "{=}"
                    + doctor.PWZ + Environment.NewLine);
            }
        }

        //doktorları programa aktarıyoruz
        public static bool AddRegisteredDoctor()
        {
            if (File.ReadAllText(doctorsPath) == null)
            {
                Console.WriteLine("file is empty");
                return true;
            }

            var doctorList = File.ReadAllLines(doctorsPath).ToList();

            foreach (var item in doctorList)
            {
                Console.WriteLine(item);
            }

            foreach (var item in doctorList)
            {
                if (item.Split("{=}").Length != 7)
                {
                    Console.WriteLine("The information in the file is not written correctly.");
                    return true;
                }

            }
            try
            {
                foreach (var item in doctorList)
                {
                    var doctor = item.Split("{=}");
                    int notAdded = 0;

                    if (!long.TryParse(doctor[4], out var id) || !int.TryParse(doctor[6], out var pwz) || id.ToString().Length != 11)
                    {
                        notAdded++;
                        continue;
                    }
                    

                    if (notAdded != 0)
                    {
                        Console.WriteLine($"Couldn't add {notAdded} doctors");
                    }

                    _ = new Doctor(doctor[0], doctor[1], doctor[2], doctor[3], long.Parse(doctor[4]), doctor[5], int.Parse(doctor[6]));
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{ex.Source}] => {ex.Message}");
                return true;
            }
            
        }

        public static void SaveNurses()
        {
            foreach (var Nurse in Nurse.GetNurseList)
            {
                File.AppendAllText(nursesPath, Nurse.Username + "{=}"
                    + Nurse.Password + "{=}"
                    + Nurse.Name + "{=}"
                    + Nurse.Surname + "{=}"
                    + Nurse.IdNumber + "{=}"
                    + Nurse.PossibleSpecialty + Environment.NewLine);
            }
        }

        //hemşireleri programa aktarıyoruz
        public static bool AddRegisteredNurse()
        {
            if (File.ReadAllText(nursesPath) == null)
            {
                Console.WriteLine("File is empty");
                return true;
            }

            var nurseList = File.ReadAllLines(nursesPath).ToList();

            foreach (var item in nurseList)
            {
                if (item.Split("{=}").Length != 6)
                {
                    Console.WriteLine("The information in the file is not written correctly.");
                    return true;
                }

            }

            foreach (var item in nurseList)
            {
                Console.WriteLine(item);
            }

            foreach (var item in nurseList)
            {
                var nurse = item.Split("{=}");
                int notAdded = 0;
                if (!long.TryParse(nurse[4], out var id) || id.ToString().Length != 11)
                {
                    notAdded++;
                    continue;
                }

                if (notAdded != 0)
                {
                    Console.WriteLine($"Couldn't add {notAdded} doctors");
                }

                _ = new Nurse(nurse[0], nurse[1], nurse[2], nurse[3], long.Parse(nurse[4]), nurse[5]);
            }
            return false;
        }

        public static void AddDoctorSentryPlan()
        {
            var doctorSentryList = File.ReadAllLines(doctorsSentryPlanPath);
            if (doctorSentryList.Length == 0)
            {
                Console.WriteLine("no registered doctor sentry plan");
                return;
            }

            if (Doctor.GetDoctorCount == 0)
            {
                Console.WriteLine("No registered doctors");
                return;
            }
            try
            {
                foreach (var doctor in doctorSentryList)
                {
                    List<Doctor> doctorList;
                    var info = doctor.Split(':');
                    var key = int.Parse(info[0]);
                    var count = int.Parse(info[^1]);
                    doctorList = new();
                    for (int i = 4; i < 4 + count; i++)
                    {                        
                        doctorList.Add(Doctor.GetDoctorList.First(x => x.IdNumber == long.Parse(info[i])));
                    }
                    Manager.doctorPlan.Add(key, doctorList);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"[{e.Source}] => {e.Message}");
            }
            
        }

        public static void AddNurseSentryPlan()
        {
            var nurseSentryList = File.ReadAllLines(nursesSentryPlanPath);
            if (nurseSentryList.Length == 0)
            {
                Console.WriteLine("no registered nurse sentry plan");
                return;
            }

            if (Doctor.GetDoctorCount == 0)
            {
                Console.WriteLine("No registered doctors");
                return;
            }
            try
            {
                foreach (var nurse in nurseSentryList)
                {
                    List<Doctor> nurseList;
                    var info = nurse.Split(':');
                    var key = int.Parse(info[0]);
                    var count = int.Parse(info[^1]);
                    nurseList = new();
                    for (int i = 4; i < 4 + count; i++)
                    {
                        nurseList.Add(Doctor.GetDoctorList.First(x => x.IdNumber == long.Parse(info[i])));
                    }
                    Manager.doctorPlan.Add(key, nurseList);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"[{e.Source}] => {e.Message}");
            }
        }

        //aylık planı dosyaya kaydediyoruz
        public static void SaveDoctorSentryPlan()
        {
            if (Manager.doctorPlan.Count == 0)
            {
                Console.WriteLine("Sentry plan not created");
                return;
            }

            foreach (var item in Manager.doctorPlan)
            {
                if (Manager.monthdays.TryGetValue(item.Key, out var day))
                {
                    var dayDoctorList = item.Value;
                    var dayDoctorNameList = string.Join(", ", dayDoctorList.Select(x => x.Name).ToList());
                    var dayDoctorSpecialtyList = string.Join(", ", dayDoctorList.Select(x => x.Specialty).ToList());
                    var dayDoctorIdList = string.Join(":", dayDoctorList.Select(x => x.IdNumber).ToList());

                    File.AppendAllText(doctorsSentryPlanPath, $"{item.Key}:{day}:{dayDoctorNameList}:{dayDoctorSpecialtyList}:{dayDoctorIdList}:{dayDoctorList.Count}" + Environment.NewLine);
                }
            }
        }
        //aylık planı dosyaya kaydediyoruz
        public static void SaveNurseSentryPlan()
        {
            if (Manager.nursePlan.Count == 0)
            {
                Console.WriteLine("Sentry plan not created");
                return;
            }

            foreach (var item in Manager.nursePlan)
            {
                if (Manager.monthdays.TryGetValue(item.Key, out var day))
                {
                    var dayNurseList = item.Value;
                    var dayNurseNameList = string.Join(", ", dayNurseList.Select(x => x.Name).ToList());
                    var dayNursePossibleSpecialtyList = string.Join(", ", dayNurseList.Select(x => x.PossibleSpecialty).ToList());
                    var dayNurseIdList = string.Join(":", dayNurseList.Select(x => x.IdNumber).ToList());

                    File.AppendAllText(nursesSentryPlanPath, $"{item.Key}:{day}:{dayNurseNameList}:{dayNursePossibleSpecialtyList}:{dayNurseIdList}:{dayNurseList.Count}" + Environment.NewLine);
                }
            }
        }
    }
}
