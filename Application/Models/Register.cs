using Domain.Entities;

namespace Application.Models
{
    public class Register
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
    }
}
