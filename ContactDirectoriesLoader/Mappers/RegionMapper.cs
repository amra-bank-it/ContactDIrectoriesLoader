using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Models;
using ContactDirectoriesLoader.Repository.Entities;

namespace ContactDirectoriesLoader.Mappers
{
    /// <summary>
    /// Перечень регионов, где расположены участники системы CONTACT - маппер.
    /// </summary>
    internal class RegionMapper : IMapper<RegionModel, Region>
    {
        public Region Map(RegionModel regionModel)
        {
            return new Region()
            {
                Version = regionModel.Version,
                Erased = (bool)regionModel.TypedErased,
                Id = regionModel.Id,
                SubdivisionIsoCode = regionModel.SubdivisionIsoCode,
                Country = (int)regionModel.TypedCountry,
                Name = regionModel.Name,
                NameSort = regionModel.NameSort,
                NameLat = regionModel.NameLat,
            };
        }
    }
}






