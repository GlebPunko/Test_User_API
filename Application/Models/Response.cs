using Domain.Entities;

namespace Application.Models
{
    public class Response
    {
        public string Login { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public Email Email { get; set; } = null!;
    }
}
