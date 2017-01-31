using System;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Collections.Generic;

namespace RentalMovieGUI
{
    public partial class UserSelection : Form
    {
        private MovieRentalDatabase.MovieRentalDatabase mrd;
        public UserSelection()
        {
            InitializeComponent();
            mrd = UserConnection.getInstance().getMovieRentalDatabase();
        }

        private void UserSelection_Load(object sender, EventArgs e)
        {
            fillComboBoxWithUserNames(mrd.printAllUsers());

        }

        private void fillComboBoxWithUserNames(List<string> names)
        {
            foreach(string name in names)
            {
                comboBox1.Items.Add(name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserRentals userRentals;

            this.Visible = false;
            string selectedUser = comboBox1.SelectedItem.ToString();
            string type = mrd.getUserType(selectedUser);

            if (type == "customer")
            {
                userRentals = new UserRentals(selectedUser);
                userRentals.Show();
            }

            if (type == "seller")
            {
                SellerMenu sellerMenu = new SellerMenu();
                sellerMenu.Show();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

public class UserConnection
{
    private static UserConnection instance = new UserConnection();
    private static TcpClientChannel channel;
    private static MovieRentalDatabase.MovieRentalDatabase mrd;
    private UserConnection()
    {
        channel = new TcpClientChannel();

        channel = new TcpClientChannel();
        ChannelServices.RegisterChannel(channel);
        mrd = (MovieRentalDatabase.MovieRentalDatabase)
        Activator.GetObject(typeof(MovieRentalDatabase.MovieRentalDatabase),
        "tcp://localhost:9999/Rental");
    }

    public static UserConnection getInstance()
    {
        return instance;
    }

    public MovieRentalDatabase.MovieRentalDatabase getMovieRentalDatabase() {
        return mrd;
    }
}
