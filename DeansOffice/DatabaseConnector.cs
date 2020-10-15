using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DeansOffice5
{
    public class DatabaseConnector
    {

		public static string ConnectionString = @"Server= DAWIDWALASFFE2; Integrated Security=True;";

		public DataGrid StudentsDataGrid;
		public List<StudentDTO> Students = new List<StudentDTO>();
		public List<StudyDTO> Studies = new List<StudyDTO>();
		public List<SubjectDTO> Subjects = new List<SubjectDTO>();

		public void GetData(List<StudentDTO> students)
		{
			using (SqlConnection con = new SqlConnection(ConnectionString))
			{

				con.Open();

				using(SqlCommand command = new SqlCommand("Select * FROM apbd.Subject;", con))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Subjects.Add(new SubjectDTO
							{
								IdSubject = (int)reader["IdSubject"],
								Name = reader["Name"].ToString()
							});
						}
					}
				}
				using (SqlCommand command = new SqlCommand("Select * FROM apbd.Studies;", con))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Studies.Add(new StudyDTO
							{
								IdStudies = (int)reader["IdStudies"],
								Name = reader["Name"].ToString()
							});
						}
					}
				}

				using (SqlCommand command = new SqlCommand("SELECT  * FROM apbd.Student", con))
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						Students.Add(new StudentDTO
						{
							IdStudent = (int)reader["IdStudent"],
							FirstName = reader["FirstName"].ToString(),
							IndexNumber = reader["IndexNumber"].ToString(),
							LastName = reader["LastName"].ToString(),
							Studies = getStudiesByStudent((int) reader["IdStudies"])
						});
					}
				}
				con.Close();
			}
			students = Students;
		}

		public List<SubjectDTO> GetSubjectsByStudent(int IdStudent)
		{
			List<SubjectDTO> subjects = new List<SubjectDTO>();
			using (SqlConnection con = new SqlConnection(ConnectionString))
			{
				con.Open();

				using(SqlCommand command = new SqlCommand("Select * FROM apbd.Subject sub INNER JOIN apbd.Student_Subject s on sub.IdSubject = s.IdSubject WHERE s.IdStudent = @IdStudent;", con))
				{
					command.Parameters.AddWithValue("@IdStudent", IdStudent);
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							subjects.Add(new SubjectDTO
							{
								IdSubject = (int)reader["IdSubject"],
								Name = reader["Name"].ToString()
							});
						}
					}
				}

			}
			return subjects;
		}

		StudyDTO getStudiesByStudent(int IdStudies)
		{
			StudyDTO study = null;
			study = Studies.Find(n => n.IdStudies == IdStudies);
			return study;
		}

		public void deleteStudent(StudentDTO student)
		{
			using (SqlConnection con = new SqlConnection(ConnectionString))
			{
				con.Open();

				using (SqlCommand command = new SqlCommand("DELETE FROM APBD.Student WHERE IdStudent=@Id; Delete From apbd.Student_Subject where IdStudent=@Id;", con))
				{
					command.Parameters.AddWithValue("@Id", student.IdStudent);
					command.ExecuteNonQuery();
				}
				con.Close();

			}
		}
		

		public void addStudent(StudentDTO student)
		{
			using (SqlConnection con = new SqlConnection(ConnectionString))
			{
				con.Open();

				using (SqlCommand command = new SqlCommand("INSERT INTO APBD.Student (FirstName, LastName, Address, IndexNumber, IdStudies) VALUES (@FirstName, @LastName, 'somewhere', @IndexNumber, @IdStudies);", con))
				{
					command.Parameters.AddWithValue("@FirstName", student.FirstName);
					command.Parameters.AddWithValue("@LastName", student.LastName);
					command.Parameters.AddWithValue("@IndexNumber", student.IndexNumber);
					command.Parameters.AddWithValue("@IdStudies", student.Studies.IdStudies);
					int affectedRows = command.ExecuteNonQuery();
				}

				foreach (SubjectDTO sub in student.Subjects)
				using (SqlCommand command = new SqlCommand("INSERT INTO APBD.Student_Subject (IdStudent, IdSubject, CreatedAt) Values(@IdStudent, @IdSubject, @CreatedAt);", con))
				{
					command.Parameters.AddWithValue("@IdStudent", student.IdStudent);
					command.Parameters.AddWithValue("@IdSubject", sub.IdSubject);
						command.Parameters.AddWithValue("CreatedAt", DateTime.Now);
						int affected = command.ExecuteNonQuery();
				}
			}
		}

		public void editStudent(StudentDTO newStud, StudentDTO oldStud)
		{
			newStud.IdStudent = oldStud.IdStudent;

			if (newStud.Equals(oldStud))
			{
				return;
			}
			else
			{
				using (SqlConnection con = new SqlConnection(ConnectionString))
				{
					con.Open();
					using (SqlCommand command = new SqlCommand("UPDATE APBD.STUDENT SET FirstName=@FName, LastName=@LName, IndexNumber=@IndNum, IdStudies=@IdStud WHERE IdStudent=@IdStudent;", con))
					{
						command.Parameters.AddWithValue("@FName", newStud.FirstName);
						command.Parameters.AddWithValue("@LName", newStud.LastName);
						command.Parameters.AddWithValue("@IndNum", newStud.IndexNumber);
						command.Parameters.AddWithValue("@IdStud", newStud.Studies.IdStudies);
						command.Parameters.AddWithValue("@IdStudent", newStud.IdStudent);
						int ffected = command.ExecuteNonQuery();
					}

					using(SqlCommand command = new SqlCommand("DELETE FROM APBD.STUDENT_SUBJECT WHERE IdStudent=@ID;", con))
					{
						command.Parameters.AddWithValue("@ID", newStud.IdStudent);
						int dd = command.ExecuteNonQuery();
					}

					foreach (SubjectDTO sub in newStud.Subjects)
						using (SqlCommand command = new SqlCommand("INSERT INTO APBD.Student_Subject (IdStudent, IdSubject, CreatedAt) Values(@IdStudent, @IdSubject, @CreatedAt);", con))
						{
							command.Parameters.AddWithValue("@IdStudent", newStud.IdStudent);
							command.Parameters.AddWithValue("@IdSubject", sub.IdSubject);
							command.Parameters.AddWithValue("CreatedAt", DateTime.Now);
							int affected = command.ExecuteNonQuery();
						}
				}

			}

		}
	}


	
}
