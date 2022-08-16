using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Models
{
    /// <summary>
    /// ограничения на суммы отправляемых
    /// переводов/платежей  - модель для сериализации
    /// </summary>
    [XmlRoot(ElementName = "ROW")]
    [Serializable]
    public class LimitModel : IDirectoryModel
    {
        [XmlIgnore]
        private bool? ErasedField { get; set; }
        [XmlIgnore]
        private int? BankIdField { get; set; }
        [XmlIgnore]
        private decimal? MinSumField { get; set; }
        [XmlIgnore]
        private decimal? MaxSumField { get; set; }

        /// <summary>
        /// Версия записи
        /// </summary>
        [XmlAttribute(AttributeName = "VERSION")]
        public int Version { get; set; }

        /// <summary>
        /// Флаг, указывающий на то, что запись подлежит удалению из справочника на
        /// стороне клиента.
        /// 0 – запись удалению не подлежит.
        /// 1 – запись подлежит удалению.
        /// </summary>
        [XmlAttribute(AttributeName = "ERASED")]
        public string Erased
        {
            get
            {
                return ErasedField.HasValue ? ErasedField.Value.ToString() : "";
            }

            set
            {
                ErasedField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToBoolean(Convert.ToInt32(value))
                 : (bool?)null;
            }
        }

        /// <summary>
        /// Уникальный идентификатор записи
        /// </summary>
        [XmlAttribute(AttributeName = "ID")]
        public int Id { get; set; }

        /// <summary>
        /// Уникальный идентификатор участника системы Contact
        /// </summary>
        [XmlAttribute(AttributeName = "BANK_ID")]
        public string BankId
        {
            get
            {
                return BankIdField.HasValue ? BankIdField.Value.ToString() : "";
            }
            set
            {
                BankIdField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// Код валюты перевода/платежа
        /// </summary>
        [XmlAttribute(AttributeName = "CURR_CODE")]
        public string CurrencyCode { get; set; }

        /// <summary>
        ///  Минимальная сумма перевода/платежа
        /// </summary>
        [XmlAttribute(AttributeName = "MIN_SUM")]
        public string MinSum
        {
            get
            {
                return MinSumField.HasValue ? MinSumField.Value.ToString() : "";
            }
            set
            {
                if (value == null)
                {
                    MinSumField = null;
                }
                else
                {
                    var cultureInfo = CultureInfo.InvariantCulture.Clone() as CultureInfo;
                    cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
                    MinSumField = Convert.ToDecimal(value, cultureInfo);
                }
            }
        }

        /// <summary>
        /// Максимальная сумма перевода/платежа
        /// </summary>
        [XmlAttribute(AttributeName = "MAX_SUM")]
        public string MaxSum
        {
            get
            {
                return MaxSumField.HasValue ? MaxSumField.Value.ToString() : "";
            }
            set
            {
                if (value == null)
                {
                    MaxSumField = null;
                }
                else
                {
                    var cultureInfo = CultureInfo.InvariantCulture.Clone() as CultureInfo;
                    cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
                    MaxSumField = Convert.ToDecimal(value, cultureInfo);
                }
            }
        }


        #region Типизированные знчения нестроковых параметров
        public bool? TypedErased => ErasedField;
        public int? TypedBankId => BankIdField;
        public decimal? TypedMinSum => MinSumField;
        public decimal? TypedMaxSum => MaxSumField;

        #endregion

    }
}
