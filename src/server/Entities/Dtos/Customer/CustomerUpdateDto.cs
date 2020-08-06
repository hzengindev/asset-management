using Core.Entities;
using Entities.Concrete;
using System;

namespace Entities.Dtos.Customer
{
    public class CustomerUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CustomerStatusTypes StatusType { get; set; }
        public CustomerStateTypes StateType { get; set; }
    }
}