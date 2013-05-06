using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSMVVM.WPF.Messaging
{
    public sealed class BasicMessenger
    {
        static BasicMessenger()
        {
            defaultInstance = new Lazy<BasicMessenger>(() => new BasicMessenger());
        }

        public static BasicMessenger Default
        {
            get
            {
                return defaultInstance.Value;
            }
        }

        private static Lazy<BasicMessenger> defaultInstance;

        public BasicMessenger()
        {
            responseDictionary = new ConcurrentDictionary<string, Action>();
        }

        public void Register(string id, Action response)
        {
            responseDictionary[id] = response;
        }

        public void Unregister(string id)
        {
            Action unused;
            responseDictionary.TryRemove(id, out unused);
        }

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
