using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContactDirectoriesLoader.Repository.Entities
{
    /// <summary>
    /// Перечень регионов, где расположены участники системы CONTACT
    /// </summary>
    [Table("REGION")]
    public class Region : IDirectory
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
        /// Код региона в соответствии с ISO 3166-2
        /// </summary>
        [Column("SUBDIVISION_ISOCODE")]
        [MaxLength(40)]
        public string? SubdivisionIsoCode { get; set; }
        
        /// <summary>
        /// Страны региона из справочника COUNTRY
        /// </summary>
        [Column("COUNTRY")]
        public int Country { get; set; }
        
        /// <summary>
        /// Название региона на русском языке
        /// </summary>
        [Column("NAME")]
        [MaxLength(255)]
        public string? Name { get; set; }

        /// <summary>
        /// Название региона на русском языке, используемое при сортировке списка
        /// регионов.
        /// </summary>
        [Column("NAME_SORT")]
        [MaxLength(255)]
        public string? NameSort { get; set; }

        /// <summary>
        /// Название региона на английском языке
        /// </summary>
        [Column("NAME_LAT")]
        [MaxLength(255)]
        public string? NameLat { get; set; }

    }
}






