using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// This file was generated from json using https://json2csharp.com/
/// </summary>
namespace OsloBysykkelUpdates
{
    /// <summary>
    /// Root of the json file object.
    /// </summary>
    public class StationStatusJson
    {
        public int last_updated { get; set; }
        public Data data { get; set; }
    }

    /// <summary>
    /// Data holds a list of stations. 
    /// </summary>
    public class Data
    {
        public List<Station> stations { get; set; }
    }

    /// <summary>
    /// Station is the object containing the curretn status of a station.
    /// Simplified to only hold what is needed to show available bikes and docks with a simple ToString. 
    /// </summary>
    public class Station
    {
        public int num_bikes_available { get; set; }
        public int num_docks_available { get; set; }
        public string station_id { get; set; }

        override
        public string ToString()
        {
            return $"Id:{station_id} Bikes:{num_bikes_available} Docks:{num_docks_available}";
        }
    }
}
