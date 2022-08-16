using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Models;
using ContactDirectoriesLoader.Repository.Entities;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Mappers
{
    /// <summary>
    /// Таблица содержит список линий метро в городах  - маппер
    /// </summary>
    internal class MetroLineMapper : IMapper<MetroLineModel, MetroLine>
    {
        public MetroLine Map(MetroLineModel metroLineModel)
        {
            return new MetroLine()
            {
                Version = metroLineModel.Version,
                Erased = (bool)metroLineModel.TypedErased,
                Id = metroLineModel.Id,
                City = (int)metroLineModel.TypedCity,
                Name = metroLineModel.Name,
            };
        }    
    }
}
