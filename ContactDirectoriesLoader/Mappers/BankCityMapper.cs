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
    /// Справочник городов, в которых расположены участники Contact
    ///  - маппер.
    /// </summary>
    internal class BankCityMapper : IMapper<BankCityModel, BankCity>
    {
        public BankCity Map(BankCityModel bankCityModel)
        {
            return new BankCity()
            {
                Version = bankCityModel.Version,
                Erased = bankCityModel.Erased,
                Id = bankCityModel.Id,
                CityHead = bankCityModel.CityHead,
                CityLat = bankCityModel.CityLat,
                Country = bankCityModel.TypedCountry,
                Region = bankCityModel.TypedRegion,
                SendingCurrencies = bankCityModel.SendingCurrencies,
                ReceivingCurrencies = bankCityModel.ReceivingCurrencies,
                PointCode = bankCityModel.PointCode,
            };
        }
    }   
}