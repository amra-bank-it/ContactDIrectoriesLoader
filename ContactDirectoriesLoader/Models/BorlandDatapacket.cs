using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Models
{
    /// <summary>
    /// Объект для десериализации ответа в XML Borland Datapacket.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "DATAPACKET", Namespace = "", IsNullable = false)]
    public partial class BorlandDatapacket<T>
        where T : IDirectoryModel
    {
        /// <summary>
        /// Коллекция объектов Row под общим тегом Rowdata
        /// </summary>
        [XmlArray("ROWDATA", IsNullable = false)]
        [XmlArrayItem("ROW", IsNullable = false)]
        public T[] Directories { get; set; }
    }
}
