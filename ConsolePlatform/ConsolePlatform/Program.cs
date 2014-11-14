using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            Database();
        }

        static void Database()
        {
            Al.Database.TblStudent.InitTableStudent();
        }
    }
}
