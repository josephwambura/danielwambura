using System;
using System.Collections.Generic;
using System.Text;
using DanielWambura.Models;

namespace DanielWambura.Models.Entities
{
    public class DawaImageType : BaseEntity<int>
    {
        public string Type { get; set; }
    }
}
