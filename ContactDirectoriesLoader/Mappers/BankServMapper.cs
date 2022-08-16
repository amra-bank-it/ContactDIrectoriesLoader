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
    /// Связь участников системы (BANKS) и оказываемые ими услуг(SERV) - маппер
    /// </summary>
    internal class BankServMapper : IMapper<BankServModel, BankServ>
    {
        public BankServ Map(BankServModel bankServModel)
        {
            return new BankServ()
            {
                Version = bankServModel.Version,
                //TODO Разобраться, чтобы nullable (или нет) тип был там и там
                Erased = (bool)bankServModel.TypedErased,
                Id = bankServModel.Id,
                BankId = bankServModel.BankId,
                ServId = bankServModel.ServId,
            };
        }
    }
}
