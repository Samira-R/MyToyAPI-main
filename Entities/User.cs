using System.ComponentModel.DataAnnotations;

namespace MyToyAPI.Entities
{
    public class User
    {
     

        [Key]
        public Guid Id { get; set; }

        // ===== Identity =====

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(256)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(512)]
        public string PasswordHash { get; set; } = null!;

        // ===== Status =====

        public bool IsActive { get; set; } = true;

        // ===== Audit =====

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // ===== Navigation =====

        // public ICollection<Order> Orders { get; set; } = new List<Order>();
        // public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }





}

