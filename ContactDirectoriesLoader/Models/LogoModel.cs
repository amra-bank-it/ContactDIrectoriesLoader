using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Models
{
    /// <summary>
    /// Логотипы участников  - модель для сериализации
    /// </summary>
    [XmlRoot(ElementName = "ROW")]
    [Serializable]
    public class LogoModel : IDirectoryModel
    {
        [XmlIgnore]
        private bool? ErasedField { get; set; }
        [XmlIgnore]
        private byte[]? LogoDataBlobField { get; set; }
        [XmlIgnore]
        private byte[]? LogoDataLatField { get; set; }

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
        /// Имя логотипа
        /// </summary>
        [XmlAttribute(AttributeName = "LOGO_NAME")]
        public string? LogoName { get; set; }

        /// <summary>
        /// Содержимое логотипа в формате JPG
        /// </summary>
        [XmlAttribute(AttributeName = "LOGO_DATA")]
        public string LogoDataBlob
        {
            get
            {
                return LogoDataBlobField != null ? Convert.ToBase64String(LogoDataBlobField) : "";
            }

            set
            {
                LogoDataBlobField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.FromBase64String(value)
                 : null;
            }
        }

        /// <summary>
        /// Содержимое логотипа в формате JPG на английском языке, если данное
        /// поле не заполнено, то следует использовать LOGO_DATA
        /// </summary>
        [XmlAttribute(AttributeName = "LOGO_DATA_LAT")]
        public string LogoDataLat
        {
            get
            {
                return LogoDataLatField != null ? Convert.ToBase64String(LogoDataLatField) : "";
            }

            set
            {
                LogoDataLatField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.FromBase64String(value)
                 : null;
            }
        }

        #region Типизированные знчения нестроковых параметров
        public bool? TypedErased => ErasedField;
        public byte[]? TypedLogoDataBlob => LogoDataBlobField;
        public byte[]? TypedLogoDataLat => LogoDataLatField;

        #endregion
    }
}
