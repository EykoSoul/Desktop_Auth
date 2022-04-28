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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TelekomNevaSvyz
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Константное значение символов для генерации кода
        public static readonly string [] symbols = {"2","3","4","5","6","7","8","9","A","B","Y","X","Z","$","@","#"};
        private void Login_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Kod_TB.Text == code && is_login_timeout != false)
            {
                MessageBox.Show("Успешная авторизация!");
                var caller = new WindowFolder.CallerWindow();
                caller.Show();
                this.Close();
            }
            //if (Kod_TB.Text == kode && is_login_timeout != false) MessageBox.Show("Успешная авторизация!");
        }
        
        //Метод генерации одноразового кода
        public static string Generate_Code(int length)
        {
            string s = "";
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                s += symbols[rand.Next(0, 15)];
            }
            return s;
        }
       
        //поле для хранения логического значения
        public static bool is_login_timeout = true;
        private async void Async_Method()
        {
            for (int i = 0; i < 30; i++)
            {
                await Task.Delay(1000);
            }
            is_login_timeout = false;
        }

        //Ввод номера
        private void Namber_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (new DataBase.DemoBKEntities().ТехПерсонал.FirstOrDefault(i => i.Номер_телефона == Namber_TB.Text.Trim()) != null) Pass_PB.IsEnabled = true;
           
        }

        //Ввод пароля
        public static string code = "none";
        private void Window_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (new DataBase.DemoBKEntities().ТехПерсонал.FirstOrDefault(i => i.Пароль == Pass_PB.Password.Trim()) != null && e.Key == Key.Enter)
            {
                code = Generate_Code(8);
                MessageBox.Show(code);
                Async_Method();
            }
            
        }
        public static string kode = "";
        private void UpdKod_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (new DataBase.DemoBKEntities().ТехПерсонал.FirstOrDefault(i => i.Пароль == Pass_PB.Password.Trim()) != null)
            {
                kode = Generate_Code(8);
                MessageBox.Show(kode);
                Async_Method();
            }
        }

        private void Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            Namber_TB.Clear();
            Pass_PB.Clear();
            Kod_TB.Clear();
        }
    }
}
