using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Models
{
    /// <summary>
    /// Перечень участников, имеющих особенности в правилах  - модель для сериализации
    /// обслуживания клиентов
    /// </summary>
    [XmlRoot(ElementName = "ROW")]
    [Serializable]
    public class FeatureModel : IDirectoryModel
    {
        [XmlIgnore]
        private bool? ErasedField { get; set; }
        [XmlIgnore]
        private int? SubjectTypeField { get; set; }
        [XmlIgnore]
        private int? SubjectCodeField { get; set; }
        [XmlIgnore]
        private bool? IsPaymentField { get; set; }
        [XmlIgnore]
        private int? LanguageField { get; set; }


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
        /// Субъект особенности обслуживания
        /// 1 – страна в целом
        /// 2 – банк в целом
        /// 3 – конкретная точка выплаты
        /// </summary>
        [XmlAttribute(AttributeName = "SUBJ_TYPE")]
        public string SubjectType
        {
            get
            {
                return SubjectTypeField.HasValue ? SubjectTypeField.Value.ToString() : "";
            }
            set
            {
                SubjectTypeField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// Идентификатор субъекта особенностей обслуживания.В зависимости от
        /// значения SUBJ_TYPE ссылается на:
        /// SUBJ_TYPE = 1 country.ID
        /// SUBJ_TYPE = 2 banks.PARENT_ID
        /// SUBJ_TYPE = 3 banks.ID
        /// </summary>
        [XmlAttribute(AttributeName = "SUBJ_CODE")]
        public string SubjectCode
        {
            get
            {
                return SubjectCodeField.HasValue ? SubjectCodeField.Value.ToString() : "";
            }
            set
            {
                SubjectCodeField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// Указывает, является ли особенность обслуживания
        /// 0 – особенностью получения переводов из этой точки
        /// 1 – особенностью отправки переводов в эту точку
        /// </summary>
        [XmlAttribute(AttributeName = "IS_PAYMENT")]
        public string IsPayment
        {
            get
            {
                return IsPaymentField.HasValue ? IsPaymentField.Value.ToString() : "";
            }

            set
            {
                IsPaymentField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToBoolean(Convert.ToInt32(value))
                 : (bool?)null;
            }
        }

        /// <summary>
        /// Язык, на котором приведено описание особенностей выплаты
        ///1 – русский
        ///2 - английский
        /// </summary>
        [XmlAttribute(AttributeName = "LANGUAGE")]
        public string Language
        {
            get
            {
                return LanguageField.HasValue ? LanguageField.Value.ToString() : "";
            }
            set
            {
                LanguageField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        #region Типизированные знчения нестроковых параметров

        public bool? TypedErased => ErasedField;
        public int? TypedSubjectType => SubjectTypeField;
        public int? TypedSubjectCode => SubjectCodeField;
        public bool? TypedIsPayment => IsPaymentField;
        public int? TypedLanguage => LanguageField;

        #endregion

    }
}
