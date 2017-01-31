namespace MovieRentalDatabase.Movie
{
    class Movie
    {
        private string title;
        private MovieCategory.MovieCategory category;
  
        public Movie(string title,MovieCategory.MovieCategory category)
        {
            this.title = title;
            this.category = category;
        }
        public string Title
        {
            get
            {
                return title;
            }
        }

        public string Category
        {
            get
            {
                return category.CategoryName;
            }
        }
    }
}
