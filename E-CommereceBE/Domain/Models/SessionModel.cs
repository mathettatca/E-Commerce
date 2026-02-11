using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SessionModel
    {
        public Guid SessionId { get; set; }
        public Guid AccountId { get; set; }
        public string? RefreshToken { get; set; }
        public string? AccessToken { get; set; }
        public DateTime ExpiredTime { get; set; }
        public LoginType LoginMethod { get; set; }
    }
        public enum LoginType
    {
        Mobile = 1,
        Web = 2
    }
}