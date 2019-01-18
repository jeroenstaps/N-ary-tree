using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_ary_Tree
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Parent { get; set; }
        public List<TreeNode<T>> Children { get; set; }
        public int index { get; set; }
        public TreeNode(T value, TreeNode<T> parent, List<TreeNode<T>> children)
        {
            this.Value = value;
            this.Parent = parent;
            this.Children = children;
            this.index = 0;
        }
    }

    public class Tree<T>
    {
        public int Count { get; set; }
        public int LeafCount { get; set; }
        public List<TreeNode<T>> TotalChildren = new List<TreeNode<T>>();
        public int maxIndex { get; set; }

        public Tree()
        {
            Count = 0;
            LeafCount = 0;
            maxIndex = 0;
        }

        public TreeNode<T> AddChildNode(TreeNode<T> parentNode, T Value)
        {
            TreeNode<T> childsNode = new TreeNode<T>(Value, parentNode, new List<TreeNode<T>>());
            TotalChildren.Add(childsNode);
            parentNode.Children.Add(childsNode);

            childsNode.index = 1 + childsNode.Parent.index;
            if (maxIndex < childsNode.index)
                maxIndex = childsNode.index;

            LeafCount++;
            Count++;

            return childsNode;
        }

        public TreeNode<T> NextGen(TreeNode<T> childNode)
        {
            TreeNode<T> parentNode = childNode;
            LeafCount--;
            return parentNode;
        }

        public List<T> TraverseNodes()
        {
            List<T> nodes = new List<T>();
            for (int i=1; i<=maxIndex; i++)
            {
                foreach (TreeNode<T> node in TotalChildren)
                    if (node.index == i)
                        nodes.Add(node.Value);
            }
            return nodes;
        }

        public void removeNode(TreeNode<T> node)
        {
            this.TotalChildren.Remove(node);
            var parentNode = node.Parent;
            parentNode.Children.Remove(node);
            Count--;

            if (node.Children.Count == 0)
                LeafCount--;
            else if (node.Children.Count != 0)
            {
                for (int i = node.Children.Count-1;i>=0;i--)
                {
                    removeNode(node.Children[i]);
                }
            }
        }

        public List<T> SumToLeafs()
        {
            List<TreeNode<T>> leafs = new List<TreeNode<T>>();
            foreach (TreeNode<T> child in TotalChildren)
                if (child.Children.Count == 0)
                    leafs.Add(child);

            List<T> sumList = new List<T>();
            foreach(TreeNode<T> leaf in leafs)
            {
                dynamic sum = default(T);
                var updateNode = leaf;
                for(int i = 0; i < maxIndex; i++)
                {
                    sum += updateNode.Value;
                    updateNode = updateNode.Parent;
                } 
                sumList.Add(sum);
            }
            return sumList;
        }
    }
}