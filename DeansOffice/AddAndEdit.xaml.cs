using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;


namespace DeansOffice5
{
    /// <summary>
    /// Interaction logic for AddAndEdit.xaml
    /// </summary>
    public partial class AddAndEdit : Window
    {
		int arg;
		DatabaseControler dbConnector;
		Student student;

		public AddAndEdit(int arg, Student student, DatabaseControler dbConnector)
		{
			this.student = student;
			this.dbConnector = dbConnector;
            InitializeComponent();
			this.arg = arg;
			foreach (Study sdto in dbConnector.GetStudies())
				Studies.Items.Add(sdto);
			foreach (Subject sdto in dbConnector.GetSubjects())
				Subjects.Items.Add(sdto);
			if (arg == 1)
			{
				FName.AppendText(student.FirstName);
				LName.AppendText(student.LastName);
				SNumber.AppendText(student.IndexNumber);
				Studies.SelectedItem = dbConnector.GetStudies()[0];
			}

        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			List<Subject> subjects = new List<Subject>();
			foreach(var i in Subjects.SelectedItems)
			{
				subjects.Add(new Subject { IdSubject = ((Subject)i).IdSubject });
			}
			Student student = new Student { FirstName = FName.Text, LastName = LName.Text, Address="empty", IndexNumber = SNumber.Text, IdStudies = ((Study)Studies.SelectedItem).IdStudies };
			if(arg == 0)
			{
				dbConnector.addStudent(student, subjects);
			}
			else
			{
				student.IdStudent = this.student.IdStudent;
				dbConnector.editStudent(student, subjects);
			}
			MainWindow mw = new MainWindow();
			mw.Show();
			this.Close();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			MainWindow mw = new MainWindow();
			mw.Show();
			this.Close();
		}
	}
}
