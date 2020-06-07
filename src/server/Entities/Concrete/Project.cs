using Core.Entities;
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
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortCode { get; set; }
        public Guid CustomerId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ModifiedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public ProjectStatusTypes StatusCode { get; set; }
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