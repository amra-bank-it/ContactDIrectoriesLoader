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
    /// Перечень лиц, операции с денежными средствами
    /// которых подлежат обязательному контролю.  - маппер
    /// </summary>
    internal class FinancialMonitoringInfoMapper : IMapper<FinancialMonitoringInfoModel, FinancialMonitoringInfo>
    {
        public FinancialMonitoringInfo Map(FinancialMonitoringInfoModel financialMonitoringInfo)
        {
            return new FinancialMonitoringInfo()
            {
                Version = financialMonitoringInfo.Version,
                Erased = (bool)financialMonitoringInfo.TypedErased,
                Id = financialMonitoringInfo.Id,
                LastName = financialMonitoringInfo.LastName,
                FirstName = financialMonitoringInfo.FirstName,
                MiddleName = financialMonitoringInfo.MiddleName,
                Birthday = financialMonitoringInfo.Birthday,
                Passport = financialMonitoringInfo.Passport,
                Address = financialMonitoringInfo.Address,
                Deleted = (bool)financialMonitoringInfo.TypedDeleted,
                NameU = financialMonitoringInfo.NameU,
            };
        }   
    }
}
