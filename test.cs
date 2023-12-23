public class BinaryTreeTest
{
    static void Main()
    {
        BinaryTree<int> binaryTree = new BinaryTree<int>();
 

    Console.WriteLine("Choose what you would like to do below");
    Console.WriteLine("\n______________________________________________________________________");
	
 
        bool control = true;
 
        while (control)
        {
            Console.WriteLine("\nWhat do you want to do ?");
            Console.WriteLine("\n");
            Console.WriteLine("\t1. Insert new nodes");
            Console.WriteLine("\t2. Display output using inorder traversal");
            Console.WriteLine("\t3. Display output using postorder traversal");
            Console.WriteLine("\t4. Search for a node");
            Console.WriteLine("\t5. Print the immediate parent of a node");
            Console.WriteLine("\t6. Print the immediate children of a node");
            Console.WriteLine("\t7. Delete a node");
            Console.WriteLine("\t8. Exit");

            Console.Write("Choice : ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice) {
                case 1 :
                    Console.WriteLine("Enter values to add to the binary tree (enter 'finish' to finish):");
 
                while (true)
                {
                    string input = Console.ReadLine();
                
                    if (input.ToLower() == "finish")
                        break;
                
                    if (int.TryParse(input, out int value))
                    {
                        binaryTree.Insert(value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer or 'done' to finish.");
                    }
                }
                break;

                case 2 : 
                Console.WriteLine("Inorder Traversal:");
                        binaryTree.InorderTraversal();
                        Console.WriteLine();
                        break;
                case 3 : 
                    Console.WriteLine("Postorder Traversal:");
                        binaryTree.PostorderTraversal();
                        Console.WriteLine();
                        break;

                case 4 : 
                    Console.Write("Enter the value to search: ");
                    int searchValue = Convert.ToInt32(Console.ReadLine());
                    int? found = binaryTree.Search(searchValue);

                    if (found.HasValue && found.Value == searchValue)
                    {
                        Console.WriteLine($"Node with value {searchValue} found in the binary tree.");
                        
                    }
                    else
                    {
                        Console.WriteLine("Node not found in the binary tree.");
                    }
                    break;

                case 5 :
                    Console.Write("Enter the value to find its parent: ");
                    int parentValue = Convert.ToInt32(Console.ReadLine());
                    int? parent = binaryTree.GetParent(parentValue);
                    if (parent != null)
                    {
                        Console.WriteLine("Parent of the node: " + parent);
                    }
                    else
                    {
                        Console.WriteLine("Node not found or it is the root node.");
                    }
                    break;

                case 6 :
                    Console.Write("Enter the value to find its children: ");
                    int childrenValue = Convert.ToInt32(Console.ReadLine());
                    binaryTree.GetChildren(childrenValue);
                    break;

                case 7 :
                    Console.Write("Enter the value to delete: ");
                        int deleteValue = Convert.ToInt32(Console.ReadLine());
                        int? foundValue = binaryTree.Search(deleteValue);

                        if (foundValue.HasValue)
                        {
                            binaryTree.Delete(deleteValue);
                            Console.WriteLine($"Deleted {foundValue} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"Value {foundValue} not found in the binary tree. No deletion performed.");
                        }
                        break;



                case 8 : 
                    Console.WriteLine("Bye! Bye!");
                    control = false; // break the loop
                    break;

                default : Console.WriteLine("Invalid input.Enter a valid choice");
                break; 
            }
       } 
    }
    
    

    }





// public class BinarySearchTreeTest
// {
//     static void Main()
//     {
//         BinaryTree<int> bst1 = new BinaryTree<int>(54);
//         bst1.Insert(25);
//         bst1.Insert(12);
//         bst1.Insert(43);
//         bst1.Insert(23);
//         bst1.Insert(60);
//         bst1.Insert(90);
//         bst1.Insert(15);

//          Console.WriteLine("Inorder Traversal:");
//         bst1.InorderTraversal();

//          Console.WriteLine("Postorder Traversal:");
//         bst1.PostorderTraversal();

//         // bst1.Search(43);
//         Console.WriteLine("value: {0}", bst1.Search(100));
//         bst1.InorderTraversal();

//         bst1.Delete(43);
//         Console.WriteLine("Inorder Traversal after deletion:");
//         bst1.InorderTraversal();


//     }
//     }