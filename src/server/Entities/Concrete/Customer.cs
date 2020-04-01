using Entities.Abstract;
using System;
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
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime ModifiedOn { get; set; }
        [Required]
        public Guid CreatedBy { get; set; }
        [Required]
        public Guid ModifiedBy { get; set; }
        [Required]
        public CustomerStatusTypes StatusCode { get; set; }
        [Required]
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