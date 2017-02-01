using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalDatabase.PointsCount
{
    class CountStrategyFactory
    {
        public ICountable get(string userName)
        {
            MovieRentalDatabase mrd = MovieRentalDatabase.getInstance();
            if (mrd.getUserRentalsCount(userName)<6)
            {
                return new NormalCount();
            }
            else
            {
                return new ExtraCount();
            }
        }
    }
}
