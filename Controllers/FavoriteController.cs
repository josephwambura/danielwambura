using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DanielWambura.Services;
using DanielWambura.ApplicationCore.Services;
using DanielWambura.Models;
using DanielWambura.Models.Entities;

namespace DanielWambura.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IDawaImageService _dawaImageSvc;
        private readonly IAlbumService _albumSvc;
        private readonly IIdentityParser<ApplicationUser> _appUserParser;

        public FavoriteController(IAlbumService albumSvc,
            IIdentityParser<ApplicationUser> appUserParser)
        {
            //_dawaImageSvc = dawaImageSvc;
            _albumSvc = albumSvc;
            _appUserParser = appUserParser;
        }


        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var user = _appUserParser.Parse(HttpContext.User);
            var viewmodel = await _albumSvc.GetFavAlbum(user);

            return View(viewmodel);
        }

        public async Task<IActionResult> AddToFav(DawaImageItem dawaImageDetails)
        {
            if (dawaImageDetails.Id != null)
            {
                var user = _appUserParser.Parse(HttpContext.User);
                var image = new FAlbumItem()
                {
                    Id = Guid.NewGuid().ToString(),
                    Quantity = 1,
                    DawaImageId = dawaImageDetails.Id
                };
                //await _albumSvc.AddImageToFavAlbum(user, image);
            }
            return RedirectToAction("Index", "Gallery");
        }

    }
}