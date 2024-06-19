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
    class majorDL
    {
        static public List<majorBL> majorList = new List<majorBL>();

        static public void addMajorInList()
        {
            majorList.Add(majorUI.getInfoAboutMajor());
        }

        public static void addMajorIntoList(majorBL d)
        {
            majorList.Add(d);
        }

        public static majorBL isDegreeExists(string degreeName)
        {
            foreach (majorBL d in majorList)
            {
                if (d.getDegreeName() == degreeName)
                {
                    return d;
                }
            }
            return null;
        }

        public static void storeintoFile(string path, majorBL d)
        {
            StreamWriter f = new StreamWriter(path, true);
            string SubjectNames = "";
            for (int x = 0; x < d.subjects.Count - 1; x++)
            {
                SubjectNames = SubjectNames + d.subjects[x].getType() + ";";
            }
            SubjectNames = SubjectNames + d.subjects[d.subjects.Count - 1].getType();
            f.WriteLine(d.getDegreeName() + "," + d.getDuration() + "," + d.getSeats() + "," + SubjectNames);
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
                    string degreeName = splittedRecord[0];
                    int duration = int.Parse(splittedRecord[1]);
                    int seats = int.Parse(splittedRecord[2]);
                    string[] splittedRecordForSubject = splittedRecord[3].Split(';');
                    majorBL d = new majorBL(degreeName, duration, seats);
                    for (int x = 0; x < splittedRecordForSubject.Length; x++)
                    {
                        subjectsBL s = subjectsDL.isSubjectExists(splittedRecordForSubject[x]);
                        if (s != null)
                        {
                            d.addSubjects(s);
                        }
                    }
                    addMajorIntoList(d);
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
