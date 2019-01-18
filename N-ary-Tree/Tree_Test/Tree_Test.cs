using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_ary_Tree;
using NUnit.Framework;

namespace Tree_Test
{
    [TestFixture]
    public class Tree_Test
    {
        [TestCase]
        public void Test_AddChildNode_int()
        {
            // Arrange
            var TreeInt = new Tree<int>();
            var root = new TreeNode<int>(0, null, new List<TreeNode<int>>());
            // Act
            var gen1c1 = TreeInt.AddChildNode(root, 10);
            var gen2p1 = TreeInt.NextGen(gen1c1);
            var gen2c1 = TreeInt.AddChildNode(gen2p1, 9);
            var gen2c2 = TreeInt.AddChildNode(gen2p1, 8);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(TreeInt.TotalChildren.Count == 3);
                Assert.Contains(gen1c1, TreeInt.TotalChildren);
                Assert.Contains(gen2c1, TreeInt.TotalChildren);
                Assert.Contains(gen2c2, TreeInt.TotalChildren);
                Assert.AreEqual(gen2p1, gen2c1.Parent);
                Assert.AreEqual(gen2p1, gen2c2.Parent);
            });
        }

        [TestCase]
        public void Test_AddChildNode_string()
        {
            // Arrange
            var TreeInt = new Tree<string>();
            var root = new TreeNode<string>(null, null, new List<TreeNode<string>>());
            // Act
            var gen1c1 = TreeInt.AddChildNode(root, "Keeper");
            var gen2p1 = TreeInt.NextGen(gen1c1);
            var gen2c1 = TreeInt.AddChildNode(gen2p1, "Linker Centrale Verdediger");
            var gen2c2 = TreeInt.AddChildNode(gen2p1, "Rechter Centrale Verdediger");
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(TreeInt.TotalChildren.Count == 3);
                Assert.Contains(gen1c1, TreeInt.TotalChildren);
                Assert.Contains(gen2c1, TreeInt.TotalChildren);
                Assert.Contains(gen2c2, TreeInt.TotalChildren);
                Assert.AreEqual(gen2p1, gen2c1.Parent);
                Assert.AreEqual(gen2p1, gen2c2.Parent);
            });
        }

        [TestCase]
        public void Test_removeNode()
        {
            // Arrange
            var TreeInt = new Tree<string>();
            var root = new TreeNode<string>(null, null, new List<TreeNode<string>>());

            var gen1c1 = TreeInt.AddChildNode(root, "Keeper");
            var gen2p1 = TreeInt.NextGen(gen1c1);
            var gen2c1 = TreeInt.AddChildNode(gen2p1, "Linker Centrale Verdediger");
            var gen2c2 = TreeInt.AddChildNode(gen2p1, "Rechter Centrale Verdediger");
            var gen3p1 = TreeInt.NextGen(gen2c1);
            var gen3c1 = TreeInt.AddChildNode(gen3p1, "Linksback");
            // Act
            TreeInt.removeNode(gen2c1);
            // Assert
            Assert.That(TreeInt.TotalChildren.Count == 2);
        }

        [TestCase]
        public void Test_Traversenodes()
        {
            // Arrange
            var TreeInt = new Tree<string>();
            var root = new TreeNode<string>(null, null, new List<TreeNode<string>>());
            var gen1c1 = TreeInt.AddChildNode(root, "Keeper");
            var gen2p1 = TreeInt.NextGen(gen1c1);
            var gen2c1 = TreeInt.AddChildNode(gen2p1, "Linker Centrale Verdediger");
            var gen2c2 = TreeInt.AddChildNode(gen2p1, "Rechter Centrale Verdediger");
            var gen3p1 = TreeInt.NextGen(gen2c1);
            var gen3c1 = TreeInt.AddChildNode(gen3p1, "Linksback");
            // Act
            var traverseNodes = TreeInt.TraverseNodes();
            // Assert
            Assert.AreEqual(traverseNodes.Count, TreeInt.TotalChildren.Count);
        }

        [TestCase]
        public void Test_SumToLeafs()
        {
            // Arrange
            var TreeInt = new Tree<int>();
            var root = new TreeNode<int>(0, null, new List<TreeNode<int>>());
            var gen1c1 = TreeInt.AddChildNode(root, 10);
            var gen2p1 = TreeInt.NextGen(gen1c1);
            var gen2c1 = TreeInt.AddChildNode(gen2p1, 9);
            var gen2c2 = TreeInt.AddChildNode(gen2p1, 8);
            // Act
            var sum = TreeInt.SumToLeafs();
            // Assert
            Assert.That(sum[0] == 19);
            Assert.That(sum[1] == 18);
        }
    }
}
