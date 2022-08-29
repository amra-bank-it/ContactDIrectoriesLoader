using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Models
{
  /// <summary>
  /// Cписок участников системы CONTACT - модель для сериализации
  /// </summary>
  [XmlRoot(ElementName = "ROW")]
  [Serializable]
  public class BadDocModel : IDirectoryModel
  {
    [XmlIgnore]
    public string? S_DOC_FIELD { get; set; }
    [XmlIgnore]
    public string? N_DOC_FIELD { get; set; }


    [XmlAttribute(AttributeName = "ID")]
    public int ID { get; set; }


    [XmlAttribute(AttributeName = "VERSION")]
    public int Version { get; set; }

    [XmlAttribute(AttributeName = "ERASED")]
    public bool Erased { get; set; }

    [XmlAttribute(AttributeName = "COUNTRY")]
    public string COUNTRY { get; set; }


    [XmlAttribute(AttributeName = "TYPDOC")]
    public int TYPDOC { get; set; }

    [XmlAttribute(AttributeName = "S_DOC")]
    public string S_DOC
    {
      get
      {
        return S_DOC_FIELD;
      }

      set
      {
        S_DOC_FIELD = value.Replace(" ", "");
      }
    }


    [XmlAttribute(AttributeName = "N_DOC")]
    public string N_DOC
    {
      get
      {
        return N_DOC_FIELD;
      }

      set
      {
        N_DOC_FIELD =value.Replace(" ","");
      }
    }

    [XmlAttribute(AttributeName = "BLOCKED")]
    public int BLOCKED { get; set; }

    [XmlAttribute(AttributeName = "INFO")]
    public string INFO { get; set; }

    [XmlAttribute(AttributeName = "INFO1")]
    public string INFO1 { get; set; }

    [XmlAttribute(AttributeName = "c10")]
    public int c10 { get; set; }

    [XmlAttribute(AttributeName = "c11")]
    public int c11 { get; set; }



  }



}
