using Core.Entities;
using System;

namespace Entities.Dtos.Project
{
    public class ProjectAddDto : IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CustomerId { get; set; }
        public string ShortCode { get; set; }
    }
}