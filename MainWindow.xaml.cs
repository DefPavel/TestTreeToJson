using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace TestTreeToJSON
{
    public partial class MainWindow : Window , INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            GetTreeList();
            DataContext = this;
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

        private void tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            nodeItem = e.NewValue as itemNode;

            MessageBox.Show(nodeItem.id.ToString());
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private itemNode _nodeItem;
        public itemNode nodeItem
        {
            get
            {
                return _nodeItem;
            }
            set
            {
                _nodeItem = value;
                RaisePropertyChanged("nodeItem");
            }
        }
        private void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
