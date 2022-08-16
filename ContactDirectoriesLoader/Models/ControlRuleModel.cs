using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Models
{
    /// <summary>
    /// Список доп. полей к заполнению - модель для сериализации.
    /// </summary>
    [XmlRoot(ElementName = "ROW")]
    [Serializable]
    public class ControlRuleModel: IDirectoryModel
    {
        [XmlIgnore]
        private bool? ErasedField { get; set; }
        [XmlIgnore]
        private int? GroupNumberField { get; set; }
        [XmlIgnore]
        private bool? IsCondField { get; set; }
        [XmlIgnore]
        private int? SortOrderField { get; set; }
        [XmlIgnore]
        private decimal? MinValueField { get; set; }
        [XmlIgnore]
        private decimal? MaxValueField { get; set; }
        [XmlIgnore]
        private int? CurrencyUseEquivalentField { get; set; }
        [XmlIgnore]
        private int? SenderResidentField { get; set; }
        [XmlIgnore]
        private bool? IsRequiredField { get; set; }
        [XmlIgnore]
        private int? MaxLenghtField { get; set; }
        [XmlIgnore]
        private int? InOutEditField { get; set; }
        [XmlIgnore]
        private bool? VisibleField { get; set; }
        [XmlIgnore]
        private int? ControlModeField { get; set; }

        /// <summary>
        /// Версия записи
        /// </summary>
        [XmlAttribute(AttributeName = "VERSION")]
        public int Version { get; set; }

        /// <summary>
        /// Флаг, указывающий на то, что запись подлежит удалению из справочника
        /// на стороне клиента.
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
        /// Номер группы полей
        /// </summary>
        [XmlAttribute(AttributeName = "GRP_NUM")]
        public string GroupNumber
        {
            get
            {
                return GroupNumberField.HasValue? GroupNumberField.Value.ToString() : "";
            }

            set
            {
                GroupNumberField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// 0 – безусловный контроль (все), 1 – условный контроль
        /// </summary>
        [XmlAttribute(AttributeName = "IS_COND")]
        public string IsCond
        {
            get
            {
                return IsCondField.HasValue ? IsCondField.Value.ToString() : "";
            }

            set
            {
                IsCondField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToBoolean(Convert.ToInt32(value))
                 : (bool?)null;
            }
        }

        /// <summary>
        /// Порядок заполнение или проверки поля
        /// </summary>
        [XmlAttribute(AttributeName = "SORTORDER")]
        public string SortOrder
        {
            get
            {
                return SortOrderField.HasValue ? SortOrderField.Value.ToString() : "";
            }

            set
            {
                SortOrderField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// Если IS_COND = 1, минимальное значение суммы
        /// </summary>
        [XmlAttribute(AttributeName = "MIN_VALUE")]
        public string MinValue
        {
            get
            {
                return MinValueField.HasValue ? MinValueField.Value.ToString() : "";
            }

            set
            {
                if (value == null)
                {
                    MinValueField = null;
                }
                else
                {
                    var cultureInfo = CultureInfo.InvariantCulture.Clone() as CultureInfo;
                    cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
                    MinValueField = Convert.ToDecimal(value, cultureInfo);
                }

            }
        }

        /// <summary>
        /// Если IS_COND = 1, максимальное значение суммы
        /// </summary>
        [XmlAttribute(AttributeName = "MAX_VALUE")]
        public string MaxValue
        {
            get
            {
                return MaxValueField.HasValue ? MaxValueField.Value.ToString() : "";
            }

            set
            {
                if (value == null)
                {
                    MaxValueField = null;
                }
                else
                {
                    var cultureInfo = CultureInfo.InvariantCulture.Clone() as CultureInfo;
                    cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
                    MaxValueField = Convert.ToDecimal(value, cultureInfo);
                }
            }
        }

        /// <summary>
        /// Если IS_COND = 1, код валюты(ISO)
        /// </summary>
        [XmlAttribute(AttributeName = "CURR_CODE")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Если IS_COND = 1, признак эквивалента в валюте CURR_CODE
        /// </summary>
        [XmlAttribute(AttributeName = "CURR_USE_EQ")]
        public string CurrencyUseEquivalent
        {
            get
            {
                return CurrencyUseEquivalentField.HasValue ? CurrencyUseEquivalentField.Value.ToString() : "";
            }

            set
            {
                CurrencyUseEquivalentField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// Если IS_COND = 1, резидентность отправителя
        /// При этом
        /// S_RESIDENT = 1, соответствует условию «отправитель резидент»,
        /// S_RESIDENT = 0, соответствует условию «отправитель нерезидент»,
        /// S_RESIDENT = -1, резидентность отправителя не учитывается
        /// </summary>
        [XmlAttribute(AttributeName = "S_RESIDENT")]
        public string SenderResident
        {
            get
            {
                return SenderResidentField.HasValue ? SenderResidentField.Value.ToString() : "";
            }

            set
            {
                SenderResidentField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// Идентификатор группы полей
        /// </summary>
        [XmlAttribute(AttributeName = "FIELD_GRP")]
        public string FieldGroup { get; set; }

        /// <summary>
        /// Название поля
        /// </summary>
        [XmlAttribute(AttributeName = "FIELD_NAME")]
        public string FieldName { get; set; }

        /// <summary>
        /// Заголовок поля на русском
        /// </summary>
        [XmlAttribute(AttributeName = "FIELD_CAPTION")]
        public string FieldCaption { get; set; }

        /// <summary>
        /// Заголовок поля на английском
        /// </summary>
        [XmlAttribute(AttributeName = "FIELD_CAPTION_LAT")]
        public string FieldCaptionLat { get; set; }

        /// <summary>
        /// Регулярная маска
        /// </summary>
        [XmlAttribute(AttributeName = "REG_MASK")]
        public string RegularMask { get; set; }

        /// <summary>
        /// БИК Центрального банка России для проверки контрольного номера счета.
        /// Если BIC заполнен, то для поля будет проводится проверка на контрольный
        /// номер ЦБ.
        /// </summary>
        [XmlAttribute(AttributeName = "BIC")]
        public string Bic { get; set; }

        /// <summary>
        /// Признак обязательности заполнения поля (0 – необязательно, 1 –
        /// обязательно)
        /// </summary>
        [XmlAttribute(AttributeName = "IS_REQUIRED")]
        public string IsRequired
        {
            get
            {
                return IsRequiredField.HasValue ? IsRequiredField.Value.ToString() : "";
            }

            set
            {
                IsRequiredField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToBoolean(Convert.ToInt32(value))
                 : (bool?)null;
            }
        }

        /// <summary>
        /// Пример заполнения поля
        /// </summary>
        [XmlAttribute(AttributeName = "EXAMPLE")]
        public string Example { get; set; }

        /// <summary>
        /// Комментарий на русском
        /// </summary>
        [XmlAttribute(AttributeName = "COMMENT")]
        public string Comment { get; set; }

        /// <summary>
        /// Комментарий на английском
        /// </summary>
        [XmlAttribute(AttributeName = "COMMENT_LAT")]
        public string CommentLat { get; set; }

        /// <summary>
        /// Максимальная длина значения поля при вводе(0 – без ограничений).
        /// Максимальная длина текстового поля может быть 255 символов
        /// </summary>
        [XmlAttribute(AttributeName = "MAX_LEN")]
        public string MaxLenght
        {
            get
            {
                return MaxLenghtField.HasValue ? MaxLenghtField.Value.ToString() : "";
            }

            set
            {
                MaxLenghtField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// Статусы документа(идентификаторы статусов, указанные через запятую),
        /// для которых допустимо изменения значения поля(статус “-999” означает,
        /// что документ еще не был передан в ОЦ).
        /// </summary>
        [XmlAttribute(AttributeName = "EDIT_STATES")]
        public string EditStates { get; set; }

        /// <summary>
        /// Краткое название поля на русском языке
        /// </summary>
        [XmlAttribute(AttributeName = "SHORT_CAPTION")]
        public string ShortCaption { get; set; }

        /// <summary>
        /// Краткое название поля на английском языке
        /// </summary>
        [XmlAttribute(AttributeName = "SHORT_CAPTION_LAT")]
        public string ShortCaptionLat { get; set; }

        /// <summary>
        /// Возможность редактирования поля: 0 – редактирование не допускается; 1 –
        /// редактирование допускается только для исходящих операций; 2 –
        /// редактирование допускается только для входящих операций; 3 –
        /// редактирование допускается для исходящих и входящих операций.При
        /// использовании значения этого поля нужно также учитывать значение поля
        /// EDIT_STATES – статусы операций, на которых возможно редактирование
        /// поля
        /// </summary>
        [XmlAttribute(AttributeName = "INOUTEDIT")]
        public string InOutEdit
        {
            get
            {
                return InOutEditField.HasValue ? InOutEditField.Value.ToString() : "";
            }

            set
            {
                InOutEditField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// Тип поля: STRING – строковое, INT – целое, DATE – дата, MONEY2 –
        /// денежное с двумя знаками после запятой, MONEY4 – денежное с четырьмя
        /// знаками после запятой
        /// </summary>
        [XmlAttribute(AttributeName = "DATA_TYPE")]
        public string DataType { get; set; }

        /// <summary>
        /// Видимость поля: 0 – поле невидимое, 1 – поле видимое.Невидимые поля –
        /// это системные поля, которые заполняются программным путем (а не
        /// операционистом). Пример невидимых полей: trnSendPoint(код точки
        /// отправки), trnPickupPoint(код точки выплаты), trnService(код услуги)
        /// </summary>
        [XmlAttribute(AttributeName = "VISIBLE")]
        public string Visible
       {
            get
            {
                return VisibleField.HasValue? VisibleField.Value.ToString() : "";
            }

            set
            {
                VisibleField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToBoolean(Convert.ToInt32(value))
                 : (bool?)null;
            }
        }

        /// <summary>
        /// Режим контроля поля по регулярной маске REG_MASK. 1 – поле
        /// контролируется на форме ввода по маске REG_MASK и по этой же маске
        /// Операционный центр проверяет формат значения поля в XML бизнесуровня; 2 – по маске REG_MASK Операционный центр проверяет формат
        /// значения поля в XML бизнес-уровня
        /// </summary>
        [XmlAttribute(AttributeName = "CONTROL_MODE")]
        public string ControlMode
        {
            get
            {
                return ControlModeField.HasValue ? ControlModeField.Value.ToString() : "";
            }

            set
            {
                ControlModeField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// Язык ввода значения поля.Пусто – язык ввода любой; ‘RU’ – русский язык
        /// ввода; 'EN' – английский язык ввода.При проверке значения поля следует
        /// не забывать про контроль по REG_MASK
        /// </summary>
        [XmlAttribute(AttributeName = "LANG")]
        public string Lang { get; set; }

        #region Типизированные знчения нестроковых параметров

        public bool? TypedErased => ErasedField;
        public int? TypedGroupNumber => GroupNumberField;
        public bool? TypedIsCond => IsCondField;
        public int? TypedSortOrder => SortOrderField;
        public decimal? TypedMinValue => MinValueField;
        public decimal? TypedMaxValue => MaxValueField;
        public int? TypedCurrencyUseEquivalent => CurrencyUseEquivalentField;
        public int? TypedSenderResident => SenderResidentField;
        public bool? TypedIsRequired => IsRequiredField;
        public int? TypedMaxLenght => MaxLenghtField;
        public int? TypedInOutEdit => InOutEditField;
        public bool? TypedVisible => VisibleField;
        public int? TypedControlMode => ControlModeField; 

        #endregion

    }
}