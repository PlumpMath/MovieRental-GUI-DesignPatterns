using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalMovieGUI
{
    public partial class SellerMenu : Form
    {
        private MovieRentalDatabase.MovieRentalDatabase mrd;
        public SellerMenu()
        {
            InitializeComponent();
            mrd = UserConnection.getInstance().getMovieRentalDatabase();

            fillTableWithAllRentals(mrd);
        }

        public void fillTableWithAllRentals(MovieRentalDatabase.MovieRentalDatabase mrd)
        {
            dataGridView1.Rows.Clear();

            foreach (MovieRentalDatabase.Row row in mrd.printAllRentals())
            {
                dataGridView1.Rows.Add(row.Columns[0], row.Columns[1], row.Columns[2], row.Columns[3],row.Columns[4]);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SellerMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddUser addUser = new AddUser();
            addUser.SellerMenu = this;
            addUser.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddCategory addCategory = new AddCategory();
            addCategory.SellerMenu = this;
            addCategory.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            UserSelection userSelection = new UserSelection();
            userSelection.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddMovie addMovie = new AddMovie();
            addMovie.SellerMenu = this;
            addMovie.Show();
        }
    }
}
