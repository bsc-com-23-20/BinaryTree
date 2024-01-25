using System;

public class BinaryTree<T> where T : IComparable
{
    Node<T>? root;
    
    public BinaryTree()
    {
        root = null;
    }
    
    public BinaryTree(T value)
    {
        root = new Node<T>(value);
    }
     
    public void Insert(T value)
    {
        if (root == null) 
        {
            root = new Node<T>(value);
        }
        else
        {
            InsertRecursively(value, root);
        }
    }
    
    private void InsertRecursively(T value, Node<T> currentNode)
    {
         
        if (value.CompareTo(currentNode.Value) < 0)
        {
            if (currentNode.Left == null)
            {
                currentNode.Left = new Node<T>(value);
            }
            else
            {
                InsertRecursively(value, currentNode.Left);
            }
        }
        else 
        {
            if (currentNode.Right == null)
            {
                currentNode.Right = new Node<T>(value);
            }
            else
            {
                InsertRecursively(value, currentNode.Right);
            }
        }
    }

 
    public T? Search(T value){
        try
        {
        Node<T>? node = SearchRecursively(root, value) ?? throw new NullReferenceException();
            return node.Value;
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Value does not exist");
            return default;
        }
    }
    
    public Node<T>? SearchRecursively(Node<T>? currentNode, T searchValue){
        if (currentNode == null){
            return null;
        }
        else if(searchValue.CompareTo(currentNode.Value) == 0){
            return currentNode;
        }
        else if(searchValue.CompareTo(currentNode.Value) < 0){
           return SearchRecursively(currentNode.Left, searchValue);
        }
        else{
           return  SearchRecursively(currentNode.Right, searchValue);
        }   
    }

    public void InorderTraversal()
    {
        InorderTraversal(root);
        Console.WriteLine(); 
    }

    public void InorderTraversal(Node<T>? currentNode){
        if (currentNode == null){
            return;
        }
        InorderTraversal(currentNode.Left); 
        Console.Write($"{currentNode.Value}   "); 
        InorderTraversal(currentNode.Right);
    }


    public void PostorderTraversal()
    {
        if (root != null){
        PostorderTraversal(root);
        Console.WriteLine();
    } 
    }

    public void PostorderTraversal(Node<T>? currentNode){
        if (currentNode == null){
            return;
        }
        PostorderTraversal(currentNode.Left);  
        PostorderTraversal(currentNode.Right);
        Console.Write($"{currentNode.Value}   "); 
    }

    public void Delete( T value){
        root = Delete(root, value);
    }

    Node<T>? Delete(Node<T>? currentNode, T value){
        if (currentNode == null){
            return currentNode;
        }
        if (value.CompareTo(currentNode.Value) < 0){
        currentNode.Left = Delete(currentNode.Left, value);
        }
        else if (value.CompareTo(currentNode.Value) > 0){
            currentNode.Right = Delete(currentNode.Right, value);
        }
        else
        {
        if(currentNode.Left == null && currentNode.Right == null){
            currentNode = null;
            return currentNode;
        
            }
            else if(currentNode.Right == null){
                Node<T>? temp = currentNode;
                currentNode = currentNode.Left;
                temp = null;
            }
             else if(currentNode.Left == null){
                Node<T>? temp = currentNode;
                currentNode = currentNode.Right;
                temp = null;
            }
            else
            {
                Node<T> min = FindMinimum(currentNode.Right);
                currentNode.Value = min.Value;
                currentNode.Right = Delete(currentNode.Right, min.Value);

            }
            }
            return currentNode;
            }
        private Node<T> FindMinimum(Node<T> currentNode)
        {
            if (currentNode.Left == null)
            {
                return currentNode;
            }
        return FindMinimum(currentNode.Left);
        }

        public T? GetParent(T value)
        {
            Node<T>? node = GetParentHandler(root, value);
            if (node is null) {
                return default;
            }
            return node.Value;
        } 
        private Node<T>? GetParentHandler(Node<T>? currentNode, T value)
        {
            if (currentNode == null)
            {
                return null;
            }

            if (currentNode.Left != null && currentNode.Left.Value.Equals(value)  ||
                (currentNode.Right != null && currentNode.Right.Value.Equals(value)))
            {
                return currentNode;
            }

            Node<T>? parentLeft = GetParentHandler(currentNode.Left, value);
            // if (parent != null)
            // {
            //     return parent;
            // }

            Node<T>? parentRight = GetParentHandler(currentNode.Right, value);
            return parentLeft ?? parentRight;
        }

        public void GetChildren(T value)
        {
            GetChildren(root, value);
        }
        private void GetChildren(Node<T>? currentNode, T value)
        {
            if (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    if (currentNode.Left != null)
                    {
                        Console.WriteLine("Left child: " + currentNode.Left.Value);
                    }
                    else
                    {
                        Console.WriteLine("No left child");
                    }
        
                    if (currentNode.Right != null)
                    {
                        Console.WriteLine("Right child: " + currentNode.Right.Value);
                    }
                    else
                    {
                        Console.WriteLine("No right child");
                    }
        
                    return;
                }

                GetChildren(currentNode.Left, value);
                GetChildren(currentNode.Right, value);
           
            }
                
        }
}