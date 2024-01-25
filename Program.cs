public class BinaryTreeTest
{
    static void Main()
    {
        BinaryTree<Person> binaryTree = new();

        List<Person> people = Person.ReadFromFile();
        foreach(var person in people){
        binaryTree.Insert(person);
        }
 
    Console.WriteLine("Choose what you would like to do below");
    Console.WriteLine("\n______________________________________________________________________");
	
        bool control = true;
 
        while (control)
        {
            Console.WriteLine("\nWhat do you want to do ?");
            Console.WriteLine("\n");
            Console.WriteLine("\t1. Output using inorder traversal");
            Console.WriteLine("\t2. Output using postorder traversal");
            Console.WriteLine("\t3. Search for a node by unique ID");
            Console.WriteLine("\t4. Exit");

            Console.Write("Choice : ");
            int choice;
            try {
                choice = Convert.ToInt32(Console.ReadLine());
            } 
            catch (System.FormatException) {
                Console.WriteLine("Invalid option, please try again");
                continue;
            }

            switch (choice){

                case 1 :
                Console.WriteLine("Inorder Traversal:"+ "\n");
                    binaryTree.InorderTraversal();
                    Console.WriteLine();
                    break;

                case 2 :
                Console.WriteLine("Postorder Traversal:" + "\n");
                    binaryTree.PostorderTraversal();
                    Console.WriteLine();
                    break;

                case 3 :
                    Search(binaryTree);
                
                break;

                case 4 :
                    Console.WriteLine("Bye! Bye!");
                    control = false;
                    break;

                default : Console.WriteLine("Invalid input.Enter a valid choice");
                break; 
            } 
        }
    }
    public static void Search(BinaryTree<Person> binaryTree)
    {
        Console.Write("Search by ID: ");
        string? id = Console.ReadLine();
        if (id is null)
        {
            Console.WriteLine("Invalid input");
            return;
        }
        var person = binaryTree.Search(id);
        Console.WriteLine(person);
    }
}