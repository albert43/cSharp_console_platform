using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Al.Database;

namespace ConsolePlatform
{
    class Program
    {
        static String m_strDbPath = "Sample.db";
        static void Main(string[] args)
        {
            Database();
            Al.Database.DatabaseApi db = new DatabaseApi(m_strDbPath, "");
            
        }

        static void Database()
        {
            TblStudent tblStudent = new TblStudent("student", m_strDbPath, "");
            TblClass tblCalss = new TblClass("class", m_strDbPath, "");

            tblStudent.create();
            tblCalss.create();
        }
    }
}
