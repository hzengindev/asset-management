using Core.Entities;
using System;

namespace Entities.Dtos.Customer
{
    public class CustomerDeleteDto : IDto
    {
        public Guid Id { get; set; }
    }
}