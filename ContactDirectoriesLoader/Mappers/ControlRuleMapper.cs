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
    /// Список доп. полей к заполнению  - маппер
    /// </summary>
    internal class ControlRuleMapper : IMapper<ControlRuleModel, ControlRule>
    {
        public ControlRule Map(ControlRuleModel controlRuleModel)
        {
            return new ControlRule()
            {
                //TODO Разобраться с nullable-полями.
                Version = controlRuleModel.Version,
                Id = controlRuleModel.Id,
                GroupNumber = (int)controlRuleModel.TypedGroupNumber,
                IsCond = (bool)controlRuleModel.TypedIsCond,
                SortOrder = (int)controlRuleModel.TypedSortOrder,
                MinValue = (decimal)controlRuleModel.TypedMinValue,
                MaxValue = (decimal)controlRuleModel.TypedMaxValue,
                CurrencyCode = controlRuleModel.CurrencyCode,
                CurrencyUseEquivalent = (int)controlRuleModel.TypedCurrencyUseEquivalent,
                SenderResident = (int)controlRuleModel.TypedSenderResident,
                FieldGroup = controlRuleModel.FieldGroup,
                FieldName = controlRuleModel.FieldName,
                FieldCaption = controlRuleModel.FieldCaption,
                FieldCaptionLat = controlRuleModel.FieldCaptionLat,
                RegularMask = controlRuleModel.RegularMask,
                Bic = controlRuleModel.Bic,
                IsRequired = (bool)controlRuleModel.TypedIsRequired,
                Example = controlRuleModel.Example,
                Comment = controlRuleModel.Comment,
                CommentLat = controlRuleModel.CommentLat,
                MaxLenght = (int)controlRuleModel.TypedMaxLenght,
                EditStates = controlRuleModel.EditStates,
                ShortCaption = controlRuleModel.ShortCaption,
                ShortCaptionLat = controlRuleModel.ShortCaptionLat,
                InOutEdit = (int)controlRuleModel.TypedInOutEdit,
                DataType = controlRuleModel.DataType,
                Visible = (bool)controlRuleModel.TypedVisible,
                ControlMode = (int)controlRuleModel.TypedControlMode,
                Lang = controlRuleModel.Lang,
            };
        }
    }
}

   