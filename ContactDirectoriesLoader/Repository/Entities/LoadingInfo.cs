using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContactDirectoriesLoader.Repository.Entities
{
    /// <summary>
    /// Таблица с информацией о загрузке справочников.
    /// </summary>
    [Table("LOADING_INFO")]
    public class LoadingInfo : IEntity
    {
        /// <summary>
        /// Уникальный идентификатор записи
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("LOADING_INFO_ID")]
        public int Id { get; set; }

        /// <summary>
        /// Версия справочника
        /// </summary>
        [Column("VERSION")]
        public int Version { get; set; }

        /// <summary>
        /// Запрашивается полный справочник или инкрементальный. 
        /// </summary>
        //[Column("REQUEST_IS_FULL")]
        //public bool RequestIsFull { get; set; }

        /// <summary>
        /// Справочник запрашивается по частям или целиком. 
        /// </summary>
        //[Column("REQUEST_BY_PARTS")]
        //public bool RequestByParts { get; set; }
        /// <summary>
        /// Идентификатор справочника, запрашиваемого по частям.
        /// </summary>
        //[Column("RESPONSE_BOOK_ID")]
        //public string ResponseBookId { get; set; }

        /// <summary>
        /// Признак IS_FULL ответа - пришёл ли в ответе полный справочник.
        /// </summary>
        [Column("RESPONSE_IS_FULL")]
        public bool ResponseIsFull { get; set; }

        /// <summary>
        /// Дата и время начала загрузки
        /// </summary>
        [Column("START_DATE_TIME")]
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Дата и время окончания загрузки
        /// </summary>
        [Column("END_DATE_TIME")]
        public DateTime EndDateTime { get; set; }
    }
}
