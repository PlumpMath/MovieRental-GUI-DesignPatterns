using System;
using System.Windows.Forms;
using RentalMovieGUI;

namespace RentalMovieGUI
{
    public partial class AllMovies : Form
    {
        private MovieRentalDatabase.MovieRentalDatabase mrd;
        private string name;
        private UserRentals userRentals;
        public AllMovies(string name)
        {
            this.name = name;
            InitializeComponent();
            mrd = UserConnection.getInstance().getMovieRentalDatabase();
            foreach (MovieRentalDatabase.Row row in mrd.printAllMovies())
            {
                dataGridView1.Rows.Add(row.Columns[0], row.Columns[1]);
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            userRentals.clearAllUserRentals();
            userRentals.fillTableWithUserRentals(mrd.printUserRentals(name));
            this.Hide();
            userRentals.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string movieTitle = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            mrd.addRental(name, movieTitle);

            userRentals.clearAllUserRentals();
            userRentals.fillTableWithUserRentals(mrd.printUserRentals(name));
            this.Hide();
            userRentals.Show();
        }

        public UserRentals UserRentals
        {
            set
            {
                userRentals = value;
            }
            get
            {
                return userRentals;
            }
        }
    }
}
