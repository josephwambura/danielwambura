using System;
using System.Collections.Generic;
using System.Text;
using DanielWambura.Models;

namespace DanielWambura.Models.Entities
{
    public class FAlbumItem : BaseEntity<string>
    {
        public int DawaImageId { get; set; }
        public int Quantity { get; set; }
    }
}
