using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentCard.Models
{
    [XmlRoot(ElementName = "DataBaseForStud", IsNullable = true), Serializable]
    public class DataBaseForStud
    {
        [Key]
        [XmlElement(ElementName = "fio")]
        public string fio { get; set; }
        [XmlElement(ElementName = "age")]
        public string age { get; set; }
        [XmlElement(ElementName = "fak")]
        public string fak { get; set; }
        [XmlElement(ElementName = "direction")]
        public string direction { get; set; }
        [XmlElement(ElementName = "course")]
        public int course { get; set; }
        [XmlElement(ElementName = "expirience")]
        public string expirience { get; set; }
    }
}