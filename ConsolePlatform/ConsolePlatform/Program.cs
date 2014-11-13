using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlatform
{
    class Program
    {
        enum LIBENUM
        {
            DEVELOP
        }

        static void Main(string[] args)
        {
            Entry(LIBENUM.DEVELOP);
        }

        static void Entry(LIBENUM Index)
        {
            switch (Index)
            {
                case LIBENUM.DEVELOP:
                    develop();
                    break;
            }
        }

        static void develop()
        { 
        }
    }
}
