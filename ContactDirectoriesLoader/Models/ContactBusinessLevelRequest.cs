using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Models
{
    [Serializable]
    [XmlRoot(ElementName = "REQUEST")]
    public class ContactBusinessLevelRequest
    {
        [XmlIgnore]
        private int? PortionField { get; set; }

        [XmlIgnore]
        private int? PartField { get; set; }

        [XmlAttribute(AttributeName = "OBJECT_CLASS")]
        public string ObjectClass { get; set; }

        [XmlAttribute(AttributeName = "ACTION")]
        public string Action { get; set; }

        [XmlAttribute(AttributeName = "POINT_CODE")]
        public string PointCode { get; set; }

        [XmlAttribute(AttributeName = "INT_SOFT_ID")]
        public string IntSoftd { get; set; }

        [XmlAttribute(AttributeName = "VERSION")]
        public string? Version { get; set; }

        [XmlAttribute(AttributeName = "TYPE_VERSION")]
        public string TypeVersion { get; set; }

        [XmlAttribute(AttributeName = "PORTION")]
        public string Portion 
        { 
            get
            {
                return PortionField.HasValue ? PortionField.Value.ToString() : "";
            }
          
            set
            {
                PortionField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        [XmlAttribute(AttributeName = "BOOK_ID")]
        public string BookId { get; set; }

        [XmlAttribute(AttributeName = "PART")]
        public string Part
        {
            get
            {
                return PartField.HasValue ? PartField.Value.ToString() : "";
            }

            set
            {
                PartField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        [XmlAttribute(AttributeName = "PACK")]
        public string Pack { get; set; }

        [XmlAttribute(AttributeName = "SignOut")]
        public string SignOut { get; set; }

        [XmlAttribute(AttributeName = "ExpectSigned")]
        public string ExpectSigned { get; set; }
    }
}
