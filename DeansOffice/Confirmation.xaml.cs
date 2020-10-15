using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DeansOffice5
{
    /// <summary>
    /// Interaction logic for Confirmation.xaml
    /// </summary>
    public partial class Confirmation : Window
    {
		Student Student;
		DatabaseControler db;
        public Confirmation(Student student, DatabaseControler db)
        {
			Student = student;
			this.db = db;
            InitializeComponent();
			Message.Content = "Are you sure to delete " + student.FirstName + " " + student.LastName + "?";
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			this.db.deleteStudent(Student);
			MainWindow window = new MainWindow();
			window.Show();
			this.Close();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			MainWindow window = new MainWindow();
			window.Show();
			this.Close();
		}
	}
}
