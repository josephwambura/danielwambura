using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanielWambura.Models
{
    public class ContactMessage
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Comment { get; set; }
    }
}
