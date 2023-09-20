using System;

namespace AnarchyInHospital
{
    class Program  
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            hospital.Work();
        }
    }

    class Hospital
    {
        private List<Patient> _patients = new List<Patient>();

        public Hospital()
        {
            _patients.Add(new Patient("Петров Иван Петрович", 12, "Ангина"));
            _patients.Add(new Patient("Седов Игорь Алексеевич", 14, "Корь"));
            _patients.Add(new Patient("Рыбаков Петр Станиславович", 11, "ОРВИ"));
            _patients.Add(new Patient("Сыркин Василий Тигранович", 10, "ОРВИ"));
            _patients.Add(new Patient("Таров Тимур Хакирович", 12, "Коронавирус"));
            _patients.Add(new Patient("Саратов Дмитрий Дмитриевич", 13, "ТИФ"));
            _patients.Add(new Patient("Иванов Сергей Никитович", 15, "Корь"));
            _patients.Add(new Patient("Табинов Лев Васильевич", 12, "Ангина"));
            _patients.Add(new Patient("Черкассов Данил Петрович", 13, "Коронавирус"));
            _patients.Add(new Patient("Бакин Никита Владиславович", 11, "ТИФ"));
            _patients.Add(new Patient("Битаркин Ашот Башотович", 10, "ОРВИ"));
            _patients.Add(new Patient("Тарелков Тигран Тигранович", 14, "Ангина"));
            _patients.Add(new Patient("Бавитаров Айдар Шакирович", 13, "Коронавирус"));
            _patients.Add(new Patient("Абакин Максим Васильевич", 14, "Тиф"));
        }

        public void Work()
        {
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Детская больница имени Пирагова №1");
                Console.WriteLine("\nГлавное меню:\n1 - Отсортировать всех больных по фио;\n2 - Отсортировать всех больных по возрасту;\n" +
                    "3 - Вывести больных с определенным заболеванием;\n4 - Выход\n");
                Console.Write("Введите команду: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowSortToInicialy();
                        break;
                    case "2":
                        ShowSortToAge();
                        break;
                    case "3":
                        FindToDiseasePatient();
                        break;
                    case "4":
                        Console.WriteLine("Выход из программы");
                        isWorking = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ShowSortToInicialy()
        {
            var parientsToInicialy = _patients.OrderBy(patient => patient.Inicialy).ToList();

            ShowInfo(parientsToInicialy);
        }

        private void ShowSortToAge()
        {
            var patientsToAge = _patients.OrderBy(patient => patient.Age).ToList();

            ShowInfo(patientsToAge);
        }

        private void FindToDiseasePatient()
        {
            Console.Write("Введите заболевание: ");
            string desease = Console.ReadLine();

            var patientToDisease = _patients.Where(patient => patient.Desease == desease).ToList();
            ShowInfo(patientToDisease);
        }

        private void ShowInfo(List<Patient> patients)
        {
            foreach (Patient patient in patients)
            {
                patient.ShowPacient();
            }
        }
    }

    class Patient
    {
        public Patient(string inicialy, int age, string desease)
        {
            Inicialy = inicialy;
            Age = age;
            Desease = desease;
        }

        public string Inicialy { get; private set; }
        public int Age { get; private set; }
        public string Desease { get; private set; }

        public void ShowPacient()
        {
            Console.WriteLine($"Пациент - {Inicialy} | возраст - {Age} | заболевание - {Desease}");
        }
    }
}
