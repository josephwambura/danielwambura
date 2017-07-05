using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanielWambura.Models
{
    public class AttendingViewModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public bool Confirm { get; set; }
        public string ExtraMessage { get; set; }
    }
}