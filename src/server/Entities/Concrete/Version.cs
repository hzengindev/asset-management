using Core.Entities;
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
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set; }
        public Guid CustomerId { get; set; }
        public string DirectoryPath { get; set; }
        public string PreviewFile { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        [DataType(DataType.DateTime)]
        public Guid CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
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