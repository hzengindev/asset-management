using Core.Entities;
using System;

namespace Entities.Dtos.Project
{
    public class ProjectDeleteDto : IDto
    {
        public Guid Id { get; set; }
    }
}
