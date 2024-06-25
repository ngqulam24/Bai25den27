using System.Text;

public interface KPI
{
    double CalculateKPI();
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Major { get; set; }

    public Person(string name, int age, string major)
    {
        Name = name;
        Age = age;
        Major = major;
    }
}

public class Student : Person, KPI
{
    public float gpa { get; set; }

    public Student(string name, int age, string major, float gpa) : base(name, age, major)
    {
        this.gpa = gpa;
    }

    public double CalculateKPI()
    {
        return gpa;
    }
    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Major: {Major}, KPI: {gpa}";
    }
}

public class Teacher : Person, KPI
{
    public int Publications { get; set; }

    public Teacher(string name, int age, string major, int publications) : base(name, age, major)
    {
        Publications = publications;
    }

    public double CalculateKPI()
    {
        return 1.5 * Publications;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Major: {Major}, Publications: {Publications}";
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Student student = new Student("Nguyễn Tiến Dũng", 20, "CNTT&TT", 3.8f);
        Teacher teacher = new Teacher("Vũ Đức Việt", 38, "CNTT&TT", 5);

        Console.WriteLine(student.ToString());
        Console.WriteLine($"Student's KPI: {student.CalculateKPI()}");

        Console.WriteLine("\n" + teacher.ToString());
        Console.WriteLine($"Teacher's KPI: {teacher.CalculateKPI()}");
    }
}