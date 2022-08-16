using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Models
{
    /// <summary>
    /// Cписок участников системы CONTACT - модель для сериализации
    /// </summary>
    [XmlRoot (ElementName = "ROW")]
    [Serializable]
    public class BankModel : IDirectoryModel
    {
        [XmlIgnore]
        private bool? ErasedField { get; set; }

        [XmlIgnore]
        private int? ParentIdField { get; set; }

        [XmlIgnore]
        private int? CountryIdField { get; set; }

        [XmlIgnore]
        private bool? IsDeletedField { get; set; }

        [XmlIgnore]
        private int? ContactField { get; set; }

        [XmlIgnore]
        private int? RegionIdField { get; set; }

        [XmlIgnore]
        private bool? IsKfmField { get; set; }

        [XmlIgnore]
        private int? IsOnlineField { get; set; }

        [XmlIgnore]
        private bool? CanRevokeField { get; set; }

        [XmlIgnore]
        private bool? CanChangeField { get; set; }

        [XmlIgnore]
        private bool? NeedGetMoneyField { get; set; }

        [XmlIgnore]
        private int? CityIdField { get; set; }

        [XmlIgnore]
        private int? LogoIdField { get; set; }

        [XmlIgnore]
        private int? ScenIdField { get; set; }

        [XmlIgnore]
        private bool? UniqueTrnField { get; set; }

        [XmlIgnore]
        private bool? MetroIdField { get; set; }

        /// <summary>
        /// Версия записи
        /// </summary>
        [XmlAttribute(AttributeName = "VERSION")]    
        public int Version { get; set; }

        /// <summary>
        /// Предлагаемая операция в БД
        /// </summary>
        [XmlAttribute(AttributeName = "DB_OPERATION")]
        public string DbOperation { get; set; }
        
        /// <summary>
        /// Флаг, указывающий на то, что запись об участнике системы подлежит
        /// удалению из справочника на стороне клиента.
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
        /// ID головного банка-участника системы CONTACT.
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
        /// Уникальный четырехбуквенный код участника системы CONTACT.
        /// </summary>
        [XmlAttribute(AttributeName = "PP_CODE")]
        public string PointCode { get; set; }

        /// <summary>
        /// Код участника в системе SWIFT
        /// </summary>
        /// <returns></returns>
        [XmlAttribute(AttributeName = "BIC")]
        public string Bic { get; set; }

        /// <summary>
        /// Название участника на английском языке
        /// </summary>
        [XmlAttribute(AttributeName = "NAME")]
        public string Name { get; set; }

        /// <summary>
        /// Название города, в котором расположен участник, на русском языке
        /// </summary>
        [XmlAttribute(AttributeName = "CITY_HEAD")]
        public string CityHead { get; set; }

        /// <summary>
        /// Адрес участника системы CONTACT на русском языке
        /// </summary>
        [XmlAttribute(AttributeName = "ADDRESS1")]
        public string Address { get; set; }

        /// <summary>
        /// Часы работы участника системы CONTACT в будние дни
        /// Для российских участников заполняется на русском языке
        /// Для прочих участников заполняется на английском языке
        /// </summary>
        [XmlAttribute(AttributeName = "ADDRESS2")]
        public string WorkingHours { get; set; }

        /// <summary>
        /// Часы работы участника системы CONTACT в выходные дни
        /// Для российских участников заполняется на русском языке
        /// Для прочих участников заполняется на английском языке
        /// </summary>
        [XmlAttribute(AttributeName = "ADDRESS3")]
        public string WeekendsHours { get; set; }

        /// <summary>
        /// Зарезервировано
        /// </summary>
        [XmlAttribute(AttributeName = "ADDRESS4")]
        public string ReservedAddress { get; set; }

        /// <summary>
        /// Телефон участника системы CONTACT.
        /// </summary>
        [XmlAttribute(AttributeName = "PHONE")]
        public string Phone { get; set; }

        /// <summary>
        /// Название участника системы CONTACT на русском языке
        /// </summary>
        [XmlAttribute(AttributeName = "NAME_RUS")]
        public string NameRus { get; set; }

        /// <summary>
        /// ID страны, где расположен участник системы CONTACT.Ссылка на
        /// COUNTRY.ID
        /// </summary>
        public string CountryId
        {
            get
            {
                return CountryIdField.HasValue ? CountryIdField.Value.ToString() : "";
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
        /// Флаг, указывающий на возможность отправки перевода/платежа в адрес
        ///участника системы CONTACT:
        ///0 – отправить перевод/платеж можно
        ///1 – отправить перевод/платеж нельзя
        /// </summary>
        [XmlAttribute(AttributeName = "DELETED")]
        public string IsDeleted
        {
            get
            {
                return IsDeletedField.HasValue ? IsDeletedField.Value.ToString() : "";
            }

            set
            {
                IsDeletedField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToBoolean(Convert.ToInt32(value))
                 : (bool?)null;
            }
        }

        /// <summary>
        /// Название города, где расположен участник системы CONTACT, на
        /// английском языке.
        /// </summary>
        [XmlAttribute(AttributeName = "CITY_LAT")]
        public string CityLat { get; set; }

        /// <summary>
        /// Адрес участника системы CONTACT на английском языке
        /// </summary>
        [XmlAttribute(AttributeName = "ADDR_LAT")]
        public string AddressLat { get; set; }

        /// <summary>
        /// Тип участника системы CONTACT
        ///4 - банки-собиратели средств на счета(платежи),
        ///5 – юридические лица, собиратели средств в оплату услуг(платежи).
        ///Другое значение – денежные переводы.
        /// </summary>
        [XmlAttribute(AttributeName = "CONTACT")]
        public string Contact
        {
            get
            {
                return ContactField.HasValue ? ContactField.Value.ToString() : "";
            }

            set
            {
                ContactField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// ID региона, где расположен участник системы. Ссылка на REGION.ID
        /// </summary>
        [XmlAttribute(AttributeName = "REGION")]
        public string RegionId
        {
            get
            {
                return RegionIdField.HasValue ? RegionIdField.Value.ToString() : "";
            }

            set
            {
                RegionIdField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// Не используется.Для совместимости с предыдущими версиями.
        /// </summary>
        [XmlAttribute(AttributeName = "IS_KFM")]
        public string IsKfm
        {
            get
            {
                return IsKfmField.HasValue ? IsKfmField.Value.ToString() : "";
            }

            set
            {
                IsKfmField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToBoolean(Convert.ToInt32(value))
                 : (bool?)null;
            }
        }

        /// <summary>
        /// Не используется. Для совместимости с предыдущими версиями.
        /// </summary>
        [XmlAttribute(AttributeName = "IS_ONLINE")]
        public string IsOnline
        {
            get
            {
                return IsOnlineField.HasValue ? IsOnlineField.Value.ToString() : "";
            }

            set
            {
                IsOnlineField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// Флаг, указывающий, возможен ли возврат средств, направленных в адрес
        ///этого участника.
        ///1 – Возврат средств по инициативе отправителя возможен
        ///0 – Возврат средств по инициативе отправителя невозможен
        /// </summary>
        [XmlAttribute(AttributeName = "CAN_REVOKE")]
        public string CanRevoke
        {
            get
            {
                return CanRevokeField.HasValue ? CanRevokeField.Value.ToString() : "";
            }

            set
            {
                CanRevokeField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToBoolean(Convert.ToInt32(value))
                 : (bool?)null;
            }
        }

        /// <summary>
        /// Флаг, указывающий, возможно ли в автоматическом режиме изменить
        ///реквизиты платежа/перевода, направленного в адрес этого участника.
        ///1 – Изменение реквизитов возможно.
        ///0 – Изменение реквизитов недопустимо.
        /// </summary>
        [XmlAttribute(AttributeName = "CAN_CHANGE")]
        public string CanChange
        {
            get
            {
                return CanChangeField.HasValue ? CanChangeField.Value.ToString() : "";
            }

            set
            {
                CanChangeField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToBoolean(Convert.ToInt32(value))
                 : (bool?)null;
            }
        }

        /// <summary>
        /// Флаг, указывающий, как разрешать ситуацию в случае отсутствия ответа
        /// Операционного центра при оплате перевода или платежа:
        /// 0 – Операцию следует считать неудачной, в приеме средств следует
        /// отказать.
        /// 1- Операцию следует считать успешной. У клиента следует принять деньги,
        /// в дальнейшем необходимо повторно прислать документ в Операционный
        /// центр
        /// </summary>
        [XmlAttribute(AttributeName = "GET_MONEY")]
        public string NeedGetMoney
        {
            get
            {
                return NeedGetMoneyField.HasValue ? NeedGetMoneyField.Value.ToString() : "";
            }

            set
            {
                NeedGetMoneyField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToBoolean(Convert.ToInt32(value))
                 : (bool?)null;
            }
        }

        /// <summary>
        /// Перечень валют, в которых участник системы, для которого сформирован
        /// справочник, может принимать от названного участника переводы и платежи.
        /// Перечень включает коды валют, разделенных точкой с запятой.
        /// Примеры:
        /// RUR; - участник принимает только рубли.
        /// RUR; USD; - участник принимает рубли и доллары.
        /// </summary>
        [XmlAttribute(AttributeName = "SEND_CURR")]
        public string SendingCurrencies { get; set; }

        /// <summary>
        /// Перечень валют, которые участник системы, для которого сформирован
        /// справочник, может посылать в адрес названного в справочнике участника.
        /// Перечень включает коды валют, разделенные точкой с запятой.
        /// Коды валют:
        /// RUR – российские рубли
        /// USD – доллары США
        /// EUR – евро.
        /// </summary>
        [XmlAttribute(AttributeName = "REC_CURR")]
        public string ReceivingCurrencies { get; set; }

        /// <summary>
        /// Список идентификаторов групп полей к заполнению в адрес этого участника.
        /// Идентификаторы разделяются запятой(,).
        /// </summary>
        [XmlAttribute(AttributeName = "ATTR_GRPS")]
        public string AttributeGroups { get; set; }

        /// <summary>
        /// ID города, где расположен участник системы. Ссылка на CITY.ID
        /// </summary>
        [XmlAttribute(AttributeName = "CITY_ID")]
        public string CityId
        {
            get
            {
                return CityIdField.HasValue ? CityIdField.Value.ToString() : "";
            }

            set
            {
                CityIdField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// ID логотипа участника. Ссылка на LOGO.ID
        /// </summary>
        [XmlAttribute(AttributeName = "LOGO_ID")]
        public string LogoId
        {
            get
            {
                return LogoIdField.HasValue ? LogoIdField.Value.ToString() : "";
            }

            set
            {
                LogoIdField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// Идентификатор сценария оформления перевода/платежа в адрес участника
        /// </summary>
        [XmlAttribute(AttributeName = "SCEN_ID")]
        public string ScenId
        {
            get
            {
                return ScenIdField.HasValue ? ScenIdField.Value.ToString() : "";
            }

            set
            {
                ScenIdField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// Признак обязательного наличия уникального номера перевода в адрес
        /// данного участника. 0 – уникальный номер необязателен; 1 – уникальный
        /// номер обязателен
        /// </summary>
        [XmlAttribute(AttributeName = "UNIQUE_TRN")]
        public string UniqueTrn
        {
            get
            {
                return UniqueTrnField.HasValue ? UniqueTrnField.Value.ToString() : "";
            }

            set
            {
                UniqueTrnField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToBoolean(Convert.ToInt32(value))
                 : (bool?)null;
            }
        }

        /// <summary>
        /// ID близлежащей станции метро, если есть.Ссылка на METRO.ID
        /// </summary>
        [XmlAttribute(AttributeName = "METRO")]
        public string MetroId
        {
            get
            {
                return MetroIdField.HasValue ? MetroIdField.Value.ToString() : "";
            }

            set
            {
                MetroIdField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToBoolean(Convert.ToInt32(value))
                 : (bool?)null;
            }
        }

        #region Типизированные знчения нестроковых параметров

        public bool? TypedErased => ErasedField;
        public int? TypedParentId => ParentIdField;
        public int? TypedCountryId => CountryIdField;
        public bool? TypedIsDeleted => IsDeletedField;
        public int? TypedContact => ContactField;
        public int? TypedRegionId => RegionIdField;
        public bool? TypedIsKfm => IsKfmField;
        public int? TypedIsOnline => IsOnlineField;
        public bool? TypedCanRevoke => CanRevokeField;
        public bool? TypedCanChange => CanChangeField;
        public bool? TypedNeedGetMoney => NeedGetMoneyField;
        public int? TypedCityId => CityIdField;
        public int? TypedLogoId => LogoIdField;
        public int? TypedScenId => ScenIdField;
        public bool? TypedUniqueTrn => UniqueTrnField;
        public bool? TypedMetroId => MetroIdField;

        #endregion
    }
}