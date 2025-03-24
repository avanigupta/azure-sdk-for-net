// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Migration.Assessment.Models
{
    /// <summary> Assessed Sql Availability Replica Summary. </summary>
    public partial class SqlAvailabilityReplicaSummary
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

        /// <summary> Initializes a new instance of <see cref="SqlAvailabilityReplicaSummary"/>. </summary>
        internal SqlAvailabilityReplicaSummary()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SqlAvailabilityReplicaSummary"/>. </summary>
        /// <param name="numberOfSynchronousReadReplicas"> Gets the number Of synchronous read replicas. </param>
        /// <param name="numberOfSynchronousNonReadReplicas"> Gets the number Of synchronous non read replicas. </param>
        /// <param name="numberOfAsynchronousReadReplicas"> Gets the number Of asynchronous read replicas. </param>
        /// <param name="numberOfAsynchronousNonReadReplicas"> Gets the number Of asynchronous non read replicas. </param>
        /// <param name="numberOfPrimaryReplicas"> Gets the number Of primary replicas. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SqlAvailabilityReplicaSummary(int? numberOfSynchronousReadReplicas, int? numberOfSynchronousNonReadReplicas, int? numberOfAsynchronousReadReplicas, int? numberOfAsynchronousNonReadReplicas, int? numberOfPrimaryReplicas, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            NumberOfSynchronousReadReplicas = numberOfSynchronousReadReplicas;
            NumberOfSynchronousNonReadReplicas = numberOfSynchronousNonReadReplicas;
            NumberOfAsynchronousReadReplicas = numberOfAsynchronousReadReplicas;
            NumberOfAsynchronousNonReadReplicas = numberOfAsynchronousNonReadReplicas;
            NumberOfPrimaryReplicas = numberOfPrimaryReplicas;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets the number Of synchronous read replicas. </summary>
        public int? NumberOfSynchronousReadReplicas { get; }
        /// <summary> Gets the number Of synchronous non read replicas. </summary>
        public int? NumberOfSynchronousNonReadReplicas { get; }
        /// <summary> Gets the number Of asynchronous read replicas. </summary>
        public int? NumberOfAsynchronousReadReplicas { get; }
        /// <summary> Gets the number Of asynchronous non read replicas. </summary>
        public int? NumberOfAsynchronousNonReadReplicas { get; }
        /// <summary> Gets the number Of primary replicas. </summary>
        public int? NumberOfPrimaryReplicas { get; }
    }
}
