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
    class subjectsBL
    {
        private int code;
        private string type;
        private int creditHours;
        private int fees;

        public subjectsBL(int code, string type, int creditHours, int fees)
        {
            this.code = code;
            this.type = type;
            this.creditHours = creditHours;
            this.fees = fees;
        }

        public void setCode(int code)
        {
            this.code = code;
        }

        public void setType(string type)
        {
            this.type = type;
        }

        public void setCrditHours(int creditHours)
        {
            this.creditHours = creditHours;
        }

        public void setFees(int fees)
        {
            this.fees = fees;
        }

        public int getCode()
        {
            return code;
        }

        public string getType()
        {
            return type;
        }

        public int getCreditHours()
        {
            return creditHours;
        }

        public int getFees()
        {
            return fees;
        }

    }
}
