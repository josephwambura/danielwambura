using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanielWambura.Models.Entities;

namespace DanielWambura.Models.DawaViewModels
{
    public class DawaImage
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public List<DawaImageItem> Data { get; set; }
    }
}