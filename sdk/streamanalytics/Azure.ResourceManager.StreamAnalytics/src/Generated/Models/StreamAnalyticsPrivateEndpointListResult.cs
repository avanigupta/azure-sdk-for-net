// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.StreamAnalytics;

namespace Azure.ResourceManager.StreamAnalytics.Models
{
    /// <summary> A list of private endpoints. </summary>
    internal partial class StreamAnalyticsPrivateEndpointListResult
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="StreamAnalyticsPrivateEndpointListResult"/>. </summary>
        internal StreamAnalyticsPrivateEndpointListResult()
        {
            Value = new ChangeTrackingList<StreamAnalyticsPrivateEndpointData>();
        }

        /// <summary> Initializes a new instance of <see cref="StreamAnalyticsPrivateEndpointListResult"/>. </summary>
        /// <param name="value"> A list of private endpoints. </param>
        /// <param name="nextLink"> The URL to fetch the next set of private endpoints. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal StreamAnalyticsPrivateEndpointListResult(IReadOnlyList<StreamAnalyticsPrivateEndpointData> value, string nextLink, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Value = value;
            NextLink = nextLink;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> A list of private endpoints. </summary>
        public IReadOnlyList<StreamAnalyticsPrivateEndpointData> Value { get; }
        /// <summary> The URL to fetch the next set of private endpoints. </summary>
        public string NextLink { get; }
    }
}
