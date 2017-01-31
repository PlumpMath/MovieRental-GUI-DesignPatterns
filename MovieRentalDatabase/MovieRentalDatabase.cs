using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MovieRentalDatabase
{
    //Singleton design pattern
    [Serializable()]
    public class MovieRentalDatabase:MarshalByRefObject
    {
        private static MovieRentalDatabase instance;

        List<MovieCategory.MovieCategory> movieCategoryList;
        List<Movie.Movie> movieList;
        List<UserType.UserType> userTypeList;
        List<User.User> userList;
        List<Rental.Rental> rentalList;

        public static MovieRentalDatabase getInstance()
        {
            if (instance == null)
            {
                instance = new MovieRentalDatabase();
            }

            return instance;
        }

        private MovieRentalDatabase()
        {
            movieCategoryList = new List<MovieCategory.MovieCategory>();
            movieList = new List<Movie.Movie>();
            userTypeList = new List<UserType.UserType>();
            userList = new List<User.User>();
            rentalList = new List<Rental.Rental>();

            initDatabase();
        }

        private void movieCategoryListInit()
        {
            string[] categoryNames = { "Horror", "Comedy", "Thriller", "Fantasy", "Adult", "Drama", "Documentary" };

            foreach (string name in categoryNames)
            {
                movieCategoryList.Add(new MovieCategory.MovieCategory(name));
            }

        }

        private MovieCategory.MovieCategory getCategoryObject(string name)
        {
            return movieCategoryList.Find(x => x.CategoryName == name);
        }

        private void MovieListInit()
        {
            Dictionary<string, string> movieToCategory = new Dictionary<string, string>()
            {
                {"Shrek","Comedy" },
                {"Arrival", "Thriller" },
                {"The Ring","Horror" }
            };

            foreach (KeyValuePair<string, string> pair in movieToCategory)
            {
                movieList.Add(new Movie.Movie(pair.Key, getCategoryObject(pair.Value)));
            }
        }

        private void userTypeListInit()
        {
            string[] names = { "seller", "customer" };

            foreach (string name in names)
            {
                userTypeList.Add(new UserType.UserType(name));
            }
        }

        private UserType.UserType getUserTypeObject(string name)
        {
            return userTypeList.Find(x => x.Name == name);
        }

        private void userListInit()
        {
            Dictionary<string, string> nicknameToType = new Dictionary<string, string>()
            {
                { "seller1","seller"},
                {"customer1","customer" },
                {"seller2","seller" },
                {"customer2","customer" }
            };

            foreach (KeyValuePair<string, string> pair in nicknameToType)
            {
                userList.Add(new User.User(pair.Key, getUserTypeObject(pair.Value)));
            }
        }
        private User.User getUserObject(string name)
        {
            return userList.Find(x => x.Name == name);
        }
        private Movie.Movie getMovieObject(string name)
        {
            return movieList.Find(x => x.Title == name);
        }

        private void rentalListInit()
        {
            Dictionary<string, string> nicknameToMovie = new Dictionary<string, string>()
            {
                {"customer1","Shrek" },
                {"customer2","The Ring" }
            };

            foreach (KeyValuePair<string, string> pair in nicknameToMovie)
            {
                rentalList.Add(new Rental.Rental(getUserObject(pair.Key), getMovieObject(pair.Value)));
            }

            rentalList.Add(new Rental.Rental(getUserObject("customer1"), getMovieObject("The Ring")));
            rentalList.Add(new Rental.Rental(getUserObject("customer1"), getMovieObject("Arrival")));
        }

        private void initDatabase()
        {
            movieCategoryListInit();
            MovieListInit();
            userTypeListInit();
            userListInit();
            rentalListInit();
        }

        public List<string> printAllUsers()
        {
            List<string> userNames=new List<string>();

            foreach (User.User user in userList)
            {
                userNames.Add(user.Name);
            }

            return userNames;
        }

        public List<string> printAllUserTypes()
        {
            List<string> userTypes = new List<string>();

            foreach(UserType.UserType type in userTypeList)
            {
                userTypes.Add(type.Name);
            }

            return userTypes;
        }

        public void addMovieCategory(string categoryName)
        {
            movieCategoryList.Add(new MovieCategory.MovieCategory(categoryName));
        }

        public List<Row> printUserRentals(string name)
        {
            List<Row> rentalListForTable = new List<Row>();
            List<Rental.Rental> userRentals = new List<Rental.Rental>();

            userRentals= rentalList.FindAll(x => x.User.Name == name);

            foreach(Rental.Rental rental in userRentals)
            {
                rentalListForTable.Add(new Row(rental.Movie.Title,rental.Movie.Category,rental.RentDate.ToString(),rental.BackDate.ToString()));
            }

            return rentalListForTable;
        }

        public List<Row> printAllMovies()
        {
            List<Row> movieListForTable = new List<Row>();

            foreach(Movie.Movie movie in movieList)
            {
                movieListForTable.Add(new Row(movie.Title,movie.Category));
            }

            return movieListForTable;
        }

        public List<Row> printAllRentals()
        {
            List<Row> allRentals = new List<Row>();

            foreach(Rental.Rental rental in rentalList)
            {
                allRentals.Add(new Row(rental.Movie.Title, rental.User.Name, rental.Movie.Category, rental.RentDate.ToString(), rental.BackDate.ToString()));
            }

            return allRentals;
        }

        public List<string> printAllMovieCategories()
        {
            List<string> movieCategories = new List<string>();

            foreach(MovieCategory.MovieCategory category in movieCategoryList)
            {
                movieCategories.Add(category.CategoryName);
            }

            return movieCategories;
        }

        public string getUserType(string userName)
        {
            return getUserObject(userName).Type.Name;
        }

        public void addRental(string userName,string movieTitle)
        {
            rentalList.Add(new Rental.Rental(getUserObject(userName), getMovieObject(movieTitle)));
        }

        public void addUser(string userName,string userType)
        {
            userList.Add(new User.User(userName, getUserTypeObject(userType)));
        }

        public void addMovie(string movieTitle, string movieCategory)
        {
            movieList.Add(new Movie.Movie(movieTitle,getCategoryObject(movieCategory)));
        }


    }

    [Serializable()]
    public class Row:MarshalByRefObject
    {
        List<string> columns=new List<string>();

        public Row(string column1,string column2,string column3,string column4)
        {
            columns.Add(column1);
            columns.Add(column2);
            columns.Add(column3);
            columns.Add(column4);
        }

        public Row(string column1, string column2, string column3, string column4,string column5)
        {
            columns.Add(column1);
            columns.Add(column2);
            columns.Add(column3);
            columns.Add(column4);
            columns.Add(column5);
        }

        public Row(string column1, string column2)
        {
            columns.Add(column1);
            columns.Add(column2);
        }

        public List<string> Columns
        {
            get
            {
                return columns;
            }
        }
    }
}
