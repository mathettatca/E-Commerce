using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class HistoryLoginModel
    {
        public Guid Id { get; set; }
        public string? DeviceId {get;set;}
        public string? DeviceName  {get;set;}
        public string? Username {get;set;}
        public DateTime? LoginDate {get;set;}
        public bool? IsActive {get;set;}
        public bool? IsSuccess {get;set;}
    }
}