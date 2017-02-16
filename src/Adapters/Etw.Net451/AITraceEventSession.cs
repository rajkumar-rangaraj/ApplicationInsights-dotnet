﻿namespace Microsoft.ApplicationInsights.EventSourceListener.EtwCollector
{
    using System;
    using Diagnostics.Tracing;
    using Microsoft.Diagnostics.Tracing.Session;
    internal class AITraceEventSession : ITraceEventSession, IDisposable
    {
        private TraceEventSession session;
        public AITraceEventSession(TraceEventSession traceEventSession)
        {
            if (traceEventSession == null)
            {
                throw new ArgumentNullException(nameof(traceEventSession));
            }
            this.session = traceEventSession;
        }

        public ETWTraceEventSource Source
        {
            get
            {
                return this.session.Source;
            }
        }

        public void DisableProvider(Guid providerGuid)
        {
            this.session.DisableProvider(providerGuid);
        }

        public void DisableProvider(string providerName)
        {
            this.session.DisableProvider(providerName);
        }

        public void Dispose()
        {
            this.session.Dispose();
        }

        public bool EnableProvider(Guid providerGuid, TraceEventLevel providerLevel = TraceEventLevel.Verbose, ulong matchAnyKeywords = ulong.MaxValue, TraceEventProviderOptions options = null)
        {
            return this.session.EnableProvider(providerGuid, providerLevel, matchAnyKeywords, options);
        }

        public bool EnableProvider(string providerName, TraceEventLevel providerLevel = TraceEventLevel.Verbose, ulong matchAnyKeywords = ulong.MaxValue, TraceEventProviderOptions options = null)
        {
            return this.session.EnableProvider(providerName, providerLevel, matchAnyKeywords, options);
        }

        public bool? IsElevated()
        {
            return TraceEventSession.IsElevated();
        }

        public bool Stop(bool noThrow = false)
        {
            return session.Stop();
        }
    }
}
