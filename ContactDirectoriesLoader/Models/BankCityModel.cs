using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Models
{
    /// <summary>
    /// Справочник городов, в которых расположены участники Contact
    ///  - модель для сериализации.
    /// </summary>
    [XmlRoot(ElementName = "ROW")]
    [Serializable]
    public class BankCityModel : IDirectoryModel
    {   
        [XmlIgnore]
        public int? CountryField { get; set; }

        [XmlIgnore]
        public int? RegionField { get; set; }

        /// <summary>
        /// Версия записи
        /// </summary>
        [XmlAttribute(AttributeName = "VERSION")]
        public int Version { get; set; }

        /// <summary>
        /// Флаг, указывающий на то, что запись подлежит удалению из справочника
        /// на стороне клиента.
        ///0 – запись удалению не подлежит.
        ///1 – запись подлежит удалению.
        /// </summary>
        [XmlAttribute(AttributeName = "ERASED")]
        public bool Erased { get; set; }

        /// <summary>
        /// Уникальный идентификатор записи
        /// </summary>
        [XmlAttribute(AttributeName = "ID")]
        public int Id { get; set; }

        /// <summary>
        /// Название города, в котором расположен участник, на русском языке
        /// </summary>
        [XmlAttribute(AttributeName = "CITY_HEAD")]
        public string CityHead { get; set; }

        /// <summary>
        /// Название города, в котором расположен участник, на английском языке
        /// </summary>
        [XmlAttribute(AttributeName = "CITY_LAT")]
        public string CityLat { get; set; }

        /// <summary>
        /// ID страны, в котором расположен город.Ссылка на COUNTRY.ID
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
        /// ID региона, в котором расположен город. Ссылка на REGION.ID
        /// </summary>
        [XmlAttribute(AttributeName = "REGION")]
        public string Region
        {
            get
            {
                return RegionField.HasValue ? RegionField.Value.ToString() : "";
            }

            set
            {
                RegionField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// Перечень валют, которые участник системы, для которого сформирован
        /// справочник, может принимать из данного города.
        /// Перечень включает коды валют, разделенных точкой с запятой.
        /// Примеры:
        /// RUR; - участник принимает только рубли.
        /// RUR; USD; - участник принимает рубли и доллары.
        /// </summary>
        [XmlAttribute(AttributeName = "SEND_CURR")]
        public string SendingCurrencies { get; set; }

        /// <summary>
        /// Перечень валют, которые участник системы, для которого сформирован
        /// справочник, может отправлять в данный город.Перечень включает коды
        /// валют, разделенные точкой с запятой.
        /// Коды валют:
        /// RUR – российские рубли USD – доллары США
        /// EUR – евро.
        /// </summary>
        [XmlAttribute(AttributeName = "REC_CURR")]
        public string ReceivingCurrencies { get; set; }

        /// <summary>
        /// Код точки выплаты.Если данное поле заполнено, то при оформлении
        /// перевода(услуга “Переводы физических лиц физическим лицам”) указание
        /// точки выплаты не требуется, перевод необходимо отправлять в адрес точки
        /// с кодом PP_CODE, при этом правила оформления перевода(список полей
        /// к заполнению, уникальность номера перевода и т.д.) определяется по
        /// таблице BANKS обычным способом
        /// </summary>
        [Column("PP_CODE")]
        public string PointCode { get; set; }


        #region Типизированные знчения нестроковых параметров

        public int? TypedCountry => CountryField;

        public int? TypedRegion => RegionField;

        #endregion
    }
}
