using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsFlightSimImporter.Models.Aircraft
{
    public class Neutral
    {
        public string LastUpdate { get; set; }
        public string OlderHistory { get; set; }
    }

    public class ReleaseNotes
    {
        public Neutral neutral { get; set; }
    }

    public class Aircraft
    {
        // I don't know the type, I don't know what even dependencies are, I don't care right now
        public List<object> dependencies { get; set; }
        public string content_type { get; set; }
        public string title { get; set; }
        public string manufacturer { get; set; }
        public string creator { get; set; }
        public string package_version { get; set; }
        public string minimum_game_version { get; set; }
        public ReleaseNotes release_notes { get; set; }
        public string total_package_size { get; set; }
    }
}
