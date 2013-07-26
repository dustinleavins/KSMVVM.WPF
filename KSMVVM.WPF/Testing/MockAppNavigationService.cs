// Copyright (c) 2013 Dustin Leavins
// See the file 'LICENSE.txt' for copying permission.
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace KSMVVM.WPF.Testing
{
    /// <summary>
    /// Mock implementation of IAppNavigationService.
    /// </summary>
    /// <remarks>
    /// If you are not using a mocking framework, you can inject an instance
    /// of this class into View Models and check nav functionality.
    /// </remarks>
    public sealed class MockAppNavigationService : IAppNavigationService
    {
        public MockAppNavigationService()
        {
            accessCountLog = new Dictionary<Type, int>();
        }

        public Page CurrentPage
        {
            get
            {
                return null;
            }
        }

        public void Navigate<TPage>(Func<TPage> page) where TPage : Page
        {
            if (accessCountLog.ContainsKey(typeof(TPage)))
            {
                accessCountLog[typeof(TPage)] += 1;
            }
            else
            {
                accessCountLog[typeof(TPage)] = 1;
            }
        }

        public void GoBack()
        {
            goBackRequestCount += 1;
        }

        /// <summary>
        /// Has this navigation service instance received any
        /// request to navigate to a page?
        /// </summary>
        /// <returns></returns>
        public bool ReceivedRequest()
        {
            return accessCountLog.Any();
        }

        /// <summary>
        /// Has this navigation service instance received a request to
        /// navigate to a page of the specified type?
        /// </summary>
        /// <param name="pageType"></param>
        /// <returns></returns>
        public bool ReceivedRequestFor(Type pageType)
        {
            return accessCountLog.ContainsKey(pageType);
        }

        /// <summary>
        /// Has this navigation service instance received a request to
        /// navigate to a page of the specified type?
        /// </summary>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004")]
        public bool ReceivedRequestFor<T>()
        {
            return ReceivedRequestFor(typeof(T));
        }

        /// <summary>
        /// Has this navigation service instance received a request
        /// to go back to a previous page?
        /// </summary>
        /// <returns></returns>
        public bool ReceivedGoBackRequest
        {
            get
            {
                return goBackRequestCount > 0;
            }
        }

        /// <summary>
        /// Gets the number of requests made for a page of
        /// the specified type.
        /// </summary>
        /// <param name="pageType"></param>
        /// <returns></returns>
        public int RequestCountFor(Type pageType)
        {
            return accessCountLog.ContainsKey(pageType) ? accessCountLog[pageType] : 0;
        }
        
        /// <summary>
        /// Gets the number of requests made for a page of
        /// the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004")]
        public int RequestCountFor<T>()
        {
            return RequestCountFor(typeof(T));
        }

        /// <summary>
        /// Gets the total number of all (non "go back") navigation requests.
        /// </summary>
        public int RequestCount
        {
            get
            {
                return accessCountLog.Sum((pair) => pair.Value);
            }
        }
        
        /// <summary>
        /// Gets the total number of "go back" requests.
        /// </summary>
        public int GoBackRequestCount
        {
            get
            {
                return goBackRequestCount;
            }
        }

        /// <summary>
        /// Resets access data for this instance.
        /// </summary>
        public void ResetAccessData()
        {
            accessCountLog.Clear();
            goBackRequestCount = 0;
        }

        private Dictionary<Type, int> accessCountLog;
        private int goBackRequestCount;
    }
}
