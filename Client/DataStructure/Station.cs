// ----------------------------------------------------------------------------
// <copyright file="Station.cs">
//   Copyright (c) Leo Hanisch
// </copyright>
// <author>Leo Hanisch</author>
// <summary>
//   Defines the Station type.
// </summary>
// ----------------------------------------------------------------------------

namespace Client.DataStructure
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// Represents a station of the munich public transportation system.
    /// </summary>
    public class Station
    {
        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude
        /// </summary>
        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the unique ID.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the place.
        /// </summary>
        [JsonProperty("place")]
        public string Place { get; set; }

        /// <summary>
        /// Gets or sets the available transportation modes.
        /// </summary>
        [JsonProperty("products")]
        public IEnumerable<TransportationMode> TransportationModes { get; set; }

        /// <summary>
        /// Gets or sets the available transportation lines.
        /// </summary>
        [JsonProperty("lines")]
        public Lines Lines { get; set; }
    }
}
