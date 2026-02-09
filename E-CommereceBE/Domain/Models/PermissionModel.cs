using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PermissionModel
    {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Code { get; set; } = null!; // PRODUCT.CREATE, ORDER.VIEW
    public string? Module { get; set; }
    }
}