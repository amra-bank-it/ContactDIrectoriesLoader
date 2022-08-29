using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Repository.Entities
{
  /// <summary>
  /// Перечень услуг, которые оказывают участники системы CONTACT.
  /// </summary>
  [Table("BAD_DOC")]
  [XmlRoot(ElementName = "ROW")]
  [Serializable]

  public class BadDoc : IDirectory
  {
    /// <summary>
    /// Версия записи
    /// </summary>
    [Column("VERSION")]
    [XmlAttribute(AttributeName = "VERSION")]
    public int Version { get; set; }

    /// <summary>
    /// Флаг, указывающий на то, что запись подлежит удалению из справочника на
    /// стороне клиента.
    /// 0 – запись удалению не подлежит.
    /// 1 – запись подлежит удалению.
    /// </summary>
    [Column("ERASED")]
    [XmlAttribute(AttributeName = "ERASED")]
    public bool Erased { get; set; }

    /// <summary>
    /// Уникальный идентификатор записи
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("ID")]
    [XmlAttribute(AttributeName = "ID")]
    public int Id { get; set; }


    [Column("COUNTRY")]
    [MaxLength(3)]
    [XmlAttribute(AttributeName = "COUNTRY")]
    public string Country { get; set; }

    [Column("TYPDOC")]
    [XmlAttribute(AttributeName = "TYPEDOC")]
    public int TypeDoc { get; set; }

    [Column("S_DOC")]
    [XmlAttribute(AttributeName = "S_DOC")]
    public string? sDoc { get; set; }

    [Column("N_DOC")]
    [XmlAttribute(AttributeName = "N_DOC")]
    public string? nDoc { get; set; }

    [Column("BLOCKED")]
    [XmlAttribute(AttributeName = "BLOCKED")]
    public int blocked { get; set; }

    [Column("INFO1")]
    [MaxLength(100)]
    [XmlAttribute(AttributeName = "INFO1")]
    public string? info1 { get; set; }

    [Column("INFO")]
    [MaxLength(100)]
    [XmlAttribute(AttributeName = "INFO")]
    public string? info { get; set; }

    [Column("c10")]
    [XmlAttribute(AttributeName = "c10")]
    public int c10 { get; set; }

    [Column("c11")]
    [XmlAttribute(AttributeName = "c11")]
    public int c11 { get; set; }
  }
}