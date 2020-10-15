using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeansOffice5
{
	public class StudentDTO
    {
		public int IdStudent { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string IndexNumber { get; set; }
		public StudyDTO Studies { get; set; }
		public List<SubjectDTO> Subjects { get; set; }
    }

	public class SubjectDTO
	{
		public int IdSubject { get; set; }
		public string Name { get; set; }
	}

public class StudyDTO
	{
	public int IdStudies { get; set; }
	public string Name { get; set; }
	}
}
