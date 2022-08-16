using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContactDirectoriesLoader.Repository.Entities
{
    /// <summary>
    /// Перечень лиц, операции с денежными средствами
    /// которых подлежат обязательному контролю.
    /// </summary>
    [Table("KFM_INFO")]
    public class FinancialMonitoringInfo : IDirectory
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
        /// Фамилия подозреваемого лица
        /// </summary>
        [Column("NAMEU_F")]
        [MaxLength(50)]
        public string? LastName { get; set; }
        
        /// <summary>
        /// Имя подозреваемого лица
        /// </summary>
        [Column("NAMEU_I")]
        [MaxLength(50)]
        public string? FirstName { get; set; }

        /// <summary>
        /// Отчество подозреваемого лица
        /// </summary>
        [Column("NAMEU_O")]
        [MaxLength(50)]
        public string? MiddleName { get; set; }

        /// <summary>
        /// Дата и место рождения подозреваемого лица
        /// </summary>
        [Column("BIRTHDAY")]
        [MaxLength(254)]
        public string? Birthday { get; set; }

        /// <summary>
        /// Документ, удостоверяющий личность подозреваемого.Время и место
        /// выдачи документа.
        /// </summary>
        [Column("PASSPORT")]
        [MaxLength(254)]
        public string? Passport { get; set; }

        /// <summary>
        /// Адрес места жительства подозреваемого лица
        /// </summary>
        [Column("ADDRESS")]
        [MaxLength(254)]
        public string? Address { get; set; }

        /// <summary>
        /// Флаг, указывающий на то, что обязательный контроль денежных операций,
        /// совершаемых лицом, прекращен.
        /// 0 - Запись актуальна, операции лица подлежат обязательному контролю
        /// 1 - Обязательный контроль денежных операций лица прекращен.
        /// </summary>
        [Column("DELETED")] 
        public bool Deleted { get; set; }

        /// <summary>
        /// Строка создается путем
        /// 1. Удаления лидирующих и завершающих пробелов из фамилии, имени,
        /// отчества подозреваемого лица, и сложением получившихся строк в одну.
        /// Пример(записи без кавычек):
        /// NAMEU_F = " ГУСЕЙНОВ "
        /// NAMEU_I = "ГАСАН"
        /// NAMEU_0 = " ХУСЕЙН ОГЛЫ"
        /// NAMEU = "ГУСЕЙНОВГАСАНХУСЕЙН ОГЛЫ"
        /// </summary>
        [Column("NAMEU")]
        [MaxLength(150)]
        public string? NameU { get; set; }
    }
}
