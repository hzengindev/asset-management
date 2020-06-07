using Core.Entities;
using System;

namespace Entities.Dtos.Project
{
    public class ProjectUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CustomerId { get; set; }
        public string ShortCode { get; set; }
        public Concrete.ProjectStatusTypes StatusCode { get; set; }
        public Concrete.ProjectStateTypes StateCode { get; set; }
    }
}