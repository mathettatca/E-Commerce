using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RolePermission
    {
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; } 
    }
}