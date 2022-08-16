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
    /// Таблица содержит список станций метро - маппер.
    /// </summary>
    internal class MetroStationMapper : IMapper<MetroStationModel, MetroStation>
    {
        public MetroStation Map(MetroStationModel metroStationModel)
        {
            return new MetroStation()
            {
                Version = metroStationModel.Version,
                Erased = (bool)metroStationModel.TypedErased,
                Id = metroStationModel.Id,
                City = (int)metroStationModel.TypedCity,
                LineId = (int)metroStationModel.TypedLineId,
                Name = metroStationModel.Name,
            };
        } 
    }
}
