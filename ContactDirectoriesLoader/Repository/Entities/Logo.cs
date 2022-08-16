using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContactDirectoriesLoader.Repository.Entities
{
    /// <summary>
    /// Логотипы участников
    /// </summary>
    [Table("LOGO")]
    public class Logo : IDirectory
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
        /// Имя логотипа
        /// </summary>
        [Column("LOGO_NAME")]
        [MaxLength(100)]
        public string? LogoName { get; set; }

        /// <summary>
        /// Содержимое логотипа в формате JPG
        /// </summary>
        [Column("LOGO_DATA_BLOB")] 
        public byte[]? LogoDataBlob { get; set; }

        /// <summary>
        /// Содержимое логотипа в формате JPG на английском языке, если данное
        /// поле не заполнено, то следует использовать LOGO_DATA
        /// </summary>
        [Column("LOGO_DATA_LAT")] 
        public byte[]? LogoDataLat { get; set; }
    }
}
