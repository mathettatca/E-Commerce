using System;
using System.Text.RegularExpressions;

namespace Domain.Models
{
    public class AccountModel
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Email {get;set;}
        
        public string? AccountName { get; set; }
        public string PasswordHash { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}