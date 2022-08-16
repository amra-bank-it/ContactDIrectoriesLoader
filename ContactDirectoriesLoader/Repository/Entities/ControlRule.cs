using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContactDirectoriesLoader.Repository.Entities
{
    /// <summary>
    /// Список доп. полей к заполнению.
    /// </summary>
    [Table("ATTRLIST")]
    public class ControlRule: IDirectory
    {
        /// <summary>
        /// Версия записи
        /// </summary>
        [Column("VERSION")]
        public int Version { get; set; }

        /// <summary>
        /// Флаг, указывающий на то, что запись подлежит удалению из справочника
        /// на стороне клиента.
        /// 0 – запись удалению не подлежит.
        /// 1 – запись подлежит удалению.
        /// </summary>
        [Column("ERASED")]
        public bool Erased { get; set; }

        /// <summary>
        /// Уникальный идентификатор записи
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID")]
        public int Id { get; set; }

        /// <summary>
        /// Номер группы полей
        /// </summary>
        [Column("GRP_NUM")]
        public int GroupNumber { get; set; }

        /// <summary>
        /// 0 – безусловный контроль (все), 1 – условный контроль
        /// </summary>
        [Column("IS_COND")]
        public bool IsCond { get; set; }

        /// <summary>
        /// Порядок заполнение или проверки поля
        /// </summary>
        [Column("SORTORDER")]
        public int SortOrder { get; set; }

        /// <summary>
        /// Если IS_COND = 1, минимальное значение суммы
        /// </summary>
        [Column("MIN_VALUE")]
        public decimal MinValue { get; set; }

        /// <summary>
        /// Если IS_COND = 1, максимальное значение суммы
        /// </summary>
        [Column("MAX_VALUE")]
        public decimal MaxValue { get; set; }

        /// <summary>
        /// Если IS_COND = 1, код валюты(ISO)
        /// </summary>
        [Column("CURR_CODE")]
        [MaxLength(3)]
        public string? CurrencyCode { get; set; }

        /// <summary>
        /// Если IS_COND = 1, признак эквивалента в валюте CURR_CODE
        /// </summary>
        [Column("CURR_USE_EQ")]
        public int CurrencyUseEquivalent { get; set; }

        /// <summary>
        /// Если IS_COND = 1, резидентность отправителя
        /// При этом
        /// S_RESIDENT = 1, соответствует условию «отправитель резидент»,
        /// S_RESIDENT = 0, соответствует условию «отправитель нерезидент»,
        /// S_RESIDENT = -1, резидентность отправителя не учитывается
        /// </summary>
        [Column("S_RESIDENT")]
        public int SenderResident { get; set; }

        /// <summary>
        /// Идентификатор группы полей
        /// </summary>
        [Column("FIELD_GRP")]
        [MaxLength(100)]
        public string? FieldGroup { get; set; }

        /// <summary>
        /// Название поля
        /// </summary>
        [Column("FIELD_NAME")]
        [MaxLength(255)]
        public string? FieldName { get; set; }

        /// <summary>
        /// Заголовок поля на русском
        /// </summary>
        [Column("FIELD_CAPTION")]
        [MaxLength(255)]
        public string? FieldCaption { get; set; }

        /// <summary>
        /// Заголовок поля на английском
        /// </summary>
        [Column("FIELD_CAPTION_LAT")]
        [MaxLength(255)]
        public string? FieldCaptionLat { get; set; }

        /// <summary>
        /// Регулярная маска
        /// </summary>
        [Column("REG_MASK")]
        [MaxLength(255)]
        public string? RegularMask { get; set; }

        /// <summary>
        /// БИК Центрального банка России для проверки контрольного номера счета.
        /// Если BIC заполнен, то для поля будет проводится проверка на контрольный
        /// номер ЦБ.
        /// </summary>
        [Column("BIC")]
        [MaxLength(9)]
        public string? Bic { get; set; }

        /// <summary>
        /// Признак обязательности заполнения поля (0 – необязательно, 1 –
        /// обязательно)
        /// </summary>
        [Column("IS_REQUIRED")]
        public bool IsRequired { get; set; }

        /// <summary>
        /// Пример заполнения поля
        /// </summary>
        [Column("EXAMPLE")]
        [MaxLength(255)]
        public string? Example { get; set; }

        /// <summary>
        /// Комментарий на русском
        /// </summary>
        [Column("COMMENT")]
        [MaxLength(255)]
        public string? Comment { get; set; }

        /// <summary>
        /// Комментарий на английском
        /// </summary>
        [Column("COMMENT_LAT")]
        [MaxLength(255)]
        public string? CommentLat { get; set; }

        /// <summary>
        /// Максимальная длина значения поля при вводе(0 – без ограничений).
        /// Максимальная длина текстового поля может быть 255 символов
        /// </summary>
        [Column("MAX_LEN")]
        public int MaxLenght { get; set; }

        /// <summary>
        /// Статусы документа(идентификаторы статусов, указанные через запятую),
        /// для которых допустимо изменения значения поля(статус “-999” означает,
        /// что документ еще не был передан в ОЦ).
        /// </summary>
        [Column("EDIT_STATES")]
        [MaxLength(100)]
        public string? EditStates { get; set; }

        /// <summary>
        /// Краткое название поля на русском языке
        /// </summary>
        [Column("SHORT_CAPTION")]
        [MaxLength(100)]
        public string? ShortCaption { get; set; }

        /// <summary>
        /// Краткое название поля на английском языке
        /// </summary>
        [Column("SHORT_CAPTION_LAT")] 
        [MaxLength(100)] 
        public string? ShortCaptionLat { get; set; }

        /// <summary>
        /// Возможность редактирования поля: 0 – редактирование не допускается; 1 –
        /// редактирование допускается только для исходящих операций; 2 –
        /// редактирование допускается только для входящих операций; 3 –
        /// редактирование допускается для исходящих и входящих операций.При
        /// использовании значения этого поля нужно также учитывать значение поля
        /// EDIT_STATES – статусы операций, на которых возможно редактирование
        /// поля
        /// </summary>
        [Column("INOUTEDIT")]
        public int InOutEdit { get; set; }

        /// <summary>
        /// Тип поля: STRING – строковое, INT – целое, DATE – дата, MONEY2 –
        /// денежное с двумя знаками после запятой, MONEY4 – денежное с четырьмя
        /// знаками после запятой
        /// </summary>
        [Column("DATA_TYPE")]
        [MaxLength(30)]
        public string? DataType { get; set; }

        /// <summary>
        /// Видимость поля: 0 – поле невидимое, 1 – поле видимое.Невидимые поля –
        /// это системные поля, которые заполняются программным путем (а не
        /// операционистом). Пример невидимых полей: trnSendPoint(код точки
        /// отправки), trnPickupPoint(код точки выплаты), trnService(код услуги)
        /// </summary>
        [Column("VISIBLE")] 
        public bool Visible { get; set; }

        /// <summary>
        /// Режим контроля поля по регулярной маске REG_MASK. 1 – поле
        /// контролируется на форме ввода по маске REG_MASK и по этой же маске
        /// Операционный центр проверяет формат значения поля в XML бизнесуровня; 2 – по маске REG_MASK Операционный центр проверяет формат
        /// значения поля в XML бизнес-уровня
        /// </summary>
        [Column("CONTROL_MODE")]
        public int ControlMode { get; set; }

        /// <summary>
        /// Язык ввода значения поля.Пусто – язык ввода любой; ‘RU’ – русский язык
        /// ввода; 'EN' – английский язык ввода.При проверке значения поля следует
        /// не забывать про контроль по REG_MASK
        /// </summary>
        [Column("LANG")]
        [MaxLength(2)]
        public string? Lang { get; set; }
    }
}