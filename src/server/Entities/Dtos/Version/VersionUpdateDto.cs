using Core.Entities;
using Entities.Concrete;
using System;

namespace Entities.Dtos.Version
{
    public class VersionUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set; }
        public Guid CustomerId { get; set; }
        public VersionStateTypes StateCode { get; set; }
        public VersionStatusTypes StatusCode { get; set; }
    }
}