using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using TEKOM.ViewModel;

namespace TEKOM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        //обработчик события ввода в текстовые поля
        private void tb_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex reg =new Regex(@"^[А-Яа-я]+(-[А-Яа-я]+)?$");
            e.Handled = !(reg.IsMatch(e.Text));
            
        }
    }
}