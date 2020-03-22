using Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifedBy { get; set; }
    }
}