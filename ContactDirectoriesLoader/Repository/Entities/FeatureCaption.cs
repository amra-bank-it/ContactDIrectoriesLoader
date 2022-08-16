using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContactDirectoriesLoader.Repository.Entities
{
    /// <summary>
    /// Текстовая информация об особенностях обслуживания в странах, банках и компаниях
    /// </summary>
    [Table("FEAT_TXT")]
    public class FeatureCaption : IDirectory
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
        public int Id { get; set; }

        /// <summary>
        /// ID особенности (поле ID таблицы FEATURE )
        /// </summary>
        [Column("FEATURE")]
        public int FeatureId { get; set; }

        /// <summary>
        /// Номер строки по порядку
        /// </summary>
        [Column("LINE_NO")] 
        public int LineNumber { get; set; }

        /// <summary>
        /// Текст строки сообщения
        /// </summary>
        [Column("LINE_TEXT")]
        [MaxLength(254)]
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
        [Column("XML_TEXT")]
        [MaxLength(254)]
        public string? XmlText { get; set; }

    }
}
