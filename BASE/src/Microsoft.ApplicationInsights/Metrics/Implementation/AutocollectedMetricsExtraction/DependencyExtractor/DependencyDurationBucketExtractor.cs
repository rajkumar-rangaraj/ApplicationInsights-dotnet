﻿namespace Microsoft.ApplicationInsights.Extensibility.Implementation.Metrics
{
    using System;
    using Microsoft.ApplicationInsights.Channel;
    using Microsoft.ApplicationInsights.DataContracts;

    internal class DependencyDurationBucketExtractor : IDimensionExtractor
    {
        public int MaxValues { get; set; } = 11;

        public string DefaultValue { get; set; } = MetricTerms.Autocollection.Common.PropertyValues.Unknown;

        public string Name { get; set; } = MetricTerms.Autocollection.DependencyCall.PropertyNames.PerformanceBucket;

        public string ExtractDimension(ITelemetry item)
        {
            var dep = item as DependencyTelemetry;
            return DurationBucketizer.GetPerformanceBucket(dep.Duration);
        }
    }
}
