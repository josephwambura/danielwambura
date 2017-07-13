using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace DanielWambura.Models.Entities
{
    public class DawaImageItem : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //public decimal Price { get; set; }
        [Display(Name = "Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateTaken { get; set; }
        public string PictureUri { get; set; }
        public int DawaImageTypeId { get; set; }
        public DawaImageType DawaImageType { get; set; }
        public int DawaImageBrandId { get; set; }
        public DawaImageBrand DawaImageBrand { get; set; }
        public DawaImageItem() { }
    }
}