using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Models
{
    /// <summary>
    /// Перечень услуг, которые оказывают участники системы CONTACT.  - модель для сериализации
    /// </summary>
    [XmlRoot(ElementName = "ROW")]
    [Serializable]
    public class ServModel : IDirectoryModel
    {
        [XmlIgnore]
        private bool? ErasedField { get; set; }
        [XmlIgnore]
        private int? ParentIdField { get; set; }
        [XmlIgnore]
        private bool? CanInField { get; set; }
        [XmlIgnore]
        private bool? CanPayField { get; set; }

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
        [XmlAttribute(AttributeName = "ID")]
        public int Id { get; set; }

        /// <summary>
        /// Родительского узла
        /// </summary>
        [XmlAttribute(AttributeName = "PARENT_ID")]
        public string ParentId
        {
            get
            {
                return ParentIdField.HasValue ? ParentIdField.Value.ToString() : "";
            }
            set
            {
                ParentIdField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// Название услуги на русском языке
        /// </summary>
        [XmlAttribute(AttributeName = "CAPTION")]
         public string Caption { get; set; }

        /// <summary>
        /// Описание услуги на русском языке
        /// </summary>
        [XmlAttribute(AttributeName = "COMMENT")]
        public string Comment { get; set; }

        /// <summary>
        /// Название услуги на английском языке
        /// </summary>
        [XmlAttribute(AttributeName = "CAPTION_LA")]
        public string CaptionLat { get; set; }

        /// <summary>
        /// Описание услуги на английском языке
        /// </summary>
        [XmlAttribute(AttributeName = "COMMENT_LA")]
        public string CommentLat { get; set; }

        /// <summary>
        /// Флаг, показывающий, может ли участник системы CONTACT принимать от
        /// физических лиц деньги за услугу
        /// 0 – прием денег невозможен
        /// 1 – прием денег возможен
        /// </summary>
        [XmlAttribute(AttributeName = "CAN_IN")]
        public string CanIn
        {
            get
            {
                return CanInField.HasValue ? CanInField.Value.ToString() : "";
            }

            set
            {
                CanInField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToBoolean(Convert.ToInt32(value))
                 : (bool?)null;
            }
        }

        /// <summary>
        /// Флаг, показывающий, может ли участник системы CONTACT выплачивать
        /// физическому лицу деньги по основанию
        /// 0 – выплата денег невозможна
        /// 1 – выплата денег возможна
        /// </summary>
        [XmlAttribute(AttributeName = "CAN_PAY")]
        public string CanPay
        {
            get
            {
                return CanPayField.HasValue ? CanPayField.Value.ToString() : "";
            }

            set
            {
                CanPayField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToBoolean(Convert.ToInt32(value))
                 : (bool?)null;
            }
        }

        /// <summary>
        /// Кассовый символ операции по приему денег от физического лица за услугу.
        /// </summary>
        [XmlAttribute(AttributeName = "CS_IN")]
        public string CsIn { get; set; }

        /// <summary>
        /// Кассовый символ комиссии участника системы за оказание услуги
        /// </summary>
        [XmlAttribute(AttributeName = "CS_IN_FEE")]
        public string CsinFee { get; set;}

        /// <summary>
        /// Кассовый символ операции по выдаче физическому лицу денег за услугу.
        /// </summary>
        [XmlAttribute(AttributeName = "CS_PAY")]
        public string CsPay { get; set; }

        #region Типизированные знчения нестроковых параметров
 
        public bool? TypedErased => ErasedField;
        public int? TypedParentId => ParentIdField;
        public bool? TypedCanIn => CanInField;
        public bool? TypedCanPay => CanPayField;
        
        #endregion

    }
}