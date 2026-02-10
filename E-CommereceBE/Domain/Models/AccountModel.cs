using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Domain.Models
{
    public class AccountModel
    {
        [Key]
        public Guid AccountId { get; set; } = Guid.NewGuid();

        public string? Email {get;set;}
        
        [Required]
        public string? AccountName { get; set; }
        public string PasswordHash { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastLogin {get;set;}     
    }
}