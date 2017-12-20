// ----------------------------------------------------------------------------
// <copyright file="TransportationMode.cs">
//   Copyright (c) Leo Hanisch
// </copyright>
// <author>Leo Hanisch</author>
// <summary>
//   Defines the TransportationMode enum.
// </summary>
// ----------------------------------------------------------------------------

namespace Client.DataStructure
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// The transportation mode enum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransportationMode
    {
        /// <summary>
        /// The S-Bahn.
        /// </summary>
        [EnumMember(Value = "s")]
        SBahn,

        /// <summary>
        /// The U-Bahn.
        /// </summary>
        [EnumMember(Value = "u")]
        UBahn,

        /// <summary>
        /// The tram.
        /// </summary>
        [EnumMember(Value = "t")]
        Tram,

        /// <summary>
        /// The bus.
        /// </summary>
        [EnumMember(Value = "b")]
        Bus,

        /// <summary>
        /// The train.
        /// </summary>
        [EnumMember(Value = "z")]
        Train,

        /// <summary>
        /// The ferry.
        /// </summary>
        [EnumMember(Value = "f")]
        Ferry
    }
}
