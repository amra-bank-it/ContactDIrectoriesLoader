using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ContactDirectoriesLoader.Repository.Entities.Base;

namespace ContactDirectoriesLoader.Repository.Entities
{
    /// <summary>
    /// Описание шагов сценариев
    /// </summary>
    [Table("SCEN_ITEM")]
    public class ScenarioItem : IDirectory
    {
        /// <summary>
        ///  Версия записи
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
        /// Идентификатор сценария
        /// </summary>
        [Column("SCEN_ID")]
        public int ScenaioId { get; set; }

        /// <summary>
        /// Номер шага
        /// </summary>
        [Column("STEP")]
        public int Step { get; set; }

        /// <summary>
        /// Список идентификаторов групп полей к заполнению на текущем шаге
        /// </summary>
        [Column("ATTR_GRPS")]
        [MaxLength(55)]
        public string? AttributeGroups { get; set; }

        /// <summary>
        /// Имя класса, метод которого необходимо вызвать для передачи значений
        /// введенных полей
        /// </summary>
        [Column("OBJECT_CLASS")] 
        [MaxLength(100)]
        public string? ObjectClass { get; set; }

        /// <summary>
        /// Имя метода класса OBJECT_CLASS, который необходимо вызвать для
        /// передачи значений введенных полей
        /// </summary>
        [Column("OBJECT_ACTION")]
        [MaxLength(100)]
        public string? ObjectAction { get; set; }

        /// <summary>
        /// Адреса списков допустимых значений полей в XML-документе на стороне
        /// Партнера, в котором хранятся все XML-запросы, выполненные на
        /// предыдущих шагах, и ответы на них.
        /// </summary>
        [Column("LIST_SRC")] 
        [MaxLength(1024)]
        public string? ListSources { get; set; }
    }
}
