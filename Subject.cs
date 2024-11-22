using System;
using System.Collections.Generic;

public class Subject
{
    public int SubjectId { get; set; }
    public string Title { get; set; }
    public int MaximumCapacity { get; set; }

    public List<StudentSubject> StudentSubjects { get; set; } 
}

