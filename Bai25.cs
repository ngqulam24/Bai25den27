using System;
using System.Text;

public abstract class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    protected string BankAccount { get; set; }

    public Person(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public abstract string GetRole();
}

// Interface KPIEvaluator
public interface KPIEvaluator
{
    double CalculateKPI();
}

// Lớp TeachingAssistant
public class TeachingAssistant : Person, KPIEvaluator
{
    public string EmployeeID { get; set; }
    private int numberOfCourses;

    public TeachingAssistant(string name, int age, string gender, string employeeID, int numberOfCourses)
        : base(name, age, gender)
    {
        EmployeeID = employeeID;
        this.numberOfCourses = numberOfCourses;
    }

    public override string GetRole()
    {
        return "Teaching Assistant";
    }

    public double CalculateKPI()
    {
        return numberOfCourses * 5;
    }
}

// Lớp Lecturer
public class Lecturer : Person, KPIEvaluator
{
    public string EmployeeID { get; set; }
    private int numberOfPublications;

    public Lecturer(string name, int age, string gender, string employeeID, int numberOfPublications)
        : base(name, age, gender)
    {
        EmployeeID = employeeID;
        this.numberOfPublications = numberOfPublications;
    }

    public override string GetRole()
    {
        return "Lecturer";
    }

    public double CalculateKPI()
    {
        return numberOfPublications * 7;
    }
}

// Lớp Professor
public sealed class Professor : Lecturer
{
    private static int countProfessors = 0;
    private int numberOfProjects;

    public Professor(string name, int age, string gender, string employeeID, int numberOfPublications, int numberOfProjects)
        : base(name, age, gender, employeeID, numberOfPublications)
    {
        this.numberOfProjects = numberOfProjects;
        countProfessors++;
    }

    public override string GetRole()
    {
        return "Professor";
    }

    public double CalculateKPI()
    {
        return (base.CalculateKPI()) + (numberOfProjects * 10);
    }
}

//bai2
class AcademicStaff
{
    private string role;
    private string name;
    private double kpi;

    public AcademicStaff(string role, string name, double kpi)
    {
        this.role = role;
        this.name = name;
        this.kpi = kpi;
    }

    public string GetRole()
    {
        return role;
    }

    public string GetName()
    {
        return name;
    }

    public double GetKPI()
    {
        return kpi;
    }
}

class Hello
{
    static AcademicStaff[] GetAcademicStaffArray()
    {
        Console.Write("Enter the number of academic staff (2-10): ");
        int n = int.Parse(Console.ReadLine());

        AcademicStaff[] staffArray = new AcademicStaff[n];

        for (int i = 0; i < n; i++)
        {
            string role;
            while (true)
            {
                Console.Write("Enter the role of staff member " + (i + 1) + " (ta, lec, or gs): ");
                role = Console.ReadLine().ToLower();
                if (role == "ta" || role == "lec" || role == "gs")
                    break;
                Console.WriteLine("Invalid role. Please enter 'ta', 'lec', or 'gs'.");
            }

            Console.Write("Enter the name of staff member " + (i + 1) + ": ");
            string name = Console.ReadLine();

            double kpi;
            while (true)
            {
                Console.Write("Enter the KPI of staff member " + (i + 1) + ": ");
                if (double.TryParse(Console.ReadLine(), out kpi) && kpi >= 0)
                    break;
                Console.WriteLine("Invalid KPI. Please enter a non-negative value.");
            }

            switch (role)
            {
                case "ta":
                    staffArray[i] = new AcademicStaff("Teaching Assistant", name, kpi);
                    break;
                case "lec":
                    staffArray[i] = new AcademicStaff("Lecturer", name, kpi);
                    break;
                case "gs":
                    staffArray[i] = new AcademicStaff("Professor", name, kpi);
                    break;
            }
        }

        return staffArray;
    }

    static void DisplayAcademicStaffArray(AcademicStaff[] staffArray)
    {
        Console.WriteLine("Academic Staff:");
        foreach (AcademicStaff staff in staffArray)
        {
            Console.WriteLine("Role: " + staff.GetRole());
            Console.WriteLine("Name: " + staff.GetName());
            Console.WriteLine("KPI: " + staff.GetKPI());
            Console.WriteLine();
        }
    }

    static int CountProfessors(AcademicStaff[] staffArray)
    {
        int professorCount = 0;
        foreach (AcademicStaff staff in staffArray)
        {
            if (staff.GetRole() == "Professor")
                professorCount++;
        }
        return professorCount;
    }

 class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\n------------------------------");
            Console.WriteLine("Bài 25");
            int choice;
            do
            {
                Console.WriteLine("1. Bài 1\n2. Bài 2\n0. Thoát.");
                Console.Write("Mời bạn nhập câu để thực hiện lệnh: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Bai1();
                        break;
                    case 2:
                        Bai2();
                        break;
                    case 0:
                        Console.WriteLine("\nĐã thoát.");
                        break;
                    default:
                        Console.WriteLine("\nMời nhập lại lựa chọn!");
                        break;
                }
            } while (choice != 0);
        }
        static void Bai1()
        {
            TeachingAssistant ta = new TeachingAssistant("John Doe", 30, "Male", "TA001", 5);
            Lecturer l = new Lecturer("Jane Smith", 40, "Female", "LEC001", 10);
            Professor p = new Professor("Dr. Alice Johnson", 50, "Female", "PROF001", 15, 3);

            // In thông tin vai trò và KPI
            Console.WriteLine($"Role: {ta.GetRole()}, KPI: {ta.CalculateKPI()}");
            Console.WriteLine($"Role: {l.GetRole()}, KPI: {l.CalculateKPI()}");
            Console.WriteLine($"Role: {p.GetRole()}, KPI: {p.CalculateKPI()}");
        }

        static void Bai2()
        {
            AcademicStaff[] staffArray = GetAcademicStaffArray();
            DisplayAcademicStaffArray(staffArray);
            int professorCount = CountProfessors(staffArray);
            Console.WriteLine("Number of Professors: " + professorCount);
        }
    }
}