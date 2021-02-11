using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Semordnilap.View
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public static readonly DependencyProperty TextCodeProperty =
            DependencyProperty.Register("TextCode", typeof(string), typeof(TextBox), new PropertyMetadata(null));

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            TextCode = "GAC";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //TODO: Property should be List<Nucleobase>, use a converter
        public string TextCode
        {
            get { return (string)GetValue(TextCodeProperty); }
            set { 
                SetValue(TextCodeProperty, value);
                OnPropertyChanged("TextCode");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //testbutton
        }

    }


}
