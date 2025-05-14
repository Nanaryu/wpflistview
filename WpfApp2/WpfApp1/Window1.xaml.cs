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
            public string? m_strBirth { get; set; }
            public string? m_strPhone { get; set; }
            public string? m_strAddr { get; set; }
            public string? m_strTown { get; set; }
            public string? m_strPst { get; set; }
            public Osoba()
            {
                m_strPESEL = "00000000000";
                m_strName = "";
                m_strSecName = "";
                m_strSurname = "";
                m_strBirth = "";
                m_strPhone = "";
                m_strAddr = "";
                m_strTown = "";
                m_strPst = "";
            }
        }
        string cap(string x)
        {
            if (x.Length > 1)
            {
                return x = x[0].ToString().ToUpper() + x.Remove(0, 1);
            }
            else return x;
        }

        bool checksum(string pesel)
        {
            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int sum = 0;

            if (pesel.Length != 11 || !pesel.All(char.IsDigit))
                return false;

            for (int i = 0; i < 10; i++)
            {
                int digit = int.Parse(pesel[i].ToString());
                sum += digit * weights[i];
            }

            int lastDigit = (10 - (sum % 10)) % 10;
            int controlDigit = int.Parse(pesel[10].ToString());

            return controlDigit == lastDigit;
        }

        bool checkbdate(string pesel, string bdate)
        {
            string[] dmy = bdate.Split('.');

            if (dmy.Length != 3)
            {
                return false;
            }

            int year = int.Parse(pesel.Substring(0, 2));
            int month = int.Parse(pesel.Substring(2, 2));
            int day = int.Parse(pesel.Substring(4, 2));

            if (month > 20)
            {
                year += 2000;
                month -= 20;
}
            else { year += 1900; }

            if (year == int.Parse(dmy[2]) && month == int.Parse(dmy[1]) && day == int.Parse(dmy[0])) 
            {
                return true;
            }

            return false;
        }

        string checkphone(string txt)
        {
            
            if (!txt.Contains("+48")) {txt = txt.Insert(0, "+48");}
            txt = txt.Replace(" ", "");
            txt = txt.Substring(0, 12);
            txt.Insert(2, " ");
            return txt;
        }


        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (isrequired())
            {
                if (!checkbdate(PeselTextBox.Text, BirthDateTextBox.Text))
                {
                    MessageBox.Show("Data urodzenia nie zgadza się z PESEL!");
                    return;
                }
                if (PeselTextBox.Text.Trim().Length != 11)
                {
                    MessageBox.Show("PESEL musi mieć 11 cyfr!");
                    return;
                }

                if (!checksum(PeselTextBox.Text))
                {
                    MessageBox.Show("Błędny PESEL!");
                    return;
                }

                var student = new Osoba
                {
                    m_strPESEL = PeselTextBox.Text.Trim(),
                    m_strName = cap(FirstNameTextBox.Text.Trim()),
                    m_strSecName = cap(SecondNameTextBox.Text.Trim()),
                    m_strSurname = cap(LastNameTextBox.Text.Trim()),
                    m_strBirth = BirthDateTextBox.Text.Trim(),
                    m_strPhone = checkphone(PhoneNumberTextBox.Text.Trim()),
                    m_strAddr = AddressTextBox.Text.Trim(),
                    m_strTown = CityTextBox.Text.Trim(),
                    m_strPst = PostalCodeTextBox.Text.Trim()
                };
                MessageBox.Show($"Dodano ucznia: {student.m_strName} {student.m_strSurname}");
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Wypełnij wszystkie wymagane pola!");
            }
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

        private bool isrequired()
        {
            return !string.IsNullOrWhiteSpace(PeselTextBox.Text) &&
                   !string.IsNullOrWhiteSpace(FirstNameTextBox.Text) &&
                   !string.IsNullOrWhiteSpace(LastNameTextBox.Text) &&
                   !string.IsNullOrWhiteSpace(BirthDateTextBox.Text) &&
                   !string.IsNullOrWhiteSpace(AddressTextBox.Text) &&
                   !string.IsNullOrWhiteSpace(CityTextBox.Text) &&
                   !string.IsNullOrWhiteSpace(PostalCodeTextBox.Text);
        }
    }
}