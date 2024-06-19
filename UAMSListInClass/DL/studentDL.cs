using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UAMSListInClass.BL;
using UAMSListInClass.DL;
using UAMSListInClass.UI;

namespace UAMSListInClass.DL
{
    class studentDL
    {
        static public List<studentBL> studentList = new List<studentBL>();
        static public List<studentBL> sortedStudentList = new List<studentBL>();

        static public List<studentBL> sortStudentsByMerit()
        {
            List<studentBL> sortedStudentList = new List<studentBL>();
            sortedStudentList = studentList.OrderByDescending(o => o.getMerit()).ToList();
            return sortedStudentList;
        }

        static public void addStudentInList()
        {
            studentDL.studentList.Add(studentUI.getInfoAboutStudent());
        }

        public static void addIntoStudentList(studentBL s)
        {
            studentList.Add(s);
        }

        public static studentBL StudentPresent(string name)
        {
            foreach (studentBL s in studentList)
            {
                if (name == s.getName() && s.regDegree != null)
                {
                    return s;
                }
            }
            return null;
        }

        public static void storeintoFile(string path, studentBL s)
        {
            StreamWriter f = new StreamWriter(path, true);
            string degreeNames = "";
            for (int x = 0; x < s.preferences.Count - 1; x++)
            {
                degreeNames = degreeNames + s.preferences[x].getDegreeName() + ";";
            }
            degreeNames = degreeNames + s.preferences[s.preferences.Count - 1].getDegreeName();
            f.WriteLine(s.getName() + "," + s.getAge() + "," + s.getFscMarks() + "," + s.getEcatMarks() + "," + degreeNames);
            f.Flush();
            f.Close();
        }

        public static bool readFromFile(string path)
        {
            StreamReader f = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string name = splittedRecord[0];
                    int age = int.Parse(splittedRecord[1]);
                    float fscMarks = float.Parse(splittedRecord[2]);
                    float ecatMarks = float.Parse(splittedRecord[3]);
                    string[] splittedRecordForPreference = splittedRecord[4].Split(';');
                    List<majorBL> preferences = new List<majorBL>();

                    for (int x = 0; x < splittedRecordForPreference.Length; x++)
                    {
                        majorBL d = majorDL.isDegreeExists(splittedRecordForPreference[x]);
                        if (d != null)
                        {
                            if (!(preferences.Contains(d)))
                            {
                                preferences.Add(d);
                            }
                        }
                    }
                    studentBL s = new studentBL(name, age, fscMarks, ecatMarks, preferences);
                    studentList.Add(s);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
