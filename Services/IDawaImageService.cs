using DanielWambura.Models.DawaViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanielWambura.ApplicationCore.Services
{
    public interface IDawaImageService
    {
        Task<DawaImage> GetDawaImageItems(int pageIndex, int itemsPage, int? brandID, int? typeId);
        Task<IEnumerable<SelectListItem>> GetBrands();
        Task<IEnumerable<SelectListItem>> GetTypes();
    }
}