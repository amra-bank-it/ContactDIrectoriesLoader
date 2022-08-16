using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContactDirectoriesLoader.Repository.Entities
{
    /// <summary>
    /// Cписок стран, где расположены участники системы CONTACT
    /// </summary>
    [Table("COUNTRY")]
    public class Country : IDirectory
    {
        /// <summary>
        /// Версия записи.
        /// </summary>
        [Column("VERSION")]
        public int Version { get; set; }

        /// <summary>
        /// Флаг, указывающий на то, что запись подлежит удалению из справочника на
        /// стороне клиента.
        /// 0 – Запись удалению не подлежит. 
        /// 1 - Запись подлежит удалению.
        /// </summary>
        [Column("ERASED")]
        public bool Erased { get; set; }

        /// <summary>
        /// Уникальный номер записи (ID в системе CONTACT и может не
        /// соответствовать общепринятым классификаторам)
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID")]
        public int Id { get; set; }

        /// <summary>
        /// Название страны на русском языке
        /// </summary>
        [Column("NAME")] 
        [MaxLength(80)]
        public string? Name { get; set; }

        /// <summary>
        /// Название страны на английском языке
        /// </summary>
        [Column("NAME_LAT")]
        [MaxLength(80)]
        public string? NameLat { get; set; }

        /// <summary>
        /// Двухсимвольный код страны по ISO.
        /// </summary>
        [Column("CODE")]
        [MaxLength(3)]
        public string Code { get; set; }

        /// <summary>
        /// Перечень валют, которые участник системы, для которого сформирован
        /// справочник, может принимать из названной в справочнике страны.
        /// Перечень включает коды валют, разделенных точкой с запятой.
        /// Примеры:
        /// RUR; -участник принимает только рубли.
        /// RUR; USD; -участник принимает рубли и доллары.
        /// </summary>
        [Column("SEND_CURR")] 
        [MaxLength(252)]
        public string? SendingCurrencies { get; set; }

        /// <summary>
        /// Перечень валют, которые участник системы, для которого сформирован
        /// справочник, может посылать в названную в справочнике страну.Перечень
        /// включает коды валют, разделенные точкой с запятой.
        /// Коды валют:
        /// RUR – российские рубли
        /// USD – доллары США
        /// EUR – евро.
        /// </summary>
        [Column("REC_CURR")]
        [MaxLength(252)]
        public string? ReceivingCurrencies { get; set; } 

        /// <summary>
        /// Флаг, указывающий, является ли страна членом FATF.
        /// 0 – не является
        /// 1 – является
        /// </summary>
        [Column("IS_FATF")] 
        public bool? IsFatf { get; set; }

        /// <summary>
        /// Код точки выплаты. Если данное поле заполнено, то при оформлении
        /// перевода(услуга “Переводы физических лиц физическим лицам”) указание
        /// города и точки выплаты не требуется, перевод необходимо отправлять в
        /// адрес точки с кодом PP_CODE, при этом правила оформления перевода
        /// (список полей к заполнению, уникальность номера перевода и т.д.)
        /// определяется по таблице BANKS обычным способом
        /// </summary>
        [Column("PP_CODE")] 
        [MaxLength(6)]
        public string? PointCode { get; set; }
    }
}