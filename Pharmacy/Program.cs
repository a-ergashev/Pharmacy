using Pharmacy.Database;
using Pharmacy.Models;


namespace Pharmacy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ControlMenu();
        }
        public static void ControlMenu()
        {
            Console.WriteLine("Welcome!\nUse the following commands to navigate through the program:");
            MedicineRepository database = new MedicineRepository();

            int command = -1;
            while(command != 0)
            {
                Console.Write("1 - Show All | 2 - Find | 3 - Add | 4 - Update | 5 - Delete | 6 - Exit\n> ");

                command = int.Parse(Console.ReadLine());

                if(command == 1)
                {
                    database.ShowAll();
                } 
                else if(command == 2)
                {
                    Console.Write("Enter keyword: ");
                    string? keyword = Console.ReadLine().ToLower();

                    Medicine? medicine = database.Find(keyword);
                    if (medicine != null)
                        medicine.Show();
                    else
                        Console.WriteLine("Not found");
                } 
                else if(command == 3)
                {
                    Console.WriteLine("Enter medicine info: ");
                    #region Inputting medicine data
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    #endregion

                    Medicine medicine = new Medicine()
                    {
                        Name = name,
                        Price = price
                    };
                    database.AddMedicine(medicine);
                    Console.WriteLine("Element added!");
                } 
                else if(command == 4)
                {
                    Console.Write("Specify medicine's ID: ");
                    int id = int.Parse(Console.ReadLine());

                    #region Inputting medicine data
                    Console.WriteLine("\nUpdate contents");
                    Console.Write("Name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Price: ");
                    decimal newPrice = decimal.Parse(Console.ReadLine());
                    #endregion

                    Medicine medicine = new Medicine()
                    {
                        Name = newName,
                        Price = newPrice
                    };
                    database.UpdateMedicine(id, medicine);
                    Console.WriteLine("Medicine updated!");
                }
                else if(command == 5)
                {
                    Console.Write("Enter medicine ID: ");
                    database.DeleteMedicine(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Medicine deleted!");
                } 
                else if(command == 6)
                    break;
                else
                    Console.WriteLine("Unspecified command number");
                Console.WriteLine();
            }
            
            Console.WriteLine("Bye!");
        }
    }
}