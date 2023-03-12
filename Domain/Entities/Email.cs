namespace Domain.Entities
{
    public class Email
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; } = null!;
        public bool Malling { get; set; }
        public int UserId { get; set; }
    }
}
