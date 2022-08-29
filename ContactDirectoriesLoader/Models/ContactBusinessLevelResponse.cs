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
    [XmlRoot(ElementName = "RESPONSE")]
    public class ContactBusinessLevelResponse
    {
        [XmlIgnore]
        private int? CurrentPartNumberField { get; set; }

        [XmlIgnore]
        private int? TotalPartsAmountField { get; set; }

        [XmlAttribute(AttributeName = "SIGN_IT")]
        public int SignIt { get; set; }

        [XmlAttribute(AttributeName = "VERSION")]
        public int Version { get; set; }

        [XmlAttribute(AttributeName = "FULL")]
        public bool Full { get; set; }

        [XmlAttribute(AttributeName = "RE")]
        public int Re { get; set; }

        [XmlAttribute(AttributeName = "ERR_TEXT")]
        public string ErrorText { get; set; }

        [XmlAttribute(AttributeName = "NOLOG")]
        public bool Nolog { get; set; }

        [XmlAttribute(AttributeName = "GLOBAL_VERSION")]
        public string GlobalVersion { get; set; }

        [XmlAttribute(AttributeName = "GLOBAL_VERSION_SERVER")]
        public string GlobalVersionServer { get; set; }

        [XmlAttribute(AttributeName = "BOOK_ID")]
        public string PartitionDirectoryId { get; set; }

        [XmlAttribute(AttributeName = "PART")]
        public string CurrentPartNumber 
        {
            get
            {
                return CurrentPartNumberField.HasValue ? CurrentPartNumberField.Value.ToString() : "";
            }

            set
            {
                CurrentPartNumberField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

        [XmlAttribute(AttributeName = "TOTAL")]
        public string TotalPartsAmount
        {
            get
            {
                return TotalPartsAmountField.HasValue ? TotalPartsAmountField.Value.ToString() : "";
            }

            set
            {
                TotalPartsAmountField =
                  !string.IsNullOrEmpty(value)
                 ? Convert.ToInt32(value)
                 : (int?)null;
            }
        }

    [XmlElement(ElementName = "BANKS")]
    public string BanksDirectory { get; set; }
    [XmlElement(ElementName = "BAD_DOC")]
    public string BadDocsDirectory { get; set; }

    [XmlElement(ElementName = "BNK_CITY")]
        public string BankCitiesDirectory { get; set; }

        [XmlElement(ElementName = "BANKSERV")]
        public string BankServicesDirectory { get; set; }

        [XmlElement(ElementName = "ATTRLIST")]
        public string ControlRulesDirectory { get; set; }

        [XmlElement(ElementName = "COUNTRY")]
        public string CountriesDirectory { get; set; }

        [XmlElement(ElementName = "FEATURE")]
        public string FeaturesDirectory { get; set; }

        [XmlElement(ElementName = "FEAT_TXT")]
        public string FeatureTextDirectory { get; set; }

        [XmlElement(ElementName = "KFM_INFO")]
        public string FinancialMonitoringInfoDirectory { get; set; }

        [XmlElement(ElementName = "MIN_MAX")]
        public string LimitsDirectory { get; set; }

        [XmlElement(ElementName = "LOGO")]
        public string LogosDirectory { get; set; }

        [XmlElement(ElementName = "METRO_LINES")]
        public string MetroLinesDirectory { get; set; }

        [XmlElement(ElementName = "METRO")]
        public string MetroStationsDirectory { get; set; }

        [XmlElement(ElementName = "REGION")]
        public string RegionsDirectory { get; set; }

        [XmlElement(ElementName = "SCEN_ITEM")]
        public string ScenarioItemsDirectory { get; set; }

        [XmlElement(ElementName = "SERV")]
        public string ServicesDirectory { get; set; }

        public int? TypedCurrentPartNumber => CurrentPartNumberField;
        public int? TypedTotalPartsAmount => TotalPartsAmountField;

    }
}
