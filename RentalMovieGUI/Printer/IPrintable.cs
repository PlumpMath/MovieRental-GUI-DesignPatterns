using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalMovieGUI.Printer
{
    interface IPrintable
    {
        void print(List<MovieRentalDatabase.Row> rentals);
    }
}
