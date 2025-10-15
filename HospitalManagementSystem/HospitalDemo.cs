namespace HospitalManagementSystem
{
    public class HospitalDemo 
    {
        public void Run() 
        {
            Console.WriteLine("=== СИСТЕМА УПРАВЛІННЯ ЛІКАРНЕЮ ===\n");
            
            Hospital hospital = new Hospital();
           
            hospital.AddDoctor(new Doctor(1, "Іван Іваненко", "Травматолог"));
            hospital.AddDoctor(new Doctor(2, "Олена Петрівна", "Хірург"));
            hospital.AddDoctor(new Doctor(3, "Сергій Асютин", "Кардіолог"));

            hospital.RegisterPatient(new Patient(1, "Іван Бількевич", 31));
            hospital.RegisterPatient(new Patient(2, "Данилко Когут", 17));
            hospital.RegisterPatient(new Patient(3, "Богдан Демчук", 19));
            hospital.RegisterPatient(new Patient(4, "Назар Харитончук", 27));
            
            hospital.CreateRoom(new HospitalRoom(101,2));
            hospital.CreateRoom(new HospitalRoom(103,4));
            hospital.CreateRoom(new HospitalRoom(102,5));
            
            hospital.HospitalizePatient(1,102);
            hospital.HospitalizePatient(2,101);
            hospital.HospitalizePatient(3,103);
            hospital.HospitalizePatient(4,103);
            
            hospital.AddMedicalRecord(new MedicalRecord(hospital.Patients[0], hospital.Doctors[0], DateTime.Now.AddDays(-10), "Призначено лікування"));
            hospital.AddMedicalRecord(new MedicalRecord(hospital.Patients[1], hospital.Doctors[1], DateTime.Now.AddDays(-5), "Операція успішна"));
            hospital.AddMedicalRecord(new MedicalRecord(hospital.Patients[2], hospital.Doctors[2], DateTime.Now.AddDays(-3), "Проведено обстеження"));
            hospital.AddMedicalRecord(new MedicalRecord(hospital.Patients[3], hospital.Doctors[1], DateTime.Now.AddDays(-7), "Реабілітація"));
            
            Console.WriteLine("\n--- ІСТОРІЯ ПАЦІЄНТА ---");
            var history = hospital.GetPatientHistory(1);  
            foreach (var record in history)
            {
                Console.WriteLine($"  Дата: {record.Date.ToShortDateString()}");
                Console.WriteLine($"  Лікар: {record.Doctor.Name}");
                Console.WriteLine($"  Опис: {record.Description}\n");
            }
            
            Console.WriteLine(hospital.GetStatistics());

        }   
    }    
}
