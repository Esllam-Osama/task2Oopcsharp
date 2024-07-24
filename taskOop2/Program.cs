using System.Linq;
using System.Threading.Channels;

namespace taskOop2;
class Course
{
  public string Name { get; set; }
  public string Instructor { get; set; }
  public Course(string name, string instructor)
  {
    Name = name;
    Instructor = instructor;
  }
  public void DisplayDetails()
  {
    Console.WriteLine($"name is: {this.Name}\ninstructor is: {this.Instructor}");
    Console.WriteLine("===========================");
  }
}
class Student
{
  public int Id { get; set; }
  public string Name { get; set; }
  public List<Course> Courses { get; set; } = new List<Course>();
  public Student(string name, int id)
  {
    Id = id;
    Name = name;
  }
  public Student(Student student)
  {
    this.Id = student.Id;
    this.Name = student.Name;
  }
  public void EnrollCourse(string course , School school)
  {
    bool chek = true;
    foreach(Course c in school.Courses)
    {
      if (c.Name==course)
      {
        Courses.Add(c);
        chek = false;
        return;
      }
    }
    if (chek)
    {
      Console.WriteLine("the course is undefind");
    }
    
  }
  public void DisplayDetails()
  {
    Console.WriteLine($"student name is: {this.Name}\nstudent id is: {this.Id}\ncourses is: [{String.Join(",", this.Courses)}]");
    Console.WriteLine("===========================");
  }
}
class School
{
  public List<Student> Students { get; set; } = new List<Student> { };
  public List<Course> Courses { get; set; } = new List<Course> { };
  public void AddStudent(Student student)
  {
    Students.Add(student);
  }
  public void AddCourse(Course course)
  {
    Courses.Add(course);
  }
  public void EnrollStudentInCourse(int studentId, string courseName,School school)
  {
    Student student = Students.Find(e => e.Id == studentId);
    //للتأكد ان الطالب موجود و ان الكورس ليس مضافا من قبل اضافه من عندى
    bool chek = false;
    foreach(Course c in this.Courses) { chek= true; }
    if (student != null && chek)
    {
      student.EnrollCourse(courseName ,school );
      Console.WriteLine("the course added");
      Console.WriteLine("===========================");

    }
    else if (student == null)
    {
      Console.WriteLine("the student is undefind");
      Console.WriteLine("===========================");

    }
    else
    {
      Console.WriteLine("This course has already been added");
      Console.WriteLine("===========================");

    }
  }
  public void DisplayAllStudents()
  {
    for (int i = 0; i < Students.Count; i++)
    {
      Console.WriteLine($"student number: {i + 1}");
      Console.WriteLine($"student name is: {Students[i].Name}");
      Console.WriteLine($"student id is: {Students[i].Id}");
      Console.WriteLine("===========================");
    }
  }
  public void DisplayAllCources()
  {
    for (int i = 0; i < Courses.Count; i++)
    {
      Console.WriteLine($"Course number: {i + 1}");
      Console.WriteLine($"Course name is: {Courses[i].Name}");
      Console.WriteLine($"course istructor is: {Courses[i].Instructor}");
      Console.WriteLine("===========================");
    }
  }
}
internal class Program
{
  static void Main(string[] args)
  {
    School school = new School();

    // Adding students to the school
    Student student1 = new Student("Alice", 1);
    Student student2 = new Student("Bob", 2);
    school.AddStudent(student1);
    school.AddStudent(student2);

    // Adding courses to the school
    Course course1 = new Course("Math", "Prof. Smith");
    Course course2 = new Course("Science", "Prof. Johnson");
    school.AddCourse(course1);
    school.AddCourse(course2);

    // Enrolling students in courses
    school.EnrollStudentInCourse(1, "Math",school);
    school.EnrollStudentInCourse(1, "Science", school);
    school.EnrollStudentInCourse(2, "Science", school);

    // Displaying all students and their details
    school.DisplayAllStudents();

    // Displaying all courses and their details
    school.DisplayAllCources();

    // Utilizing copy constructors
    Student copyStudent = new Student(student1);
    Console.WriteLine("Copy of Student Details:");
    copyStudent.DisplayDetails();
  }
}

