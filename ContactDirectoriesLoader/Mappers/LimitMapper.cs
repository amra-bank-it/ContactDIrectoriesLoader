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
    /// ограничения на суммы отправляемых
    /// переводов/платежей  - маппер
    /// </summary>
    internal class LimitMapper : IMapper<LimitModel, Limit>
    {
        public Limit Map(LimitModel limitModel)
        {
            return new Limit()
            {
                Version = limitModel.Version,
                Erased = (bool)limitModel.TypedErased,
                Id = limitModel.Id,
                BankId = (int)limitModel.TypedBankId,
                CurrencyCode = limitModel.CurrencyCode,
                MinSum = (decimal)limitModel.TypedMinSum,
                MaxSum = (decimal)limitModel.TypedMaxSum,
            };
        }
    }
}
