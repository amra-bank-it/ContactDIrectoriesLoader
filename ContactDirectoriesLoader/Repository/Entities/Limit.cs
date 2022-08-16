using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContactDirectoriesLoader.Repository.Entities
{
    /// <summary>
    /// ограничения на суммы отправляемых
    /// переводов/платежей
    /// </summary>
    [Table("MIN_MAX")]
    public class Limit : IDirectory
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
        /// Уникальный идентификатор участника системы Contact
        /// </summary>
        [Column("BANK_ID")]
        public int BankId { get; set; }

        /// <summary>
        /// Код валюты перевода/платежа
        /// </summary>
        [Column("CURR_CODE")]
        [MaxLength(3)]
        public string? CurrencyCode { get; set; }

        /// <summary>
        ///  Минимальная сумма перевода/платежа
        /// </summary>
        [Column("MIN_SUM")] 
        public decimal MinSum { get; set; }

        /// <summary>
        /// Максимальная сумма перевода/платежа
        /// </summary>
        [Column("MAX_SUM")] 
        public decimal MaxSum { get; set; }
    }
}
