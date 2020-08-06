using Core.Entities;
using System;

namespace Entities.Dtos.Version
{
    public class VersionDeleteDto : IDto
    {
        public Guid Id { get; set; }
    }
}
