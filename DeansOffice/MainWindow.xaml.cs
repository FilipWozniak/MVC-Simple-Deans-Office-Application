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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeansOffice5
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		DatabaseControler dBControler;
		public MainWindow()
		{
			InitializeComponent();
			dBControler = new DatabaseControler();
			StudentDataGrid.ItemsSource = (new DatabaseControler()).getData();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{ 
			AddAndEdit window = new AddAndEdit(0, null, this.dBControler);
			window.Show();
			this.Close();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			Confirmation window = new Confirmation((Student)StudentDataGrid.SelectedItem, dBControler);
			window.Show();
			this.Close();
		}

		private void StudentDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			int n = (sender as DataGrid).SelectedItems.Count;
			rowcount.Content = "Selected " + n + " rows.";
		}

		private void StudentDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			AddAndEdit window = new AddAndEdit(1, (Student)StudentDataGrid.SelectedItem, dBControler);
			window.Show();
			this.Close();
		}
	}
}
