using System;
using System.Linq;
using System.Threading;

namespace HospitalStaff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //text doyalarını oluşturuyoruz

            _ = new Manager("admin", "1234", "fatih", "ayhan", 11111111111);

            Config.CreateFile();

            Console.WriteLine("files were created. If it already exists, do not take any action.\n" +
                "If the files do not exist, close the program and fill in the specified format.");

            Console.WriteLine("managers.txt => username{=}password{=}name...");
            Console.WriteLine("doctors.txt => username{=}password{=}name...");
            Console.WriteLine("nurses.txt => username{=}password{=}name...");

            Console.WriteLine("You can create the monthly sentry plan from within the program and save it to the file.");
            Thread.Sleep(5000);

            //kayıtlı olan kişileri programa aktarıyoruz

            Console.WriteLine("Would you like to get personnel information from the file? (y/n)");
            var result1 = Console.ReadLine();

            if (result1.ToLower() == "y")
            {
                if (Config.AddRegisteredManager()) { Thread.Sleep(TimeSpan.FromSeconds(60)); return; }
                if (Config.AddRegisteredDoctor()) { Thread.Sleep(TimeSpan.FromSeconds(60)); return; }
                if (Config.AddRegisteredNurse()) { Thread.Sleep(TimeSpan.FromSeconds(60)); return; }

                Console.WriteLine("successful");
            }
            else
            {
                Console.WriteLine("Personnel information not transferred");
            }            
            
            Console.WriteLine("Would you like to add the registered monthly sentry plans? (y/n)");
            var result = Console.ReadLine();

            //doktor planlarını programa aktarıyoruz
            if (result.ToLower() == "y")
            {
                Config.AddDoctorSentryPlan();
                Config.AddNurseSentryPlan();
            }
            else
                Console.WriteLine("not added");

            Thread.Sleep(5000);
            Console.Clear();

            Console.WriteLine("Hello and welcome to the hospital management system");
            Console.WriteLine("select a profile to login");
            Console.WriteLine("1-) Manager");
            Console.WriteLine("2-) Doctor");
            Console.WriteLine("3-) Nurse");
            
            comeOption:

            if (char.TryParse(Console.ReadLine(), out var option))
            {
                if (option == '1')
                {
                    //kullanıcı adı ve şifreyi alıyoruz
                    comeInfo:
                    Console.Write("Please enter username: ");
                    var username = Console.ReadLine();
                    Console.Write("Please enter password: ");
                    var password = Console.ReadLine();

                    //kullanıcı adı ve şifreyi kontrol ediyoruz
                    var managerList = Manager.GetManagerList;
                    int managerSuccessCounter = 0;
                    foreach (var manager in managerList)
                    {
                        if (username == manager.Username)
                        {
                            managerSuccessCounter++;
                        }
                        if (password == manager.Password)
                        {
                            managerSuccessCounter++;
                        }
                    }

                    //kullanıcı adı ve şifre yanlışsa tekrar kullanıcı adı ve şifre girmeye gönderiyoruz
                    if (managerSuccessCounter != 2)
                    {
                        Console.WriteLine("username or password is wrong");
                        Thread.Sleep(2000);
                        Console.Clear();
                        goto comeInfo;
                    }
                    else
                    {
                        //yöneticinin yapabileceği işlemleri sıralıyoruz
                        var manager = Manager.GetManager(username);
                        Console.WriteLine("Login successful");
                        comeManagerOpiton:
                        Console.WriteLine("select the action you want to do");
                        Console.WriteLine("1-) Add manager");
                        Console.WriteLine("2-) Add doctor");
                        Console.WriteLine("3-) Add nurse");
                        Console.WriteLine("4-) Create monthly sentry schedule for doctors and nurses");
                        Console.WriteLine("5-) Show monthly sentry schedule");
                        Console.WriteLine("6-) view the manager list");
                        Console.WriteLine("7-) view the doctor list");
                        Console.WriteLine("8-) view the nurse list");
                        Console.WriteLine("9-) save managers");
                        Console.WriteLine("10-) save doctors");
                        Console.WriteLine("11-) save nurses");

                        comeEnterManagerOption:

                        if (int.TryParse(Console.ReadLine(), out var managerOption))
                        {
                            switch(managerOption)
                            {
                                //1. seneçenek seçildiyse
                                case 1:

                                    //eklenecek yöneticinin bilgilerini giriyoruz
                                    Console.Write("enter the manager's username: ");
                                    var managerUsername = Console.ReadLine();
                                    Console.Write("enter the manager's password: ");
                                    var managerPassword = Console.ReadLine();
                                    Console.Write("enter the manager's name: ");
                                    var managerName = Console.ReadLine();
                                    Console.Write("enter the manager's surname: ");
                                    var managerSurname = Console.ReadLine();
                                    Console.Write("enter the manager's id: ");
                                    comeIdNumber:
                                    if (!long.TryParse(Console.ReadLine(), out var managerIdNumber))
                                    {
                                        Console.WriteLine("please enter a valid ID number");
                                        goto comeIdNumber;
                                    }
                                    if (managerIdNumber.ToString().Length != 11)
                                    {
                                        Console.WriteLine("please enter a valid ID number");
                                        goto comeIdNumber;
                                    }

                                    _ = new Manager(managerUsername, managerPassword, managerName, managerSurname, managerIdNumber);
                                    Console.WriteLine("Add manager successful");
                                    Thread.Sleep(2000);

                                    break;
                                case 2:

                                    //eklenecek doktorun bilgilerini giriyoruz
                                    Console.Write("enter the doctor's username: ");
                                    var doctorUsername = Console.ReadLine();
                                    Console.Write("enter the doctor's password: ");
                                    var doctorPassword = Console.ReadLine();
                                    Console.Write("enter the doctor's name: ");
                                    var doctorName = Console.ReadLine();
                                    Console.Write("enter the doctor's surname: ");
                                    var doctorSurname = Console.ReadLine();
                                    Console.WriteLine("enter the doctor's specialty");
                                    var doctorSpecialty = Console.ReadLine();
                                    Console.WriteLine("enter the doctor's PWZ number");

                                    comeDoctorPWZNumber:
                                                                            
                                    if (!int.TryParse(Console.ReadLine(), out var doctorPWZ))
                                    {
                                        Console.WriteLine("please enter a integer value");
                                        goto comeDoctorPWZNumber;
                                    }                                                          

                                    Console.Write("enter the doctor's id: ");

                                    comeDoctorIdNumber:
                                    if (!long.TryParse(Console.ReadLine(), out var doctorIdNumber))
                                    {
                                        Console.WriteLine("please enter a valid ID number");
                                        goto comeDoctorIdNumber;
                                    }
                                    if (doctorIdNumber.ToString().Length != 11)
                                    {
                                        Console.WriteLine("please enter a valid ID number");
                                        goto comeDoctorIdNumber;
                                    }

                                    _ = new Doctor(doctorUsername, doctorPassword, doctorName, doctorSurname, doctorIdNumber, doctorSpecialty, doctorPWZ);
                                    Console.WriteLine("Add doctor successfull");
                                    Thread.Sleep(2000);

                                    break;
                                case 3:

                                    //eklenecek hemşirenin bilgilerini giriyoruz
                                    Console.Write("enter the nurse's username: ");
                                    var nurseUsername = Console.ReadLine();
                                    Console.Write("enter the nurse's password: ");
                                    var nursePassword = Console.ReadLine();
                                    Console.Write("enter the nurse's name: ");
                                    var nurseName = Console.ReadLine();
                                    Console.Write("enter the nurse's surname: ");
                                    var nurseSurname = Console.ReadLine();
                                    Console.Write("enter the nurse's possible specialty: ");
                                    var nursePossibleSpecialty = Console.ReadLine();

                                    Console.Write("enter the doctor's id: ");

                                    comeNurseIdNumber:
                                    if (!long.TryParse(Console.ReadLine(), out var nurseIdNumber))
                                    {
                                        Console.WriteLine("please enter a valid ID number");
                                        goto comeNurseIdNumber;
                                    }
                                    if (nurseIdNumber.ToString().Length != 11)
                                    {
                                        Console.WriteLine("please enter a valid ID number");
                                        goto comeNurseIdNumber;
                                    }

                                    _ = new Nurse(nurseUsername, nursePassword, nurseName, nurseSurname, nurseIdNumber, nursePossibleSpecialty);
                                    Console.WriteLine("Add nurse successful");
                                    Thread.Sleep(2000);

                                    break;
                                case 4:

                                    if (Doctor.GetDoctorCount < 6 || Nurse.GetNurseCount < 6)
                                    {
                                        Console.WriteLine("not enough doctors and nurses");
                                        Thread.Sleep(5000);
                                        goto comeManagerOpiton;
                                    }
                                    //doktor ve hemşirelerin aylık nöbet planlarını oluşturuyoruz
                                    manager.CreateMonthlySentryPlan();
                                    Console.WriteLine("Sentry plan created");

                                    Console.WriteLine("Would you like to save? (y/n)");
                                    var sentrySaveResult = Console.ReadLine();
                                    if (sentrySaveResult.ToLower() == "y")
                                    {
                                        Config.SaveDoctorSentryPlan();
                                        Config.SaveNurseSentryPlan();
                                        Console.WriteLine("saved");
                                    }
                                    else
                                    {
                                        Console.WriteLine("not saved");
                                    }
                                    Thread.Sleep(2000);

                                    break;
                                case 5:

                                    if (Manager.doctorPlan.Count == 0 || Manager.nursePlan.Count == 0)
                                    {
                                        Console.WriteLine("Sentry plan not created");
                                        goto comeManagerOpiton;
                                    }

                                    Console.WriteLine("Doctors plan;");
                                    //aylık doktor nöbet planını gösteriyoruz
                                    foreach (var item in Manager.doctorPlan)
                                    {
                                        if (Manager.monthdays.TryGetValue(item.Key, out var day))
                                        {
                                            var dayDoctorList = item.Value;
                                            var dayDoctorNameList = string.Join(", ", dayDoctorList.Select(x => x.Name).ToList());
                                            var dayDoctorSpecialtyList = string.Join(", ", dayDoctorList.Select(x => x.Specialty).ToList());

                                            Console.WriteLine($"{item.Key} day of the month: {day}; {dayDoctorNameList}; sorted specialty {dayDoctorSpecialtyList}");
                                        }
                                    }

                                    Console.WriteLine("Nurses plan;");
                                    //aylık hemşire nöbet planını gösteriyoruz
                                    foreach (var item in Manager.nursePlan)
                                    {
                                        if(Manager.monthdays.TryGetValue(item.Key, out var day))
                                        {
                                            var dayNurseList = item.Value;
                                            var dayNurseNameList = string.Join(", ", dayNurseList.Select(x => x.Name).ToList());
                                            var dayNursePossibleSpecialtyList = string.Join(", ", dayNurseList.Select(x => x.PossibleSpecialty).ToList());

                                            Console.WriteLine($"{item.Key} day of the month: {day}; {dayNurseNameList}; sorted possible specialty {dayNursePossibleSpecialtyList}");
                                        }
                                    }

                                    Console.WriteLine("press a key to return to the interface");
                                    Console.ReadLine();
                                    Thread.Sleep(1000);

                                    break;
                                case 6:

                                    //yöneticilerin bilgilerini gösteriyoruz
                                    foreach (var managerInfo in Manager.GetManagerList)
                                    {
                                        Console.WriteLine($"Name: {managerInfo.Name}\n" +
                                            $"Surname: {managerInfo.Surname}\n" +
                                            $"Id number: {managerInfo.IdNumber}");
                                        Console.WriteLine();
                                    }

                                    Console.WriteLine("press any key to continue");
                                    Console.ReadLine();                                    

                                    break;
                                case 7:

                                    //doktorların bilgilerini gösteriyoruz
                                    foreach (var doctorInfo in Doctor.GetDoctorList)
                                    {
                                        Console.WriteLine($"Name: {doctorInfo.Name}\n" +
                                            $"Surname: {doctorInfo.Surname}\n" +
                                            $"Id number: {doctorInfo.IdNumber}\n" +
                                            $"Specialty: {doctorInfo.Specialty}\n" +
                                            $"PWZ: {doctorInfo.PWZ}");

                                        Console.WriteLine();
                                    }

                                    Console.WriteLine("press any key to continue");
                                    Console.ReadLine();

                                    break;
                                case 8:

                                    //hemşirelerin bilgilerini gösteriyoruz
                                    foreach (var nurseInfo in Nurse.GetNurseList)
                                    {
                                        Console.WriteLine($"Name: {nurseInfo.Name}\n" +
                                            $"Surname: {nurseInfo.Surname}\n" +
                                            $"Id number: {nurseInfo.IdNumber}\n" +
                                            $"Possible specialty: {nurseInfo.PossibleSpecialty}\n");
                                        Console.WriteLine();
                                    }

                                    Console.WriteLine("press any key to continue");
                                    Console.ReadLine();

                                    break;
                                case 9:

                                    //yöneticileri dosyaya kaydediyoruz ctrl + sol click yaparak fonksiyona ulaşabilirsiniz
                                    Config.SaveManagers();

                                    Console.WriteLine("save successful");
                                    Thread.Sleep(3000);

                                    break;
                                case 10:

                                    //doktorları dosyaya kaydediyoruz ctrl + sol click yaparak fonksiyona ulaşabilirsiniz
                                    Config.SaveDoctors();

                                    Console.WriteLine("save successful");
                                    Thread.Sleep(3000);

                                    break;
                                case 11:

                                    //hemşireleri dosyaya kaydediyoruz ctrl + sol click yaparak fonksiyona ulaşabilirsiniz
                                    Config.SaveNurses();

                                    Console.WriteLine("save successful");
                                    Thread.Sleep(3000);

                                    break;
                                default:
                                    Console.WriteLine("please make a valid choice");
                                    goto comeEnterManagerOption;
                            }

                            Console.Clear();
                            goto comeManagerOpiton;
                        }
                        else
                        {
                            Console.WriteLine("please make a valid choice");
                            goto comeEnterManagerOption;
                        }
                    }
                }
                else if (option == '2')
                {
                    comeInfo:
                    //kullanıcıdan kullanıcı adı ve şifre istiyoruz
                    Console.Write("Please enter username: ");
                    var username = Console.ReadLine();
                    Console.Write("Please enter password: ");
                    var password = Console.ReadLine();

                    int doctorSuccessCounter = 0;
                    //kullanıcı adı ve şifreyi bütün kayıtlarda kontrol ediyoruz
                    foreach (var item in Doctor.GetDoctorList)
                    {
                        if (item.Username == username)
                        {
                            doctorSuccessCounter++;
                        }
                        if (item.Password == password)
                        {
                            doctorSuccessCounter++;
                        }
                    }

                    //kullanıcı adı veya şifre hatalıysa bu bloğa giriyor
                    if (doctorSuccessCounter != 2)
                    {
                        Console.WriteLine("username or password is wrong");
                        Thread.Sleep(2000);
                        Console.Clear();
                        goto comeInfo;
                    }
                    //hatalı değilse bu bloğa giriyor
                    else
                    {
                        var doctor = Doctor.GetDoctor(username);
                        Console.WriteLine("select the action you want to do");
                        comeDoctorOption:
                        //doktorların yapabileceği seçenekler
                        Console.WriteLine("1-) view doctors information");
                        Console.WriteLine("2-) view nurses information");
                        Console.WriteLine("3-) view doctor sentry plan");
                        Console.WriteLine("4-) view nurse sentry plan");

                        comeEnterDoctorOption:

                        if (char.TryParse(Console.ReadLine(), out var doctorOption))
                        {
                            switch(doctorOption)
                            {
                                case '1':

                                    Console.WriteLine("---");
                                    //doktorların bilgilerini gösteriyoru
                                    foreach (var item in Doctor.GetDoctorList)
                                    {
                                        Console.WriteLine($"Name : {item.Name}\n" +
                                            $"Surname : {item.Surname}\n" +
                                            $"Id number : {item.IdNumber}\n" +
                                            $"Specialty : {item.Specialty}\n" +
                                            $"PWZ number : {item.PWZ}\n" +
                                            "---");
                                    }

                                    Console.WriteLine("press any key to continue");
                                    Console.ReadLine();                                    
                                    Thread.Sleep(2000);

                                    break;
                                case '2':

                                    Console.WriteLine("---");
                                    //hemşirelerin bilgilerini gösteriyoruz
                                    foreach (var item in Nurse.GetNurseList)
                                    {
                                        Console.WriteLine($"Name : {item.Name}\n" +
                                            $"Surname : {item.Surname}\n" +
                                            $"Id number : {item.IdNumber}\n" +
                                            $"Possible Specialty : {item.PossibleSpecialty}\n" +
                                            "---");
                                    }

                                    Console.WriteLine("press any ket to continue");
                                    Console.ReadLine();
                                    Thread.Sleep(2000);

                                    break;
                                case '3':
                                    //planı gösterilecek doktorun id numarasını istiyoruz
                                    Console.Write("please enter doctor's id number: ");
                                    
                                    comeDoctorEnterIdNumber:

                                    if (!long.TryParse(Console.ReadLine(), out var idNumber))
                                    {
                                        Console.WriteLine("please enter a valid id number");
                                        goto comeDoctorEnterIdNumber;
                                    }
                                    if (idNumber.ToString().Length != 11)
                                    {
                                        Console.WriteLine("please enter a valid id number");
                                        goto comeDoctorEnterIdNumber;
                                    }
                                    //planı gösterilecek doktoru alıyoruz 
                                    var infoDoctor = Doctor.GetDoctorList.FirstOrDefault(x => x.IdNumber == idNumber);

                                    foreach (var item in Manager.doctorPlan)
                                    {
                                        //doktorun aylık planını gösteriyoruz
                                        if (Manager.monthdays.TryGetValue(item.Key, out var day))
                                        {
                                            var writeDoctorPlan = item.Value.FirstOrDefault(x => x == infoDoctor);
                                            if (writeDoctorPlan != null)
                                            {
                                                Console.WriteLine($"{item.Key} day of the month: {day}; {writeDoctorPlan.Name} specialty: {writeDoctorPlan}");
                                            }
                                        }
                                    }

                                    break;
                                case '4':
                                    //aynı şekilde üstteki ile aynı işlemler bu sefer hemşire için geçerli
                                    Console.Write("please enter nurse's id number: ");

                                    comeNurseEnterIdNumber:

                                    if (!long.TryParse(Console.ReadLine(), out var nurseIdNumber))
                                    {
                                        Console.WriteLine("please enter a valid id number");
                                        goto comeNurseEnterIdNumber;
                                    }
                                    if (nurseIdNumber.ToString().Length != 11)
                                    {
                                        Console.WriteLine("please enter a valid id number");
                                        goto comeNurseEnterIdNumber;
                                    }

                                    var infoNurse = Nurse.GetNurseList.FirstOrDefault(x => x.IdNumber == nurseIdNumber);

                                    foreach (var item in Manager.nursePlan)
                                    {
                                        if (Manager.monthdays.TryGetValue(item.Key, out var day))
                                        {
                                            var writeNursePlan = item.Value.FirstOrDefault(x => x == infoNurse);
                                            if (writeNursePlan != null)
                                            {
                                                Console.WriteLine($"{item.Key} day of the month: {day}; {writeNursePlan.Name} specialty: {writeNursePlan}");
                                            }
                                        }
                                    }

                                    break;
                                default:
                                    Console.WriteLine("please make a valid choice");
                                    goto comeEnterDoctorOption;
                            }

                            Console.Clear();
                            goto comeDoctorOption;
                        }
                        else
                        {
                            Console.WriteLine("please make a valid choice");
                            goto comeDoctorOption;
                        }
                    }
                }
                else if (option == '3')
                {
                    comeInfo:
                    //doktor olarak giriş yaptığımızda geçerli olan herşey burada hemşire için de geçerli
                    Console.Write("Please enter username: ");
                    var username = Console.ReadLine();
                    Console.Write("Please enter password: ");
                    var password = Console.ReadLine();

                    int doctorSuccessCounter = 0;

                    foreach (var item in Nurse.GetNurseList)
                    {
                        if (item.Username == username)
                        {
                            doctorSuccessCounter++;
                        }
                        if (item.Password == password)
                        {
                            doctorSuccessCounter++;
                        }
                    }

                    if (doctorSuccessCounter != 2)
                    {
                        Console.WriteLine("username or password is wrong");
                        Thread.Sleep(2000);
                        Console.Clear();
                        goto comeInfo;
                    }
                    else
                    {
                        var nurse = Nurse.GetNurse(username);
                        Console.WriteLine("select the action you want to do");
                        comeDoctorOption:
                        Console.WriteLine("1-) view doctors information");
                        Console.WriteLine("2-) view nurses information");
                        Console.WriteLine("3-) view doctor sentry plan");
                        Console.WriteLine("4-) view nurse sentry plan");

                        comeEnterDoctorOption:

                        if (char.TryParse(Console.ReadLine(), out var doctorOption))
                        {
                            switch (doctorOption)
                            {
                                case '1':

                                    Console.WriteLine("---");

                                    foreach (var item in Doctor.GetDoctorList)
                                    {
                                        Console.WriteLine($"Name : {item.Name}\n" +
                                            $"Surname : {item.Surname}\n" +
                                            $"Id number : {item.IdNumber}\n" +
                                            $"Specialty : {item.Specialty}\n" +
                                            $"PWZ number : {item.PWZ}\n" +
                                            "---");
                                    }

                                    Console.WriteLine("press any key to continue");
                                    Console.ReadLine();
                                    Thread.Sleep(2000);

                                    break;
                                case '2':

                                    Console.WriteLine("---");

                                    foreach (var item in Nurse.GetNurseList)
                                    {
                                        Console.WriteLine($"Name : {item.Name}\n" +
                                            $"Surname : {item.Surname}\n" +
                                            $"Id number : {item.IdNumber}\n" +
                                            $"Possible Specialty : {item.PossibleSpecialty}\n" +
                                            "---");
                                    }

                                    Console.WriteLine("press any ket to continue");
                                    Console.ReadLine();
                                    Thread.Sleep(2000);

                                    break;
                                case '3':

                                    Console.Write("please enter doctor's id number: ");

                                comeDoctorEnterIdNumber:

                                    if (!long.TryParse(Console.ReadLine(), out var idNumber))
                                    {
                                        Console.WriteLine("please enter a valid id number");
                                        goto comeDoctorEnterIdNumber;
                                    }
                                    if (idNumber.ToString().Length != 11)
                                    {
                                        Console.WriteLine("please enter a valid id number");
                                        goto comeDoctorEnterIdNumber;
                                    }

                                    var infoDoctor = Doctor.GetDoctorList.FirstOrDefault(x => x.IdNumber == idNumber);

                                    foreach (var item in Manager.doctorPlan)
                                    {
                                        if (Manager.monthdays.TryGetValue(item.Key, out var day))
                                        {
                                            var writeDoctorPlan = item.Value.FirstOrDefault(x => x == infoDoctor);
                                            if (writeDoctorPlan != null)
                                            {
                                                Console.WriteLine($"{item.Key} day of the month: {day}; {writeDoctorPlan.Name} specialty: {writeDoctorPlan}");
                                            }
                                        }
                                    }

                                    break;
                                case '4':

                                    Console.Write("please enter nurse's id number: ");

                                comeNurseEnterIdNumber:

                                    if (!long.TryParse(Console.ReadLine(), out var nurseIdNumber))
                                    {
                                        Console.WriteLine("please enter a valid id number");
                                        goto comeNurseEnterIdNumber;
                                    }
                                    if (nurseIdNumber.ToString().Length != 11)
                                    {
                                        Console.WriteLine("please enter a valid id number");
                                        goto comeNurseEnterIdNumber;
                                    }

                                    var infoNurse = Nurse.GetNurseList.FirstOrDefault(x => x.IdNumber == nurseIdNumber);

                                    foreach (var item in Manager.nursePlan)
                                    {
                                        if (Manager.monthdays.TryGetValue(item.Key, out var day))
                                        {
                                            var writeNursePlan = item.Value.FirstOrDefault(x => x == infoNurse);
                                            if (writeNursePlan != null)
                                            {
                                                Console.WriteLine($"{item.Key} day of the month: {day}; {writeNursePlan.Name} specialty: {writeNursePlan}");
                                            }
                                        }
                                    }

                                    break;
                                default:
                                    Console.WriteLine("please make a valid choice");
                                    goto comeEnterDoctorOption;
                            }

                            Console.Clear();
                            goto comeDoctorOption;
                        }
                        else
                        {
                            Console.WriteLine("please make a valid choice");
                            goto comeDoctorOption;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("please make a valid choice");
                    goto comeOption;
                }
            }
            else
            {
                Console.WriteLine("please make a valid choice");
                goto comeOption;
            }

            
        }
    }
}
//Bir tane administrator class'ımız olsun ve onu abstract yapalım.
//Ordan miras alarak manager, doctor ve nurse oluşturalım ve özelliklerini girelim

