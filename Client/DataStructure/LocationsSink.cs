// ----------------------------------------------------------------------------
// <copyright file="LocationsSink.cs">
//   Copyright (c) Leo Hanisch
// </copyright>
// <author>Leo Hanisch</author>
// <summary>
//   Defines the TransportationMode enum.
// </summary>
// ----------------------------------------------------------------------------

namespace Client.DataStructure
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// The location sink wraps all locations.
    /// </summary>
    public class LocationsSink
    {
        /// <summary>
        /// Gets or sets the locations.
        /// </summary>
        [JsonProperty("locations")]
        public IEnumerable<Station> Locations { get; set; }
    }
}
