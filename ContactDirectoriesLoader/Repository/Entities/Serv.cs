using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContactDirectoriesLoader.Repository.Entities
{
    /// <summary>
    /// Перечень услуг, которые оказывают участники системы CONTACT.
    /// </summary>
    [Table("SERV")]
    public class Serv : IDirectory
    {
        /// <summary>
        /// Версия записи
        /// </summary>
        [Column("VERSION")] 
        public int Version { get; set; }

        /// <summary>
        /// Флаг, указывающий на то, что запись подлежит удалению из справочника на
        /// стороне клиента.
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
        /// Родительского узла
        /// </summary>
        [Column("PARENT_ID")] 
        public int ParentId { get; set; }

        /// <summary>
        /// Название услуги на русском языке
        /// </summary>
        [Column("CAPTION")]  
        [MaxLength(100)]
        public string? Caption { get; set; }

        /// <summary>
        /// Описание услуги на русском языке
        /// </summary>
        [Column("COMMENT")]
        [MaxLength(254)]
        public string? Comment { get; set; }

        /// <summary>
        /// Название услуги на английском языке
        /// </summary>
        [Column("CAPTION_LA")]
        [MaxLength(100)]
        public string? CaptionLat { get; set; }

        /// <summary>
        /// Описание услуги на английском языке
        /// </summary>
        [Column("COMMENT_LA")]
        [MaxLength(254)]
        public string? CommentLat { get; set; }

        /// <summary>
        /// Флаг, показывающий, может ли участник системы CONTACT принимать от
        /// физических лиц деньги за услугу
        /// 0 – прием денег невозможен
        /// 1 – прием денег возможен
        /// </summary>
        [Column("CAN_IN")]
        public bool CanIn { get; set; }

        /// <summary>
        /// Флаг, показывающий, может ли участник системы CONTACT выплачивать
        /// физическому лицу деньги по основанию
        /// 0 – выплата денег невозможна
        /// 1 – выплата денег возможна
        /// </summary>
        [Column("CAN_PAY")]
        public bool CanPay { get; set; }

        /// <summary>
        /// Кассовый символ операции по приему денег от физического лица за услугу.
        /// </summary>
        [Column("CS_IN")]
        [MaxLength(10)]
        public string? CsIn { get; set; }

        /// <summary>
        /// Кассовый символ комиссии участника системы за оказание услуги
        /// </summary>
        [Column("CS_IN_FEE")]
        [MaxLength(10)]
        public string? CsinFee { get; set;}

        /// <summary>
        /// Кассовый символ операции по выдаче физическому лицу денег за услугу.
        /// </summary>
        [Column("CS_PAY")]
        [MaxLength(10)]
        public string? CsPay { get; set; }
    }
}