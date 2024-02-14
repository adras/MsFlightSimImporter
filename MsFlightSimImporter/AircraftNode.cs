using ICSharpCode.TreeView;
using MsFlightSimImporter.Models.Aircraft;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MsFlightSimImporter
{
    public class AircraftNode 
    {
        private string title;
        private string manufacturer;


        public string Title
        {
            get => title; set
            {
                title = value;
            }
        }
        public string Manufacturer
        {
            get => manufacturer; set
            {
                manufacturer = value;
            }
        }

        public AircraftNode(Aircraft aircraft)
        {
            Title = aircraft.title;
            Manufacturer = aircraft.manufacturer;
        }


    }
}
