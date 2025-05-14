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
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;

namespace WpfApp1
{
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void RemoveSel_Click(object sender, RoutedEventArgs e)
        {
            while (mainList.SelectedItems.Count > 0)
            {
                mainList.Items.Remove(mainList.SelectedItems[0]);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki CSV z separatorem (,) |*.csv|Pliki CSV z separatorem (;) |*.csv";
            openFileDialog.Title = "Otwórz plik CSV";
            if (openFileDialog.ShowDialog() == true)
            {
                mainList.Items.Clear();
                string filePath = openFileDialog.FileName;
                int selectedFilterIndex = openFileDialog.FilterIndex;
                string delimiter = ";";
                if (selectedFilterIndex == 1)
                {
                    delimiter = ",";
                }
                Encoding encoding = Encoding.UTF8;
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath, encoding);
                    foreach (var line in lines)
                    {
                        string[] columns = line.Split(delimiter);
                        if (columns != null)
                        {
                            Osoba uczen = new();
                            uczen.m_strPESEL = columns.ElementAtOrDefault(0);
                            uczen.m_strName = columns.ElementAtOrDefault(1);
                            uczen.m_strSecName = columns.ElementAtOrDefault(2);
                            uczen.m_strSurname = columns.ElementAtOrDefault(3);
                            uczen.m_strBirth = columns.ElementAtOrDefault(4);
                            uczen.m_strPhone = columns.ElementAtOrDefault(5);
                            uczen.m_strAddr = columns.ElementAtOrDefault(6);
                            uczen.m_strTown = columns.ElementAtOrDefault(7);
                            uczen.m_strPst = columns.ElementAtOrDefault(8);
                            mainList.Items.Add(uczen);
                        }
                    }
                }
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki CSV z separatorem (,) |*.csv|Pliki CSV z separatorem (;) |*.csv";
            saveFileDialog.Title = "Zapisz jako plik CSV";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                string delimiter = ";";
                if (saveFileDialog.FilterIndex == 1)
                {
                    delimiter = ",";
                }
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Osoba item in mainList.Items)
                    {
                        var row = $"{item.m_strPESEL}{delimiter}{item.m_strName}{delimiter}{item.m_strSecName}{delimiter}{item.m_strSurname}{delimiter}{item.m_strBirth}{delimiter}{item.m_strPhone}{delimiter}{item.m_strAddr}{delimiter}{item.m_strTown}{delimiter}{item.m_strPst}";

                        writer.WriteLine(row);
                    }
                }
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        string checkphone(string txt)
        {
            if (!txt.Contains("+48")) { txt = txt.Insert(0, "+48"); }
            txt = txt.Replace(" ", "");
            return txt;
        }
        string cap(string x)
        {
            if (x.Length > 1)
            {
                return x = x[0].ToString().ToUpper() + x.Remove(0, 1);
            }
            else return x;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            var addWindow = new Window1();
            if (addWindow.ShowDialog() == true)
            {
                mainList.Items.Add(new Osoba
                {
                    m_strPESEL = addWindow.PeselTextBox.Text.Trim(),
                    m_strName = cap(addWindow.FirstNameTextBox.Text.Trim()),
                    m_strSecName = cap(addWindow.SecondNameTextBox.Text.Trim()),
                    m_strSurname = cap(addWindow.LastNameTextBox.Text.Trim()),
                    m_strBirth = addWindow.BirthDateTextBox.Text.Trim(),
                    m_strPhone = checkphone(addWindow.PhoneNumberTextBox.Text.Trim()),
                    m_strAddr = addWindow.AddressTextBox.Text.Trim(),
                    m_strTown = addWindow.CityTextBox.Text.Trim(),
                    m_strPst = addWindow.PostalCodeTextBox.Text.Trim()
                });

                mainList.Items.Refresh();
            }
        }
    }
}