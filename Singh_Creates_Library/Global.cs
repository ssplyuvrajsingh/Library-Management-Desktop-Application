using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLB
{
    public class Global_Var
    {
        static int G_Lib_Id;
        public void G_Id(int a)
        {
            G_Lib_Id = a;
            G_V();
        }
        public static int G_V()
        {
            return G_Lib_Id;
        }

    }

}
