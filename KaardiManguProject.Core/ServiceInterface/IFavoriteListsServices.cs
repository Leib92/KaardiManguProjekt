using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaardiManguProject.Core.Domain;
using KaardiManguProject.Core.Dto;

namespace KaardiManguProject.Core.ServiceInterface
{
    public interface IFavoriteListsServices
    {
        Task<FavoriteList> DetailsAsync(Guid id);
        Task<FavoriteList> Create(FavoriteListDTO dto);
        Task<FavoriteList> Update(FavoriteListDTO updatedList, string typeOfMethod);
    }
}
