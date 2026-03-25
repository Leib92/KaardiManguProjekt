using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaardiManguProject.Core.Domain;
using KaardiManguProject.Core.Dto.AccuWeatherDTOs;
using KaardiManguProject.Core.Dto.OmdbapiDTOs;

namespace KaardiManguProject.Core.ServiceInterface
{
    public interface IOmdbapiServices
    {
        Task<OmdbapiMovieResultDTO> OmdbapiResult(OmdbapiMovieResultDTO dto);
        Movie Create(OmdbapiMovieCreateDTO dto);
    }
}
