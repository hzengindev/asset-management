using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;

namespace Entities
{
    public class AMContext : DbContext
    {
        public AMContext(DbContextOptions<AMContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Concrete.Version> Versions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userId = Guid.NewGuid();
            var projectId = Guid.NewGuid();
            var customerId = Guid.NewGuid();
            var projectUserId = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = userId,
                FirstName= "admin",
                LastName="admin",
                Email = "admin@test.com",
                PasswordHash = "Pe/GAkoysqFrrBJ9ECjYmzO0JH6Eu6Xae3YcY5Hld39noqbz8vvhTcZp+uZ5whfJuK+PBqNpIMEACVQc7ZDqXw==",
                PasswordSalt = "Pj8PdCe/AMmXEcpofLIwMQe487JOZKRUVj6+drP75QtaTazArhso+zE7IxN1ehtKD3ldJfJE9+Rta0knsQ9hOWBvZob6WJTIfdMW1vMy9LosGpc5VWWq1x3OFl9HiMqAz98rpS0oXd7woxZYjEFyyGyISCyLIMW+aFeqoXJq9jc=",
                StateCode = UserStateTypes.Active,
                StatusCode = UserStatusTypes.Active,
                ModifiedBy = userId,
                ModifiedOn = DateTime.Now,
                CreatedBy = userId,
                CreatedOn = DateTime.Now
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = customerId,
                Name = "Demo customer",
                StateCode = CustomerStateTypes.Active,
                StatusCode = CustomerStatusTypes.Active,
                ModifiedBy = userId,
                ModifiedOn = DateTime.Now,
                CreatedBy = userId,
                CreatedOn = DateTime.Now
            });

            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = projectId,
                CustomerId = customerId,
                Name = "Demo project",
                Description = "Demo project",
                ShortCode = "Demo-Project",
                StateCode = ProjectStateTypes.Active,
                StatusCode = ProjectStatusTypes.Active,
                ModifiedBy = userId,
                ModifiedOn = DateTime.Now,
                CreatedBy = userId,
                CreatedOn = DateTime.Now
            });

            modelBuilder.Entity<ProjectUser>().HasData(new ProjectUser
            {
                Id = projectUserId,
                ProjectId = projectId,
                UserId = userId
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}