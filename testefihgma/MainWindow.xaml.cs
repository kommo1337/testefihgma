using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace testefihgma
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

        private void rect374_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void rect376_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SaveData(StatusBX.Text, TimeStartBX.Text, TimeEndBX.Text, DificultBX.Text, NameBX.Text, PhoneBX.Text, ModelBX.Text, YearBX.Text, NumberCarBX.Text, MileageBX.Text, VINBX.Text);
        }
        public void SaveData(string Status, string TimeStart, string TimeEnd, string Dificult, string Name, string Phone, string Model, string Year, string NumberCar, string Mileage, string VIN)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderName = $"Заказ-наряды от {DateTime.Now:yyyy.MM.dd}";
            string folderPath = System.IO.Path.Combine(desktopPath, folderName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = $"Заказ-наярд {DateTime.Now:yyyy.MM.dd_HH.mm}_{GetNextFileNumber(folderPath)}.txt";
            string filePath = System.IO.Path.Combine(folderPath, fileName);
            string data = $"Статус - {Status}\nДата начала - {TimeStart}\nДата окончания - {TimeEnd}\nСложность - {Dificult}\n\nИнформация о клиенте\n\n" +
                $"ФИО - {Name}\nТелефон - {Phone}\nМарка и модель - {Model}\nГод выпуска - {Year}\nНомер машины - {NumberCar}\nПробег - {Mileage}\nVIN номер - {VIN}\n";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(data);
                    MessageBox.Show("Сохранено.");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private int GetNextFileNumber(string directory)
        {
            string[] files = Directory.GetFiles(directory, "*.txt");
            return files.Length + 1;
        }
    }
}
