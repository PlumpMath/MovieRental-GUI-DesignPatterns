using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRentalDatabase.Movie;

namespace MovieRentalDatabase.PointsCount
{
    class NormalCount : ICountable
    {
        public void count(string userName)
        {
            MovieRentalDatabase mrd = MovieRentalDatabase.getInstance();
            User.User user = mrd.getUserObject(userName);
            user.Points = user.Points + 1;
        }
    }
}
