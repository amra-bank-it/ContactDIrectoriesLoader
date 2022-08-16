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
    /// Перечень услуг, которые оказывают участники системы CONTACT.  - маппер
    /// </summary>
    internal class ServMapper : IMapper<ServModel, Serv>
    {
        public Serv Map(ServModel servModel)
        {
            return new Serv()
            {
                Version = servModel.Version,
                Erased = (bool)servModel.TypedErased,
                Id = servModel.Id,
                ParentId = (int)servModel.TypedParentId,
                Caption = servModel.Caption,
                Comment = servModel.Comment,
                CaptionLat = servModel.CaptionLat,
                CommentLat = servModel.CommentLat,
                CanIn = (bool)servModel.TypedCanIn,
                CanPay = (bool)servModel.TypedCanPay,
                CsIn = servModel.CsIn,
                CsinFee = servModel.CsinFee,
                CsPay = servModel.CsPay,
            };
        }
    }
}