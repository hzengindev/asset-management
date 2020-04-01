using Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    [Table("Project")]
    public class Project : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        [MaxLength(100)]
        public string ShortCode { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime ModifiedOn { get; set; }
        [Required]
        public Guid CreatedBy { get; set; }
        [Required]
        public Guid ModifiedBy { get; set; }
        [Required]
        public ProjectStatusTypes StatusCode { get; set; }
        [Required]
        public ProjectStateTypes StateCode { get; set; }
    }

    public enum ProjectStatusTypes : short
    {
        Deactive = 0,
        Active = 1
    }
    public enum ProjectStateTypes : short
    {
        Deactive = 0,
        Active = 1
    }
}