using System;

public class BinaryTree<T> where T : IComparable
{
    Node<T>? root;
    
    public BinaryTree()
    {
        root = null;
    }
    /* 
    Constructor initiates the root node of the tree with the provided value
    */
    public BinaryTree(T value)
    {
        root = new Node<T>(value);
    }
    /*
    inserts a new value in the binary tree
    */ 
    public void Insert(T value)
    {
        if (root == null) //if tree is empty, create a new node at root
        {
            root = new Node<T>(value);
        }
        else
        {
            InsertRecursively(value, root);
        }
    }
    // does the recursive insertion assertion till it finds a null node
    private void InsertRecursively(T value, Node<T> currentNode)
    {
        /*
        checks if the new value is less than the value on the current node
        it inserts the new value to the left if the condition is true
        */
         
        if (value.Equals(currentNode.Value))
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
        /*
        if the value is greater than or equal to the value on the current node
        it inserts the new value to the right 
        */
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

    /**
 * Searches for a node with the given value in the binary tree.
 */
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
        else if(searchValue.Equals(currentNode.Value)){
            return currentNode;
        }
        else if(searchValue.Equals(currentNode.Value)){
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
        // a recursive call to go search for the node in left subtree if value being inserted is less than the root
        if (value.Equals(currentNode.Value) ){
        currentNode.Left = Delete(currentNode.Left, value);
        }
        else if (value.Equals(currentNode.Value) ){
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
            return GetParent(root, value);
        }

        private T? GetParent(Node<T>? currentNode, T value)
        {
            if (currentNode == null)
            {
                return default;
            }

            if (currentNode.Left != null && currentNode.Left.Value.Equals(value)  ||
                (currentNode.Right != null && currentNode.Right.Value.Equals(value)))
            {
                return currentNode.Value;
            }

            T? parent = GetParent(currentNode.Left, value);
            if (parent != null)
            {
                return parent;
            }

            parent = GetParent(currentNode.Right, value);
            return parent;
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
        
                
            }
                GetChildren(currentNode.Left, value);
                GetChildren(currentNode.Right, value);

        }
}