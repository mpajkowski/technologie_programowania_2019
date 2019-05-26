using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui.Utils
{
    public class Text
    {
        static void ValidateInput(string input)
        {
            if (input.Length > 40)
            {
                throw new ArgumentException("Text too long");
            }

            if (input == string.Empty)
            {
                throw new ArgumentException("Empty string");
            }
        }
    }
}
