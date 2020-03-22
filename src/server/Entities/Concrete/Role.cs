using Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class Role : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}