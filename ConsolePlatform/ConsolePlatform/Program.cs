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
            DEVELOP,
            CONFIG
        }

        static void Main(string[] args)
        {
            Entry(LIBENUM.CONFIG);
        }

        static void Entry(LIBENUM Index)
        {
            switch (Index)
            {
                case LIBENUM.DEVELOP:
                    develop();
                    break;
                case LIBENUM.CONFIG:
                    config();
                    break;
            }
        }

        static void develop()
        { 
        }

        static void config()
        {
            Al.Config.Sample s = new Al.Config.Sample();
            s.setSample();
            s.getSample();

        }
    }
}
