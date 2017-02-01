namespace MovieRentalDatabase.PointsCount
{
    class CountStrategy
    {
        ICountable countStrategy;

        public CountStrategy(ICountable countStrategy)
        {
            this.countStrategy = countStrategy;
        }

        public void executeStrategy(string userName)
        {
            countStrategy.count(userName);
        }
    }
}
