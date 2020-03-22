using Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class UserRole : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}