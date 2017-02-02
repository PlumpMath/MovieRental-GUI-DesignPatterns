using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalMovieGUI.Printer
{
    class ToHTML : IPrintable
    {
        public void print(List<MovieRentalDatabase.Row> rentals)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("output.html");

            file.WriteLine("<table>");
            file.WriteLine("<tr><td>A</td><td>B</td><td>C</td><td>D</td></tr>");
            foreach (MovieRentalDatabase.Row value in rentals)
            {
                file.WriteLine("<tr><td>"+value.Columns[0]+ "</td><td>" + value.Columns[1] + "</td><td>" + value.Columns[2] + "</td><td>" + value.Columns[3]+ "</td></tr>");
            }
            file.WriteLine("</table>");

            file.Close();
            MessageBox.Show("File saved !");
            System.Diagnostics.Process.Start(@"output.html");
        }
    }
}
