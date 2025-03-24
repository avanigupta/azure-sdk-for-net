// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Migration.Assessment.Models
{
    /// <summary> Assessed Sql Instance Database Summary. </summary>
    public partial class AssessedSqlInstanceDatabaseSummary
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

        /// <summary> Initializes a new instance of <see cref="AssessedSqlInstanceDatabaseSummary"/>. </summary>
        internal AssessedSqlInstanceDatabaseSummary()
        {
        }

        /// <summary> Initializes a new instance of <see cref="AssessedSqlInstanceDatabaseSummary"/>. </summary>
        /// <param name="numberOfUserDatabases"> Gets the number of user databases. </param>
        /// <param name="totalDatabaseSizeInMB"> Gets the total database size in MB. </param>
        /// <param name="largestDatabaseSizeInMB"> Gets the largest database size in MB. </param>
        /// <param name="totalDiscoveredUserDatabases"> Gets the total discovered user databases. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal AssessedSqlInstanceDatabaseSummary(int? numberOfUserDatabases, double? totalDatabaseSizeInMB, double? largestDatabaseSizeInMB, int? totalDiscoveredUserDatabases, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            NumberOfUserDatabases = numberOfUserDatabases;
            TotalDatabaseSizeInMB = totalDatabaseSizeInMB;
            LargestDatabaseSizeInMB = largestDatabaseSizeInMB;
            TotalDiscoveredUserDatabases = totalDiscoveredUserDatabases;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets the number of user databases. </summary>
        public int? NumberOfUserDatabases { get; }
        /// <summary> Gets the total database size in MB. </summary>
        public double? TotalDatabaseSizeInMB { get; }
        /// <summary> Gets the largest database size in MB. </summary>
        public double? LargestDatabaseSizeInMB { get; }
        /// <summary> Gets the total discovered user databases. </summary>
        public int? TotalDiscoveredUserDatabases { get; }
    }
}
