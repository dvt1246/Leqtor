using System;
using System.Linq;

class Program
{
    static void Main()
    {
        using var context = new AppDbContext();
        context.Database.EnsureCreated(); 

        var repository = new Repository(context);

        
        var subject1 = new Subject
        {
            Title = "Mathematics",
            MaximumCapacity = 30
        };

        var subject2 = new Subject
        {
            Title = "Biology",
            MaximumCapacity = 20
        };

        repository.AddSubject(subject1);
        repository.AddSubject(subject2);


        var student1 = new Student
        {
            Name = "Davit",
            EnrollmentDate = DateTime.Now
        };
        var student2 = new Student
        {
            Name = "Giorgi",
            EnrollmentDate = DateTime.Now
        };
        var student3 = new Student
        {
            Name = "Zura",
            EnrollmentDate = DateTime.Now
        };

        repository.AddStudent(student1);
        repository.AddStudent(student2);
        repository.AddStudent(student3);

        repository.EnrollStudentToSubject(student1.StudentId, subject1.SubjectId);
        repository.EnrollStudentToSubject(student2.StudentId, subject1.SubjectId);
        repository.EnrollStudentToSubject(student3.StudentId, subject2.SubjectId);

        var subjects = repository.GetAllSubjects();
        foreach (var subject in subjects)
        {
            Console.WriteLine($"Subject: {subject.Title}");
            foreach (var studentSubject in subject.StudentSubjects)
            {
                Console.WriteLine($"  Student: {studentSubject.Student.Name}");
            }
        }
    }
}