/*
Projenin amacı hastane için bir idari sistem oluşturmaktır. 
sistem hastane çalışanlarının kayıtlarını tutması gerekiyor. 
Her çalışanın bir adı, soyadı vardır ve kimlik numarası ile kullanıcı adı ve şifre. 
Sistem şunları içerir:
aşağıdaki kullanıcı türleri: doktor, hemşire, yönetici.
Doktor, her kullanıcının standart verilerinin yanı sıra bir uzmanlığa da sahiptir (kardiyolog,
ürolog, nörolog veya laringolog) ve PWZ numarası.
Doktorlar ve hemşireler de bir kişinin ayda en fazla 10 nöbetçi görevi olabileceği ve her gün yapamayacakları varsayılarak, 
24 saat nöbetçi görevlerinin listesi. Ayrıca tek doktor
Belirli bir uzmanlığın belirli bir günde görev almasına izin verilir (örneğin, bir kardiyolog,
ürolog ve nörolog belirli bir günde görevde olabilir, ancak iki kardiyolog değil).
Sistemi başlattıktan sonra kullanıcı adı ve şifre istiyor. 
Giriş yaptıktan sonra, doktorlar ve hemşireler söz konusu olduğunda, 
yalnızca tüm doktor ve hemşirelerin bir listesini görüntülemek mümkündür.
(isim, iş + olası uzmanlık) ve belirtilen kişinin görev programı verilen ay.

Giriş yaptıktan sonra, yönetici listedeki tüm kullanıcıları görebilir. Ayrıca verilerini düzenleyebilir
her birini (programla birlikte) ve yeni kullanıcılar (yöneticiler dahil) ekleyin
sistem.

Programın sonunda tüm çalışan listesi seri hale getirilerek bir dosyaya kaydedilir ve
başlangıçta - okuyun ve seri durumdan çıkarın.
Proje, nesne yönelimli programlama paradigmasını takip etmeli ve
kalıtım, kapsülleme, soyutlama ve polimorfizm. Ayrıca dayanıklı olmalı
hatalara (hem kullanıcı hem de sistem hataları, örneğin eksik dosya).
 */