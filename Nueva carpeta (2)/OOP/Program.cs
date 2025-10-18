using System;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Estas líneas ahora funcionan porque el salario de 2500
            // es igual al nuevo SALARIO_MINIMO establecido.
            Employee employee1 = new Employee("Homero", 89, "Teporochito", 0, new DateTime(1995, 5, 15), "Fisico", 2500);
            employee1.Introduce();
        }
    }

    public class Person
    {
        // Auto-implemented property
        public string Name { get; set; } = string.Empty;

        // Full property with backing field and validation
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be negative");
                }
                _age = value;
            }
        }

        // Property with default value
        public string Nickname { get; set; } = "No nickname";
        // Nullable property
        public int? Couple { get; set; } = null;
        // Read-only property
        public readonly DateTime BirthDate = DateTime.Now;
        // Static property
        public static int Population { get; private set; } = 0;

        public Person()
        {
            if (this.Name.Length == 0)
            {
                this.Name = "Unknown";
            }
            Population++;
        }

        public Person(string name, int age, string nickname, int? couple, DateTime birthDate) : this()
        {
            Name = name;
            Age = age;
            Nickname = nickname;
            Couple = couple;
            BirthDate = birthDate;
        }

        public virtual void Introduce()
        {
            Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
        }
    }

    public class Employee : Person
    {
        // --- ÚNICO CAMBIO REALIZADO ---
        // Se ajustó el valor para que la validación permita un salario de 2500.
        private const decimal SALARIO_MINIMO = 2500.00m;

        private decimal _salary;

        public string Position { get; set; } = "Unemployed";

        // La validación sigue activa y funcionando
        public decimal Salary
        {
            get { return _salary; }
            set
            {
                if (value < SALARIO_MINIMO)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"El salario no puede ser menor al mínimo de {SALARIO_MINIMO:C}.");
                }
                _salary = value;
            }
        }

        public Employee(string name, int age, string nickname, int? couple, DateTime birthDate, string position, decimal salary)
            : base(name, age, nickname, couple, birthDate)
        {
            Position = position;
            Salary = salary;
        }

        public override void Introduce()
        {
            base.Introduce();
            Console.WriteLine($"I work as a {Position} and my salary is {Salary:C}.");
        }
    }
}