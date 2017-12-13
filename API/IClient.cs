// ----------------------------------------------------------------------------
// <copyright file="IClient.cs">
//   Copyright (c) Leo Hanisch
// </copyright>
// <author>Leo Hanisch</author>
// <summary>
//   Defines the IClient interface.
// </summary>
// ----------------------------------------------------------------------------

namespace API
{
    using System;
    using System.Dynamic;
    using System.Threading;

    /// <summary>
    /// The IClient interface.
    /// </summary>
    public interface IClient
    {
        /// <summary>
        /// Gets all nearby stations for the given <paramref name="latitude"/> and <paramref name="longitude"/>.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns>A JSON string.</returns>
        string GetNerbyStations(float latitude, float longitude);

        /// <summary>
        /// Gets the corresponding ID for the given <paramref name="stationName"/>.
        /// </summary>
        /// <param name="stationName">The station name.</param>
        /// <returns>The station ID.</returns>
        int GetIdForStation(string stationName);

        /// <summary>
        /// Gets all stations for the given <paramref name="location"/>.
        /// </summary>
        /// <param name="location">The location. For example a street or a station name.</param>
        /// <returns>A JSON string.</returns>
        string GetStationsForLocation(string location);

        /// <summary>
        /// Gets the route from the given <paramref name="startId"/> to the <paramref name="destId"/> at a given <paramref name="time"/>.
        /// </summary>
        /// <param name="startId">The ID of the start station.</param>
        /// <param name="destId">The ID of the destination.</param>
        /// <param name="time">The time.</param>
        /// <param name="isArrivalTime">Indicates wheteher <paramref name="time"/> is arrival or departure time.</param>
        /// <param name="maxWalkTimeToStart">The maximum walking time to the departure.</param>
        /// <param name="maxWalkTimeToDest">The maximum walking time to the destination.</param>
        /// <returns>A JSON string.</returns>
        string GetRoute(
            int startId,
            int destId,
            DateTime? time = null,
            bool isArrivalTime = false,
            int maxWalkTimeToStart = 0,
            int maxWalkTimeToDest = 0);

        /// <summary>
        /// Gets all departures for the given <paramref name="stationId"/>.
        /// </summary>
        /// <param name="stationId">The station ID.</param>
        /// <returns>A JSON string.</returns>
        string GetDepartures(int stationId);

        /// <summary>
        /// Gets all current interuptions.
        /// </summary>
        /// <returns>A JSON string.</returns>
        string GetInteruptions();
    }
}
