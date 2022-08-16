using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContactDirectoriesLoader.Repository.Entities
{
    /// <summary>
    /// Перечень участников, имеющих особенности в правилах
    /// обслуживания клиентов
    /// </summary>
    [Table("FEATURE")]
    public class Feature : IDirectory
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
        public  int Id { get; set; }

        /// <summary>
        /// Субъект особенности обслуживания
        /// 1 – страна в целом
        /// 2 – банк в целом
        /// 3 – конкретная точка выплаты
        /// </summary>
        [Column("SUBJ_TYPE")]
        public int SubjectType { get; set; }

        /// <summary>
        /// Идентификатор субъекта особенностей обслуживания.В зависимости от
        /// значения SUBJ_TYPE ссылается на:
        /// SUBJ_TYPE = 1 country.ID
        /// SUBJ_TYPE = 2 banks.PARENT_ID
        /// SUBJ_TYPE = 3 banks.ID
        /// </summary>
        [Column("SUBJ_CODE")]
        public int SubjectCode { get; set; }

        /// <summary>
        /// Указывает, является ли особенность обслуживания
        /// 0 – особенностью получения переводов из этой точки
        /// 1 – особенностью отправки переводов в эту точку
        /// </summary>
        [Column("IS_PAYMENT")] 
        public bool IsPayment { get; set; }

        /// <summary>
        /// Язык, на котором приведено описание особенностей выплаты
        ///1 – русский
        ///2 - английский
        /// </summary>
        [Column("LANGUAGE")] 
        public int Language { get; set; }
    }
}
