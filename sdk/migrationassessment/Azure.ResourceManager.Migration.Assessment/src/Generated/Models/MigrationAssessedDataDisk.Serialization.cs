// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Migration.Assessment.Models
{
    public partial class MigrationAssessedDataDisk : IUtf8JsonSerializable, IJsonModel<MigrationAssessedDataDisk>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<MigrationAssessedDataDisk>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<MigrationAssessedDataDisk>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MigrationAssessedDataDisk>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MigrationAssessedDataDisk)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(Suitability))
            {
                writer.WritePropertyName("suitability"u8);
                writer.WriteStringValue(Suitability.Value.ToString());
            }
            if (Optional.IsDefined(SuitabilityExplanation))
            {
                writer.WritePropertyName("suitabilityExplanation"u8);
                writer.WriteStringValue(SuitabilityExplanation.Value.ToString());
            }
            if (Optional.IsDefined(SuitabilityDetail))
            {
                writer.WritePropertyName("suitabilityDetail"u8);
                writer.WriteStringValue(SuitabilityDetail.Value.ToString());
            }
            if (Optional.IsDefined(RecommendedDiskSize))
            {
                writer.WritePropertyName("recommendedDiskSize"u8);
                writer.WriteStringValue(RecommendedDiskSize.Value.ToString());
            }
            if (Optional.IsDefined(RecommendedDiskType))
            {
                writer.WritePropertyName("recommendedDiskType"u8);
                writer.WriteStringValue(RecommendedDiskType.Value.ToString());
            }
            if (Optional.IsDefined(RecommendedDiskSizeGigabytes))
            {
                writer.WritePropertyName("recommendedDiskSizeGigabytes"u8);
                writer.WriteNumberValue(RecommendedDiskSizeGigabytes.Value);
            }
            if (Optional.IsDefined(RecommendDiskThroughputInMbps))
            {
                writer.WritePropertyName("recommendDiskThroughputInMbps"u8);
                writer.WriteNumberValue(RecommendDiskThroughputInMbps.Value);
            }
            if (Optional.IsDefined(RecommendedDiskIops))
            {
                writer.WritePropertyName("recommendedDiskIops"u8);
                writer.WriteNumberValue(RecommendedDiskIops.Value);
            }
            if (Optional.IsDefined(MonthlyStorageCost))
            {
                writer.WritePropertyName("monthlyStorageCost"u8);
                writer.WriteNumberValue(MonthlyStorageCost.Value);
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(DisplayName))
            {
                writer.WritePropertyName("displayName"u8);
                writer.WriteStringValue(DisplayName);
            }
            if (Optional.IsDefined(GigabytesProvisioned))
            {
                writer.WritePropertyName("gigabytesProvisioned"u8);
                writer.WriteNumberValue(GigabytesProvisioned.Value);
            }
            if (Optional.IsDefined(MegabytesPerSecondOfRead))
            {
                writer.WritePropertyName("megabytesPerSecondOfRead"u8);
                writer.WriteNumberValue(MegabytesPerSecondOfRead.Value);
            }
            if (Optional.IsDefined(MegabytesPerSecondOfWrite))
            {
                writer.WritePropertyName("megabytesPerSecondOfWrite"u8);
                writer.WriteNumberValue(MegabytesPerSecondOfWrite.Value);
            }
            if (Optional.IsDefined(NumberOfReadOperationsPerSecond))
            {
                writer.WritePropertyName("numberOfReadOperationsPerSecond"u8);
                writer.WriteNumberValue(NumberOfReadOperationsPerSecond.Value);
            }
            if (Optional.IsDefined(NumberOfWriteOperationsPerSecond))
            {
                writer.WritePropertyName("numberOfWriteOperationsPerSecond"u8);
                writer.WriteNumberValue(NumberOfWriteOperationsPerSecond.Value);
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        MigrationAssessedDataDisk IJsonModel<MigrationAssessedDataDisk>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MigrationAssessedDataDisk>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MigrationAssessedDataDisk)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMigrationAssessedDataDisk(document.RootElement, options);
        }

        internal static MigrationAssessedDataDisk DeserializeMigrationAssessedDataDisk(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            MigrationAssessmentCloudSuitability? suitability = default;
            AssessmentSuitabilityExplanation? suitabilityExplanation = default;
            AssessmentDiskSuitabilityDetail? suitabilityDetail = default;
            AssessmentDiskSize? recommendedDiskSize = default;
            AssessmentDiskType? recommendedDiskType = default;
            int? recommendedDiskSizeGigabytes = default;
            double? recommendDiskThroughputInMbps = default;
            double? recommendedDiskIops = default;
            double? monthlyStorageCost = default;
            string name = default;
            string displayName = default;
            double? gigabytesProvisioned = default;
            double? megabytesPerSecondOfRead = default;
            double? megabytesPerSecondOfWrite = default;
            double? numberOfReadOperationsPerSecond = default;
            double? numberOfWriteOperationsPerSecond = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("suitability"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    suitability = new MigrationAssessmentCloudSuitability(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("suitabilityExplanation"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    suitabilityExplanation = new AssessmentSuitabilityExplanation(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("suitabilityDetail"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    suitabilityDetail = new AssessmentDiskSuitabilityDetail(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("recommendedDiskSize"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    recommendedDiskSize = new AssessmentDiskSize(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("recommendedDiskType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    recommendedDiskType = new AssessmentDiskType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("recommendedDiskSizeGigabytes"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    recommendedDiskSizeGigabytes = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("recommendDiskThroughputInMbps"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    recommendDiskThroughputInMbps = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("recommendedDiskIops"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    recommendedDiskIops = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("monthlyStorageCost"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    monthlyStorageCost = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("displayName"u8))
                {
                    displayName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("gigabytesProvisioned"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    gigabytesProvisioned = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("megabytesPerSecondOfRead"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    megabytesPerSecondOfRead = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("megabytesPerSecondOfWrite"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    megabytesPerSecondOfWrite = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("numberOfReadOperationsPerSecond"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    numberOfReadOperationsPerSecond = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("numberOfWriteOperationsPerSecond"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    numberOfWriteOperationsPerSecond = property.Value.GetDouble();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new MigrationAssessedDataDisk(
                suitability,
                suitabilityExplanation,
                suitabilityDetail,
                recommendedDiskSize,
                recommendedDiskType,
                recommendedDiskSizeGigabytes,
                recommendDiskThroughputInMbps,
                recommendedDiskIops,
                monthlyStorageCost,
                name,
                displayName,
                gigabytesProvisioned,
                megabytesPerSecondOfRead,
                megabytesPerSecondOfWrite,
                numberOfReadOperationsPerSecond,
                numberOfWriteOperationsPerSecond,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<MigrationAssessedDataDisk>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MigrationAssessedDataDisk>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(MigrationAssessedDataDisk)} does not support writing '{options.Format}' format.");
            }
        }

        MigrationAssessedDataDisk IPersistableModel<MigrationAssessedDataDisk>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MigrationAssessedDataDisk>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeMigrationAssessedDataDisk(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MigrationAssessedDataDisk)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MigrationAssessedDataDisk>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
