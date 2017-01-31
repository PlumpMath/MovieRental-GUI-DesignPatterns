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
    public partial class AddCategory : Form
    {
        MovieRentalDatabase.MovieRentalDatabase mrd;
        SellerMenu sellerMenu;
        public AddCategory()
        {
            InitializeComponent();
            mrd = UserConnection.getInstance().getMovieRentalDatabase();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string categoryName = textBox1.Text;

            mrd.addMovieCategory(categoryName);

            this.Close();
            sellerMenu.fillTableWithAllRentals(mrd);
            sellerMenu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
    }
}
