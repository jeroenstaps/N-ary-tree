using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_ary_Tree;

namespace Tree_Use
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> TreeInt = new Tree<int>();
            var root = new TreeNode<int>(0, null, new List<TreeNode<int>>());

            var gen1c1 = TreeInt.AddChildNode(root, 10);

            var gen2p = TreeInt.NextGen(gen1c1);
            var gen2c1 = TreeInt.AddChildNode(gen2p, 9);
            var gen2c2 = TreeInt.AddChildNode(gen2p, 6);

            var gen3p = TreeInt.NextGen(gen2c1);
            var gen3c1 = TreeInt.AddChildNode(gen3p, 7);

            var gen3p2 = TreeInt.NextGen(gen2c2);
            var gen3c2 = TreeInt.AddChildNode(gen3p2, 7);


            var sum1 = TreeInt.SumToLeafs();
            foreach (var sum in sum1)
                Console.WriteLine(sum);
            Console.ReadLine();

            TreeInt.removeNode(gen2c2);

            var traversed = TreeInt.TraverseNodes();
            foreach (var integer in traversed)
                Console.WriteLine(integer);
            Console.ReadLine();

            var sum2 = TreeInt.SumToLeafs();
            foreach (var sum in sum2)
                Console.WriteLine(sum);
            Console.ReadLine();



        }
    }
}
