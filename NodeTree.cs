using System.Collections.ObjectModel;

namespace TestTreeToJSON
{
    public class NodeTree
    {
        public NodeTree()
        {
            Tree = new ObservableCollection<itemNode>();
        }
        public ObservableCollection<itemNode> Tree { get; set; } 
    }
    public class itemNode
    {
        public itemNode()
        {
            child = new ObservableCollection<itemNode>();
        }
        public ObservableCollection<itemNode> child { get; set; }
        public int id { get; set; }
        public string nameDepartment { get; set; }
        public string nameShort { get; set; }
        public int parent_id { get; set; }     

    }

}
