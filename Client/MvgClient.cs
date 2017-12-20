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
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    
    using Client.DataStructure;

    using Newtonsoft.Json;

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
            _client.BaseAddress = new Uri("https://www.mvg.de/");
        }

        /// <summary>
        /// Gets the unique ID for the given <paramref name="stationName"/>.
        /// </summary>
        /// <param name="stationName">The station name.</param>
        /// <returns>The station ID or 0.</returns>
        public async Task<int> GetStationId(string stationName)
        {
            if (string.IsNullOrEmpty(stationName))
            {
                throw new ArgumentException("The value must not be null or empty.", nameof(stationName));
            }

            var stations = await this.GetStations(stationName);
            return stations.FirstOrDefault(station => station.Name == stationName).Id;
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
                "fahrinfo/api/location/nearby?latitude="
                + latitude.ToString(CultureInfo.InvariantCulture)
                + "&longitude="
                + longitude.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Gets all available stations.
        /// </summary>
        /// <returns>A JSON string.</returns>
        public async Task<IEnumerable<Station>> GetAllStations()
        {
            var response = await _client.GetStringAsync("fahrinfo/api/location/queryWeb?q=");
            return JsonConvert.DeserializeObject<LocationsSink>(response).Locations;
        }

        /// <summary>
        /// Gets all stations or addresses for the given <paramref name="location"/>.
        /// </summary>
        /// <param name="location">The location. For example a street or a station name.</param>
        /// <returns>A JSON string.</returns>
        public async Task<IEnumerable<Station>> GetStations(string location)
        {
            if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentException("The value must not be null or empty.", nameof(location));
            }

            var response = await _client.GetStringAsync("fahrinfo/api/location/queryWeb?q=" + location);
            return JsonConvert.DeserializeObject<LocationsSink>(response).Locations;
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
        public async Task<string> GetRoute(
            int startId,
            int destId,
            DateTime? time = null,
            bool isArrivalTime = false,
            int maxWalkTimeToStart = 0,
            int maxWalkTimeToDest = 0)
        {
            if (startId <= 0)
            {
                throw new ArgumentException("The value must be greater than 0.", nameof(startId));
            }

            if (destId <= 0)
            {
                throw new ArgumentException("The value must be greater than 0.", nameof(destId));
            }

            if (maxWalkTimeToDest < 0)
            {
                throw new ArgumentException("The value must be zero or greater.", nameof(maxWalkTimeToDest));
            }

            if (maxWalkTimeToStart < 0)
            {
                throw new ArgumentException("The value must be zero or greater.", nameof(maxWalkTimeToStart));
            }

            var options = new List<string>
            {
                // Settings for start and destination
                "fromStation=" + startId,
                "toStation=" + destId
            };

            // Settings for time
            var dto = time != null ? new DateTimeOffset((DateTime)time) : new DateTimeOffset(DateTime.Now);
            var unixSeconds = dto.ToUnixTimeMilliseconds();
            options.Add("time=" + unixSeconds);

            // Is given time arrival time?
            if (isArrivalTime)
            {
                options.Add("arrival=true");
            }

            // Settings for footway travel time
            options.Add("maxTravelTimeFootwayToStation=" + maxWalkTimeToStart);
            options.Add("maxTravelTimeFootwayToDestination=" + maxWalkTimeToDest);

            return await _client.GetStringAsync("fahrinfo/api/routing/?" + string.Join("&", options));
        }

        /// <summary>
        /// Gets all departures for the given <paramref name="stationId"/>.
        /// </summary>
        /// <param name="stationId">The station ID.</param>
        /// <returns>A JSON string.</returns>
        public async Task<string> GetDepartures(int stationId)
        {
            if (stationId <= 0)
            {
                throw new ArgumentException("The value must be greater than 0", nameof(stationId));
            }

            return await _client.GetStringAsync("fahrinfo/api/departure/" + stationId + "?footway=0");
        }

        /// <summary>
        /// Gets all current interuptions.
        /// </summary>
        /// <returns>A JSON string.</returns>
        public async Task<string> GetInteruptions()
        {
            return await _client.GetStringAsync(".rest/betriebsaenderungen/api/interruptions");
        }
    }
}
