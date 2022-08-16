using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.Xml.Serialization;
using ContactDirectoriesLoader.Contracts;

namespace ContactDirectoriesLoader.Models
{
    /// <summary>
    /// Описание шагов сценариев  - модель для сериализации
    /// </summary>
    [XmlRoot(ElementName = "ROW")]
    [Serializable]
    public class ScenarioItemModel : IDirectoryModel
    {
        [XmlIgnore]
        private bool? ErasedField { get; set; }
        [XmlIgnore]
        private int? ScenaioIdField { get; set; }
        [XmlIgnore]
        private int? StepField { get; set; }

        /// <summary>
        ///  Версия записи
        /// </summary>
        [XmlAttribute(AttributeName = "VERSION")]
        public int Version { get; set; }

        /// <summary>
        /// Флаг, указывающий на то, что запись подлежит удалению из справочника
        /// на стороне клиента.
        /// 0 – запись удалению не подлежит.
        /// 1 – запись подлежит удалению.
        /// </summary>
        [XmlAttribute(AttributeName = "ERASED")]
        public string Erased
        {
            get
            {
                return ErasedField.HasValue ? ErasedField.Value.ToString() : "";
            }

            set
            {
                ErasedField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToBoolean(Convert.ToInt32(value))
                 : (bool?)null;
            }
        }

        /// <summary>
        /// Уникальный идентификатор записи
        /// </summary>
        [XmlAttribute(AttributeName = "ID")]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор сценария
        /// </summary>
        [XmlAttribute(AttributeName = "SCEN_ID")]
        public string ScenaioId
        {
            get
            {
                return ScenaioIdField.HasValue ? ScenaioIdField.Value.ToString() : "";
            }
            set
            {
                ScenaioIdField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }

        }

        /// <summary>
        /// Номер шага
        /// </summary>
        [XmlAttribute(AttributeName = "STEP")]
        public string Step
        {
            get
            {
                return StepField.HasValue ? StepField.Value.ToString() : "";
            }
            set
            {
                StepField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }

        }

        /// <summary>
        /// Список идентификаторов групп полей к заполнению на текущем шаге
        /// </summary>
        [Column("ATTR_GRPS")]
        [MaxLength(55)]
        [XmlAttribute(AttributeName = "LANGUAGE")]
        public string AttributeGroups { get; set; }

        /// <summary>
        /// Имя класса, метод которого необходимо вызвать для передачи значений
        /// введенных полей
        /// </summary>
        [XmlAttribute(AttributeName = "OBJECT_CLASS")]
        public string ObjectClass { get; set; }

        /// <summary>
        /// Имя метода класса OBJECT_CLASS, который необходимо вызвать для
        /// передачи значений введенных полей
        /// </summary>
        [XmlAttribute(AttributeName = "OBJECT_ACTION")]
        public string ObjectAction { get; set; }

        /// <summary>
        /// Адреса списков допустимых значений полей в XML-документе на стороне
        /// Партнера, в котором хранятся все XML-запросы, выполненные на
        /// предыдущих шагах, и ответы на них.
        /// </summary>
        [XmlAttribute(AttributeName = "LIST_SRC")]
        public string ListSources { get; set; }

        #region Типизированные знчения нестроковых параметров
        public bool? TypedErased => ErasedField;
        public int? TypedScenaioId => ScenaioIdField;
        public int? TypedStep => StepField;

        #endregion
    }
}
