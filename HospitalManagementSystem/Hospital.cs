namespace HospitalManagementSystem
{
    public class Hospital 
    {
        public List<Doctor> Doctors {get; set;} 
        public List<Patient> Patients {get; set;} 
        public List<HospitalRoom> Rooms {get; set;} 
        public List<MedicalRecord> Records {get; set;} 
        
        public Hospital()
        {
            Doctors = new List<Doctor>();
            Patients = new List<Patient>();
            Rooms = new List<HospitalRoom>();
            Records = new List<MedicalRecord>();
        }
        
        public void AddDoctor(Doctor doctor)
        {
            Doctors.Add(doctor);
            Console.WriteLine($"Лікар {doctor.Name} ({doctor.Specialization}) доданий до системи");
        }
        public void RegisterPatient(Patient patient)
        {
            Patients.Add(patient);
            Console.WriteLine($"Пацієнт {patient.Name}, {patient.Age} років, зареєстрований");
        }

        public void CreateRoom(HospitalRoom room)
        {
            Rooms.Add(room);
            Console.WriteLine($"Палата №{room.RoomNumber} створена (місткість: {room.Capacity})");
        }

        public void HospitalizePatient(int patientId, int roomNumber)
        {
            if (!Patients.Exists(p => p.Id == patientId))
            {
                Console.WriteLine($"Пацієнт з ID {patientId} не знайдений!");
                return;
            }
            
            if (!Rooms.Exists(r => r.RoomNumber == roomNumber))
            {
                Console.WriteLine($"Палата №{roomNumber} не знайдена!");
                return;
            }
            HospitalRoom room = Rooms.Find(r => r.RoomNumber == roomNumber);
            Patient patient = Patients.Find(p => p.Id == patientId);
            
            room.AddPatient(patient); 
        }
        
        public void AddMedicalRecord(MedicalRecord record)
        {
            Records.Add(record);
            Console.WriteLine($"Медичний запис створено: {record.Patient.Name} -> {record.Doctor.Name}\n");
        }
        
        public List<MedicalRecord> GetPatientHistory(int patientId)
        {
            List<MedicalRecord> history = Records.FindAll(record =>record.Patient.Id == patientId);
            return history;
        }
        
        public string GetStatistics()
        {
            int totalPatientsInRooms = 0; 
            
            foreach (var room in Rooms) 
            {
                totalPatientsInRooms += room.Patients.Count;
            }
            
            string stats = $"\n=== СТАТИСТИКА ЛІКАРНІ ===\n" +
                           $"Кількість лікарів: {Doctors.Count}\n" +
                           $"Кількість зареєстрованих пацієнтів: {Patients.Count}\n" +
                           $"Кількість палат: {Rooms.Count}\n" +
                           $"Кількість пацієнтів у палатах: {totalPatientsInRooms}\n" +
                           $"Кількість медичних записів: {Records.Count}\n";
            return stats;
        }
    }    
}
