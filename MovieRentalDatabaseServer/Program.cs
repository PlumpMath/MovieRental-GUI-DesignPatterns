using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;


namespace MovieRentalDatabaseServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpServerChannel channel = new TcpServerChannel(9999);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType
                (typeof(MovieRentalDatabase.MovieRentalDatabase), "Rental",
                WellKnownObjectMode.Singleton);
            Console.WriteLine("Service is running ...");
            Console.ReadLine();
        }
    }
}
