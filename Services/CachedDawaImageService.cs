using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanielWambura.Models.Entities;
using DanielWambura.Models.DawaViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;

namespace DanielWambura.ApplicationCore.Services
{
    public class CachedDawaImageService : IDawaImageService
    {
        private readonly IMemoryCache _cache;
        private readonly DawaImageService _dawaImageService;
        private static readonly string _brandsKey = "brands";
        private static readonly string _typesKey = "types";
        private static readonly string _itemsKeyTemplate = "items-{0}-{1}-{2}-{3}";
        private static readonly TimeSpan _defaultCacheDuration = TimeSpan.FromSeconds(30);

        public CachedDawaImageService(IMemoryCache cache, DawaImageService dawaImageService)
        {
            _cache = cache;
            _dawaImageService = dawaImageService;
        }

        public async Task<IEnumerable<SelectListItem>> GetBrands()
        {
            return await _cache.GetOrCreateAsync(_brandsKey, async entry =>
            {
                entry.SlidingExpiration = _defaultCacheDuration;
                return await _dawaImageService.GetBrands();
            });
        }

        public async Task<DawaImage> GetDawaImageItems(int pageIndex, int itemsPage, int? brandID, int? typeId)
        {
            string cacheKey = String.Format(_itemsKeyTemplate, pageIndex, itemsPage, brandID, typeId);
            return await _cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.SlidingExpiration = _defaultCacheDuration;
                return await _dawaImageService.GetDawaImageItems(pageIndex, itemsPage, brandID, typeId);
            });
        }

        public async Task<IEnumerable<SelectListItem>> GetTypes()
        {
            return await _cache.GetOrCreateAsync(_typesKey, async entry =>
            {
                entry.SlidingExpiration = _defaultCacheDuration;
                return await _dawaImageService.GetTypes();
            });
        }
    }
}
