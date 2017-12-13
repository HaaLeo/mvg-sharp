// ----------------------------------------------------------------------------
// <copyright file="ClientFactory.cs">
//   Copyright (c) Leo Hanisch
// </copyright>
// <author>Leo Hanisch</author>
// <summary>
//   Defines the ClientFactory type.
// </summary>
// ----------------------------------------------------------------------------

namespace API
{
    using System;

    /// <summary>
    /// The client factory class.
    /// </summary>
    public class ClientFactory
    {
        /// <summary>
        /// Creates a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <returns>The <see cref="Client"/> instance.</returns>
        public virtual IClient CreateClient()
        {
            return new Client();
        }
    }
}
