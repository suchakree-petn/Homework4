class Program
{
    static Tree<string> tree = new Tree<string>();

    static void Main(string[] args)
    {
        Queue<TreeNode<string>> queue = new Queue<TreeNode<string>>();
        TreeNode<string> parent = null;
        Input(parent, queue);
        TreeNode<string> popNode = null;
        pointing(queue, popNode);
        Queue<string> queue2 = new Queue<string>();
        string target = Console.ReadLine();
        if (target != tree.Get(0))
        {
            do
            {
                target = FindPrevTarget(target).GetValue();
                Console.WriteLine(target);
            } while (target != tree.Get(0));
        }
        else
        {
            Console.WriteLine(tree.Get(0));
        }
    }
    static TreeNode<string> FindPrevTarget(string name)
    {
        for (int i = 0; i < tree.GetLength(); i++)
        {
            TreeNode<string> node = tree.GetTreeNode(i);
            if (node.Child() != null)
            {
                if (node.Child().GetValue() == name)
                {
                    return tree.GetTreeNode(i);

                }
            }
            if (node.Next() != null)
            {
                if (node.Next().GetValue() == name)
                {
                    return FindPrevTarget(tree.Get(i));
                }
            }
        }
        return null;
    }
    static TreeNode<string> pointing(Queue<TreeNode<string>> queue, TreeNode<string> popNode)
    {
        popNode = queue.Pop();
        if (tree.GetLength() == 0)
        {
            tree.AddChild(-1, popNode.GetValue());
        }
        while (popNode.GetMaxChild() > 0)
        {
            if (popNode.Child() == null)
            {
                popNode.SetChild(pointing(queue, popNode));
                tree.AddLenght();
            }
            else
            {
                TreeNode<string> ptr = popNode;
                ptr = ptr.Child();
                while (ptr.Next() != null)
                {
                    ptr = ptr.Next();
                }
                ptr.SetNext(pointing(queue, popNode));
                tree.AddLenght();
            }
            popNode.ReduceChild();
        }
        if (queue.GetLength() == 0 && popNode.GetValue() == tree.Get(0))
        {
            tree.GetTreeNode(0).SetChild(popNode.Child());
            popNode.SetChild(null);
        }
        return popNode;
    }
    static void Input(TreeNode<string> parent, Queue<TreeNode<string>> queue)
    {
        parent = new TreeNode<string>(Console.ReadLine());
        int child = int.Parse(Console.ReadLine());
        parent.SetMaxChild(child);
        queue.Push(parent);
        while (child > 0)
        {
            Input(parent, queue);
            child--;
        }
    }
}