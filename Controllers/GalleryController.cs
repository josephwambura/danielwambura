using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using DanielWambura.ApplicationCore.Services;
using DanielWambura.ApplicationCore.Exceptions;
using DanielWambura.Models.DawaViewModels;

namespace DanielWambura.Controllers
{
    //[Authorize]
    public class GalleryController : Controller
    {
        private readonly IHostingEnvironment _env;
        private readonly IDawaImageService _dawaImageService;
        private readonly IImageService _imageService;
        private readonly IAppLogger<GalleryController> _logger;

        public GalleryController(IHostingEnvironment env,
            IDawaImageService dawaImageService,
            IImageService imageService,
            IAppLogger<GalleryController> logger)
        {
            _env = env;
            _dawaImageService = dawaImageService;
            _imageService = imageService;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int? brandFilterApplied, int? typesFilterApplied, int? page)
        {
            var itemsPage = 10;
            var dawaImages = await _dawaImageService.GetDawaImageItems(page ?? 0, itemsPage, brandFilterApplied, typesFilterApplied);

            var vm = new DawaImageIndex()
            {
                DawaImageItems = dawaImages.Data,
                Brands = await _dawaImageService.GetBrands(),
                Types = await _dawaImageService.GetTypes(),
                BrandFilterApplied = brandFilterApplied ?? 0,
                TypesFilterApplied = typesFilterApplied ?? 0,
                PaginationInfo = new PaginationInfo()
                {
                    ActualPage = page ?? 0,
                    ItemsPerPage = dawaImages.Data.Count,
                    TotalItems = dawaImages.Count,
                    TotalPages = int.Parse(Math.Ceiling(((decimal)dawaImages.Count / itemsPage)).ToString())
                }
            };

            vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
            vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";

            return View(vm);
        }
        
        [HttpGet("[controller]/upload/{id}")]
        public IActionResult GetImage(int id)
        {
            byte[] imageBytes;
            try
            {
                imageBytes = _imageService.GetImageBytesById(id);
            }
            catch (DawaImageImageMissingException ex)
            {
                _logger.LogWarning($"No image found for id: {id}" + ex.ToString());
                return NotFound();
            }
            return File(imageBytes, "image/png");
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
