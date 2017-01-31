namespace MovieRentalDatabase.User
{
    class User
    {
        private string name;
        private UserType.UserType type;

        public User (string name, UserType.UserType type)
        {
            this.name = name;
            this.type = type;
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
    }
}
