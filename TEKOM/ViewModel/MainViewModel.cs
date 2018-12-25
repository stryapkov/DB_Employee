using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using TEKOM.Model;


namespace TEKOM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        Logic lg=new Logic();
        
        public RelayCommand AddEmployee { get; set; }
        public RelayCommand DeletEmployee { get; set; }
        public RelayCommand ChangeEmployee { get; set; }

        public MainViewModel()
        {
            AddEmployee=new RelayCommand(Lg.AddEmployee);
            DeletEmployee = new RelayCommand(Lg.DeleteEmployee);
            ChangeEmployee=new RelayCommand(Lg.ChangeEmployee);
        }
        public Logic Lg
        {
            get { return lg; }
            set
            {
                Set(ref lg, value);
                RaisePropertyChanged(nameof(Lg));
            }
        }
        
    }
}