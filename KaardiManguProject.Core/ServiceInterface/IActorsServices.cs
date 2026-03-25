using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaardiManguProject.Core.Domain;
using KaardiManguProject.Core.Dto;

namespace KaardiManguProject.Core.ServiceInterface
{
    public interface IActorsServices
    {
        Task<Actors> Create(ActorsDTO dto);
        Task<Actors> Update(ActorsDTO dto);
        Task<Actors> Delete(Guid id);
        Task<Actors> DetailsAsync(Guid id);
    }
}
