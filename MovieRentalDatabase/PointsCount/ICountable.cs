using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalDatabase.PointsCount
{
    interface ICountable
    {
        void count(string userName);
    }
}
