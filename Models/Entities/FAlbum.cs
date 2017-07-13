using System;
using System.Collections.Generic;
using System.Text;
using DanielWambura.Models;

namespace DanielWambura.Models.Entities
{
    public class FAlbum : BaseEntity<string>
    {
        public string UserId { get; set; }
        public List<FAlbumItem> Items { get; set; } = new List<FAlbumItem>();
    }
}
