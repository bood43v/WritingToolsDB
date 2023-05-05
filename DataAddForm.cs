using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingToolsDB
{
    public static class DataAddForm
    {
        public static string manufacturer = "";
        public static string model_name = "";
        public static string ink_color = "";
        public static double ball_diameter = 0;
        public static int quantity = 0;
        public static double price = 0;
        public static bool isEmpty()
        {
            if (manufacturer == null) return false;
            else return true;
        }

    }
}
