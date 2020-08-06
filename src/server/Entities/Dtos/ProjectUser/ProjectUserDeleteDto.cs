using Core.Entities;
using System;

namespace Entities.Dtos.ProjectUser
{
    public class ProjectUserDeleteDto : IDto
    {
        public Guid Id { get; set; }
    }
}