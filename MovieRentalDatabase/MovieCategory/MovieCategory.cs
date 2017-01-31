namespace MovieRentalDatabase.MovieCategory
{
    class MovieCategory
    {
        private string categoryName;

        public MovieCategory(string categoryName)
        {
            this.categoryName = categoryName;
        }

        public string CategoryName
        {
            get
            {
                return categoryName;
            }
        }
    }
}