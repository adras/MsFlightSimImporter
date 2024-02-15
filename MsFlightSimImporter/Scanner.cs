using MsFlightSimImporter.Models;
using MsFlightSimImporter.Models.Aircraft;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MsFlightSimImporter
{
    internal class ManifestReader
    {
        public static ManifestInfo Read(string filePath)
        {
            string json = File.ReadAllText(filePath);
            ManifestInfo aircraft = JsonSerializer.Deserialize<ManifestInfo>(json);
            
            // Return null on error
            return aircraft;
        }
    }

    internal class Scanner
    {
        public IEnumerable<ManifestInfo> ScanManifests(DirectoryInfo flightSimDir)
        {

            foreach (FileInfo manifestFile in flightSimDir.EnumerateFiles("manifest.json", SearchOption.AllDirectories))
            {
                ManifestInfo manifest = ManifestReader.Read(manifestFile.FullName);
                if (manifest.content_type == "AIRCRAFT")
                { 
                }
                yield return manifest;
            }
        }

        internal IEnumerable<Project> ScanProjects(DirectoryInfo projectDir)
        {
            DirectoryInfo projectRoot = projectDir;
            foreach (FileInfo testFile in projectDir.EnumerateFiles("*.xml", SearchOption.AllDirectories))
            {
                XmlReader reader = XmlReader.Create(testFile.FullName);
                while(reader.Read())
                {
                    if (reader.Name== "Project")
                    {
                        projectRoot = testFile.Directory.Parent;
                        goto done;
                    }
                }
            }
            done:
            // if projectRoot is null, there are not projects yet, that should be treated as error to the user
            // user needs to create a project first
            // unless we get the real directory
            // therefore we try the real directory in this case, the one set by the user (see initialization)

            foreach (DirectoryInfo prjDir in projectRoot.EnumerateDirectories())
            {
                // Let's hope there's only one
                FileInfo file = prjDir.EnumerateFiles("*.xml").FirstOrDefault();

                XmlSerializer serializer = new XmlSerializer(typeof(Project));
                Project project = serializer.Deserialize(XmlReader.Create(file.FullName)) as Project;
                yield return project;

            }

        }
    }
}
