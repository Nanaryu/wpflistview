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

namespace wpflistview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string m_id { get; set; }
        public string m_name { get; set; }
        public string m_lname { get; set; }
        public string m_p { get; set; }

        class Item
        {
            string name, lname, pesel;
            public Item(string name, string lname, string pesel)
            {
                this.name = name;
                this.lname = lname;
                this.pesel = pesel;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
        }
    }
}