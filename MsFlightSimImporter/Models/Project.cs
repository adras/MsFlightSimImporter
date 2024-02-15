using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MsFlightSimImporter.Models
{
    [XmlRoot("Project")]
    public class Project
    {
        [XmlAttribute("Version")]
        public int Version { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("FolderName")]
        public string FolderName { get; set; }

        [XmlAttribute("PublishingGroupFolderName")]
        public string PublishingGroupFolderName { get; set; }

        [XmlAttribute("MetadataFolderName")]
        public string MetadataFolderName { get; set; }

        [XmlAttribute("PublishingGroupMetadataFolderName")]
        public string PublishingGroupMetadataFolderName { get; set; }

        public string OutputDirectory { get; set; }
        public string TemporaryOutputDirectory { get; set; }
        public string PublishingGroupTemporaryOutputDirectory { get; set; }

        public List<string> Packages { get; set; }
        public List<string> PublishingGroups { get; set; }
    }
}
