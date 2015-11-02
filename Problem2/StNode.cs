using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Problem2
{
    public class StNode
    {
        private readonly List<StNode> _children = new List<StNode>();

        public StNode(string value)
        {
            Value = value;
            Range = 1;
            Nodeid = 0;
        }

        public long Nodeid { get; private set; }

        public StNode Parent { get; private set; }

        public string Value { get; set; }

        public int Range { get; private set; }

        public StNode this[int index]
        {
            get { return _children[index]; }
        }

        public int Level
        {
            get { return Ancestors.Count(); }
        }


        public bool IsRoot
        {
            get { return Parent == null; }
        }

        public IList<StNode> Children
        {
            get { return _children; }
        }

        public IEnumerable<StNode> Ancestors
        {
            get
            {
                if (IsRoot)
                {
                    return Enumerable.Empty<StNode>();
                }
                return Parent.ToIEnumarable().Concat(Parent.Ancestors);
            }
        }

        public StNode Insert(IEnumerable<StNode> nodes, int level)
        {
            foreach (var stNode in nodes)
            {
                Insert(stNode, level);
            }
            return this;
        }


        public void Add(List<StNode> nodelist2)
        {
            foreach (var stNode in nodelist2)
            {
                Add(stNode);
            }
        }

        private void Insert(StNode stNode, int level)
        {
            if (Level < 0) throw new InvalidEnumArgumentException("level has to be greater than or equal to zero");

            if (level < Level)
            {
                if (Parent != null)
                    Parent.Insert(stNode, level);
                else
                {
                    Parent = stNode;
                }
            }
            else if (level > Level)
            {
                var child = Children.FirstOrDefault();
                if (child != default(StNode))
                {
                    child.Insert(stNode, level);
                }
                else
                {
                    _children.Add(stNode);
                    stNode.Parent = this;
                }
            }
            else
            {
                if (IsRoot)
                    throw new InvalidEnumArgumentException("could not insert at root level, root alreay present");

                Parent.Children.Add(stNode);
                stNode.Parent = Parent;
            }
            stNode.ReArrange();
        }


        private void Add(StNode stNode)
        {
            Children.Add(stNode);
            stNode.Parent = this;
            stNode.ReArrange();
        }

        private void ReArrange()
        {
            Nodeid = GenerateNodeId();

            if (Parent != null) Range = Parent.Range + 1;
            else Range = 1;
        }

        private long GenerateNodeId()
        {
            var parentRange = Parent.Range.ToString();
            var nodeid = Parent.Children.Max(x => x.Nodeid);
            var maxNodeId = nodeid.ToString();

            if (maxNodeId.Length > parentRange.Length)
            {
                nodeid = int.Parse(maxNodeId.Substring(parentRange.Length, maxNodeId.Length - 1)) + 1;
            }

            return int.Parse(parentRange + nodeid);
        }
    }
}