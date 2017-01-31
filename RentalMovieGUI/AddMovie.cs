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
    public partial class AddMovie : Form
    {
        MovieRentalDatabase.MovieRentalDatabase mrd;
        SellerMenu sellerMenu;
        public AddMovie()
        {
            InitializeComponent();
            mrd = UserConnection.getInstance().getMovieRentalDatabase();

            foreach(string movieCategory in mrd.printAllMovieCategories())
            {
                comboBox1.Items.Add(movieCategory);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string movieTitle = textBox1.Text;
            string movieCategory = comboBox1.SelectedItem.ToString();

            mrd.addMovie(movieTitle, movieCategory);

            this.Close();
            sellerMenu.fillTableWithAllRentals(mrd);
            sellerMenu.Show();

        }

        public SellerMenu SellerMenu
        {
            set
            {
                sellerMenu = value;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            sellerMenu.fillTableWithAllRentals(mrd);
            sellerMenu.Show();
        }
    }
}
