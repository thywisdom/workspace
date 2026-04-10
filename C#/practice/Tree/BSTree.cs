using System;

namespace Tree{
class Node
{
    public int Data ;
    public Node Left, Right;
    public Node(int Data)
    {
        this.Data = Data;
        Left = null;
        Right = null;
    }
}

class BSTree
{
    public Node Root;

    public void Insert(int data){ Root = InsertRec(Root,data);}

    private Node InsertRec(Node root , int data)
    {
        if(root == null)
        {
            root = new Node(data);
            return root;
        }

        if( root.Data > data)
        {
             root.Left = InsertRec(root.Left, data);
        }
        else if ( root.Data < data)
        {
             root.Right = InsertRec(root.Right,data);
        }

        return root;
    }

    public void Inorder(Node root)
    {
        if(root != null)
        {
            Inorder(root.Left);
            Console.Write($"{root.Data} ");
            Inorder(root.Right);
        }

    }
    public void Preorder(Node root)
    {
        if(root != null)
        {
            
            Console.Write($"{root.Data} ");
            Preorder(root.Left);
            Preorder(root.Right);
        }
    }
    public void Postorder(Node root)
    {
        if(root != null)
        {
            
            Console.Write($"{root.Data} ");
            Postorder(root.Left);
            Postorder(root.Right);
        }
    }
}
}