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
    class majorUI
    {
        static public majorBL getInfoAboutMajor()
        {
            Console.Write("Enter Degree Name =");
            string name = Console.ReadLine();
            Console.Write("Enter Degree Duration =");
            int duration = int.Parse(Console.ReadLine());
            Console.Write("Enter Degree Seats =");
            int seats = int.Parse(Console.ReadLine());

            majorBL m = new majorBL(name, duration, seats);

            Console.Write("Enter How many Subjects to Enter = ");
            int subNumber = int.Parse(Console.ReadLine());
            for (int x = 0; x < subNumber; x++)
            {
                subjectsBL s = subjectsUI.getInfoAboutSubjects();
                if (m.addSubjects(s))
                {
                    if (!(subjectsDL.subjectsList.Contains(s)))
                    {
                        subjectsDL.addSubjectIntoList(s);
                        subjectsDL.storeintoFile("subject.txt", s);
                    }

                    Console.WriteLine("Subject Added");
                }
                else
                {
                    Console.WriteLine("Subject Not Added");
                    Console.WriteLine("20 credit hour limit exceeded");
                    x--;
                }
            }
            return m;
        }

        static public void viewDegreeProgram()
        {
            for (int x = 0; x < majorDL.majorList.Count; x++)
            {
                Console.WriteLine(majorDL.majorList[x].getDegreeName());
            }
        }
    }
}
