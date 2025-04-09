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

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

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


            private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            var student = new Student
            {
                Pesel = PeselTextBox.Text,
                FirstName = FirstNameTextBox.Text,
                SecondName = SecondNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                BirthDate = BirthDateTextBox.Text,
                PhoneNumber = PhoneNumberTextBox.Text,
                Address = AddressTextBox.Text,
                City = CityTextBox.Text,
                PostalCode = PostalCodeTextBox.Text
            };

            MessageBox.Show($"Dodano ucznia: {student.FirstName} {student.LastName}");
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (isinputted())
            {
                var result = MessageBox.Show("Czy na pewno chcesz zamknąć?", "", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.No)
                {
                    return;
                }
            }

            DialogResult = false;
            Close();
        }

        private bool isinputted()
        {
            return !string.IsNullOrWhiteSpace(PeselTextBox.Text) ||
                   !string.IsNullOrWhiteSpace(FirstNameTextBox.Text) ||
                   !string.IsNullOrWhiteSpace(SecondNameTextBox.Text) ||
                   !string.IsNullOrWhiteSpace(LastNameTextBox.Text) ||
                   !string.IsNullOrWhiteSpace(BirthDateTextBox.Text) ||
                   !string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text) ||
                   !string.IsNullOrWhiteSpace(AddressTextBox.Text) ||
                   !string.IsNullOrWhiteSpace(CityTextBox.Text) ||
                   !string.IsNullOrWhiteSpace(PostalCodeTextBox.Text);
        }
    }
}
