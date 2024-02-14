﻿using MsFlightSimImporter.Models.Aircraft;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MsFlightSimImporter
{
    internal class ManifestReader
    {
        public static Aircraft Read(string filePath)
        {
            string json = File.ReadAllText(filePath);
            Aircraft aircraft = JsonSerializer.Deserialize<Aircraft>(json);
            
            // Return null on error
            return aircraft;
        }
    }

    internal class Scanner
    {
        public void Scan(DirectoryInfo flightSimDir)
        {
            List<Aircraft> aircraftList = new List<Aircraft>();

            foreach (FileInfo manifestFile in flightSimDir.EnumerateFiles("manifest.json", SearchOption.AllDirectories))
            {
                Aircraft aircraft = ManifestReader.Read(manifestFile.FullName);
                aircraftList.Add(aircraft);
            }
        }
    }
}