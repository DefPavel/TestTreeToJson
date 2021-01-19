using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace TestTreeToJSON
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetTreeList(); 
           
        }
        private void GetTreeList()
        {
            using (FileStream fstream = File.OpenRead("data.json"))
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
        }    
    }
}
