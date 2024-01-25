using System.Text;
using System.Text.RegularExpressions;
public partial class Person : IComparable<Person>

{
    private string FirstName { get; set; }
    private string LastName { get; set; }
    private int Age { get; set; }
    private string UniqueID { get; set; }   
    public Person(string firstName, string lastName, int age, string uniqueID )
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        UniqueID = uniqueID;
    }

    public override string ToString()
    {
        string person = "FirstName: " + FirstName + "\nLastName: " + LastName + "\nAge: " + Age + "\nID: " + UniqueID + "\n";
        return person + "\n";
    }

    public override bool Equals(object? obj)
    {
        if (obj is not null)
        {
            string otherId = (string)obj;
            return UniqueID.Equals(otherId);
        }
        return false;
    }

    public int CompareTo(Person? other)
    {
        if (other is null){
            return -1;
        }
        int otherAge = other.Age;
        return Age.CompareTo(otherAge);
    }
   
    public static List<Person> ReadFromFile()
    {
        List<Person> people = new();
        try {
            var lines = File.ReadAllText("./COM314.TXT");
            Regex regex = MyRegex();
            string[] entities = lines.Split(new[] {"\r\n\r\n", "\n\n"}, StringSplitOptions.RemoveEmptyEntries);
            foreach(string person in entities)
            {
                Match match = regex.Match(person);
                if (match.Success)
                {
                    string firstName = match.Groups[1].Value;
                    string lastName = match.Groups[2].Value;
                    int age = int.Parse(match.Groups[3].Value);
                    string uniqueID = match.Groups[4].Value;
                     if (people.Any(p => p.UniqueID == uniqueID))
                        {
                            Console.WriteLine($"Node with unique ID '{uniqueID}' skipped, it already exists.");
                            continue;
                        }
                    Person person1 = new(firstName,lastName,age,uniqueID);
                    people.Add(person1);
                    
                }
            }
            return people;
        }
        catch (Exception e) {
            Console.WriteLine("Error: {0}", e);
            return people;
        }
    }
    [GeneratedRegex("^(.+)\\r?\\n(.+)\\r?\\n(\\d+)\\r?\\n(.+)$")]
    private static partial Regex MyRegex();

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}
