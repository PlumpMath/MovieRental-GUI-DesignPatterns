using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;
using RentalMovieGUI;

namespace RentalMovieGUI
{
    public partial class UserRentals : Form
    {
        private string name;
        private MovieRentalDatabase.MovieRentalDatabase mrd;
        private UserSelection userSelection;
        public UserRentals(string name)
        {
            InitializeComponent();

            this.name = name;
            mrd = UserConnection.getInstance().getMovieRentalDatabase();
            label1.Text = name;
            fillTableWithUserRentals(mrd.printUserRentals(name));
        }

        public void fillTableWithUserRentals(List<MovieRentalDatabase.Row> rentals)
        {
            foreach(MovieRentalDatabase.Row row in rentals)
            {
                dataGridView1.Rows.Add(row.Columns[0], row.Columns[1], row.Columns[2], row.Columns[3]);
            }
        }

        public void clearAllUserRentals()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AllMovies allMovies = new AllMovies(name);
            allMovies.UserRentals = this;
            this.Visible = false;
            allMovies.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            userSelection = new UserSelection();
            userSelection.Show();

        }
    }
}
