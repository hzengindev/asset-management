using Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class RolePermission : IEntity
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public string Scheme { get; set; }
    }
}