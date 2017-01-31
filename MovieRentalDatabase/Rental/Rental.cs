using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalDatabase.Rental
{
    class Rental
    {
        private User.User user;
        private Movie.Movie movie;
        private DateTime rentDate;
        private DateTime backDate;

        public Rental(User.User user, Movie.Movie movie)
        {
            this.user = user;
            this.movie = movie;
            rentDate = new DateTime();
            backDate = rentDate.AddDays(7);
        }

        public User.User User
        {
            get
            {
                return user;
            }
        }

        public Movie.Movie Movie
        {
            get
            {
                return movie;
            }
        }

        public DateTime RentDate
        {
            get
            {
                return rentDate;
            }
        }

        public DateTime BackDate
        {
            get
            {
                return backDate;
            }
        }
    }
}
