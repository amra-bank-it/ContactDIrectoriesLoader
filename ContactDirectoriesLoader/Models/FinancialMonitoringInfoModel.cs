using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Models
{
    /// <summary>
    /// Перечень лиц, операции с денежными средствами
    /// которых подлежат обязательному контролю.  - модель для сериализации
    /// </summary>
    [XmlRoot(ElementName = "ROW")]
    [Serializable]
    public class FinancialMonitoringInfoModel : IDirectoryModel
    {
        [XmlIgnore]
        private bool? ErasedField { get; set; }
        [XmlIgnore]
        private bool? DeletedField { get; set; }

        /// <summary>
        /// Версия записи
        /// </summary>
        [XmlAttribute(AttributeName = "VERSION")]
        public int Version { get; set; }

        /// <summary>
        /// Флаг, указывающий на то, что запись подлежит удалению из справочника на
        /// стороне клиента.
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
        /// Фамилия подозреваемого лица
        /// </summary>
        [XmlAttribute(AttributeName = "NAMEU_F")]
        public string LastName { get; set; }
        
        /// <summary>
        /// Имя подозреваемого лица
        /// </summary>
        [XmlAttribute(AttributeName = "NAMEU_I")]
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество подозреваемого лица
        /// </summary>
        [XmlAttribute(AttributeName = "NAMEU_O")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Дата и место рождения подозреваемого лица
        /// </summary>
        [XmlAttribute(AttributeName = "BIRTHDAY")]
        public string Birthday { get; set; }

        /// <summary>
        /// Документ, удостоверяющий личность подозреваемого.Время и место
        /// выдачи документа.
        /// </summary>
        [XmlAttribute(AttributeName = "PASSPORT")]
        public string Passport { get; set; }

        /// <summary>
        /// Адрес места жительства подозреваемого лица
        /// </summary>
        [XmlAttribute(AttributeName = "ADDRESS")]
        public string Address { get; set; }

        /// <summary>
        /// Флаг, указывающий на то, что обязательный контроль денежных операций,
        /// совершаемых лицом, прекращен.
        /// 0 - Запись актуальна, операции лица подлежат обязательному контролю
        /// 1 - Обязательный контроль денежных операций лица прекращен.
        /// </summary>
        [XmlAttribute(AttributeName = "DELETED")]
        public string Deleted
        {
            get
            {
                return DeletedField.HasValue ? DeletedField.Value.ToString() : "";
            }

            set
            {
                DeletedField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToBoolean(Convert.ToInt32(value))
                 : (bool?)null;
            }
        }

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
        [XmlAttribute(AttributeName = "NAMEU")]
        public string NameU { get; set; }

        #region Типизированные знчения нестроковых параметров
        
        public bool? TypedErased => ErasedField;
        public bool? TypedDeleted => DeletedField;

        #endregion
    }
}
