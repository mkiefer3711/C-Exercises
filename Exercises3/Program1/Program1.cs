// Author: Maddison Kiefer
// Program for a university with four departments. Displays the staff, their salary, and what they do.

using System;

namespace Program1
{
    // Interface for objects that can be taught
    public interface ITeachable
    {
        // Method for teaching
        void Teach();
    }
    // Interface for objects that can administrate
    public interface IAdmin
    {
        // Method for administration
        void Administrate();
    }
    // Class representing a staff member
    public class Staff
    {
        // Name of the staff member
        public string Name { get; set; }
        // Salary of the staff member
        public double Salary { get; set; }

        // Constructor to initialize Name and Salary
        public Staff(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }
        // Method to display information about the staff member
        public virtual void DisplayInfo()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Salary is: " + Salary);
        }
    }

    // Class representing a Professor, inherits from Staff and implements ITeachable
    public class Professor : Staff, ITeachable
    {
        // Class taught by the professor
        public string Class { get; set; }

        // Constructor to initialize Name, Salary, and Class
        public Professor(string name, double salary, string className) : base(name, salary)
        {
            Class = className;
        }

        // Override method to display professor's information
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("I am a professor, and I teach classes");
            Teach();
        }
        // Implementation of Teach method from ITeachable interface
        public void Teach()
        {
            Console.WriteLine("I teach " + Class);
        }
    }

    // Class representing a Researcher, inherits from Staff and implements ITeachable
    public class Researcher : Staff, ITeachable
    {
        // Enum for different research specialties
        public enum ResearchSpeciality { NEUROSCIENCE, ROBOTICS, PSYCHOLOGY, CHEMISTRY }
        // Research speciality of the researcher
        public ResearchSpeciality Speciality { get; set; }

        // Constructor to initialize Name, Salary, and Speciality
        public Researcher(string name, double salary, ResearchSpeciality speciality) : base(name, salary)
        {
            Speciality = speciality;
        }

        // Override method to display researcher's information
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("I am a researcher, and I do research");
            Teach();
        }
        // Implementation of Teach method from ITeachable interface
        public void Teach()
        {
            Console.WriteLine("I do research in " + Speciality);
        }
    }

    // Class representing a Dean, inherits from Staff and implements ITeachable and IAdmin
    public class Dean : Staff, ITeachable, IAdmin
    {
        // Constructor to initialize Name and Salary
        public Dean(string name, double salary) : base(name, salary)
        {
        }

        // Override method to display dean's information, including teaching and administrative details
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Teach();
            Administrate();
        }
        // Implementation of Teach method from ITeachable interface
        public void Teach()
        {
            Console.WriteLine("I am a dean, and I teach classes");
        }
        // Implementation of Administrate method from IAdmin interface
        public void Administrate()
        {
            Console.WriteLine("I am a dean and an administrator");
        }
    }

    // Class representing an Administrator, inherits from Staff and implements IAdmin
    public class Administrator : Staff, IAdmin
    {
        // Constructor to initialize Name and Salary
        public Administrator(string name, double salary) : base(name, salary)
        {
        }
        // Override method to display administrator's information, including administrative details
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Administrate();
        }
        // Implementation of Administrate method from IAdmin interface
        public void Administrate()
        {
            Console.WriteLine("I am an administrator");
        }
    }

    // Class representing a Department
    public class Department
    {
        // Array to hold staff members in the department
        public Staff[] Staff { get; set; }

        // Constructor to initialize the Staff array with a length of 10
        public Department()
        {
            Staff = new Staff[10];
        }
        // Method to display information about the staff members in the department
        public void DisplayInfo()
        {
            foreach (var staff in Staff)
            {
                if (staff != null)
                {
                    staff.DisplayInfo();
                    Console.WriteLine();
                }
            }
        }
    }

    // Class representing a University
    public class University
    {
        // Enum for the four different departments
        public enum DepartmentType { MATH, ENGLISH, GEOGRAPHY, COMPUTERSCIENCE }

        // Array to hold departments in the university
        public Department[] Departments { get; set; }

        // Constructor to initialize the Departments array with a length of 4 and create Department objects
        public University()
        {
            Departments = new Department[4];
            for (int i = 0; i < 4; i++)
            {
                Departments[i] = new Department();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Create a new University object
            var u = new University();

            Console.WriteLine("Module 3 - Exercise 1 - University\n");

            // Assign staff members to departments and display information
            u.Departments[0].Staff[0] = new Professor("Daniel", 45000, "Geometry");
            u.Departments[1].Staff[0] = new Administrator("Brooke", 60000);
            u.Departments[2].Staff[0] = new Dean("Kristen", 85000);
            u.Departments[3].Staff[0] = new Researcher("Rachel", 55000, Researcher.ResearchSpeciality.ROBOTICS);

            // Display information for each department
            Console.WriteLine("Department 1\n");
            u.Departments[0].DisplayInfo();
            u.Departments[1].DisplayInfo();
            u.Departments[2].DisplayInfo();
            u.Departments[3].DisplayInfo();

            // Create a new University object
            var u2 = new University();

            // Assign staff members to departments and display information
            u2.Departments[0].Staff[0] = new Professor("Kelly", 47000, "Trigonometry");
            u2.Departments[1].Staff[0] = new Administrator("Tyler", 59000);
            u2.Departments[2].Staff[0] = new Dean("Tom", 86000);
            u2.Departments[1].Staff[1] = new Researcher("Suzan", 55000, Researcher.ResearchSpeciality.PSYCHOLOGY);
            u2.Departments[0].Staff[1] = new Dean("Matt", 88000);
            u2.Departments[3].Staff[0] = new Professor("Taylor", 48000, "CIS102");

            // Display information for each department
            Console.WriteLine("Department 2\n");
            u2.Departments[0].DisplayInfo();
            u2.Departments[1].DisplayInfo();
            u2.Departments[2].DisplayInfo();
            u2.Departments[3].DisplayInfo();
            Console.WriteLine("Done");
        }
    }
}
