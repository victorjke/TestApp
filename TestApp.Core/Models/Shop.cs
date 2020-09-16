using System.Collections.Generic;
using System.Xml.Serialization;


namespace TestApp.Core.Models
{
    [XmlRoot("shop")]
    public class Shop
    {
        [XmlElement("offers")]
        public List<object> OffersList { get; set; }
    }
}