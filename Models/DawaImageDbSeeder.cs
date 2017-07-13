using DanielWambura.Models.Entities;
using DanielWambura.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanielWambura.Models
{
    public class DawaImageDbSeeder
    {
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                var context = (DawaDbContext)applicationBuilder.ApplicationServices.GetService(typeof(DawaDbContext));

                // TODO: Only run this if using a real database
                // context.Database.Migrate();
                context.Database.EnsureCreated();

                if (!context.DawaImageBrands.Any())
                {
                    context.DawaImageBrands.AddRange(
                        GetPreconfiguredDawaImageBrands());

                    await context.SaveChangesAsync();
                }

                if (!context.DawaImageTypes.Any())
                {
                    context.DawaImageTypes.AddRange(
                        GetPreconfiguredDawaImageTypes());

                    await context.SaveChangesAsync();
                }

                if (!context.DawaImageItems.Any())
                {
                    context.DawaImageItems.AddRange(
                        GetPreconfiguredItems());

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger("DawaDatabase seed");
                    log.LogError(ex.Message);
                    await SeedAsync(applicationBuilder, loggerFactory, retryForAvailability);
                }
            }
        }

        static IEnumerable<DawaImageBrand> GetPreconfiguredDawaImageBrands()
        {
            return new List<DawaImageBrand>()
            {
                new DawaImageBrand() { Brand = "Parent"},
                new DawaImageBrand() { Brand = "Sibling" },
                new DawaImageBrand() { Brand = "Family" },
                new DawaImageBrand() { Brand = "Classmates" },
                new DawaImageBrand() { Brand = "Agemates" },
                new DawaImageBrand() { Brand = "Colleagues" }
            };
        }

        static IEnumerable<DawaImageType> GetPreconfiguredDawaImageTypes()
        {
            return new List<DawaImageType>()
            {
                new DawaImageType() { Type = "Male"},
                new DawaImageType() { Type = "Female" },
                new DawaImageType() { Type = "Other"},
                new DawaImageType() { Type = "Mixed" },
            };
        }

        static IEnumerable<DawaImageItem> GetPreconfiguredItems()
        {
            return new List<DawaImageItem>()
            {
                new DawaImageItem() { DawaImageTypeId=1,DawaImageBrandId=3, Description = "Mr. Mburu with sons: the late Mburu and Wanjohi", Name = "Mr. Mburu with sons: the late Mburu and Wanjohi", DateTaken= DateTime.Parse("1994-04-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/1001" },
                new DawaImageItem() { DawaImageTypeId=1,DawaImageBrandId=3, Description = "Mr. Mburu with son Githithu", Name = "Mr. Mburu with son Githithu", DateTaken= DateTime.Parse("2009-02-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/1002" },
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=3, Description = "Mr. Mburu with wife Wairimu and daughter Murugi", Name = "Mr. Mburu with wife Wairimu and daughter Murugi", DateTaken= DateTime.Parse("2017-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/1003" },
                new DawaImageItem() { DawaImageTypeId=4,DawaImageBrandId=2, Description = "Mr. Mburu with some siblings and sons", Name = "Mr. Mburu with some siblings and sons", DateTaken= DateTime.Parse("1991-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/1004" },
                
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=2, Description = "Mr. Mburu with a sibling, Susan Njoki", Name = "Mr. Mburu with a sibling, Susan Njoki", DateTaken= DateTime.Parse("1984-04-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/1005" },
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=3, Description = "Mr. Mburu with wife at son Mburu's funeral", Name = "Mr. Mburu with wife at son Mburu's funeral", DateTaken= DateTime.Parse("2011-02-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/1006" },
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=3, Description = "Mr. Mburu with grandchildren", Name = "Mr. Mburu with grandchildren", DateTaken= DateTime.Parse("2011-02-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/1007" },
               
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=2, Description = "Left Front Red", Name = "Left Front Red", DateTaken= DateTime.Parse("2013-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/1" },
                new DawaImageItem() { DawaImageTypeId=1,DawaImageBrandId=5, Description = "Left Rear Red", Name = "Left Rear Red", DateTaken= DateTime.Parse("1999-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/2" },
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=2, Description = "Right Red", Name = "Right Red", DateTaken= DateTime.Parse("1995-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/3" },
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=5, Description = "Right Close Rear Red", Name = "Right Close Rear Red", DateTaken= DateTime.Parse("2005-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/4"  },
                new DawaImageItem() { DawaImageTypeId=1,DawaImageBrandId=5, Description = "Right Front Red", Name = "Right Front Red", DateTaken= DateTime.Parse("1999-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/5" },
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=2, Description = "Left Up-Front Red", Name = "Left Up-Front Red", DateTaken= DateTime.Parse("1995-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/6" },
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=5, Description = "Left Up-Rear Red", Name = "Left Up-Rear Red", DateTaken= DateTime.Parse("2005-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/7"  },
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=5, Description = "Right Close-Up Front Red", Name = "Right Close-Up Front Red", DateTaken= DateTime.Parse("2013-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/8" },
                new DawaImageItem() { DawaImageTypeId=1,DawaImageBrandId=5, Description = "Right 45 Angle Aerial Rear Red", Name = "Right 45 Angle Aerial Rear Red", DateTaken= DateTime.Parse("2002-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/9" },
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=2, Description = "Front 45 Angle Aerial Red", Name = "Front 45 Angle Aerial Red", DateTaken= DateTime.Parse("1979-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/10" },
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=2, Description = "Left Front DashWheel Red", Name = "Left Front DashWheel Red", DateTaken= DateTime.Parse("1988-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/11" },
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=5, Description = "Prism White TShirt", Name = "Prism White TShirt", DateTaken= DateTime.Parse("1997-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/12" },
                
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=5, Description = "Label 45 Angle Dash Red", Name = "Label 45 Angle Dash Red", DateTaken= DateTime.Parse("2013-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/13" },
                new DawaImageItem() { DawaImageTypeId=1,DawaImageBrandId=5, Description = "Wheel 45 Angle Dash Red", Name = "Wheel 45 Angle Dash Red", DateTaken= DateTime.Parse("2002-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/14" },
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=2, Description = "Left Headlights Red", Name = "Left Headlights Red", DateTaken= DateTime.Parse("1979-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/15" },
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=2, Description = "Right Side-Mirror Red", Name = "Right Side-Mirror Red", DateTaken= DateTime.Parse("1988-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/16" },
                new DawaImageItem() { DawaImageTypeId=2,DawaImageBrandId=5, Description = "Right Side-Backbody Red", Name = "Right Side-Backbody Red", DateTaken= DateTime.Parse("1997-09-01"), PictureUri = "http://dmwbaseurltobereplaced/gallery/upload/17" }
            };
        }
    }
}