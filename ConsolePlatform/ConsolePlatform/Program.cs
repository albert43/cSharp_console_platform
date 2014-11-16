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
        static void Main(string[] args)
        {
            Database();
        }

        static void Database()
        {
            TblStudent s = new TblStudent();

            s.InitTableStudent();
            s.Schema();
        }
    }

    public class TblStudent
    {
        enum COLUMNS
        {
            ID,
            NAME,
            CLASS,
            END
        }

        static Al.Database.DatabaseApi m_db;

        public TblStudent()
        {
            m_db = new DatabaseApi("test.db", "");
        }

        public void Schema()
        {
            COLUMN_DEF_S[] ColsStudent = new COLUMN_DEF_S[3];

            m_db.getTable("student", ref ColsStudent);
        }

        public void InitTableStudent()
        {
            COLUMN_DEF_S[] ColsStudent = new COLUMN_DEF_S[3];
            int i;

            ColsStudent[(int)COLUMNS.ID] = new COLUMN_DEF_S();
            ColsStudent[(int)COLUMNS.ID].strColumnName = "id";
            ColsStudent[(int)COLUMNS.ID].PrimaryKey = PRIMARY_KEY_T.NOT_AUTO;

            ColsStudent[(int)COLUMNS.NAME] = new COLUMN_DEF_S();
            ColsStudent[(int)COLUMNS.NAME].strColumnName = "name";
            ColsStudent[(int)COLUMNS.NAME].DataType = DATA_T.STRING;
            ColsStudent[(int)COLUMNS.NAME].PrimaryKey = PRIMARY_KEY_T.NONE;
            ColsStudent[(int)COLUMNS.NAME].bNotNull = true;
            ColsStudent[(int)COLUMNS.NAME].bUnique = false;

            ColsStudent[(int)COLUMNS.CLASS] = new COLUMN_DEF_S();
            ColsStudent[(int)COLUMNS.CLASS].strColumnName = "class";
            ColsStudent[(int)COLUMNS.CLASS].DataType = DATA_T.INTEGER;
            ColsStudent[(int)COLUMNS.CLASS].PrimaryKey = PRIMARY_KEY_T.NONE;
            ColsStudent[(int)COLUMNS.CLASS].bNotNull = false;
            ColsStudent[(int)COLUMNS.CLASS].bUnique = false;
            ColsStudent[(int)COLUMNS.CLASS].ForeignKey = new FOREIGN_KEY_S();
            ColsStudent[(int)COLUMNS.CLASS].ForeignKey.strForeignTable = "class";
            ColsStudent[(int)COLUMNS.CLASS].ForeignKey.strColumnName = new string[1];
            ColsStudent[(int)COLUMNS.CLASS].ForeignKey.strColumnName[0] = "id";

            TABLE_DEF_S tblStudent = new TABLE_DEF_S();
            tblStudent.strTableName = "student";
            tblStudent.Columns = ColsStudent;

            m_db.createTable("student", ColsStudent);
            //Al.Config.ConfigJson cfg = new Config.ConfigJson("table_student.cofig");
            //cfg.setConfig<TABLE_DEF_S>(tblStudent);
        }
    }
}
