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
    public partial class AddUser : Form
    {
        MovieRentalDatabase.MovieRentalDatabase mrd;
        SellerMenu sellerMenu;
        public AddUser()
        {
            InitializeComponent();
            mrd = UserConnection.getInstance().getMovieRentalDatabase();
            
            foreach(string userType in mrd.printAllUserTypes())
            {
                comboBox1.Items.Add(userType);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string userType = comboBox1.SelectedItem.ToString();

            mrd.addUser(userName, userType);
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
