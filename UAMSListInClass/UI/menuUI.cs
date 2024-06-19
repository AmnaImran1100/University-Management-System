using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMSListInClass.UI
{
    class menuUI
    {
        static public int menu()
        {
            Console.WriteLine("***************************************************");
            Console.WriteLine("                       UAMS                        ");
            Console.WriteLine("***************************************************");
            Console.WriteLine("1. ADD Degree Program");
            Console.WriteLine("2. ADD students");
            Console.WriteLine("3. Generate Merit");
            Console.WriteLine("4. View Registered Students");
            Console.WriteLine("5. View Students of the Specific Program");
            Console.WriteLine("6. Register Subjects foe the Specific Student");
            Console.WriteLine("7. Calculate Fees for all Registered Students");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your option = ");
            int option = int.Parse(Console.ReadLine());
            return option;
        }

        static public void clear()
        {
            Console.WriteLine("Press any Key to Continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
