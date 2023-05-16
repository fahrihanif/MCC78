using BasicConnection.Model;

namespace BasicConnection.View;

public class EducationView
{
    public void Output(Education education)
    {
        Console.WriteLine("");
        Console.WriteLine("Id: " + education.Id);
        Console.WriteLine("Major: " + education.Major);
        Console.WriteLine("Degree: " + education.Degree);
        Console.WriteLine("GPA: " + education.GPA);
        Console.WriteLine("Universty Id : " + education.UniversityId);
        Console.WriteLine("-----------------------------------------");
    }
}