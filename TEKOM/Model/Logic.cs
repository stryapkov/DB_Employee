using GalaSoft.MvvmLight;
using System.Data.Entity;
using System.Windows;

namespace TEKOM.Model
{
    public class Logic : ViewModelBase
    {
        #region Переменные
        private Employee employee;
        public Employes db;
        //временные переменные, используются для передачи
        //параметров в текстбоксы и для изменения записи в БД
        private string sNameTmp;
        private string nameTmp;
        private string lNameTmp;
        #endregion
        #region Свойства
        public string LNameTmp
       {
           get { return lNameTmp; }
           set {
               Set(ref lNameTmp, value);
               RaisePropertyChanged(nameof(LNameTmp));
           }
       }
        public string NameTmp
        {
            get { return nameTmp; }
            set
            {
                Set(ref nameTmp, value);
                RaisePropertyChanged(nameof(NameTmp));
            }
        }
        public string SNameTmp
        {
            get { return sNameTmp; }
            set
            {
                Set(ref sNameTmp, value);
                RaisePropertyChanged(nameof(SNameTmp));
            }
        }

        public Employee Employee
        {
            get { return employee; }
            set
            {
                if (value != null)
                {
                    employee = value;
                    SNameTmp = value.SurName;
                    LNameTmp = value.LastName;
                    NameTmp = value.Name;
                }
            }
        }
        public Employes DB
        {
            get { return db; }
            set
            {
                Set(ref db, value);
                RaisePropertyChanged(nameof(DB));
            }
        }
        #endregion

        //конструктор класса
        public Logic()
        {
            db = new Employes();
            employee = new Employee();
            db.Employees.Load();
        }

        /// <summary>
        /// метод проверки временных переменных на присвоение значения отличного от NULL
        /// </summary>
        /// <returns></returns>
        bool Flag()
        {
            if (LNameTmp == null | SNameTmp == null | NameTmp == null)
                return false;
            else return true;
        }

        /// <summary>
        /// метод добавлящий сотрудника в список
        /// </summary>
        public void AddEmployee()
        {
            if (Flag()==true)
            {
                Employee employ = new Employee();
                //проверка временных переменных на NULL
                //если временная переменная равна NULL то присваивается выбранное
                //на данный момент значение поля из DataGrid
                employ.LastName = lNameTmp ?? employee.LastName;
                employ.Name = nameTmp ?? employee.Name;
                employ.SurName = sNameTmp ?? employee.SurName;
                //добавление сотрудника и сохранение изменений
                db.Employees.Add(employ);
                db.SaveChanges();
            }
            else MessageBox.Show("Заполните все поля");
        }
        /// <summary>
        /// метод удаления выбранной из таблицы записи
        /// </summary>
        public void DeleteEmployee()
        {
            try
            {
                db.Employees.Remove(db.Employees.Find(Employee.Id));
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Выберете запись из списка");
            }
           
        }
        /// <summary>
        /// метод изменения данных в выбранной из таблицы записи
        /// </summary>
        public void ChangeEmployee()
        {
                //проверка временных переменных на NULL
                //если временная переменная равна NULL то присваивается выбранное
                //на данный момент значение поля из DataGrid
                employee.LastName = lNameTmp ?? employee.LastName;
                employee.Name = nameTmp ?? employee.Name;
                employee.SurName = sNameTmp ?? employee.SurName;
               
                 //сохранение изменений бд
                //а так же обновление DataGrid
                DB.SaveChanges();
                DB = new Employes();
                DB.Employees.Load();
                MessageBox.Show("Объект обновлен");
        }

    }
}
