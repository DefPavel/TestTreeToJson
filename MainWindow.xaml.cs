using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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

namespace TestTreeToJSON
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //GetTreeList(); 
            GetTree();
        }

      /*  private void GetTreeList()
        {
            string path = @"D:\\data.json";

            using (FileStream fstream = File.OpenRead($"{path}"))
            {
                // преобразуем строку в байты
                byte[] array = new byte [fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.UTF8.GetString(array);

                NodeTree node = JsonSerializer.Deserialize<NodeTree>(textFromFile);

                tree.ItemsSource = node.Tree;

               
            }
        }*/
        public  void GetTree()
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://10.0.0.15/api/pers/tree/getAll");   // Создаём запрос
                req.Method = HttpMethod.Get.Method;                                            // Выбираем метод запроса
                req.Accept = "application/json";

                using (WebResponse response =  req.GetResponse())                   // Получаем ответ от сервера
                {
                    using (Stream responseStream = response.GetResponseStream())             // Запускаем поток для чтения содержимого "response"
                    {
                        using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                        {
                            tree.ItemsSource = JsonSerializer.Deserialize<NodeTree>(reader.ReadToEnd()).Tree;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                   // return JsonSerializer.Deserialize<NodeTree>(reader.ReadToEnd());
                }

            }
        }
    }
}
