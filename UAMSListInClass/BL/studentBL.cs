using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMSListInClass.BL;
using UAMSListInClass.UI;
using UAMSListInClass.DL;

namespace UAMSListInClass.BL
{
    class studentBL
    {
        private string name;
        private int age;
        private float fscMarks;
        private float ecatMarks;
        private float merit;
        public majorBL regDegree;
        public List<majorBL> preferences;
        public List<subjectsBL> regSubjects;
       
        public studentBL(string name, int age, float fscMarks, float ecatMarks, List<majorBL> preferences)
        {
            this.name = name;
            this.age = age;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
            this.preferences = preferences;
            calculateMerit();
            regSubjects = new List<subjectsBL>();
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setAge(int age)
        {
            this.age = age;
        }

        public void setFscMarks(float fscMarks)
        {
            this.fscMarks = fscMarks;
        }

        public void setEcatMarks(float ecatMarks)
        {
            this.ecatMarks = ecatMarks;
        }

        public string getName()
        {
            return name;
        }

        public int getAge()
        {
            return age;
        }

        public float getFscMarks()
        {
            return fscMarks;
        }

        public float getEcatMarks()
        {
            return ecatMarks;
        }

        public float getMerit()
        {
            return merit;
        }


        public void calculateMerit()
        {
            this.merit = (((fscMarks / 1100) * 0.45F) + ((ecatMarks / 400) * 0.55F)) * 100;
        }

        public int getCreditHours()
        {
            int total = 0;
            for (int x = 0; x < regSubjects.Count; x++)
            {
                total = total + regSubjects[x].getCreditHours();
            }
            return total;
        }

        public bool regSubject(subjectsBL s)
        {
            int hours = getCreditHours();
            if (regDegree != null && regDegree.ifSubjectExists(s) && hours + s.getCreditHours() <= 9)
            {
                regSubjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int calculateFee()
        {
            int fee = 0;
            if (regDegree != null)
            {
                foreach (subjectsBL sub in regSubjects)
                {
                    fee = fee + sub.getFees();
                }
            }
            return fee;
        }

        static public void giveAdmission(List<studentBL> sortedStudentsList)
        {
            foreach (studentBL s in studentDL.sortedStudentList)
            {
                foreach (majorBL m in s.preferences)
                {
                    if (m.getSeats() > 0 && s.regDegree == null)
                    {
                        s.regDegree = m;
                        m.getSeats()--;
                        break;
                    }
                }
            }
        }

        static public studentBL studentPresent(string name)
        {
            foreach (studentBL s in studentDL.studentList)
            {
                if (name == s.name && s.regDegree != null)
                {
                    return s;
                }
            }
            return null;
        }
    }
}
