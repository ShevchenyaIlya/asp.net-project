namespace WebApplication1.models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAuthenticated { get; set; }
        public string ImageUrl { get; set; }
    }
}