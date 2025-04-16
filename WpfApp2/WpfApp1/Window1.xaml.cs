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

        class Osoba
        {
            public string? m_strPESEL { get; set; }
            public string? m_strName { get; set; }
            public string? m_strSecName { get; set; }
            public string? m_strSurname { get; set; }
            public Osoba()
            {
                m_strPESEL = "00000000000";
                m_strName = "";
                m_strSecName = "";
                m_strSurname = "";
            }
        }


        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            var student = new Osoba
            {
                m_strPESEL = PeselTextBox.Text,
                m_strName = FirstNameTextBox.Text,
                m_strSecName = SecondNameTextBox.Text,
                m_strSurname = LastNameTextBox.Text
            };

            MessageBox.Show($"Dodano ucznia: {student.m_strName} {student.m_strSurname}");
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