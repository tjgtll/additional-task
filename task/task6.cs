
using System;
using System.Collections.Generic;

namespace hw11
{
    class Country : IName, IInfo
    {
        public string Name { get; set; }

        public Country(string Name)
        {
            this.Name = Name;
        }
        
        public string Info
        {
            get => $"{Name}";
        }
    }

    class Region : IName, IInfo
    {
        Country Country;

        public string Name { get; set; }

        public Region(Country Country, string Name)
        {
            this.Country = Country;
            this.Name = Name;
        }

        public string Info
        {
            get => Country.Info+"\n"+$"{Name} область";
        }
    }

    class Adress : IInfo
    {
        Region Region;
        string StreetName;
        int StreetNumber;
        int ApartmentNumber;
        string Zipcode;
        string Town;

        public Adress(Region Region, string StreetName, int StreetNumber, int ApartmentNumber, string Zipcode, string Town)
        {
            this.Region = Region;
            this.StreetName = StreetName;
            this.StreetNumber = StreetNumber;
            this.ApartmentNumber = ApartmentNumber;
            this.Zipcode = Zipcode;
            this.Town = Town;
        }

        public string Info
        {
            get => Region.Info + "\n" 
                + StreetName + $" д.{StreetNumber}" + $" кв.{ApartmentNumber}" + "\n"
                + Zipcode + "\n" 
                + Town;
        }
    }

    class Department : IName, IInfo
    {
        public string Name { get; set; }

        public Department(string Name)
        {
            this.Name = Name;
        }
        public string Info
        {
            get => $"Департамент : {Name}";
        }
    }

    class Employee : IInfo
    {
        Role Role;
        Adress Adress;
        Department Department;
        Position Position;
        string FirstName;
        string LastName;
        string MiddleName;
        string Email;

        public Employee(string FirstName, string LastName, string MiddleName, string Email, Adress Adress , Department Department, Role Role, Position Position)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.MiddleName = MiddleName;
            this.Email = Email;
            this.Adress = Adress;
            this.Department = Department;
            this.Role = Role;
            this.Position = Position;
        }

        public string Info
        {
            get => "ФИО : "+FirstName +" "+ LastName +" " + MiddleName + "\n" 
                + $"email : {Email}" + "\n" 
                + Department.Info + "\n" 
                + Role.Name + "\n" 
                + Position.Name + "\n" 
                + Adress.Info;


        }
    }

    class Role : IName
    {
        public string Name { get; set; }
        public Role(string Name)
        {
            this.Name = Name;
        }
    }

    class Position : IName
    {
        public string Name { get; set; }

        public Position(string Name)
        {
            this.Name = Name;
        }
    }

    public interface IName
    {
        string Name { get; set; }
    }

    public interface IInfo
    {
        string Info { get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Country Belarus = new Country("Беларусь");
            Region Brest = new Region(Belarus, "Брестская");
            Region Minsk = new Region(Belarus, "Минская");
            Adress Adr1 = new Adress(Brest, "Бехтерева", 11, 54, "224001", "Брест");
            Adress Adr2 = new Adress(Brest, "Белоозёрская", 101, 4, "224014", "Брест");
            Adress Adr3 = new Adress(Minsk, "Георгиевская", 8, 58, "222410", "Вилейка");
            Adress Adr4 = new Adress(Minsk, "Георгиевская", 8, 59, "222410", "Вилейка");

            Role front = new Role("front-end developer");
            Role back = new Role("back-end developer");

            Position junior = new Position("Junior");
            Position middle = new Position("Junior");
            Position senior = new Position("Junior");

            Department developers = new Department("Разработка ПО");

            List<Employee> Emp = new List<Employee>();
            Emp.Add(new Employee("Пономарёв", "Савелий", "Авдеевич", "Pastik@mail.ru", Adr1, developers, back, senior));
            Emp.Add(new Employee("Фадеев", "Яков", "Аркадьевич", "vot4uk@mail.ru", Adr2, developers, front, middle));
            Emp.Add(new Employee("Иванков", "Яков", "Геннадиевич", "pivo@mail.ru", Adr3, developers, back, senior));
            Emp.Add(new Employee("Дмитриев", "Ефим", "Юрьевич", "cxntu@mail.ru", Adr4, developers, back, middle));
            Emp.Add(new Employee("Пономарёва", "Клавдия", "Робертовна", "lxst@mail.ru", Adr1, developers, front, junior));

            foreach(Employee e in Emp)
            {
                Console.WriteLine(e.Info);
                Console.WriteLine();
            }
        }
    }
}
