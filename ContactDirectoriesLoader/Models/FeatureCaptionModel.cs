using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Models
{
    /// <summary>
    /// Текстовая информация об особенностях обслуживания в странах, банках и компаниях  - модель для сериализации
    /// </summary>
    [XmlRoot(ElementName = "ROW")]
    [Serializable]
    public class FeatureCaptionModel : IDirectoryModel
    {
        [XmlIgnore]
        private bool? ErasedField { get; set; }
        [XmlIgnore]
        private int? FeatureIdField { get; set; }
        [XmlIgnore]
        private int? LineNumberField { get; set; }

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
        /// ID особенности (поле ID таблицы FEATURE )
        /// </summary>
        [XmlAttribute(AttributeName = "FEATURE")]
        public string FeatureId
        {
            get
            {
                return FeatureIdField.HasValue ? FeatureIdField.Value.ToString() : "";
            }
            set
            {
                FeatureIdField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// Номер строки по порядку
        /// </summary>
        [XmlAttribute(AttributeName = "LINE_NO")]
        public string LineNumber
        {
            get
            {
                return LineNumberField.HasValue ? LineNumberField.Value.ToString() : "";
            }
            set
            {
                LineNumberField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        /// <summary>
        /// Текст строки сообщения
        /// </summary>
        [XmlAttribute(AttributeName = "LINE_TEXT")]
        public string? LineText { get; set; }

        /// <summary>
        /// Текст XML, содержащей особенности выплаты участника, в соответствии со
        
        /// <?xml version = "1.0" encoding="utf-8"?>
        ///<xs:schema xmlns:xs="http://www.w3.org/2001/XMLSchema">
        ///<xs:element name = "FEATURE" >
        ///< xs:complexType>
        ///<xs:sequence>
        ///<xs:element name = "NAME" type="FeatureNameType"/>
        ///<xs:simpleType name = "FeatureNameType" >
        ///< xs:restriction base="xs:string">
        ///<xs:enumeration value = "DELIVERY_METHOD" />
        ///<xs:enumeration value = "TERM_DELIVERY" />
        ///<xs:enumeration value = "TERM_CANCELL_FROM" />
        ///<xs:enumeration value = "TERM_CANCELL_TO" />
        ///<xs:enumeration value = "TERM_CANCELL_MEASURE_UNIT" />
        ///<xs:enumeration value = "CUT_OFF_TIME" />
        ///<xs:enumeration value = "PAID_CURRENCY" />
        ///<xs:enumeration value = "RATE_EXCHANGE" />
        ///<xs:enumeration value = "LANGUAGE_SMS" />
        ///<xs:enumeration value = "NOTE" />
        ///<xs:enumeration value = " BNF_BANK_TYPE " />
        ///<xs:enumeration value = " BNF_TYPE " />
        ///<xs:enumeration value = " ACCOUNT_CURRENCY " />
        ///</xs:restriction>
        ///</xs:simpleType>
        ///<xs:element name = "VALUE" type="xs:string"/>
        ///</xs:sequence>
        ///</xs:complexType>
        ///</xs:element>
        ///</xs:schema>
        ///Пример xml-документа:
        ///<?xml version = "1.0" encoding="utf-8"?>
        ///<FEATURE>
        ///<Name>DELIVERY_METHOD</Name>
        ///<value>Наличные<value>
        ///<FEATURE/>
        ///<FEATURE>
        ///<Name>TERM_DELIVERY</Name>
        ///<value>15 минут</value>
        ///</FEATURE>
        /// </summary>
        [XmlAttribute(AttributeName = "XML_TEXT")]
        public string XmlText { get; set; }

        #region Типизированные знчения нестроковых параметров

        public bool? TypedErased => ErasedField;
        public int? TypedFeatureId => FeatureIdField;
        public int? TypedLineNumber => LineNumberField;

        #endregion

    }
}
