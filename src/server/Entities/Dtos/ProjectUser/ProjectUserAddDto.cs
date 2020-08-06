using Core.Entities;
using System;

namespace Entities.Dtos.ProjectUser
{
    public class ProjectUserAddDto : IDto
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }   
    }
}