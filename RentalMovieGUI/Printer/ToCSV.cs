using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalMovieGUI.Printer
{
    class ToCSV : IPrintable
    {
        public void print(List<MovieRentalDatabase.Row> rentals)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("output.csv");
            foreach (MovieRentalDatabase.Row value in rentals)
            {
                file.WriteLine(value.Columns[0] + ";" + value.Columns[1] + ";" + value.Columns[2] + ";" + value.Columns[3]);
            }

            file.Close();
            MessageBox.Show("File saved !");
            System.Diagnostics.Process.Start(@"output.csv");
        }
    }
}
