using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RoleModel
    {
        [Key]
        public Guid Id { get; set; } =Guid.NewGuid();
        public string Code { get; set; } = null!; // ADMIN, SELLER, BUYER
        public string? Name { get; set; }

    }
}