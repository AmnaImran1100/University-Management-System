using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMSListInClass.BL;
using UAMSListInClass.DL;
using UAMSListInClass.UI;


namespace UAMSListInClass
{
    class Program
    {
        static void Main(string[] args)
        {
            string subjectPath = "subject.txt";
            string degreePath = "degree.txt";
            string studentPath = "student.txt";
            if (subjectsDL.readFromFile(subjectPath))
            {
                Console.WriteLine("Subject Data Loaded Successfully");
            }
            if (majorDL.readFromFile(degreePath))
            {
                Console.WriteLine("DegreeProgram Data Loaded Successfully");
            }
            if (studentDL.readFromFile(studentPath))
            {
                Console.WriteLine("Student Data Loaded Successfully");
            }
            menuUI.clear();
            int option = 0;
            while (option != 8)
            {
                option = menuUI.menu();
                menuUI.clear();
                if (option == 1)
                {
                    majorBL d = majorUI.getInfoAboutMajor();
                    majorDL.addMajorIntoList(d);
                    majorDL.storeintoFile(degreePath, d);
                    menuUI.clear();
                }
                else if (option == 2)
                {
                    if (majorDL.majorList.Count > 0)
                    {
                        studentBL s = studentUI.getInfoAboutStudent();
                        studentDL.addIntoStudentList(s);
                        studentDL.storeintoFile(studentPath, s);
                        menuUI.clear();
                    }
                }
                else if (option == 3)
                {
                    studentDL.sortedStudentList = studentDL.sortStudentsByMerit();
                    studentBL.giveAdmission(studentDL.sortedStudentList);
                    studentUI.printStudents();
                    menuUI.clear();
                }
                else if (option == 4)
                {
                    studentUI.registeredStudents();
                    menuUI.clear();
                }
                else if (option == 5)
                {
                    Console.Write("Enter Degree Name =");
                    string name = Console.ReadLine();
                    studentUI.specificDegree(name);
                    menuUI.clear();
                }
                else if (option == 6)
                {
                    Console.Write("Enter the student name =");
                    string name = Console.ReadLine();
                    studentBL s = studentBL.studentPresent(name);
                    if (s != null)
                    {
                        subjectsUI.viewSubjects(s);
                        subjectsUI.registerSubjects(s);
                        menuUI.clear();
                    }

                }
                else if (option == 7)
                {
                    studentUI.fee();
                    menuUI.clear();
                }
            }
        }

    }
}
