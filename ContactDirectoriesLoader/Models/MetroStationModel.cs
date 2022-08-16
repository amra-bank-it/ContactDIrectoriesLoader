using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Models
{
    /// <summary>
    /// Таблица содержит список станций метро  - модель для сериализации
    /// </summary>
    [XmlRoot(ElementName = "ROW")]
    [Serializable]
    public class MetroStationModel : IDirectoryModel
    {
        [XmlIgnore]
        private bool? ErasedField { get; set; }
        [XmlIgnore]
        private int? CityField { get; set; }
        [XmlIgnore]
        private int? LineIdField { get; set; }

        /// <summary>
        /// Версия записи
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
        /// ID города.Ссылка на BNK_CITY.ID
        /// </summary>
        [XmlAttribute(AttributeName = "CITY")]
        public string City
        {
            get
            {
                return CityField.HasValue ? CityField.Value.ToString() : "";
            }
            set
            {
                CityField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// ID линии. Ссылка на METRO_LINES.ID
        /// </summary>
        [XmlAttribute(AttributeName = "LINE")]
        public string LineId
        {
            get
            {
                return LineIdField.HasValue ? LineIdField.Value.ToString() : "";
            }
            set
            {
                LineIdField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// Наименование станции
        /// </summary>
        [XmlAttribute(AttributeName = "NAME")]
        public string? Name { get; set; }

        #region Типизированные знчения нестроковых параметров
      
        public bool? TypedErased => ErasedField;
        public int? TypedCity => CityField;
        public int? TypedLineId => LineIdField;

        #endregion
    }
}
