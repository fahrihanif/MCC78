using BasicConnection.Model;

namespace BasicConnection.View;

public class UniversityView
{
    public void Output(University university)
    {
        Console.WriteLine("");
        Console.WriteLine("Id: " + university.Id);
        Console.WriteLine("Name: " + university.Name);
        Console.WriteLine("-----------------------------------------");
    }
    
    public void Output(List<University> universities)
    {
        foreach (var university in universities)
        {
            Output(university);
        }
    }
    
    public void Output(string message)
    {
        Console.WriteLine(message);
    }
}