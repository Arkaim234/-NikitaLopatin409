using System;
using System.Threading;

class ThreadSafeBinaryTree
{
    private class Node
    {
        public int Value;
        public Node Left, Right;

        public Node(int value)
        {
            Value = value;
        }
    }

    private Node root;
    private ReaderWriterLockSlim treeLock = new ReaderWriterLockSlim();

    public void Add(int value)
    {
        treeLock.EnterWriteLock();
        try
        {
            root = AddRecursive(root, value);
        }
        finally
        {
            treeLock.ExitWriteLock();
        }
    }

    private Node AddRecursive(Node node, int value)
    {
        if (node == null)
            return new Node(value);

        if (value < node.Value)
            node.Left = AddRecursive(node.Left, value);
        else if (value > node.Value)
            node.Right = AddRecursive(node.Right, value);
        // Дубликаты игнорируем

        return node;
    }

    public bool Contains(int value)
    {
        treeLock.EnterReadLock();
        try
        {
            return ContainsRecursive(root, value);
        }
        finally
        {
            treeLock.ExitReadLock();
        }
    }

    private bool ContainsRecursive(Node node, int value)
    {
        if (node == null)
            return false;

        if (value == node.Value)
            return true;
        else if (value < node.Value)
            return ContainsRecursive(node.Left, value);
        else
            return ContainsRecursive(node.Right, value);
    }

    public void Print()
    {
        treeLock.EnterReadLock();
        try
        {
            PrintRecursive(root, 0);
        }
        finally
        {
            treeLock.ExitReadLock();
        }
    }

    private void PrintRecursive(Node node, int indent)
    {
        if (node != null)
        {
            PrintRecursive(node.Right, indent + 4);
            Console.WriteLine(new string(' ', indent) + node.Value);
            PrintRecursive(node.Left, indent + 4);
        }
    }
}

