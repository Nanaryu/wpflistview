using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
using static WpfApp1.Window1;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public class Student
        {
            public string Pesel { get; set; }
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public string LastName { get; set; }
            public string BirthDate { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string PostalCode { get; set; }
        }

        private List<Student> students = new();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new Window1();
            if (addWindow.ShowDialog() == true)
            {
                students.Add(new Student
                {
                    Pesel = addWindow.PeselTextBox.Text,
                    FirstName = addWindow.FirstNameTextBox.Text,
                    SecondName = addWindow.SecondNameTextBox.Text,
                    LastName = addWindow.LastNameTextBox.Text,
                    BirthDate = addWindow.BirthDateTextBox.Text,
                    PhoneNumber = addWindow.PhoneNumberTextBox.Text,
                    Address = addWindow.AddressTextBox.Text,
                    City = addWindow.CityTextBox.Text,
                    PostalCode = addWindow.PostalCodeTextBox.Text
                });

                StudentListView.Items.Refresh();
            }
        }
    }
}