using System;
using System.Collections.Generic;

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public DateTime EnrollmentDate { get; set; }

    public List<StudentSubject> StudentSubjects { get; set; } 
}

