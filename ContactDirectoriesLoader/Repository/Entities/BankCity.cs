using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContactDirectoriesLoader.Repository.Entities
{
    /// <summary>
    /// Справочник городов, в которых расположены участники
    /// Contact
    /// </summary>
    [Table("BNK_CITY")]
    public class BankCity : IDirectory
    {
        /// <summary>
        /// Версия записи
        /// </summary>
        [Column("VERSION")]
        public int Version  { get; set; }

        /// <summary>
        /// Флаг, указывающий на то, что запись подлежит удалению из справочника
        /// на стороне клиента.
        ///0 – запись удалению не подлежит.
        ///1 – запись подлежит удалению.
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
        /// Название города, в котором расположен участник, на русском языке
        /// </summary>
        [Column("CITY_HEAD")] 
        [MaxLength(35)]
        public string? CityHead { get; set; }

        /// <summary>
        /// Название города, в котором расположен участник, на английском языке
        /// </summary>
        [Column("CITY_LAT")]
        [MaxLength(35)]
        public string? CityLat { get; set; }

        /// <summary>
        /// ID страны, в котором расположен город.Ссылка на COUNTRY.ID
       /// </summary>
        [Column("COUNTRY")]
        public int? Country { get; set; }

        /// <summary>
        /// ID региона, в котором расположен город. Ссылка на REGION.ID
        /// </summary>
        [Column("REGION")] 
        public int? Region { get; set; }

        /// <summary>
        /// Перечень валют, которые участник системы, для которого сформирован
        /// справочник, может принимать из данного города.
        /// Перечень включает коды валют, разделенных точкой с запятой.
        /// Примеры:
        /// RUR; - участник принимает только рубли.
        /// RUR; USD; - участник принимает рубли и доллары.
        /// </summary>
        [Column("SEND_CURR")]
        [MaxLength(252)]
        public string? SendingCurrencies { get; set; }

        /// <summary>
        /// Перечень валют, которые участник системы, для которого сформирован
        /// справочник, может отправлять в данный город.Перечень включает коды
        /// валют, разделенные точкой с запятой.
        /// Коды валют:
        /// RUR – российские рубли USD – доллары США
        /// EUR – евро.
        /// </summary>
        [Column("REC_CURR")]
        [MaxLength(252)]
        public string? ReceivingCurrencies { get; set; }

        /// <summary>
        /// Код точки выплаты.Если данное поле заполнено, то при оформлении
        /// перевода(услуга “Переводы физических лиц физическим лицам”) указание
        /// точки выплаты не требуется, перевод необходимо отправлять в адрес точки
        /// с кодом PP_CODE, при этом правила оформления перевода(список полей
        /// к заполнению, уникальность номера перевода и т.д.) определяется по
        /// таблице BANKS обычным способом
        /// </summary>
        [Column("PP_CODE")]
        [MaxLength(6)]
        public string? PointCode { get; set; }
    }
}
