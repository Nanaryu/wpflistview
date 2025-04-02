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

namespace wpflistview
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
        class Newitem
        {
            public string m_id { get; set; }
            public string m_name { get; set; }
            public string m_lname { get; set; }
            public string m_p { get; set; }
            Random rnd = new Random();

            public Newitem(string _name, string _lname, string _p)
            {
                m_id = rnd.Next().ToString();
                m_name = _name;
                m_lname = _lname;
                m_p = _p;
            }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Owner as MainWindow;
            mainWindow.ListView.Items.Add(new { m_id = rnd.Next(10000).ToString(), m_name = n1.Text, m_lname = n2.Text, m_p = n3.Text });
            this.Close();
        }
    }
}
