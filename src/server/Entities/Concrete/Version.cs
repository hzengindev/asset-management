using Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    [Table("Version")]
    public class Version : IEntity
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
        public Guid ProjectId { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        [MaxLength(1000)]
        public string DirectoryPath { get; set; }
        [Required]
        [MaxLength(1000)]
        public string PreviewFile { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public VersionStatusTypes StatusCode { get; set; }
        public VersionStateTypes StateCode { get; set; }
    }

    public enum VersionStatusTypes : short
    {
        Deactive = 0,
        Active = 1
    }
    public enum VersionStateTypes : short
    {
        Deactive = 0,
        Active = 1
    }
}