using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MsFlightSimImporter.Models
{
    [XmlRoot(ElementName = "Project")]
    public class Project
    {
        [XmlElement(ElementName = "OutputDirectory")]
        public string OutputDirectory { get; set; }

        [XmlElement(ElementName = "TemporaryOutputDirectory")]
        public string TemporaryOutputDirectory { get; set; }

        [XmlElement(ElementName = "PublishingGroupTemporaryOutputDirectory")]
        public string PublishingGroupTemporaryOutputDirectory { get; set; }

        [XmlElement(ElementName = "Packages")]
        public Packages Packages { get; set; }

        [XmlElement(ElementName = "PublishingGroups")]
        public string PublishingGroups { get; set; }
    }

    public class Packages
    {
        [XmlElement(ElementName = "Package")]
        public string Package { get; set; }
    }
}
