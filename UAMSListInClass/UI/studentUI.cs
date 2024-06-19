using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMSListInClass.BL;
using UAMSListInClass.UI;
using UAMSListInClass.DL;

namespace UAMSListInClass.UI
{
    class studentUI
    {
        static public studentBL getInfoAboutStudent()
        {
            List<majorBL> preferences = new List<majorBL>();
            Console.Write("Enter Student Name = ");
            string name = Console.ReadLine();
            Console.Write("Enter Student Age = ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter FSC Marks = ");
            float fscMarks = float.Parse(Console.ReadLine());
            Console.Write("Enter ECAT Marks = ");
            float ecatMarks = float.Parse(Console.ReadLine());

            Console.WriteLine("Available Degree Programs");
            majorUI.viewDegreeProgram();

            Console.Write("How many preferences to enter =");
            int prefNumber = int.Parse(Console.ReadLine());
            for (int x = 0; x < prefNumber; x++)
            {
                string degName = Console.ReadLine();
                bool flag = false;
                foreach (majorBL m in majorDL.majorList)
                {
                    if (degName == m.getDegreeName() && !(preferences.Contains(m)))
                    {
                        preferences.Add(m);
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Invalid Degree Program Name");
                    x--;
                }
            }

            studentBL s = new studentBL(name, age, fscMarks, ecatMarks, preferences);
            return s;
        }

        static public void registeredStudents()
        {
            Console.WriteLine("NAME" + "\t\t" + "FSC" + "\t\t" + "ECAT" + "\t\t" + "AGE");
            foreach (studentBL s in studentDL.studentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.getName() + "\t\t" + s.getFscMarks() + "\t\t" + s.getEcatMarks() + "\t\t" + s.getAge());
                }
            }
        }

        static public void printStudents()
        {
            foreach (studentBL s in studentDL.studentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.getName() + " got Admission in " + s.regDegree.getDegreeName());
                }
                else
                {
                    Console.WriteLine(s.getName() + "did not get Admission");
                }
            }
        }

        static public void specificDegree(string name)
        {
            Console.WriteLine("NAME" + "\t\t" + "FSC" + "\t\t" + "ECAT" + "\t\t" + "AGE");
            foreach (studentBL s in studentDL.studentList)
            {
                if (s.regDegree != null)
                {
                    if (name == s.regDegree.getDegreeName())
                    {
                        Console.WriteLine(s.getName() + "\t\t" + s.getFscMarks() + "\t\t" + s.getEcatMarks() + "\t\t" + s.getAge());
                    }
                }
            }
        }

        static public void fee()
        {
            foreach (studentBL s in studentDL.studentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.getName() + " has " + s.calculateFee() + " fees ");
                }
            }
        }
    }
}
