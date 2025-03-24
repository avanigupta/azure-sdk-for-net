// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Migration.Assessment.Models
{
    /// <summary> SQL target options. </summary>
    public partial class SqlPaasTargetConfig
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

        /// <summary> Initializes a new instance of <see cref="SqlPaasTargetConfig"/>. </summary>
        public SqlPaasTargetConfig()
        {
            TargetLocations = new ChangeTrackingList<AzureLocation>();
        }

        /// <summary> Initializes a new instance of <see cref="SqlPaasTargetConfig"/>. </summary>
        /// <param name="computeTier"> Gets or sets the Azure SQL compute tier. </param>
        /// <param name="hardwareGeneration"> Gets or sets the Azure SQL hardware generation. </param>
        /// <param name="targetType"> Gets or sets the Azure SQL target type. </param>
        /// <param name="serviceTier"> Gets or sets the Azure SQL service tier. </param>
        /// <param name="targetLocations"> Gets or sets the target location. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SqlPaasTargetConfig(MigrationAssessmentComputeTier? computeTier, MigrationAssessmentHardwareGeneration? hardwareGeneration, MigrationAssessmentTargetType? targetType, AssessmentSqlServiceTier? serviceTier, IList<AzureLocation> targetLocations, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ComputeTier = computeTier;
            HardwareGeneration = hardwareGeneration;
            TargetType = targetType;
            ServiceTier = serviceTier;
            TargetLocations = targetLocations;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets or sets the Azure SQL compute tier. </summary>
        public MigrationAssessmentComputeTier? ComputeTier { get; set; }
        /// <summary> Gets or sets the Azure SQL hardware generation. </summary>
        public MigrationAssessmentHardwareGeneration? HardwareGeneration { get; set; }
        /// <summary> Gets or sets the Azure SQL target type. </summary>
        public MigrationAssessmentTargetType? TargetType { get; set; }
        /// <summary> Gets or sets the Azure SQL service tier. </summary>
        public AssessmentSqlServiceTier? ServiceTier { get; set; }
        /// <summary> Gets or sets the target location. </summary>
        public IList<AzureLocation> TargetLocations { get; }
    }
}
