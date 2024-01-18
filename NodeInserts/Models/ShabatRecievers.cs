using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeInserts.Models
{
    public  class ShabatRecievers
    {
        private string parent1;
        private string parent2;
        private int day;
        private int month;
        private int year;   

        public ShabatRecievers(string name1,string name2, int day, int month, int year) 
        {
            this.parent1 = name1;
            this.parent2 = name2;
            this.month = month;    
            this.year = year;
            this.day=day;

        }

        public string GetParent1()
        { return parent1; }
        public string GetParent2() { return parent2; }
        public int GetDay() { return day; }
        public int GetMonth() { return month; }
        public int GetYear() { return year; }


    }
}
