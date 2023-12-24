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
            int choice;
            try {

             choice = Convert.ToInt32(Console.ReadLine());
            } catch (System.FormatException) {
                Console.WriteLine("Invalid option, please try again");
                continue;
            }

            switch (choice) {
                case 1 :
                    Console.WriteLine("Enter values to add to the binary tree or 'exit' to finish:");
 
                while (true)
                {
                    string? input = Console.ReadLine();
                    if (input == null)
                {
                    Console.WriteLine("Error: Input is null.");
                    break;
                }
                
                    if (input.ToLower() == "exit")
                        break;
                    
                    if (int.TryParse(input, out int value))
                    {
                        binaryTree.Insert(value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer or 'exit' to finish.");
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
                    try{
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
                    }
                        catch (System.FormatException) {
                        Console.WriteLine("Invalid option, please try again");
                        continue;
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





