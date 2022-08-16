using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Models
{
    /// <summary>
    /// Cписок стран, где расположены участники системы CONTACT - модель для сериализации.
    /// </summary>
    [XmlRoot(ElementName = "ROW")]
    [Serializable]
    public class CountryModel : IDirectoryModel
    {
        [XmlIgnore]
        private bool? ErasedField { get; set; }
        [XmlIgnore]
        private bool? IsFatfField { get; set; }

        /// <summary>
        /// Версия записи.
        /// </summary>
        [XmlAttribute(AttributeName = "VERSION")]
        public int Version { get; set; }

        /// <summary>
        /// Флаг, указывающий на то, что запись подлежит удалению из справочника на
        /// стороне клиента.
        /// 0 – Запись удалению не подлежит. 
        /// 1 - Запись подлежит удалению.
        /// </summary>
        [XmlAttribute(AttributeName = "ERASED")]
        public string Erased 
        {
            get
            {
                return ErasedField.HasValue? ErasedField.Value.ToString() : "";
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
        /// Уникальный номер записи (ID в системе CONTACT и может не
        /// соответствовать общепринятым классификаторам)
        /// </summary>
        [XmlAttribute(AttributeName = "ID")]
        public int Id { get; set; }

        /// <summary>
        /// Название страны на русском языке
        /// </summary>
        [XmlAttribute(AttributeName = "NAME")]
        public string Name { get; set; }

        /// <summary>
        /// Название страны на английском языке
        /// </summary>
        [XmlAttribute(AttributeName = "NAME_LAT")]
        public string NameLat { get; set; }

        /// <summary>
        /// Двухсимвольный код страны по ISO.
        /// </summary>
        [XmlAttribute(AttributeName = "CODE")]
        public string Code { get; set; }

        /// <summary>
        /// Перечень валют, которые участник системы, для которого сформирован
        /// справочник, может принимать из названной в справочнике страны.
        /// Перечень включает коды валют, разделенных точкой с запятой.
        /// Примеры:
        /// RUR; -участник принимает только рубли.
        /// RUR; USD; -участник принимает рубли и доллары.
        /// </summary>
        [XmlAttribute(AttributeName = "SEND_CURR")]
        public string SendingCurrencies { get; set; }

        /// <summary>
        /// Перечень валют, которые участник системы, для которого сформирован
        /// справочник, может посылать в названную в справочнике страну.Перечень
        /// включает коды валют, разделенные точкой с запятой.
        /// Коды валют:
        /// RUR – российские рубли
        /// USD – доллары США
        /// EUR – евро.
        /// </summary>
        [XmlAttribute(AttributeName = "REC_CURR")]
        public string ReceivingCurrencies { get; set; } 

        /// <summary>
        /// Флаг, указывающий, является ли страна членом FATF.
        /// 0 – не является
        /// 1 – является
        /// </summary>
        [XmlAttribute(AttributeName = "IS_FATF")]
        public string IsFatf
        {
            get
            {
                return IsFatfField.HasValue ? IsFatfField.Value.ToString() : "";
            }

            set
            {
                IsFatfField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToBoolean(Convert.ToInt32(value))
                 : (bool?)null;
            }
        }

        /// <summary>
        /// Код точки выплаты. Если данное поле заполнено, то при оформлении
        /// перевода(услуга “Переводы физических лиц физическим лицам”) указание
        /// города и точки выплаты не требуется, перевод необходимо отправлять в
        /// адрес точки с кодом PP_CODE, при этом правила оформления перевода
        /// (список полей к заполнению, уникальность номера перевода и т.д.)
        /// определяется по таблице BANKS обычным способом
        /// </summary>
        [XmlAttribute(AttributeName = "PP_CODE")]
        public string PointCode { get; set; }

        #region Типизированные знчения нестроковых параметров
        
        public bool? TypedErased => ErasedField;
        public bool? TypedIsFatf => IsFatfField;
        
        #endregion

    }
}