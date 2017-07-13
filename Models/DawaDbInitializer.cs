using DanielWambura.Data;
using DanielWambura.Models.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanielWambura.Models
{
    public static class DawaStoresDbInitializer
    {
        public static void Initialize(DawaDbContext context)
        {
            context.Database.EnsureCreated();
            //context.Database.EnsureDeleted();

            var dib = new DawaImageBrand[]
            {
                new DawaImageBrand() { Brand = "Brother"},
                new DawaImageBrand() { Brand = "Sister" },
                new DawaImageBrand() { Brand = "Son" },
                new DawaImageBrand() { Brand = "Daughter" },
                new DawaImageBrand() { Brand = "Cousin" }
            };

            foreach (DawaImageBrand p in dib) { context.DawaImageBrands.Add(p); }

            context.SaveChanges();

            var dit = new DawaImageType[]
            {
                new DawaImageType() { Type = "Mug"},
                new DawaImageType() { Type = "T-Shirt" },
                new DawaImageType() { Type = "Sheet" },
                new DawaImageType() { Type = "USB Memory Stick" }
            };

            foreach (DawaImageType p in dit) { context.DawaImageTypes.Add(p); }

            context.SaveChanges();

            var dii = new DawaImageItem[]
            {
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=2, Description = ".NET Bot Black Sweatshirt", Name = ".NET Bot Black Sweatshirt", DateTaken= DateTime.Parse("2013-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/1" },
                new DawaImageItem() { DawaImageTypeId=1,DawaImageBrandId=2, Description = ".NET Black & White Mug", Name = ".NET Black & White Mug", DateTaken= DateTime.Parse("2013-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/2" },
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=5, Description = "Prism White T-Shirt", Name = "Prism White T-Shirt", DateTaken= DateTime.Parse("2013-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/3" },
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=2, Description = ".NET Foundation Sweatshirt", Name = ".NET Foundation Sweatshirt", DateTaken= DateTime.Parse("2013-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/4" },
                new DawaImageItem() { DawaImageTypeId=3,DawaImageBrandId=5, Description = "Roslyn Red Sheet", Name = "Roslyn Red Sheet", DateTaken= DateTime.Parse("2013-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/5" },
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=2, Description = ".NET Blue Sweatshirt", Name = ".NET Blue Sweatshirt", DateTaken= DateTime.Parse("2013-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/6" },
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=5, Description = "Roslyn Red T-Shirt", Name = "Roslyn Red T-Shirt", DateTaken= DateTime.Parse("2013-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/7"  },
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=5, Description = "Kudu Purple Sweatshirt", Name = "Kudu Purple Sweatshirt", DateTaken= DateTime.Parse("2013-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/8" },
                new DawaImageItem() { DawaImageTypeId=1,DawaImageBrandId=5, Description = "Cup<T> White Mug", Name = "Cup<T> White Mug", DateTaken= DateTime.Parse("2013-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/9" },
                new DawaImageItem() { DawaImageTypeId=3,DawaImageBrandId=2, Description = ".NET Foundation Sheet", Name = ".NET Foundation Sheet", DateTaken= DateTime.Parse("2013-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/10" },
                new DawaImageItem() { DawaImageTypeId=3,DawaImageBrandId=2, Description = "Cup<T> Sheet", Name = "Cup<T> Sheet", DateTaken= DateTime.Parse("2013-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/11" },
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=5, Description = "Prism White TShirt", Name = "Prism White TShirt", DateTaken= DateTime.Parse("2013-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/12" }
            };

            foreach (DawaImageItem p in dii) { context.DawaImageItems.Add(p); }

            context.SaveChanges();
        }
    }
}
