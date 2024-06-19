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
    class majorBL
    {
        private string degreeName;
        private int duration;
        private int seats;
        public List<subjectsBL> subjects;

        public majorBL(string degreeName, int duration, int seats)
        {
            this.degreeName = degreeName;
            this.duration = duration;
            this.seats = seats;
            subjects = new List<subjectsBL>();
        }

        public void setDegreeName(string degreeName)
        {
            this.degreeName = degreeName;
        }

        public void setDuration(int duration)
        {
            this.duration = duration;
        }

        public void setSeats(int seats)
        {
            this.seats = seats;
        }

        public string getDegreeName()
        {
            return degreeName;
        }

        public int getDuration()
        {
            return duration;
        }

        public int getSeats()
        {
            return seats;
        }

        public int getCreditHours()
        {
            int total = 0;
            for (int x = 0; x < subjects.Count; x++)
            {
                total = total + subjects[x].getCreditHours();
            }
            return total;
        }

        public bool addSubjects(subjectsBL s)
        {
            int creditHours = getCreditHours();
            if (creditHours + s.getCreditHours() <= 20)
            {
                subjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ifSubjectExists(subjectsBL sub)
        {
            foreach (subjectsBL s in subjects)
            {
                if (s.getCode() == sub.getCode())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
