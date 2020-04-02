using Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    [Table("User")]
    public class User : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(1000)]
        public string PasswordSalt { get; set; }
        [Required]
        [MaxLength(1000)]
        public string PasswordHash { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public UserStatusTypes StatusCode { get; set; }
        public UserStateTypes StateCode { get; set; }
    }

    public enum UserStatusTypes : short
    {
        Deactive = 0,
        Active = 1
    }
    public enum UserStateTypes : short
    {
        Deactive = 0,
        Active = 1
    }
}