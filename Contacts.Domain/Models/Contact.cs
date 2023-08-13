namespace Contacts.Domain.Models
{
    public class Contact:BaseEntity
    {
        public User User { get; set; }
    }
}
