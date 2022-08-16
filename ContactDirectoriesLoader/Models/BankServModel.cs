using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Models
{
    /// <summary>
    /// таблица, связывающая участников системы (BANKS) и оказываемые ими услуги(SERV)
    /// </summary>
    [XmlRoot(ElementName = "ROW")]
    [Serializable]
    public class BankServModel : IDirectoryModel
    {
        [XmlIgnore]
        private bool? ErasedField { get; set; }

        /// <summary>
        /// Версия записи.
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
        /// ID банка-участника системы Contact (BANKS.ID)
        /// </summary>
        [XmlAttribute(AttributeName = "BANK_ID")]
        public int BankId { get; set; }

        /// <summary>
        /// ID услуги (SERV.ID)
        /// </summary>
        [XmlAttribute(AttributeName = "SERV_ID")]
        public int ServId { get; set; }

        #region Типизированные знчения нестроковых параметров

        public bool? TypedErased => ErasedField;

        #endregion
    }
}
