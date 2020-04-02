using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    [Table("Customer")]
    public class Customer : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public CustomerStatusTypes StatusCode { get; set; }
        public CustomerStateTypes StateCode { get; set; }
    }

    public enum CustomerStatusTypes : short
    {
        Deactive = 0,
        Active = 1
    }
    public enum CustomerStateTypes : short
    {
        Deactive = 0,
        Active = 1
    }
}