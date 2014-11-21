using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Al.Database;

namespace ConsolePlatform
{
    public class TableBase
    {
        public String m_strTableName;
        public String m_strDbPath { set; get; }
        public String m_strPassword { set; get; }
        public DatabaseApi m_hDb;

        public TableBase(String strTableName, String strDbPath, String strPassword)
        {
            m_strTableName = strTableName;
            m_strDbPath = strDbPath;
            m_strPassword = strPassword;

            m_hDb = new DatabaseApi(strDbPath, strPassword);
        }
    }

    public class TblStudent : TableBase
    {
        enum COLUMNS
        {
            ID,
            NAME,
            CLASS,
            END
        }

        public TblStudent(String strTableName, String strDbPath, String strPassword)
            : base(strTableName, strDbPath, strPassword)
        {
        }

        public void create() 
        {
            COLUMN_DEF_S[] ColsStudent = new COLUMN_DEF_S[3];
            int i;

            ColsStudent[(int)COLUMNS.ID] = new COLUMN_DEF_S();
            ColsStudent[(int)COLUMNS.ID].strColumnName = "id";
            ColsStudent[(int)COLUMNS.ID].PrimaryKey = PRIMARY_KEY_T.NONE;

            ColsStudent[(int)COLUMNS.NAME] = new COLUMN_DEF_S();
            ColsStudent[(int)COLUMNS.NAME].strColumnName = "name";
            ColsStudent[(int)COLUMNS.NAME].DataType = DATA_T.STRING;
            ColsStudent[(int)COLUMNS.NAME].PrimaryKey = PRIMARY_KEY_T.NONE;
            ColsStudent[(int)COLUMNS.NAME].bNotNull = true;
            ColsStudent[(int)COLUMNS.NAME].bUnique = false;

            ColsStudent[(int)COLUMNS.CLASS] = new COLUMN_DEF_S();
            ColsStudent[(int)COLUMNS.CLASS].strColumnName = "class";
            ColsStudent[(int)COLUMNS.CLASS].DataType = DATA_T.INTEGER;
            ColsStudent[(int)COLUMNS.CLASS].PrimaryKey = PRIMARY_KEY_T.NOT_AUTO;
            Data df = new Data(DATA_T.INTEGER);
            df.m_i = 3;
            ColsStudent[(int)COLUMNS.CLASS].DefaultValue = df;
            ColsStudent[(int)COLUMNS.CLASS].bNotNull = true;
            ColsStudent[(int)COLUMNS.CLASS].bUnique = true;
            ColsStudent[(int)COLUMNS.CLASS].ForeignKey = new FOREIGN_KEY_S();
            ColsStudent[(int)COLUMNS.CLASS].ForeignKey.strForeignTable = "class";
            ColsStudent[(int)COLUMNS.CLASS].ForeignKey.strColumnName = new string[1];
            ColsStudent[(int)COLUMNS.CLASS].ForeignKey.strColumnName[0] = "id";
           

            TABLE_DEF_S tblStudent = new TABLE_DEF_S();
            tblStudent.strTableName = "student";
            tblStudent.Columns = ColsStudent;

            m_hDb.createTable(tblStudent.strTableName, ColsStudent);
            //Al.Config.ConfigJson cfg = new Config.ConfigJson("table_student.cofig");
            //cfg.setConfig<TABLE_DEF_S>(tblStudent);
        }

        void getSchema()
        {
            COLUMN_DEF_S[] ColsStudent;
            
        }
    }

    public class TblClass : TableBase
    {
        enum COLUMNS
        {
            ID,
            NAME,
            END
        }

        public TblClass(String strTableName, String strDbPath, String strPassword)
            : base(strTableName, strDbPath, strPassword)
        {
        }

        public void create()
        {
            COLUMN_DEF_S[] ColsClass = new COLUMN_DEF_S[2];
            int i;

            ColsClass[(int)COLUMNS.ID] = new COLUMN_DEF_S();
            ColsClass[(int)COLUMNS.ID].strColumnName = "id";
            ColsClass[(int)COLUMNS.ID].PrimaryKey = PRIMARY_KEY_T.NOT_AUTO;
            
            ColsClass[(int)COLUMNS.NAME] = new COLUMN_DEF_S();
            ColsClass[(int)COLUMNS.NAME].strColumnName = "name";
            ColsClass[(int)COLUMNS.NAME].DataType = DATA_T.STRING;
            ColsClass[(int)COLUMNS.NAME].PrimaryKey = PRIMARY_KEY_T.NONE;
            ColsClass[(int)COLUMNS.NAME].bNotNull = true;
            ColsClass[(int)COLUMNS.NAME].bUnique = false;
            

            TABLE_DEF_S tblClass = new TABLE_DEF_S();
            tblClass.strTableName = "class";
            tblClass.Columns = ColsClass;

            m_hDb.createTable(tblClass.strTableName, ColsClass);
            //Al.Config.ConfigJson cfg = new Config.ConfigJson("table_student.cofig");
            //cfg.setConfig<TABLE_DEF_S>(tblStudent);
        }
    }
}
