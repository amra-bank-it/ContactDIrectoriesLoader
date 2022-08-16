using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Models
{
    /// <summary>
    /// Перечень регионов, где расположены участники системы CONTACT  - модель для сериализации
    /// </summary>
    [XmlRoot(ElementName = "ROW")]
    [Serializable]
    public class RegionModel : IDirectoryModel
    {
        [XmlIgnore]
        private bool? ErasedField { get; set; }
        [XmlIgnore]
        private int? CountryField { get; set; }

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
        /// Код региона в соответствии с ISO 3166-2
        /// </summary>
        [XmlAttribute(AttributeName = "SUBDIVISION_ISOCODE")]
        public string SubdivisionIsoCode { get; set; }
        
        /// <summary>
        /// Страны региона из справочника COUNTRY
        /// </summary>
        [XmlAttribute(AttributeName = "COUNTRY")]
        public string Country
        {
            get
            {
                return CountryField.HasValue ? CountryField.Value.ToString() : "";
            }
            set
            {
                CountryField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }
        
        /// <summary>
        /// Название региона на русском языке
        /// </summary>
        [XmlAttribute(AttributeName = "NAME")]
        public string Name { get; set; }

        /// <summary>
        /// Название региона на русском языке, используемое при сортировке списка
        /// регионов.
        /// </summary>
        [XmlAttribute(AttributeName = "NAME_SORT")]
        public string NameSort { get; set; }

        /// <summary>
        /// Название региона на английском языке
        /// </summary>
        [XmlAttribute(AttributeName = "NAME_LAT")]
        public string? NameLat { get; set; }

        #region Типизированные знчения нестроковых параметров

        public bool? TypedErased => ErasedField;

        public int? TypedCountry => CountryField;

        #endregion
    }
}






