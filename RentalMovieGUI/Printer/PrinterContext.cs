using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalMovieGUI.Printer
{
    class PrinterContext
    {
        IPrintable context;

        public PrinterContext(IPrintable context)
        {
            this.context = context;
        }

        public void executeStrategy(List<MovieRentalDatabase.Row> rentals)
        {
            context.print(rentals);
        }
    }
}
