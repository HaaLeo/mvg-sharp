// ----------------------------------------------------------------------------
// <copyright file="MvgClient.cs">
//   Copyright (c) Leo Hanisch
// </copyright>
// <author>Leo Hanisch</author>
// <summary>
//   Defines the Client type.
// </summary>
// ----------------------------------------------------------------------------

namespace Client
{
    using System;
    using System.Globalization;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// The unofficial .NET client for the MVG web API.
    /// </summary>
    public class MvgClient : IClient
    {
        /// <summary>
        /// The http client to perform API requests.
        /// </summary>
        private static HttpClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="MvgClient"/> class.
        /// </summary>
        public MvgClient()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("X-MVG-Authorization-Key", "5af1beca494712ed38d313714d4caff6");
            _client.BaseAddress = new Uri("https://www.mvg.de/fahrinfo/api/");
        }

        /// <summary>
        /// Gets all nearby stations for the given <paramref name="latitude"/> and <paramref name="longitude"/>.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns>A JSON string.</returns>
        public async Task<string> GetNerbyStations(double latitude, double longitude)
        {
            if (latitude == 0)
            {
                throw new ArgumentException("The argument must not be zero.", nameof(latitude));
            }

            if (longitude == 0)
            {
                throw new ArgumentException("The argument must not be zero.", nameof(longitude));
            }

            return await _client.GetStringAsync(
                "location/nearby?latitude="
                + latitude.ToString(CultureInfo.InvariantCulture)
                + "&longitude="
                + longitude.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Gets all available stations.
        /// </summary>
        /// <returns>A JSON string.</returns>
        public async Task<string> GetAllStations()
        {
            return await _client.GetStringAsync("location/queryWeb?q=");
        }

        /// <summary>
        /// Gets all stations for the given <paramref name="location"/>.
        /// </summary>
        /// <param name="location">The location. For example a street or a station name.</param>
        /// <returns>A JSON string.</returns>
        public string GetStationsForLocation(string location)
        {
            if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentException("The value must not be null or empty.", nameof(location));
            }

            //// Todo: Add api call
            throw new NotImplementedException();
        }

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
        public string GetRoute(
            int startId,
            int destId,
            DateTime? time = null,
            bool isArrivalTime = false,
            int maxWalkTimeToStart = 0,
            int maxWalkTimeToDest = 0)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all departures for the given <paramref name="stationId"/>.
        /// </summary>
        /// <param name="stationId">The station ID.</param>
        /// <returns>A JSON string.</returns>
        public string GetDepartures(int stationId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all current interuptions.
        /// </summary>
        /// <returns>A JSON string.</returns>
        public string GetInteruptions()
        {
            throw new NotImplementedException();
        }
    }
}
