using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaardiManguProject.Core.Domain;
using KaardiManguProject.Core.Dto;

namespace KaardiManguProject.Core.ServiceInterface
{
    public interface IMovieServices
    {
        Task<Movie> Create (MoviesDTO dto);
        Task<Movie> Update(MoviesDTO dto);
        Task<Movie> Delete(Guid id);
        Task<Movie> DetailsAsync(Guid id);
    }
}
