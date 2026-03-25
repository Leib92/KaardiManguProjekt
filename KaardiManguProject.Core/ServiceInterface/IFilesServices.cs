using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaardiManguProject.Core.Domain;
using KaardiManguProject.Core.Dto;

namespace KaardiManguProject.Core.ServiceInterface
{
    public interface IFilesServices
    {
        void FilesToApi(MoviesDTO dto, Movie domain);

        Task<FileToApi> RemoveImageFromApi(FileToApiDTO dto);

        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDTO[] dto);
    }
}
