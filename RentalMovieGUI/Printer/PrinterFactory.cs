using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalMovieGUI.Printer
{
    class PrinterFactory
    {
        public IPrintable get(string text)
        {
            if (text == "HTML")
            {
                return new ToHTML();
            }
            else if (text == "CSV")
            {
                return new ToCSV();
            }
            else
            {
                return null;
            }

        }
    }
}
