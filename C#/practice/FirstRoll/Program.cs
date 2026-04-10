using System;
using BLL;
using DAL;


namespace  firstroll {
public class Program
    {

    private static readonly StudentService service = new ();
        // static string connectionString = 
        // "Server=localhost,1433;Database=StudentDB;User Id=sa;Password=@dmin123";
    private static void DisplayOptions()
        {
            Console.WriteLine("WELCOME TO YOUR STUDENT MANAGEMENT APPLICATION");
            Console.WriteLine("1. Get all Students");
            Console.WriteLine("2. Add a new Student");
            Console.WriteLine("3. Update a Student (require ID) ");
            Console.WriteLine("4. Delete a Student by (require ID)");
            Console.WriteLine("5. Search a Student by (ID or Name)");
            Console.WriteLine("6. Exit -> \n\n");
            
            Console.Write("Your choice:  ");
            Console.WriteLine("\n");
        }
        
    public static void Main()
        {
                  
        while(true){

            DisplayOptions();
            
            if(!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine("Invalid Option! Try again.");
                    continue;
                }

            switch(option)
            {
                case 1: 
                        service.GetStudents();
                        break;
                case 2:
                        service.AddStudent();
                        break;
                case 3:
                        service.UpdateStudent();
                        break;
                case 4: 
                        service.DeleteStudent();
                        break;
                case 5:
                        service.SearchStudent();
                        break;
                case 6: 
                        Console.WriteLine("Exiting Goodbye!");
                        return;
                default:
                        Console.WriteLine("Invalid Entry - Try again !");
                        break;
            }
            Console.WriteLine("\nEnter ENTER to continue...");
            Console.ReadLine();
        }
            
        }

    
    }
}