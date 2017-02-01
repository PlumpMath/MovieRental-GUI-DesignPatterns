namespace MovieRentalDatabase.User
{
    public class User
    {
        private string name;
        private UserType.UserType type;
        private int points;

        public User (string name, UserType.UserType type)
        {
            this.name = name;
            this.type = type;
            this.points = 0;
        }

        public string Name
        {
            get { return name; }
        }

        public UserType.UserType Type
        {
            get
            {
                return type;
            }
        }

        public int Points
        {
            get { return points; }
            set { points = value; }
        }
    }
}
