// Copyright (c) 2013 Dustin Leavins
// See the file 'LICENSE.txt' for copying permission.
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSMVVM.WPF.Messaging
{
    /// <summary>
    /// Basic messaging class.
    /// </summary>
    /// <remarks>
    /// This class works with string IDs. Only the ID is sent as part
    /// of messaging.
    /// </remarks>
    public sealed class BasicMessenger
    {
        /// <summary>
        /// Default instance of <c>BasicMessenger</c>.
        /// </summary>
        /// <remarks>
        /// BasicMessenger is not a singleton class, and this property exists
        /// for convenience.
        /// </remarks>
        public static BasicMessenger Default
        {
            get
            {
                return defaultInstance.Value;
            }
        }

        private static Lazy<BasicMessenger> defaultInstance = 
            new Lazy<BasicMessenger>(() => new BasicMessenger());

        public BasicMessenger()
        {
            responseDictionary = new ConcurrentDictionary<string, Action>();
        }

        /// <summary>
        /// Register a response <c>Action</c> for the <c>id</c>.
        /// </summary>
        /// <param name="id">Message id</param>
        /// <param name="response">Message response</param>
        public void Register(string id, Action response)
        {
            responseDictionary[id] = response;
        }

        /// <summary>
        /// Unregisters the <c>Action</c> currently registered with the given id.
        /// </summary>
        /// <param name="id">Message id</param>
        public void Unregister(string id)
        {
            Action unused;
            responseDictionary.TryRemove(id, out unused);
        }

        /// <summary>
        /// Send a message with the given id; this will invoke the currently
        /// registered <c>Action</c> (if one is currently registered)
        /// </summary>
        /// <param name="id">Message id</param>
        public void Send(string id)
        {
            Action actionHandler;
            responseDictionary.TryGetValue(id, out actionHandler);

            if (actionHandler != null)
            {
                actionHandler.Invoke();
            }
        }

        private ConcurrentDictionary<string, Action> responseDictionary;
    }
}
