using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContactDirectoriesLoader.Repository.Entities
{
    /// <summary>
    /// таблица, связывающая участников системы (BANKS) и оказываемые ими услуги(SERV)
    /// </summary>
    [Table("BANKSERV")]
    public class BankServ : IDirectory
    {
        /// <summary>
        /// Версия записи.
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
        /// ID банка-участника системы Contact (BANKS.ID)
        /// </summary>
        [Column("BANK_ID")]
        public int BankId { get; set; }

        /// <summary>
        /// ID услуги (SERV.ID)
        /// </summary>
        [Column("SERV_ID")]
        public int ServId { get; set; }
    }
}
