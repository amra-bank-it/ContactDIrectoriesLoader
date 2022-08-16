using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Models
{
    /// <summary>
    /// Логотипы участников  - маппер
    /// </summary>
    internal class LogoMapper : IMapper<LogoModel, Logo>
    {
        public Logo Map(LogoModel logoModel)
        {
            return new Logo()
            {
                Version = logoModel.Version,
                Erased = (bool)logoModel.TypedErased,
                Id = logoModel.Id,
                LogoName = logoModel.LogoName,
                LogoDataBlob = logoModel.LogoDataBlob != null ? Convert.FromBase64String(logoModel.LogoDataBlob) : null,
                LogoDataLat = logoModel.LogoDataLat != null ? Convert.FromBase64String(logoModel.LogoDataLat) : null,
            };
        }
    }
}
