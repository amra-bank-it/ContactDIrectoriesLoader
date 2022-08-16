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
    /// Cписок стран, где расположены участники системы CONTACT - маппер
    /// </summary>
    internal class CountryMapper : IMapper<CountryModel, Country>
    {
        public Country Map(CountryModel countryModel)
        {
            return new Country()
            {
                Version = countryModel.Version,
                Erased = (bool)countryModel.TypedErased,
                Id = countryModel.Id,
                Name = countryModel.Name,
                NameLat = countryModel.NameLat,
                Code = countryModel.Code,
                SendingCurrencies = countryModel.SendingCurrencies,
                ReceivingCurrencies = countryModel.ReceivingCurrencies,
                IsFatf = countryModel.TypedIsFatf,
                PointCode = countryModel.PointCode,
            };
        }
    }
}