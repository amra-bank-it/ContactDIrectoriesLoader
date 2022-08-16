using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Models;
using ContactDirectoriesLoader.Repository.Entities;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDirectoriesLoader.Mappers
{
    internal class BankMapper : IMapper<BankModel, Bank>
    {
        public Bank Map(BankModel bankModel)
        {
            return new Bank()
            {
                Version = bankModel.Version,
                DbOperation = bankModel.DbOperation,
                //TODO Разобраться, чтобы nullable (или нет) тип был там и там
                Erased = (bool)bankModel.TypedErased,
                Id = bankModel.Id,
                ParentId = bankModel.TypedParentId,
                PointCode = bankModel.PointCode,
                Bic = bankModel.Bic,
                Name = bankModel.Name,
                CityHead = bankModel.CityHead,
                Address = bankModel.Address,
                WorkingHours = bankModel.WorkingHours,
                WeekendsHours = bankModel.WeekendsHours,
                ReservedAddress = bankModel.ReservedAddress,
                Phone = bankModel.Phone,
                NameRus = bankModel.NameRus,
                CountryId = bankModel.TypedCountryId,
                IsDeleted = bankModel.TypedIsDeleted,
                CityLat = bankModel.CityLat,
                AddressLat = bankModel.AddressLat,
                Contact = bankModel.TypedContact,
                RegionId = bankModel.TypedRegionId,
                IsKfm = bankModel.TypedIsKfm,
                IsOnline = bankModel.TypedIsOnline,
                CanRevoke = bankModel.TypedCanRevoke,
                CanChange = bankModel.TypedCanChange,
                NeedGetMoney = bankModel.TypedNeedGetMoney,
                SendingCurrencies = bankModel.SendingCurrencies,
                ReceivingCurrencies = bankModel.ReceivingCurrencies,
                AttributeGroups = bankModel.AttributeGroups,
                CityId = bankModel.TypedCityId,
                LogoId = bankModel.TypedLogoId,
                ScenId = bankModel.TypedScenId,
                UniqueTrn = bankModel.TypedUniqueTrn,
                MetroId = bankModel.TypedMetroId,
            };
        }
    }
}
