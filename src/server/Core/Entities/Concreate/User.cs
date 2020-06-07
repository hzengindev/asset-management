using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Concrete
{
    [Table("User")]
    public class User : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public string RefreshToken { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? RefreshTokenExpiryDate { get; set; }
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