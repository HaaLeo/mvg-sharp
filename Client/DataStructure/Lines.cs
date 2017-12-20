// ----------------------------------------------------------------------------
// <copyright file="Lines.cs">
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
    /// The lines class.
    /// </summary>
    [JsonObject("lines")]
    public class Lines
    {
        /// <summary>
        /// Gets or sets the tram lines.
        /// </summary>
        [JsonProperty("tram")]
        public IEnumerable<int> Tram { get; set; }

        /// <summary>
        /// Gets or sets the night tram lines.
        /// </summary>
        [JsonProperty("nachttram")]
        public IEnumerable<int> NachtTram { get; set; }

        /// <summary>
        /// Gets or sets the S-Bahn lines.
        /// </summary>
        [JsonProperty("sbahn")]
        public IEnumerable<int> SBahn { get; set; }

        /// <summary>
        /// Gets or sets the U-Bahn lines.
        /// </summary>
        [JsonProperty("ubahn")]
        public IEnumerable<int> UBahn { get; set; }

        /// <summary>
        /// Gets or sets the bus lines.
        /// </summary>
        [JsonProperty("bus")]
        public IEnumerable<int> Bus { get; set; }

        /// <summary>
        /// Gets or sets the night bus lines.
        /// </summary>
        [JsonProperty("nachtbus")]
        public IEnumerable<int> NachtBus { get; set; }

        /// <summary>
        /// Gets or sets other lines.
        /// </summary>
        [JsonProperty("otherlines")]
        public IEnumerable<int> OtherLines { get; set; }
    }
}
