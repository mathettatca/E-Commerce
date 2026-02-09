using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AccountRoleModel
    {
    public Guid AccountId { get; set; }
    public Guid RoleId { get; set; }
    public string RoleName {get;set;}
    }
}