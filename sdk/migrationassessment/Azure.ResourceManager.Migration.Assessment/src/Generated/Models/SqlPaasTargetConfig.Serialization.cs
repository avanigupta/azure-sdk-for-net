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
    public partial class SqlPaasTargetConfig : IUtf8JsonSerializable, IJsonModel<SqlPaasTargetConfig>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<SqlPaasTargetConfig>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<SqlPaasTargetConfig>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SqlPaasTargetConfig>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SqlPaasTargetConfig)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(ComputeTier))
            {
                writer.WritePropertyName("computeTier"u8);
                writer.WriteStringValue(ComputeTier.Value.ToString());
            }
            if (Optional.IsDefined(HardwareGeneration))
            {
                writer.WritePropertyName("hardwareGeneration"u8);
                writer.WriteStringValue(HardwareGeneration.Value.ToString());
            }
            if (Optional.IsDefined(TargetType))
            {
                writer.WritePropertyName("targetType"u8);
                writer.WriteStringValue(TargetType.Value.ToString());
            }
            if (Optional.IsDefined(ServiceTier))
            {
                writer.WritePropertyName("serviceTier"u8);
                writer.WriteStringValue(ServiceTier.Value.ToString());
            }
            if (Optional.IsCollectionDefined(TargetLocations))
            {
                writer.WritePropertyName("targetLocations"u8);
                writer.WriteStartArray();
                foreach (var item in TargetLocations)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
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

        SqlPaasTargetConfig IJsonModel<SqlPaasTargetConfig>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SqlPaasTargetConfig>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SqlPaasTargetConfig)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSqlPaasTargetConfig(document.RootElement, options);
        }

        internal static SqlPaasTargetConfig DeserializeSqlPaasTargetConfig(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            MigrationAssessmentComputeTier? computeTier = default;
            MigrationAssessmentHardwareGeneration? hardwareGeneration = default;
            MigrationAssessmentTargetType? targetType = default;
            AssessmentSqlServiceTier? serviceTier = default;
            IList<AzureLocation> targetLocations = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("computeTier"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    computeTier = new MigrationAssessmentComputeTier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("hardwareGeneration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    hardwareGeneration = new MigrationAssessmentHardwareGeneration(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("targetType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    targetType = new MigrationAssessmentTargetType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("serviceTier"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    serviceTier = new AssessmentSqlServiceTier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("targetLocations"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<AzureLocation> array = new List<AzureLocation>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new AzureLocation(item.GetString()));
                    }
                    targetLocations = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new SqlPaasTargetConfig(
                computeTier,
                hardwareGeneration,
                targetType,
                serviceTier,
                targetLocations ?? new ChangeTrackingList<AzureLocation>(),
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<SqlPaasTargetConfig>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SqlPaasTargetConfig>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(SqlPaasTargetConfig)} does not support writing '{options.Format}' format.");
            }
        }

        SqlPaasTargetConfig IPersistableModel<SqlPaasTargetConfig>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SqlPaasTargetConfig>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeSqlPaasTargetConfig(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(SqlPaasTargetConfig)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<SqlPaasTargetConfig>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
