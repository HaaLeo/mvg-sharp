// ----------------------------------------------------------------------------
// <copyright file="ClientFactory.cs">
//   Copyright (c) Leo Hanisch
// </copyright>
// <author>Leo Hanisch</author>
// <summary>
//   Defines the ClientFactory type.
// </summary>
// ----------------------------------------------------------------------------

namespace Client
{
    using System;

    /// <summary>
    /// The client factory class.
    /// </summary>
    public class ClientFactory
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MvgClient"/> class.
        /// </summary>
        /// <returns>The <see cref="MvgClient"/> instance.</returns>
        public virtual IClient CreateMvgClient()
        {
            return new MvgClient();
        }
    }
}

