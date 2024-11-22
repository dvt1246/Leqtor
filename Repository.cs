using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Repository
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public void AddSubject(Subject subject)
    {
        _context.Subjects.Add(subject);
        _context.SaveChanges();
    }

    public void AddStudent(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
    }

    public void EnrollStudentToSubject(int studentId, int subjectId)
    {
        var studentSubject = new StudentSubject
        {
            StudentId = studentId,
            SubjectId = subjectId
        };
        _context.StudentSubjects.Add(studentSubject);
        _context.SaveChanges();
    }

    public IQueryable<Subject> GetAllSubjects()
    {
        return _context.Subjects.Include(s => s.StudentSubjects).ThenInclude(ss => ss.Student);
    }

    public IQueryable<Student> GetStudentsForSubject(int subjectId)
    {
        return _context.Students
            .Where(s => s.StudentSubjects.Any(ss => ss.SubjectId == subjectId))
            .Include(s => s.StudentSubjects)
            .ThenInclude(ss => ss.Subject);
    }
}

