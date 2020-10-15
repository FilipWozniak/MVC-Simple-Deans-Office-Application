using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeansOffice5
{
	public class DatabaseControler
	{
		masterEntities context;
		public List<Study> GetStudies()
		{
			return context.Studies.ToList();
		}
		
		public List<Subject> GetSubjects()
		{
			return context.Subjects.ToList();
		}
		public DatabaseControler()
		{
			context = new masterEntities();
		}

		public List<Student> getData()
		{
			List<Student> students = context.Students.ToList();
			students.ForEach(n => n.Study = context.Studies.Where(s => s.IdStudies == n.IdStudies).First());
			return students;
		}

		public void addStudent(Student student, List<Subject> subjects)
		{
			context.Students.Add(student);
			foreach (Subject s in subjects)
				context.Student_Subject.Add(new Student_Subject
				{
					IdStudent = student.IdStudent,
					IdSubject = s.IdSubject,
					CreatedAt = DateTime.Now
				});
			context.SaveChanges();
		}
		public void editStudent(Student student, List<Subject> subjects)
		{
			Student s = context.Students.Where(n => n.IdStudent == student.IdStudent).First();
			s.IdStudies = student.IdStudies;
			s.FirstName = student.FirstName;
			s.LastName = student.LastName;
			s.IndexNumber = student.IndexNumber;

			context.Student_Subject.RemoveRange(context.Student_Subject.Where(n => n.IdStudent == student.IdStudent));
			foreach (Subject sub in subjects)
				context.Student_Subject.Add(new Student_Subject
				{
					IdStudent = student.IdStudent,
					IdSubject = sub.IdSubject,
					CreatedAt = DateTime.Now
				});
			context.SaveChanges();
		}

		public void deleteStudent(Student s)
		{
			context.Students.RemoveRange(context.Students.Where(n=>n.IdStudent==s.IdStudent));
			context.Student_Subject.RemoveRange(context.Student_Subject.Where(n => n.IdStudent == s.IdStudent));
			context.SaveChanges();
		}
	}
}
