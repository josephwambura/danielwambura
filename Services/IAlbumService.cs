using DanielWambura.Models.Entities;
using DanielWambura.Models;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DanielWambura.ApplicationCore.Services
{
    public interface IAlbumService
    {
        Task<FAlbum> GetFavAlbum(ApplicationUser user);
    }

    public interface IIdentityParser<T>
    {
        T Parse(IPrincipal principal);
    }
}