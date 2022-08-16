using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Repository.Entities
{
    /// <summary>
    /// Cписок участников системы CONTACT
    /// </summary>
    [Table("BANKS")]
    [XmlRoot (ElementName = "ROW")]
    [Serializable]
    public class Bank : IDirectory
    {
        /// <summary>
        /// Версия записи
        /// </summary>
        [Column("VERSION")]
        [XmlAttribute(AttributeName = "VERSION")]    
        public int Version { get; set; }

        /// <summary>
        /// Предлагаемая операция в БД
        /// </summary>
        [NotMapped] 
        [XmlAttribute(AttributeName = "DB_OPERATION")]   
        public string? DbOperation { get; set; }

        /// <summary>
        /// Флаг, указывающий на то, что запись об участнике системы подлежит
        /// удалению из справочника на стороне клиента.
        /// 0 – запись удалению не подлежит.
        /// 1 – запись подлежит удалению.
        /// </summary>
        [Column("ERASED")]
        [XmlAttribute(AttributeName = "ERASED")]
        public bool Erased { get; set; }

        /// <summary>
        /// Уникальный идентификатор записи
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID")]
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// ID головного банка-участника системы CONTACT.
        /// </summary>
        [Column("PARENT_ID")]
        [XmlAttribute(AttributeName = "PARENT_ID")]
        public int? ParentId { get; set; }

        /// <summary>
        /// Уникальный четырехбуквенный код участника системы CONTACT.
        /// </summary>
        [Column("PP_CODE")]
        [MaxLength(6)]
        [XmlAttribute(AttributeName = "PP_CODE")]
        public string? PointCode { get; set; }

        /// <summary>
        /// Код участника в системе SWIFT
        /// </summary>
        /// <returns></returns>
        [Column("bic")]
        [MaxLength(12)]
        [XmlAttribute(AttributeName = "")]
        public string? Bic { get; set; }

        /// <summary>
        /// Название участника на английском языке
        /// </summary>
        [Column("NAME")]
        [MaxLength(150)]
        [XmlAttribute(AttributeName = "NAME")]
        public string? Name { get; set; }

        /// <summary>
        /// Название города, в котором расположен участник, на русском языке
        /// </summary>
        [Column("CITY_HEAD")]
        [MaxLength(35)]
        [XmlAttribute(AttributeName = "CITY_HEAD")]
        public string? CityHead { get; set; }

        /// <summary>
        /// Адрес участника системы CONTACT на русском языке
        /// </summary>
        [Column("ADDRESS1")]
        [MaxLength(140)]
        [XmlAttribute(AttributeName = "ADDRESS1")]
        public string? Address { get; set; }

        /// <summary>
        /// Часы работы участника системы CONTACT в будние дни
        /// Для российских участников заполняется на русском языке
        /// Для прочих участников заполняется на английском языке
        /// </summary>
        [Column("ADDRESS2")]
        [MaxLength(200)]
        [XmlAttribute(AttributeName = "ADDRESS2")]
        public string? WorkingHours { get; set; }

        /// <summary>
        /// Часы работы участника системы CONTACT в выходные дни
        /// Для российских участников заполняется на русском языке
        /// Для прочих участников заполняется на английском языке
        /// </summary>
        [Column("ADDRESS3")]
        [MaxLength(200)]
        [XmlAttribute(AttributeName = "ADDRESS3")]
        public string? WeekendsHours { get; set; }

        /// <summary>
        /// Зарезервировано
        /// </summary>
        [Column("ADDRESS4")]
        [MaxLength(35)]
        [XmlAttribute(AttributeName = "ADDRESS4")]
        public string? ReservedAddress { get; set; }

        /// <summary>
        /// Телефон участника системы CONTACT.
        /// </summary>
        [Column("PHONE")]
        [MaxLength(100)]
        [XmlAttribute(AttributeName = "PHONE")]
        public string? Phone { get; set; }

        /// <summary>
        /// Название участника системы CONTACT на русском языке
        /// </summary>
        [Column("NAME_RUS")]
        [MaxLength(100)]
        [XmlAttribute(AttributeName = "NAME_RUS")]
        public string? NameRus { get; set; }

        /// <summary>
        /// ID страны, где расположен участник системы CONTACT.Ссылка на
        /// COUNTRY.ID
        /// </summary>
        [Column("COUNTRY")]
        [XmlAttribute(AttributeName = "COUNTRY")]
        public int? CountryId { get; set; }

        /// <summary>
        /// Флаг, указывающий на возможность отправки перевода/платежа в адрес
        ///участника системы CONTACT:
        ///0 – отправить перевод/платеж можно
        ///1 – отправить перевод/платеж нельзя
        /// </summary>
        [Column("DELETED")]
        [XmlAttribute(AttributeName = "DELETED")]
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// Название города, где расположен участник системы CONTACT, на
        /// английском языке.
        /// </summary>
        [Column("CITY_LAT")]
        [MaxLength(35)]
        [XmlAttribute(AttributeName = "CITY_LAT")]
        public string? CityLat { get; set; }

        /// <summary>
        /// Адрес участника системы CONTACT на английском языке
        /// </summary>
        [Column("ADDR_LAT")]
        [MaxLength(140)]
        [XmlAttribute(AttributeName = "ADDR_LAT")]
        public string? AddressLat { get; set; }

        /// <summary>
        /// Тип участника системы CONTACT
        ///4 - банки-собиратели средств на счета(платежи),
        ///5 – юридические лица, собиратели средств в оплату услуг(платежи).
        ///Другое значение – денежные переводы.
        /// </summary>
        [Column("CONTACT")]
        [XmlAttribute(AttributeName = "CONTACT")]
        public int? Contact { get; set; }

        /// <summary>
        /// ID региона, где расположен участник системы. Ссылка на REGION.ID
        /// </summary>
        [Column("REGION")]
        [XmlAttribute(AttributeName = "REGION")]
        public int? RegionId { get; set; }

        /// <summary>
        /// Не используется.Для совместимости с предыдущими версиями.
        /// </summary>
        [Column("IS_KFM")]
        [XmlAttribute(AttributeName = "IS_KFM")]
        public bool? IsKfm { get; set; }

        /// <summary>
        /// Не используется. Для совместимости с предыдущими версиями.
        /// </summary>
        [Column("IS_ONLINE")]
        [XmlAttribute(AttributeName = "IS_ONLINE")]
        public int? IsOnline { get; set; }

        /// <summary>
        /// Флаг, указывающий, возможен ли возврат средств, направленных в адрес
        ///этого участника.
        ///1 – Возврат средств по инициативе отправителя возможен
        ///0 – Возврат средств по инициативе отправителя невозможен
        /// </summary>
        [Column("CAN_REVOKE")]
        [XmlAttribute(AttributeName = "CAN_REVOKE")]
        public bool? CanRevoke { get; set; }

        /// <summary>
        /// Флаг, указывающий, возможно ли в автоматическом режиме изменить
        ///реквизиты платежа/перевода, направленного в адрес этого участника.
        ///1 – Изменение реквизитов возможно.
        ///0 – Изменение реквизитов недопустимо.
        /// </summary>
        [Column("CAN_CHANGE")]
        [XmlAttribute(AttributeName = "CAN_CHANGE")]
        public bool? CanChange { get; set; }

        /// <summary>
        /// Флаг, указывающий, как разрешать ситуацию в случае отсутствия ответа
        /// Операционного центра при оплате перевода или платежа:
        /// 0 – Операцию следует считать неудачной, в приеме средств следует
        /// отказать.
        /// 1- Операцию следует считать успешной. У клиента следует принять деньги,
        /// в дальнейшем необходимо повторно прислать документ в Операционный
        /// центр
        /// </summary>
        [Column("GET_MONEY")]
        [XmlAttribute(AttributeName = "GET_MONEY")]
        public bool? NeedGetMoney { get; set; }

        /// <summary>
        /// Перечень валют, в которых участник системы, для которого сформирован
        /// справочник, может принимать от названного участника переводы и платежи.
        /// Перечень включает коды валют, разделенных точкой с запятой.
        /// Примеры:
        /// RUR; - участник принимает только рубли.
        /// RUR; USD; - участник принимает рубли и доллары.
        /// </summary>
        [Column("SEND_CURR")]
        [MaxLength(252)]
        [XmlAttribute(AttributeName = "SEND_CURR")]
        public string? SendingCurrencies { get; set; }

        /// <summary>
        /// Перечень валют, которые участник системы, для которого сформирован
        /// справочник, может посылать в адрес названного в справочнике участника.
        /// Перечень включает коды валют, разделенные точкой с запятой.
        /// Коды валют:
        /// RUR – российские рубли
        /// USD – доллары США
        /// EUR – евро.
        /// </summary>
        [Column("REC_CURR")]
        [MaxLength(252)]
        [XmlAttribute(AttributeName = "REC_CURR")]
        public string? ReceivingCurrencies { get; set; }

        /// <summary>
        /// Список идентификаторов групп полей к заполнению в адрес этого участника.
        /// Идентификаторы разделяются запятой(,).
        /// </summary>
        [Column("ATTR_GRPS")]
        [MaxLength(55)]
        [XmlAttribute(AttributeName = "ATTR_GRPS")]
        public string? AttributeGroups { get; set; }

        /// <summary>
        /// ID города, где расположен участник системы. Ссылка на CITY.ID
        /// </summary>
        [Column("CITY_ID")]
        [XmlAttribute(AttributeName = "CITY_ID")]
        public int? CityId { get; set; }

        /// <summary>
        /// ID логотипа участника. Ссылка на LOGO.ID
        /// </summary>
        [Column("LOGO_ID")]
        [XmlAttribute(AttributeName = "LOGO_ID")]
        public int? LogoId { get; set; }

        /// <summary>
        /// Идентификатор сценария оформления перевода/платежа в адрес участника
        /// </summary>
        [Column("SCEN_ID")]
        [XmlAttribute(AttributeName = "SCEN_ID")]
        public int? ScenId { get; set; }

        /// <summary>
        /// Признак обязательного наличия уникального номера перевода в адрес
        /// данного участника. 0 – уникальный номер необязателен; 1 – уникальный
        /// номер обязателен
        /// </summary>
        [Column("UNIQUE_TRN")]
        [XmlAttribute(AttributeName = "UNIQUE_TRN")]
        public bool? UniqueTrn { get; set; }

        /// <summary>
        /// ID близлежащей станции метро, если есть.Ссылка на METRO.ID
        /// </summary>
        [Column("METRO")]
        [XmlAttribute(AttributeName = "METRO")]
        public bool? MetroId { get; set; }
    }
}

