using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UAMSListInClass.BL;
using UAMSListInClass.UI;
using UAMSListInClass.DL;

namespace UAMSListInClass.DL
{
    class subjectsDL
    {
        public static List<subjectsBL> subjectsList = new List<subjectsBL>();

        public static void storeintoFile(string path, subjectsBL s)
        {
            StreamWriter f = new StreamWriter(path, true);
            f.WriteLine(s.getCode() + "," + s.getType() + "," + s.getCreditHours() + "," + s.getFees());
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
                    int code = int.Parse(splittedRecord[0]);
                    string type = splittedRecord[1];
                    int creditHours = int.Parse(splittedRecord[2]);
                    int fees = int.Parse(splittedRecord[3]);
                    subjectsBL s = new subjectsBL(code, type, creditHours, fees);
                    addSubjectIntoList(s);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void addSubjectIntoList(subjectsBL s)
        {
            subjectsList.Add(s);
        }

        public static subjectsBL isSubjectExists(string type)
        {
            foreach (subjectsBL s in subjectsList)
            {
                if (s.getType() == type)
                {
                    return s;
                }
            }
            return null;
        }
    }
}
