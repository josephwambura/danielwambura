using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using DanielWambura.Models.Entities;
using DanielWambura.Models.DawaViewModels;
using DanielWambura.Data;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
//using Dapper;

namespace DanielWambura.ApplicationCore.Services
{
    public class DawaImageService : IDawaImageService
    {
        private readonly DawaDbContext _context;
        private readonly IOptionsSnapshot<DawaImageSettings> _settings;
        private readonly ILogger<DawaImageService> _logger;

        public DawaImageService(DawaDbContext context,
            IOptionsSnapshot<DawaImageSettings> settings,
            ILoggerFactory loggerFactory)
        {
            _context = context;
            _settings = settings;
            _logger = loggerFactory.CreateLogger<DawaImageService>();
        }

        public async Task<DawaImage> GetDawaImageItems(int pageIndex, int itemsPage, int? brandId, int? typeId)
        {
            _logger.LogInformation("GetDawaImageItems called.");
            var root = (IQueryable<DawaImageItem>)_context.DawaImageItems;

            if (typeId.HasValue)
            {
                root = root.Where(ci => ci.DawaImageTypeId == typeId);
            }

            if (brandId.HasValue)
            {
                root = root.Where(ci => ci.DawaImageBrandId == brandId);
            }

            var totalItems = await root
                .LongCountAsync();

            var itemsOnPage = await root
                .Skip(itemsPage * pageIndex)
                .Take(itemsPage)
                .ToListAsync();

            itemsOnPage = ComposePicUri(itemsOnPage);

            return new DawaImage() { Data = itemsOnPage, PageIndex = pageIndex, Count = (int)totalItems };
        }

        public async Task<IEnumerable<SelectListItem>> GetBrands()
        {
            _logger.LogInformation("GetBrands called.");
            var brands = await _context.DawaImageBrands.ToListAsync();

            //// create
            //var newBrand = new DawaImageBrand() { Brand = "Acme" };
            //_context.Add(newBrand);
            //await _context.SaveChangesAsync();

            //// read and update
            //var existingBrand = _context.Find<DawaImageBrand>(1);
            //existingBrand.Brand = "Updated Brand";
            //await _context.SaveChangesAsync();

            //// delete
            //var brandToDelete = _context.Find<DawaImageBrand>(2);
            //_context.DawaImageBrands.Remove(brandToDelete);
            //await _context.SaveChangesAsync();

            //var brandsWithItems = await _context.DawaImageBrands
            //    .Include(b => b.Items)
            //    .ToListAsync();


            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            foreach (DawaImageBrand brand in brands)
            {
                items.Add(new SelectListItem() { Value = brand.Id.ToString(), Text = brand.Brand });
            }

            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetTypes()
        {
            _logger.LogInformation("GetTypes called.");
            var types = await _context.DawaImageTypes.ToListAsync();
            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            foreach (DawaImageType type in types)
            {
                items.Add(new SelectListItem() { Value = type.Id.ToString(), Text = type.Type });
            }

            return items;
        }

        private List<DawaImageItem> ComposePicUri(List<DawaImageItem> items)
        {
            var baseUri = _settings.Value.DawaImageBaseUrl;
            items.ForEach(x =>
            {
                //x.PictureUri = x.PictureUri.Replace("http://catalogbaseurltobereplaced", baseUri);
                x.PictureUri = x.PictureUri.Replace("http://dmwbaseurltobereplaced", baseUri);
            });

            return items;
        }

        //public async Task<IEnumerable<DawaImageType>> GetDawaImageTypes()
        //{
        //    return await _context.DawaImageTypes.ToListAsync();
        //}

        //private readonly SqlConnection _conn;
        //public async Task<IEnumerable<DawaImageType>> GetDawaImageTypesWithDapper()
        //{
        //    return await _conn.QueryAsync<DawaImageType>("SELECT * FROM DawaImageType");
        //}
    }
}
