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
    class subjectsUI
    {
        static public subjectsBL getInfoAboutSubjects()
        {
            Console.Write("Enter Subect Code =");
            int code = int.Parse(Console.ReadLine());
            Console.Write("Enter Subject Type =");
            string type = Console.ReadLine();
            Console.Write("Enter Subjects Credit Hours =");
            int creditHours = int.Parse(Console.ReadLine());
            Console.Write("Enter Subject Fee =");
            int fee = int.Parse(Console.ReadLine());

            subjectsBL s = new subjectsBL(code, type, creditHours, fee);
            return s;
        }

        static public void registerSubjects(studentBL s)
        {
            Console.Write("Enter how many subjects you want to register =");
            int subCount = int.Parse(Console.ReadLine());
            for (int x = 0; x < subCount; x++)
            {
                Console.Write("Enter the subject code =");
                int code = int.Parse(Console.ReadLine());
                bool flag = false;
                foreach (subjectsBL sub in s.regDegree.subjects)
                {
                    if (code == sub.getCode() && !(s.regSubjects.Contains(sub)))
                    {
                        s.regSubject(sub);
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Enter Valid Course");
                    x--;
                }
            }
        }

        static public void viewSubjects(studentBL s)
        {
            if (s.regDegree != null)
            {
                Console.WriteLine("Subject Code  \t Subject Type");
                foreach (subjectsBL sub in s.regDegree.subjects)
                {
                    Console.WriteLine(sub.getCode() + "\t\t" + sub.getType());
                }
            }
        }
    }
}
