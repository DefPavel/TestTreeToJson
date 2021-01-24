using System.ComponentModel;

namespace TestTreeToJSON
{
    public class NodeTree
    {
        public NodeTree()
        {
            Tree = new BindingList<itemNode>();
        }
        public BindingList<itemNode> Tree { get; set; } 
    }
    public class itemNode
    {
        public itemNode()
        {
            child = new BindingList<itemNode>();
        }

        private int _id;
        private string _nameDepartment;
        private string _nameShort;
        private int _parent_id;

        public BindingList<itemNode> child { get; set; }

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string nameDepartment
        {
            get { return _nameDepartment; }
            set { _nameDepartment = value; }
        }
        public string nameShort
        {
            get { return _nameShort; }
            set { _nameShort = value; }
        }
        public int parent_id
        {
            get { return _parent_id; }
            set { _parent_id = value; }
        }
 

    }

}
