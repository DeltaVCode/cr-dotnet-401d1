namespace TodoApi.Models.Api
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }

        public static implicit operator User(ApplicationUser user)
        {
            if (user == null) return null;

            return new User
            {
                Id = user.Id,
                Username = user.UserName,
            };
        }
    }
}