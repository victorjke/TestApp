using System.Dynamic;
using System.Xml.Serialization;


namespace TestApp.Core.Models
{
    [XmlRoot("yml_catalog")]
    public class Catalog
    {
        [XmlElement("shop")]
        public Shop Shop { get; set; }
    }
}