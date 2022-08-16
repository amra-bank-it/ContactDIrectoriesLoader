using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContactDirectoriesLoader.Repository.Entities
{
    /// <summary>
    /// Таблица содержит список станций метро
    /// </summary>
    [Table("METRO")]
    public class MetroStation : IDirectory
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
        /// ID города.Ссылка на BNK_CITY.ID
        /// </summary>
        [Column("CITY")]
        public int City { get; set; }

        /// <summary>
        /// ID линии. Ссылка на METRO_LINES.ID
        /// </summary>
        [Column("LINE")]
        public int LineId { get; set; }

        /// <summary>
        /// Наименование станции
        /// </summary>
        [Column("NAME")]
        [MaxLength(100)]
        public string? Name { get; set; }
    }
}
