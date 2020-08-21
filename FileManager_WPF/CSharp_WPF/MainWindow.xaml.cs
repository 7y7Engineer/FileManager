/* По заданному пути поиска сформировать списки файлов (в левой панели) и каталогов (в правой панели) 
 * с указанием их атрибутов и даты создания. В меню предусмотреть возможность удаления выбранного файла.
 * Используемые элементы: TextBox, Label, ListView, GridSplitter
*/
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Diagnostics;


namespace Lab5_CSharp_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<MyFileInfo> files;
        public ObservableCollection<MyFileInfo> folders;
        public MainWindow()
        {
            InitializeComponent();
            // создаём специальные ObservableCollection (при добавлении в них элементов, они автоматически обновят элементы показанные в ListView)
            // при добавлении в такие коллекции элементов вызывают специальное событие
            files = new ObservableCollection<MyFileInfo>();   // коллекция для файлов
            folders = new ObservableCollection<MyFileInfo>(); // для папок
            lv_files.ItemsSource = files; // привязываем коллекцию к ListView
            lv_folders.ItemsSource = folders;
        }

        private void Mn_about_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработал студент ПОВТ-16 Власов Никита", "Об авторе",MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Mn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // завершаем приложение
        }

        private void Btn_selectPath_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog()) // открываем диалоговое окно выбора папки анализа
            {
                dialog.Description = "Укажите место расположения папки";
                System.Windows.Forms.DialogResult result = dialog.ShowDialog(); // получаем имя кнопки, по которой закрыли диалоговое окно
                if (result.ToString() == "OK") // если ок, то путь выбрали
                {
                    tb_path.Text = dialog.SelectedPath.ToString(); // кладём в текстбокс путь к выбранной папке
                }
            }

        }
        private void updateInfos()
        {
            files.Clear();
            folders.Clear();
            DirectoryInfo dir;
            try
            {
                dir = new DirectoryInfo(tb_path.Text); // получаем доступ к папке
                var test = dir.GetDirectories(); // делаем тестовое получение
                                                 // ошибку получим только при получении файлов или папок
            }
            catch
            {
                MessageBox.Show("неверный путь", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            foreach (var temp in dir.GetDirectories()) // проходим по всем папкам выбранной директории
            {
                folders.Add(new MyFileInfo(temp.Name, temp.CreationTime, temp.Attributes, temp.FullName)); // каждую папку добавляем в коллекцию папок
            }
            foreach (var temp in dir.GetFiles()) // проходим по всем файлам выбранной директории
            {
                files.Add(new MyFileInfo(temp.Name, temp.CreationTime, temp.Attributes, temp.FullName)); // каждый файл добавляем в коллекцию файлов
            }
        }

        private void Btn_search_Click(object sender, RoutedEventArgs e)
        {
            updateInfos(); // при нажатии кнопки "Поиск" обновляем информацию
        }

        private void Mn_delete_Click(object sender, RoutedEventArgs e)
        {
            MyFileInfo t = (MyFileInfo)lv_files.SelectedItem; // если элемент не был выделен, selectedItem = null
            if (t == null)
            {
                MessageBox.Show("Файл не выбран", "ERROR");
                return;
            }
            FileInfo file = new FileInfo(t.path); // полный путь к файлу хранится в его свойстве path
            try
            {
                file.Delete(); // пытаемся удалить файл
            }
            catch
            {
                MessageBox.Show("Выбранный файл невозможно удалить","ERROR");
                return;
            }
            MessageBox.Show("Файл \""+file.Name+ "\" успешно удалён", "SUCCESS");
            updateInfos();
        }

        private void lv_files_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MyFileInfo t = (MyFileInfo)lv_files.SelectedItem;
            FileInfo file = new FileInfo(t.path);
            try
            {
                Process.Start(file.ToString());
            }
            catch
            {
                MessageBox.Show("Не удалось открыть выбранный файл!", "ERROR");
                return;
            }
        }
    }

    public class MyFileInfo
    {
        public string path { get; set; }
        public string FileName { get; set; }
        public string FileAttribute { get; set; }
        public string createTime { get; set; }
        public MyFileInfo (string name, DateTime crTime, FileAttributes attr, string pth)
        {
            FileName = name;
            createTime = crTime.ToShortDateString() +" "+ crTime.ToLongTimeString(); // соединяем строку даты и строку времени
            path = pth;
            // формируем список атрибутов файла или папки
            FileAttribute = "";
            if ((attr & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                FileAttribute += "R ";
            }
            if ((attr & FileAttributes.Hidden) == FileAttributes.Hidden)
            {
                FileAttribute += "H ";
            }
            if ((attr & FileAttributes.Archive) == FileAttributes.Archive)
            {
                FileAttribute += "A ";
            }
            if ((attr & FileAttributes.System) == FileAttributes.System)
            {
                FileAttribute += "S ";
            }
        }
    }
}
