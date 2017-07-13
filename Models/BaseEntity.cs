using System;
using System.Collections.Generic;
using System.Text;

namespace DanielWambura.Models
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}